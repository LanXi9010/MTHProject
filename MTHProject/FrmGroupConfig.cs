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
namespace MTHProject
{
    public enum StoreArea
    {
        输出线圈,
        输入线圈,
        输入寄存器,
        输出寄存器
    }
    public partial class FrmGroupConfig : Form
    {
        public FrmGroupConfig()
        {
            InitializeComponent();
            this.cmb_StoreArea.DataSource = Enum.GetNames(typeof(StoreArea));
            //this.cmb_StoreArea.DataSource = new string[] { "输出线圈", "输入线圈", "输入寄存器", "输出寄存器" };
            this.dgv_Main.AutoGenerateColumns = false;
            groups = GetGroupFormExcel();
            Refresh();
        }
        private string path = Application.StartupPath + "\\Config\\Group.xlsx";
        private List<Group> groups = new List<Group>();
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
        /// <summary>
        /// 通信组是否存在
        /// </summary>
        /// <param name="groupName"></param>
        /// <returns></returns>
        private bool isGroupNameExits(string groupName)
        {
            return groups.FindAll(g=>g.GroupName == groupName).ToList().Count > 0;
        }
        /// <summary>
        /// dgv的信息更新为新的通信组
        /// </summary>
        private void RefreshGroup()
        {
            if (groups.Count > 0 && groups != null)
            {
                this.dgv_Main.DataSource = null;
                this.dgv_Main.DataSource = groups;
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
        #region 增删改通信组
        /// <summary>
        /// 增加通信组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Add_Click(object sender, EventArgs e)
        {
            string groupName = this.txt_GroupName.Text.Trim();
            if (groupName.Length == 0)//判断是否为空
            {
                new FrmMsgBoxWithoutAck("组名不能为空!", "添加通信组").Show();
                return;
            }
            if (isGroupNameExits(groupName))
            {
                new FrmMsgBoxWithoutAck("组名已经存在!", "添加通信组").Show();
                return;
            }
            groups.Add(new Group()
            {
                GroupName = groupName,
                StoreArea = cmb_StoreArea.Text.Trim(),
                Length = Convert.ToUInt16(this.num_Length.Value),
                Start = Convert.ToUInt16(this.num_Start.Value),
                Remark=txt_Remark.Text.Trim(),
            });

            try
            {
                MiniExcel.SaveAs(path, groups, overwriteFile: true);
                new FrmMsgBoxWithoutAck("添加成功!", "添加通信组").Show();
                RefreshGroup();
            }
            catch (Exception ex)
            {
                new FrmMsgBoxWithoutAck("添加失败" + ex.Message, "添加通信组").Show();
            }
        }
        /// <summary>
        /// 删除通信组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            string groupName= this.txt_GroupName.Text.Trim();
            if (groupName.Length == 0)
            {
                new FrmMsgBoxWithoutAck("通信组为空!","删除通信组").Show();
                return;
            }
            if (!isGroupNameExits(groupName))
            {
                new FrmMsgBoxWithoutAck("通信组不存在!", "删除通信组").Show();
                return;
            }
            groups.RemoveAll(g=>g.GroupName == groupName);
            RefreshGroup();
            try
            {
                MiniExcel.SaveAs(path, groups, overwriteFile: true);
                new FrmMsgBoxWithoutAck("通信组删除成功", "删除通信组").Show();
                //刷新数据
                RefreshGroup();
            }
            catch (Exception ex)
            {
                new FrmMsgBoxWithoutAck("删除通信组失败:" + ex.Message, "删除通信组").Show();
            }
        }

        /// <summary>
        /// 修改通信组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Modify_Click(object sender, EventArgs e)
        {
            string groupName = this.txt_GroupName.Text.Trim();

            if (!isGroupNameExits(groupName))
            {
                new FrmMsgBoxWithoutAck("通信组名称不存在！", "修改通信组").Show();
                return;
            }
            var group = groups.Find(c => c.GroupName == groupName);
            group.Start = Convert.ToUInt16(this.num_Start.Value);
            group.Length = Convert.ToUInt16(this.num_Length.Value);
            group.StoreArea = this.cmb_StoreArea.Text.Trim();
            group.Remark = this.txt_Remark.Text.Trim();
            try
            {
                MiniExcel.SaveAs(path, groups, overwriteFile: true);
                //刷新数据
                RefreshGroup();
            }
            catch (Exception ex)
            {
                new FrmMsgBoxWithoutAck("修改通信组失败:" + ex.Message, "修改通信组").Show();
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

                if (value == null || value.ToString().Length == 0)
                {
                    e.Value = "---";
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
                UpdateGroup(groups[e.RowIndex]);
            }
        }
        private void UpdateGroup(Group group)
        {
            if (group != null)
            {
                this.txt_GroupName.Text = group.GroupName;
                this.num_Start.Text = group.Start.ToString();
                this.num_Length.Text = group.Length.ToString();
                this.cmb_StoreArea.Text = group.StoreArea;
                this.txt_Remark.Text = group.Remark;
            }
        }
    }
}

