using MiniExcelLibs;
using MTHModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MTHHelper;
using thinger.DataConvertLib;
namespace MTHProject
{
    public partial class FrmVariableConfig : Form
    {
        public FrmVariableConfig()
        {
            InitializeComponent();
            this.cmb_DataType.DataSource = Enum.GetNames(typeof(DataType));
            this.dgv_Main.AutoGenerateColumns = false;
            groups = GetGroupFormExcel();
            variables=GetVarFromExcel();
            this.cmb_GroupName.SelectedIndexChanged += cmb_GroupName_SelectedIndexChanged;
            if (groups.Count > 0)
            {
                foreach (var item in groups)
                {
                    if (item.GroupName == null)
                    {
                        break;
                    }
                    this.cmb_GroupName.Items.Add(item.GroupName);
                }
                    this.cmb_GroupName.SelectedIndex = 0;
            }
        }
        private string varPath=Application.StartupPath+"\\Config\\Variable.xlsx";
        private List<Variable> variables = new List<Variable>();
        private string path = Application.StartupPath + "\\Config\\Group.xlsx";
        private List<Group> groups = new List<Group>();
        private void cmb_GroupName_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshVariables();
        }
        /// <summary>
        /// 从Excel中读取数据
        /// </summary>
        /// <returns>读取的变量组</returns>

        private List<Variable> GetVarFromExcel()
        {
            try
            {
                return MiniExcel.Query<Variable>(varPath).ToList();
            }
            catch (Exception ex)
            {
                return new List<Variable>();
            }
        }
        /// <summary>
        /// 从Excel中读取通信组
        /// </summary>
        /// <returns></returns>
        private List<Group> GetGroupFormExcel()
        {
            try
            {
                return MiniExcel.Query<Group>(path).ToList();
            }
            catch (Exception ex)
            {
                return new List<Group>(); 
            }
        }
        private bool IsVarNameExits(string varName)
        {
            return variables.FindAll(v=>v.VarName == varName).ToList().Count > 0;
        }
        private List<Variable> GetVariablesByGroupName(string groupName)
        {
            if (groupName == null)
            {
                return variables;
            }
            else
            {
                return variables.FindAll(g=> g.GroupName == groupName).ToList();
            }
        }
        private void RefreshVariables()
        {
            var variablelist = GetVariablesByGroupName(this.cmb_GroupName.Text.Trim());
            if (variablelist != null && variablelist.Count > 0)
            {
                this.dgv_Main.DataSource = null;
                this.dgv_Main.DataSource= variablelist;
            }
        }
        #region 无边框拖动
        private Point mPoint;
        private void Panel_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint = new Point(e.X, e.Y);
        }

        private void Panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - mPoint.X, this.Location.Y + e.Y - mPoint.Y);
            }
        }

        #endregion
        #region 增删改变量
        /// <summary>
        /// 添加变量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Add_Click(object sender, EventArgs e)
        {
            string varName = this.txt_VarName.Text.Trim();

            if (varName.Length == 0)
            {
                new FrmMsgBoxWithoutAck("变量名称不能为空！", "添加变量").Show();
                return;
            }

            if (IsVarNameExits(varName))
            {
                new FrmMsgBoxWithoutAck("变量名称已经存在！", "添加变量").Show();
                return;
            }

            variables.Add(new Variable()
            {
                VarName = varName,
                StartIndex = Convert.ToUInt16(this.num_StartIndex.Value),
                OffsetOrLength = Convert.ToUInt16(this.num_OffsetOrLength.Value),
                DataType = this.cmb_DataType.Text.Trim(),
                GroupName = this.cmb_GroupName.Text.Trim(),
                PosAlarm = this.chk_PosAlarm.Checked,
                NegAlarm = this.chk_NegAlarm.Checked,
                Scale = Convert.ToSingle(this.num_Scale.Value),
                Offset = Convert.ToSingle(this.num_Offset.Value),
                Remark = this.txt_Remark.Text.Trim()
            });
            try
            {
                MiniExcel.SaveAs(varPath, variables, overwriteFile: true);

                new FrmMsgBoxWithoutAck("添加变量成功", "添加变量").Show();

                //刷新数据
                RefreshVariables();
            }
            catch (Exception ex)
            {
                new FrmMsgBoxWithoutAck("添加变量失败:" + ex.Message, "添加变量").Show();
            }
        }

        /// <summary>
        /// 删除通信组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            string variableName = this.txt_VarName.Text.Trim();

            if (!IsVarNameExits(variableName))
            {
                new FrmMsgBoxWithoutAck("变量名称不存在！", "删除变量").Show();
                return;
            }

            variables.RemoveAll(c => c.VarName == variableName);

            try
            {
                MiniExcel.SaveAs(varPath, variables, overwriteFile: true);

                //刷新数据
                RefreshVariables();
            }
            catch (Exception ex)
            {
                new FrmMsgBoxWithoutAck("删除变量失败:" + ex.Message, "删除变量").Show();
            }
        }

        /// <summary>
        /// 修改通信组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Modify_Click(object sender, EventArgs e)
        {
            string variableName = this.txt_VarName.Text.Trim();

            if (!IsVarNameExits(variableName))
            {
                new FrmMsgBoxWithoutAck("变量名称不存在！", "删除变量").Show();
                return;
            }

            var variable = variables.Find(c => c.VarName == variableName);

            variable.StartIndex = Convert.ToUInt16(this.num_StartIndex.Value);
            variable.OffsetOrLength = Convert.ToUInt16(this.num_OffsetOrLength.Value);
            variable.DataType = cmb_DataType.Text.Trim();
            variable.GroupName = this.cmb_GroupName.Text.Trim();
            variable.PosAlarm = this.chk_PosAlarm.Checked;
            variable.NegAlarm = this.chk_NegAlarm.Checked;
            variable.Scale = Convert.ToSingle(this.num_Scale.Value);
            variable.Offset = Convert.ToSingle(this.num_Offset.Value);
            variable.Remark = this.txt_Remark.Text.Trim();

            try
            {
                MiniExcel.SaveAs(varPath, variables, overwriteFile: true);

                //刷新数据
                RefreshVariables();
            }
            catch (Exception ex)
            {
                new FrmMsgBoxWithoutAck("修改变量失败:" + ex.Message, "修改变量").Show();
            }
        }
        #endregion
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv_Main_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                object value = this.dgv_Main.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (value != null && (e.ColumnIndex == 5 || e.ColumnIndex == 6))
                {
                   e.Value=value.ToString()=="True"?"启用":"禁用";
                }
                else
                {
                    if (value == null || value.ToString().Length == 0)
                    {
                        e.Value = "---";
                    }
                }
            }
        }
        private void dgv_Main_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewHelper.DgvRowPostPaint((DataGridView)sender, e);
        }
        private void dgv_Main_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                UpdateVariable(variables[e.RowIndex]);
            }
        }
        private void UpdateVariable(Variable variable)
        {
            if (variable != null)
            {
                this.cmb_GroupName.Text = variable.GroupName;
                this.txt_VarName.Text = variable.VarName;
                this.num_StartIndex.Text = variable.StartIndex.ToString();
                this.num_OffsetOrLength.Text = variable.OffsetOrLength.ToString();
                this.cmb_DataType.Text = variable.DataType;
                this.chk_PosAlarm.Checked = variable.PosAlarm;
                this.chk_NegAlarm.Checked = variable.NegAlarm;
                this.num_Scale.Value = Convert.ToDecimal(variable.Scale);
                this.num_Offset.Value = Convert.ToDecimal(variable.Offset);
                this.txt_Remark.Text = variable.Remark;
            }
        }


    }
}

