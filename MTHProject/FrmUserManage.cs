using MTHBLL;
using MTHHelper;
using MTHModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MTHProject
{
    public partial class FrmUserManage : Form
    {
        public FrmUserManage()
        {
            InitializeComponent();
            this.dgv_UserManage.AutoGenerateColumns = false;
            UpdateData();
        }
        private List<SysAdmin> sysAdmins= new List<SysAdmin>();
        private SysAdminManage sysAdminManage= new SysAdminManage();
        #region  更新数据到dgv
        private void UpdateData()
        {
            try
            {
                sysAdmins = sysAdminManage.QuerySysAdmins();
                this.dgv_UserManage.DataSource = null;
                this.dgv_UserManage.DataSource = sysAdmins;
            }
            catch (Exception ex)
            {
                new FrmMsgBoxWithoutAck("查询失败" + ex.Message, "查询信息失败").ShowDialog();
            }

        }
        #endregion
        #region 设置权限选框的状态
        private void ModifyCheckBox(bool value)
        {
            this.chk_ParamSet.Checked = value;
            this.chk_Recipe.Checked = value;
            this.chk_UserManage.Checked = value;
            this.chk_HistoryLog.Checked = value;
            this.chk_HistoryTrend.Checked = value;
        }
        #endregion
        #region 添加用户函数
        private void btn_Add_Click(object sender, EventArgs e)
        {
            //数据验证
            if (this.txt_LoginName.Text.Length == 0)
            {
                new FrmMsgBoxWithoutAck("用户名不能为空!", "添加用户").Show();
                return;
            }

            if (this.txt_LoginPwd.Text.Length == 0)
            {
                new FrmMsgBoxWithoutAck("用户密码不能为空!", "添加用户").Show();
                return;
            }

            if (this.txt_LoginPwd2.Text.Length == 0)
            {
                new FrmMsgBoxWithoutAck("确认密码不能为空!", "添加用户").Show();
                return;
            }

            if (this.txt_LoginPwd.Text.Trim() != this.txt_LoginPwd2.Text.Trim())
            {
                new FrmMsgBoxWithoutAck("两次输入密码不一致!", "添加用户").Show();
                return;
            }

            if (sysAdmins.Where(c => c.LoginName == this.txt_LoginName.Text.Trim()).ToList().Count() > 0)
            {
                new FrmMsgBoxWithoutAck("用户名已经存在!", "添加用户").Show();
                return;
            }
            SysAdmin sysAdmin = new SysAdmin()
            {
                LoginName = this.txt_LoginName.Text,
                LoginPwd = this.txt_LoginPwd2.Text,
                HistoryLog = chk_HistoryLog.Checked,
                HistoryTrend = chk_HistoryTrend.Checked,
                ParamSet = chk_ParamSet.Checked,
                Recipe = chk_Recipe.Checked,
                UserManage = chk_UserManage.Checked,
            };
            if (sysAdminManage.AddSysAdmin(sysAdmin))
            {
                UpdateData();
            }
            else
            {
                new FrmMsgBoxWithoutAck("添加失败，请检查", "用户添加").Show();
            }
        }
            #endregion
        #region 修改用户
        private void btn_Modify_Click(object sender, EventArgs e)
        {
            if (this.dgv_UserManage.SelectedRows.Count == 0)
            {
                new FrmMsgBoxWithoutAck("请先在用户列表中选择要修改的用户!", "修改用户").Show();
                return;
            }

            SysAdmin selectedAdmin = sysAdmins[this.dgv_UserManage.SelectedRows[0].Index];

            //数据验证
            if (this.txt_LoginName.Text.Length == 0)
            {
                new FrmMsgBoxWithoutAck("用户名不能为空!", "修改用户").Show();
                return;
            }

            if (this.txt_LoginPwd.Text.Length == 0)
            {
                new FrmMsgBoxWithoutAck("用户密码不能为空!", "修改用户").Show();
                return;
            }

            if (this.txt_LoginPwd2.Text.Length == 0)
            {
                new FrmMsgBoxWithoutAck("确认密码不能为空!", "修改用户").Show();
                return;
            }

            if (this.txt_LoginPwd.Text.Trim() != this.txt_LoginPwd2.Text.Trim())
            {
                new FrmMsgBoxWithoutAck("两次输入密码不一致!", "修改用户").Show();
                return;
            }
            //判断是否修改用户名
            if (selectedAdmin.LoginName != this.txt_LoginName.Text.Trim())
            {
                if (sysAdmins.Where(c => c.LoginName == this.txt_LoginName.Text.Trim()).ToList().Count > 0)
                {
                    new FrmMsgBoxWithoutAck("用户名重复","修改用户").ShowDialog();
                    return;
                }
            }
            SysAdmin sysAdmin = new SysAdmin()
            {
                LoginId = selectedAdmin.LoginId,
                LoginName = this.txt_LoginName.Text.Trim(),
                LoginPwd = this.txt_LoginPwd.Text.Trim(),
                HistoryLog = this.chk_HistoryLog.Checked,
                HistoryTrend = this.chk_HistoryTrend.Checked,
                Recipe = chk_Recipe.Checked,
                ParamSet = chk_ParamSet.Checked,
                UserManage = this.chk_UserManage.Checked,
            };
            if (sysAdminManage.ModifySysAdmin(sysAdmin))
            {
                UpdateData();
            }
            else
            {
                new FrmMsgBoxWithoutAck("修改用户失败!", "修改用户").Show();
            }
        }
        #endregion
        #region 删除用户
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            //数据验证
            if (this.txt_LoginName.Text.Length == 0)
            {
                new FrmMsgBoxWithoutAck("用户名不能为空!", "添加用户").Show();
                return;
            }

            if (this.txt_LoginPwd.Text.Length == 0)
            {
                new FrmMsgBoxWithoutAck("用户密码不能为空!", "添加用户").Show();
                return;
            }

            if (this.txt_LoginPwd2.Text.Length == 0)
            {
                new FrmMsgBoxWithoutAck("确认密码不能为空!", "添加用户").Show();
                return;
            }

            if (this.txt_LoginPwd.Text.Trim() != this.txt_LoginPwd2.Text.Trim())
            {
                new FrmMsgBoxWithoutAck("两次输入密码不一致!", "添加用户").Show();
                return;
            }
            var result= new FrmMsgBoxWithAck("确定要删除该用户吗?", "删除用户").ShowDialog();
            if (result == DialogResult.OK)
            {
                if (sysAdminManage.DeleteSysAdmin(sysAdmins[this.dgv_UserManage.SelectedRows[0].Index].LoginId))
                {
                    UpdateData();
                }
                else
                {
                    new FrmMsgBoxWithoutAck("删除用户失败!", "删除用户").Show();
                }
            }
        }
            #endregion
        #region 清空函数
        private void btn_Clear_Click(object sender, EventArgs e)
        {
            this.txt_LoginName.Clear();
            this.txt_LoginPwd.Clear();
            this.txt_LoginPwd2.Clear();
            ModifyCheckBox(!chk_ParamSet.Checked);
        }
        #endregion
        #region 权限全选函数
        private void btn_SelectAll_Click(object sender, EventArgs e)
        {
            ModifyCheckBox(!chk_ParamSet.Checked);
        }
        #endregion
        #region dgv行号设置
        private void dgv_UserManage_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewHelper.DgvRowPostPaint(sender as DataGridView,e);
        }
        #endregion
        #region 选中的dgv行数据更新到其他UI
        private void dgv_UserManage_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >=0)
            {
                UpdateInfo(sysAdmins[e.RowIndex]);
            }
        }
        private void UpdateInfo(SysAdmin sysAdmin)
        {
            if (sysAdmin!=null)
            {
                this.txt_LoginName.Text = sysAdmin.LoginName;
                this.txt_LoginPwd.Text = sysAdmin.LoginPwd;
                this.txt_LoginPwd2.Text = sysAdmin.LoginPwd;
                this.chk_ParamSet.Checked = sysAdmin.ParamSet;
                this.chk_Recipe.Checked = sysAdmin.Recipe;
                this.chk_HistoryLog.Checked = sysAdmin.HistoryLog;
                this.chk_HistoryTrend.Checked = sysAdmin.HistoryTrend;
                this.chk_UserManage.Checked = sysAdmin.UserManage;
            }
        }
        #endregion
        #region dgv单元格式化
        private void dgv_UserManage_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 2)
            {
                object value = this.dgv_UserManage.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (value != null)
                {
                    if (value.ToString().ToLower() == "true")
                    {
                        e.Value = "启用";
                    }
                    else
                    {
                        e.Value = "禁用";
                    }
                }
            }
        }
        #endregion
    }

}
