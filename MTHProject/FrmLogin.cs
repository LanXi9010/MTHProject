using MTHBLL;
using MTHModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MTHProject
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        private SysAdminManage sysAdminManage = new SysAdminManage();
        #region 登录按钮
        private void btn_Login_Click(object sender, EventArgs e)
        {
            if (this.txt_LoginName.Text.Trim().Length == 0)
            {
                new FrmMsgBoxWithoutAck("用户名为空!", "用户登录").ShowDialog();
                this.txt_LoginName.Focus();
                return;
            }
            if (this.txt_Pwd.Text.Trim().Length == 0)
            {
                new FrmMsgBoxWithoutAck("密码为空", "用户登录").ShowDialog();
                this.txt_Pwd.Focus();
                return;
            }
            SysAdmin sysAdmin = new SysAdmin();
            {
                sysAdmin.LoginName = this.txt_LoginName.Text.Trim();
                sysAdmin.LoginPwd = this.txt_Pwd.Text.Trim();
            };
            sysAdmin = sysAdminManage.AdminLogin(sysAdmin);
            if (sysAdmin == null)
            {
                new FrmMsgBoxWithoutAck("用户名或密码错误", "用户登录").ShowDialog();
                this.txt_LoginName.Focus();
                return;
            }
            else
            {
                DialogResult = DialogResult.OK;
                CommonMethods.CurrentAdmin = sysAdmin;
            }
        }
        #endregion
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
        #region 关闭按钮
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        #region 密码框按下Enter
        private void txt_Pwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btn_Login_Click(null, null);
            }
        }
        #endregion
        #region 启用软键盘
        private void StartKeyBoard()
        {
            //打开软键盘
            try
            {
                if (!System.IO.File.Exists(Environment.SystemDirectory + "\\osk.exe"))
                {
                    MessageBox.Show("软件盘可执行文件不存在！");
                    return;
                }
                softKey = System.Diagnostics.Process.Start(Environment.SystemDirectory + "\\osk.exe");
                // 上面的语句在打开软键盘后，系统还没立刻把软键盘的窗口创建出来了。所以下面的代码用循环来查询窗口是否创建，只有创建了窗口
                // FindWindow才能找到窗口句柄，才可以移动窗口的位置和设置窗口的大小。这里是关键。
                IntPtr intptr = IntPtr.Zero;
                while (IntPtr.Zero == intptr)
                {
                    System.Threading.Thread.Sleep(100);
                    intptr = FindWindow(null, "屏幕键盘");
                }


                // 获取屏幕尺寸
                int iActulaWidth = Screen.PrimaryScreen.Bounds.Width;
                int iActulaHeight = Screen.PrimaryScreen.Bounds.Height;


                // 设置软键盘的显示位置，底部居中
                int posX = (iActulaWidth - 1000) / 2;
                int posY = (iActulaHeight - 300);


                //设定键盘显示位置
                MoveWindow(intptr, posX, posY, 1000, 300, true);


                //设置软键盘到前端显示
                SetForegroundWindow(intptr);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        // 申明要使用的dll和api
        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        public extern static IntPtr FindWindow(string lpClassName, string lpWindowName);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll", EntryPoint = "MoveWindow")]
        public static extern bool MoveWindow(System.IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);


        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);


        private System.Diagnostics.Process softKey;

        #endregion
        #region 双击用户名框出现软键盘
        private void txt_LoginName_DoubleClick(object sender, EventArgs e)
        {
            StartKeyBoard();
        }
        #endregion
    }
}

