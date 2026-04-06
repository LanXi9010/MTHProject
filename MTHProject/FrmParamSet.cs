using MTHControlLib;
using MTHHelper;
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
    public partial class FrmParamSet : Form
    {
        public FrmParamSet(string devPath)
        {
            InitializeComponent();
            this.devPath = devPath;

            updateTimer.Interval = 500;
            updateTimer.Tick += updateTimer_Tick;

            InitParam();

            CommonBindEvent();

            this.FormClosing += (sender, e) =>
            {
                this.updateTimer.Stop();
            };

            this.updateTimer.Start();
            
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            //定时获取限度值，报警值由人设置
            GetLimitParam();
        }

        private string devPath = string.Empty;

        private Timer updateTimer = new Timer();

        /// <summary>
        /// 通用事件绑定方法
        /// </summary>
        private void CommonBindEvent()
        {
            //遍历PanelMain里面的TextSet控件为它的事件绑定上函数
            foreach (var item in this.PanelMain.Controls.OfType<TextSet>())
            {
                if (item.BindVarName != null && item.BindVarName.ToString().Length > 0)
                {
                    item.ControlDoubleClick += btn_DoubleClick;
                }
            }

            foreach (var item in this.PanelMain.Controls.OfType<CheckBoxEx>())
            {
                if (item.Tag != null && item.Tag.ToString().Length > 0)
                {
                    item.CheckedChanged += checkBox_Changed;
                }
            }
        }

        /// <summary>
        /// 初始化参数
        /// </summary>
        private void InitParam()
        {
            this.txt_IP.Text = CommonMethods.Device.IPAddress;
            this.txt_Port.Text = CommonMethods.Device.Port.ToString();

            GetLimitParam();

            GetAlarmParam();
        }
        #region 读取数据
        /// <summary>
        /// 实时读取限值数据
        /// </summary>
        private void GetLimitParam()
        {
            if (CommonMethods.Device.IsConnected)
            {
                foreach (var item in this.PanelMain.Controls.OfType<TextSet>())
                {
                    if (item.BindVarName != null && item.BindVarName.ToString().Length > 0)
                    {
                        item.CurrentValue = CommonMethods.Device[item.BindVarName.ToString()].ToString();
                    }
                    if (item.AlarmVarName != null && item.AlarmVarName.ToString().Length > 0)
                    {
                        item.IsAlarm = CommonMethods.Device[item.AlarmVarName].ToString() == "True";
                    }
                }
            }
        }

        /// <summary>
        /// 实时读取和启用状态数据
        /// </summary>
        private void GetAlarmParam()
        {
            if (CommonMethods.Device.IsConnected)
            {
                foreach (var item in this.PanelMain.Controls.OfType<CheckBoxEx>())
                {
                    if (item.Tag != null && item.Tag.ToString().Length > 0)
                    {
                        item.Checked = CommonMethods.Device[item.Tag.ToString()].ToString() == "1";
                    }
                }
            }
        }
        #endregion
        #region textSet双击事件函数
        /// <summary>
        /// 双击弹窗，设置属性值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_DoubleClick(object sender, EventArgs e)
        {
            if (sender is TextSet textSet)
            {
                if (textSet.BindVarName != null && textSet.BindVarName.Length > 0)
                {
                    FrmModify frmModify = new FrmModify(textSet.TitleName, textSet.BindVarName, textSet.CurrentValue);
                    frmModify.ShowDialog();
                }
            }
        }
        #endregion
        #region checkBox状态改变事件函数
        private void checkBox_Changed(object sender,EventArgs e)
        {
            if(sender is CheckBoxEx ckb)
            {
                if (ckb.Tag != null && ckb.Tag.ToString().Length > 0)
                {
                    //依据checkBox的勾选状态去改变报警启用
                 bool result= CommonMethods.
                        CommonWrite(ckb.Tag.ToString(),ckb.Checked?"1":"0");
                    if(!result)
                    {
                        ckb.CheckedChanged -= checkBox_Changed;
                        ckb.Checked = !ckb.Checked;
                        ckb.CheckedChanged += checkBox_Changed;
                    }
                }
            }
        }
        #endregion
        #region 按钮事件函数
        private void btn_GroupConfig_Click(object sender, EventArgs e)
        {
            new FrmGroupConfig().ShowDialog();
        }

        private void btn_VarConfig_Click(object sender, EventArgs e)
        {
            new FrmVariableConfig().ShowDialog();
        }

        private void btn_Sure_Click(object sender, EventArgs e)
        {
            bool result = IniConfigHelper.WriteIniData("设备参数", "IP地址", this.txt_IP.Text.Trim(), devPath);

            result &= IniConfigHelper.WriteIniData("设备参数", "端口号", this.txt_Port.Text.Trim(), devPath);
            if (result)
            {
                CommonMethods.Device.IPAddress = this.txt_IP.Text.Trim();

                CommonMethods.Device.Port = Convert.ToInt32(this.txt_Port.Text.Trim());

                DialogResult dialogResult = new FrmMsgBoxWithAck("通信参数配置成功,是否立即重连?", "通信设置").ShowDialog();

                if (dialogResult == DialogResult.OK)
                {
                    CommonMethods.Device.IsConnected = false;
                }
            }
            else
            {
                new FrmMsgBoxWithoutAck("通信参数配置失败", "通信设置").Show();
            }
        }

        private void btn_Canel_Click(object sender, EventArgs e)
        {
            this.txt_IP.Text = CommonMethods.Device.IPAddress;
            this.txt_Port.Text = CommonMethods.Device.Port.ToString();
        }
        #endregion
    }
}  

