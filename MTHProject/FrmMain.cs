using MiniExcelLibs;
using MTHBLL;
using MTHControlLib;
using MTHHelper;
using MTHModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using thinger.DataConvertLib;

namespace MTHProject
{
    public partial class FrmMain : Form
    {

        public FrmMain()
        {

            InitializeComponent();
            naviButtons.Add(this.Navibtn_Monitor);
            naviButtons.Add(this.naviButton1);
            naviButtons.Add(this.naviButton2);
            naviButtons.Add(this.naviButton3);
            naviButtons.Add(this.naviButton4);
            naviButtons.Add(this.naviButton5);
            this.Load += FrmMain_Load;
            timer.Interval = 2000;
            timer.AutoReset = true;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
            this.FormClosing += FrmMain_FormClosing;
            actualDataList.CollectionChanged += ActualDataList_CollectionChanged;
        }
        #region 字段
        private string devPath = Application.StartupPath + "\\Config\\Device.ini";
        private string groupPath = Application.StartupPath + "\\Config\\Group.xlsx";
        private string variablePath = Application.StartupPath + "\\Config\\Variable.xlsx";
        private ActualDataManage actualDataManage = new ActualDataManage();
        private SysLogManage sysLogManage = new SysLogManage();
        private System.Timers.Timer timer = new System.Timers.Timer();
        private CancellationTokenSource cts;//通信信号
        private int CurrentIndex = 0;
        private List<NaviButton> naviButtons = new List<NaviButton>();
        #endregion
        #region 当前时间属性
        public string CurrrentTime
        {
            get { return DateTime.Now.ToString("yyyy-MM-dd,HH-mm-ss"); }
        }
        #endregion
        #region 集合
        private ObservableCollection<string> actualDataList = new ObservableCollection<string>();
        #endregion
        #region 主窗体加载函数
        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.lbl_User.Text = CommonMethods.CurrentAdmin.LoginName;
            CommonNaviButton_Click(Navibtn_Monitor, null);
            CommonMethods.Device = LoadDevice(devPath, groupPath, variablePath);
            if (CommonMethods.Device != null)
            {
                CommonMethods.AddLog(0, "设备信息加载成功");
            }
            CommonMethods.Device.AlarmTrigEvent += Device_AlarmTrigEvent;
            cts = new CancellationTokenSource();
            Task.Run(new Action
            (() => {
                DeviceCommunication(CommonMethods.Device);
            }), cts.Token);
        }
        #endregion
        #region 获取星期信息
        private string[] weeks = { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
        private string week
        {
            get { return weeks[Convert.ToInt32(DateTime.Now.DayOfWeek)]; }
        }
        #endregion
        #region 计时器执行函数
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            //更新时间和通信状态
            this.Invoke(new Action(() =>
            {
                this.lbl_CurrentTime.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToString("HH:mm:ss") + " " + week;
                this.led_CommState.Value = CommonMethods.Device != null && CommonMethods.Device.IsConnected;
            }));
            if (CommonMethods.Device != null && CommonMethods.Device.IsConnected)
            {
                //判断
                bool result = CommonMethods.Device["模块1温度"] != null;
                result &= CommonMethods.Device["模块1湿度"] != null;
                result &= CommonMethods.Device["模块2温度"] != null;
                result &= CommonMethods.Device["模块2湿度"] != null;
                result &= CommonMethods.Device["模块3温度"] != null;
                result &= CommonMethods.Device["模块3湿度"] != null;
                result &= CommonMethods.Device["模块4温度"] != null;
                result &= CommonMethods.Device["模块4湿度"] != null;
                result &= CommonMethods.Device["模块5温度"] != null;
                result &= CommonMethods.Device["模块5湿度"] != null;
                result &= CommonMethods.Device["模块6温度"] != null;
                result &= CommonMethods.Device["模块6湿度"] != null;

                if (result)
                {
                    actualDataManage.AddActualData(new ActualData()
                    {
                        InsertTime = CurrrentTime,
                        Station1Temp = CommonMethods.Device["模块1温度"].ToString(),
                        Station1Humidity = CommonMethods.Device["模块1湿度"].ToString(),
                        Station2Temp = CommonMethods.Device["模块2温度"].ToString(),
                        Station2Humidity = CommonMethods.Device["模块2湿度"].ToString(),
                        Station3Temp = CommonMethods.Device["模块3温度"].ToString(),
                        Station3Humidity = CommonMethods.Device["模块3湿度"].ToString(),
                        Station4Temp = CommonMethods.Device["模块4温度"].ToString(),
                        Station4Humidity = CommonMethods.Device["模块4湿度"].ToString(),
                        Station5Temp = CommonMethods.Device["模块5温度"].ToString(),
                        Station5Humidity = CommonMethods.Device["模块5湿度"].ToString(),
                        Station6Temp = CommonMethods.Device["模块6温度"].ToString(),
                        Station6Humidity = CommonMethods.Device["模块6湿度"].ToString(),

                    });
                }
            }
        }
        #endregion
        #region 窗体退出确认
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = new FrmMsgBoxWithAck("是否确认退出系统?", "退出系统").ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                timer.Stop();
                CommonMethods.modbus?.DisConnect();
                cts?.Cancel();
            }
            else
            {
                e.Cancel = true;
            }
        }
        #endregion
        #region 上位机软件同设备通信
        private void DeviceCommunication(Device device)
        {
            while (!cts.IsCancellationRequested)
            {
                if (device.IsConnected)
                {
                    foreach (var group in device.GroupList)
                    {
                        byte[] data = null;
                        int rebackLength = 0;
                        //处理bool类型数据
                        if (group.StoreArea == "输入线圈" || group.StoreArea == "输出线圈")
                        {
                            switch (group.StoreArea)
                            {
                                case "输入线圈":
                                    data = CommonMethods.modbus.ReadInputCoils(group.Start, group.Length);
                                    rebackLength = ShortLib.GetByteLengthFromBoolLength(group.Length);
                                    break;
                                case "输出线圈":
                                    data = CommonMethods.modbus.ReadOutputCoils(group.Start, group.Length);
                                    rebackLength = ShortLib.GetByteLengthFromBoolLength(group.Length);
                                    break;
                                default:
                                    break;
                            }
                            //返回报文正确，解析变量
                            if (data != null && data.Length == rebackLength)
                            {
                                foreach (var Var in group.VarList)
                                {
                                    int start = Var.StartIndex - group.Start;
                                    DataType dataType = (DataType)Enum.Parse(typeof(DataType), Var.DataType, true);
                                    switch (dataType)
                                    {
                                        case DataType.Bool:
                                            Var.VarValue = BitLib.
                                                GetBitFromByteArray
                                                (data, start, Var.OffsetOrLength);//bool值为1byte
                                            break;
                                        default:
                                            break;
                                    }
                                    //直接更新变量
                                    device.UpdateVariable(Var);
                                }
                            }
                            else
                            {
                                device.IsConnected = false;
                                break;
                            }
                        }
                        else
                        {
                            switch (group.StoreArea)
                            {
                                case "输入寄存器":
                                    data = CommonMethods.modbus.ReadInputRegisters(group.Start, group.Length);
                                    rebackLength = group.Length * 2;
                                    break;
                                case "输出寄存器":
                                    data = CommonMethods.modbus.ReadOutputRegisters(group.Start, group.Length);
                                    rebackLength = group.Length * 2;
                                    break;
                                default:
                                    break;
                            }
                            if (data != null && data.Length == rebackLength)
                            {
                                //变量解析
                                foreach (var variable in group.VarList)
                                {
                                    DataType dataType = (DataType)Enum.Parse(typeof(DataType), variable.DataType, true);

                                    int start = variable.StartIndex - group.Start;//获取变量在整个报文中的起始索引

                                    start *= 2;

                                    switch (dataType)
                                    {
                                        case DataType.Bool:
                                            variable.VarValue = BitLib.GetBitFrom2BytesArray(data, start, variable.OffsetOrLength, CommonMethods.dataFormat == DataFormat.BADC || CommonMethods.dataFormat == DataFormat.DCBA);
                                            break;
                                        case DataType.Byte:
                                            variable.VarValue = ByteLib.GetByteFromByteArray(data, CommonMethods.dataFormat == DataFormat.BADC || CommonMethods.dataFormat == DataFormat.DCBA ? start : start + 1);
                                            break;
                                        case DataType.Short:
                                            variable.VarValue = ShortLib.GetShortFromByteArray(data, start, CommonMethods.dataFormat);
                                            break;
                                        case DataType.UShort:
                                            variable.VarValue = UShortLib.GetUShortFromByteArray(data, start, CommonMethods.dataFormat);
                                            break;
                                        case DataType.Int:
                                            variable.VarValue = IntLib.GetIntFromByteArray(data, start, CommonMethods.dataFormat);
                                            break;
                                        case DataType.UInt:
                                            variable.VarValue = UIntLib.GetUIntFromByteArray(data, start, CommonMethods.dataFormat);
                                            break;
                                        case DataType.Float:
                                            variable.VarValue = FloatLib.GetFloatFromByteArray(data, start, CommonMethods.dataFormat);
                                            break;
                                        case DataType.Double:
                                            variable.VarValue = DoubleLib.GetDoubleFromByteArray(data, start, CommonMethods.dataFormat);
                                            break;
                                        case DataType.Long:
                                            variable.VarValue = LongLib.GetLongFromByteArray(data, start, CommonMethods.dataFormat);
                                            break;
                                        case DataType.ULong:
                                            variable.VarValue = ULongLib.GetULongFromByteArray(data, start, CommonMethods.dataFormat);
                                            break;
                                        case DataType.String:
                                            variable.VarValue = StringLib.GetStringFromByteArrayByEncoding(data, start, variable.OffsetOrLength, Encoding.ASCII);
                                            break;
                                        case DataType.ByteArray:
                                            variable.VarValue = ByteArrayLib.GetByteArrayFromByteArray(data, start, variable.OffsetOrLength);
                                            break;
                                        case DataType.HexString:
                                            variable.VarName = StringLib.GetHexStringFromByteArray(data, start, variable.OffsetOrLength);
                                            break;
                                        default:
                                            break;
                                    }
                                    //处理
                                    //先做线性转换，再更新
                                    variable.VarValue = MigrationLib.GetMigrationValue(variable.VarValue, variable.Scale.ToString(), variable.Offset.ToString()).Content;
                                    device.UpdateVariable(variable);
                                }
                            }
                            else
                            {
                                device.IsConnected = false;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    //非首次连接，需要延时
                    if (device.ReConnectSign)
                    {
                        CommonMethods.modbus?.DisConnect();
                        Thread.Sleep(device.ReConnectTime);
                    }
                    //通信连接
                    {
                        CommonMethods.modbus = new ModbusTCP();
                        device.IsConnected = CommonMethods.modbus.Connect(device.IPAddress, device.Port);

                        if (device.ReConnectSign)
                        {
                            CommonMethods.AddLog(device.IsConnected ? 0 : 1, device.IsConnected ? "控制器重新连接成功" : "控制器重新连接失败");
                        }
                        else
                        {
                            //CommonMethods.AddLog(device.IsConnected ? 0 : 1, device.IsConnected ? "初次重连成功" : "初次重连失败");
                            device.ReConnectSign = true;
                        }
                    }
                }
            }
        }
        #endregion
        #region 设备解析
        public Device LoadDevice(string devicePath, string groupPath, string variablePath)
        {
            try
            {
                List<Group> groupList = LoadGroup(groupPath, variablePath);
                return new Device()
                {
                    IPAddress = IniConfigHelper.ReadIniData("设备参数", "IP地址", "127.0.0.1", devicePath),
                    Port = Convert.ToInt32(IniConfigHelper.ReadIniData("设备参数", "端口号", "502", devicePath)),
                    GroupList = groupList,//这里不做查找是因为数据是针对一个设备的，而一个设备具备数据中的全部组
                };
            }
            catch
            {
                return null;
            }
        }
        #endregion
        #region 通信组及通信变量的解析
        private List<Group> LoadGroup(string groupPath, string variablePath)
        {
            //判断文件是否存在
            if (!File.Exists(groupPath))
            {
                CommonMethods.AddLog(1, "通信组文件不存在");
                return null;
            }
            if (!File.Exists(variablePath))
            {
                CommonMethods.AddLog(1, "通信变量文件不存在");
                return null;
            }

            //先解析通信组
            List<Group> GpList = null;
            try
            {
                GpList = MiniExcel.Query<Group>(groupPath).ToList();
            }
            catch (Exception ex)
            {
                CommonMethods.AddLog(1, "通信组加载失败:" + ex.Message);
                return null;
            }

            List<Variable> VarList = null;
            try
            {
                VarList = MiniExcel.Query<Variable>(variablePath).ToList();
            }
            catch (Exception ex)
            {
                CommonMethods.AddLog(1, "通信变量加载失败:" + ex.Message);
                return null;
            }

            if (GpList != null && VarList != null)
            {
                foreach (var group in GpList)
                {
                    group.VarList = VarList.FindAll(c => c.GroupName == group.GroupName).ToList();
                }
                return GpList;
            }
            else
            {
                return null;
            }

        }
        #endregion
        #region 设备报警
        private void Device_AlarmTrigEvent(bool ackType, Variable var01)
        {
            if (ackType)
            {
                CommonMethods.AddLog(1, var01.Remark + "触发");
                //存储
                sysLogManage.AddSysLog(new SysLog()
                {
                    InsertTime = CurrrentTime,
                    Note = var01.Remark,
                    AlarmType = "触发",
                    Operator = CommonMethods.CurrentAdmin.LoginName,
                    VarName = var01.VarName,
                });
                if (!actualDataList.Contains(var01.Remark))
                {
                    actualDataList.Add(var01.Remark);
                }
            }
            if (!ackType)
            {
                CommonMethods.AddLog(0, var01.Remark + "消除");

                //存储
                sysLogManage.AddSysLog(new SysLog()
                {
                    InsertTime = CurrrentTime,
                    Note = var01.Remark,
                    AlarmType = "消除",
                    Operator = CommonMethods.CurrentAdmin.LoginName,
                    VarName = var01.VarName,
                });
                if (actualDataList.Contains(var01.Remark))
                {
                    actualDataList.Remove(var01.Remark);
                }
            }
        }
        #endregion
        #region 将有无报警显示到UI
        private void ActualDataList_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            //根据集合数量显示UI
            this.Invoke(new Action(
                () =>
                {
                    switch (actualDataList.Count)
                    {
                        case 0:
                            this.scrollingAlarm.Text = "当前系统无报警";
                            break;
                        default:
                            this.scrollingAlarm.Text = string.Join(" ", actualDataList);
                            break;
                    }
                }));
        }
        #endregion
        #region 导航按钮事件
        public void CommonNaviButton_Click(object sender, EventArgs e)
        {
            if (sender is NaviButton navi)//判断触发事件的对象是NaviButton，即自定义的导航按钮
            {
                if (Enum.IsDefined(typeof(FormNames), navi.TitleName))//如果导航按钮的Title字符串与枚举值其一对应则执行下行代码
                {
                    //拿到导航按钮对应的窗体枚举值
                    FormNames formNames = (FormNames)Enum.
                          Parse(typeof(FormNames), navi.TitleName, true);//将TitleName值解析为FormNames的一个值赋给formNames

                    //用户权限处理
                    switch (formNames)
                    {
                        case FormNames.参数设置:
                            if (!CommonMethods.CurrentAdmin.ParamSet)
                            {
                                new FrmMsgBoxWithoutAck("用户权限不足，请切换用户!", "权限不足").ShowDialog();
                                return;
                            }
                            break;
                        case FormNames.配方管理:
                            if (!CommonMethods.CurrentAdmin.Recipe)
                            {
                                new FrmMsgBoxWithoutAck("用户权限不足，请切换用户!", "权限不足").ShowDialog();
                                return;
                            }
                            break;
                        case FormNames.报警追溯:
                            if (!CommonMethods.CurrentAdmin.HistoryLog)
                            {
                                new FrmMsgBoxWithoutAck("用户权限不足，请切换用户!", "权限不足").ShowDialog();
                                return;
                            }
                            break;
                        case FormNames.历史趋势:
                            if (!CommonMethods.CurrentAdmin.HistoryTrend)
                            {
                                new FrmMsgBoxWithoutAck("用户权限不足，请切换用户!", "权限不足").ShowDialog();
                                return;
                            }
                            break;
                        case FormNames.用户管理:
                            if (!CommonMethods.CurrentAdmin.UserManage)
                            {
                                new FrmMsgBoxWithoutAck("用户权限不足，请切换用户!", "权限不足").ShowDialog();
                                return;
                            }
                            break;
                        default:
                            break;
                    }
                    //窗体切换
                    OpenForm(this.MainPanel, formNames);
                    //设置Title
                    SetTitle(this.lbl_Title, formNames);
                    //设置选中
                    SetNaviButtonSelected(this.TopPanel, navi);
                }
            }
        }
        #endregion
        #region 打开窗体函数
        /// <summary>
        /// 通用打开函数
        /// </summary>
        /// <param name="mainPanel">容器控件</param>
        /// <param name="formNames">窗体枚举名称</param>
        private void OpenForm(Panel mainPanel, FormNames formNames)
        {
            //考虑Panel里面已经存在窗体
            int controlCount = mainPanel.Controls.Count;//获取Panel里面的控件数量
            int closeCount = 0;//已经关闭的数量
            bool isFind = false;//找到标志
            for (int i = 0; i < controlCount; i++)//遍历Panel内部的控件,这里不能使用foreach，以免出现容器内控件状态已改变的警告
            {
                Control crl = mainPanel.Controls[i - closeCount];
                if (crl is Form form)//这里主要处理窗体，判断控件是否是窗体
                {
                    if (form.Text == formNames.ToString())//如果该窗体是所找的(要修改前端form的Text)
                    {
                        form.BringToFront();
                        isFind = true;
                        break;
                    }
                    else if ((FormNames)Enum.Parse(typeof(FormNames),//不是所找的窗体，判断是不是固定窗体，如果是，不关闭。
                                                                     //反之,关闭。
                        form.Text, true) >= FormNames.临界窗体)
                    {
                        form.Close();
                        closeCount++;
                    }
                }
            }
            //考虑新建窗体
            if (!isFind)
            {
                Form form = null;
                switch (formNames)
                {
                    case FormNames.集中监控:
                        form = new FrmMonitor();
                        CommonMethods.AddLog = ((FrmMonitor)form).AddLog;
                        break;
                    case FormNames.参数设置:
                        form = new FrmParamSet(devPath);
                        break;
                    case FormNames.配方管理:
                        form = new FrmRecipe(this.devPath);
                        break;
                    case FormNames.报警追溯:
                        form = new FrmAlarm();
                        break;
                    case FormNames.历史趋势:
                        form = new FrmHistory();
                        break;
                    case FormNames.用户管理:
                        form = new FrmUserManage();
                        break;
                    default:
                        break;
                }
                //设置新建窗体的默认属性，防止忘记设置
                if (form != null)
                {
                    form.TopLevel = false;//设置非顶层窗体
                    form.Dock = DockStyle.Fill;//设置填充满
                    form.Parent = mainPanel;//设置窗体的父容器为Panel
                    form.BringToFront();//设置窗体提前
                    form.Show();//显示窗体
                }
            }
        }
        #endregion
        #region 设置Title函数
        /// <summary>
        /// 设置Title函数
        /// </summary>
        /// <param name="label">目标标签</param>
        /// <param name="formNames">窗体名</param>
        private void SetTitle(Label label, FormNames formNames)
        {
            label.Text = formNames.ToString();
        }
        #endregion
        #region 设置选中函数
        /// <summary>
        /// 设置导航按钮选中
        /// </summary>
        /// <param name="mainPanel">导航按钮容器</param>
        /// <param name="naviButton">导航按钮</param>
        private void SetNaviButtonSelected(Panel mainPanel, NaviButton naviButton)
        {
            foreach (var item in mainPanel.Controls.OfType<NaviButton>())
            {
                item.IsSelected = false;
            }
            naviButton.IsSelected = true;
        }
        #endregion
        #region 减少闪烁
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle = 0x02000000;
                return cp;
            }
        }
        #endregion
        #region 退出按钮
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        #region 左右切换
        private void btn_Right_Click(object sender, EventArgs e)
        {
            CurrentIndex++;
            if (CurrentIndex < naviButtons.Count)
            {
                CommonNaviButton_Click(naviButtons[CurrentIndex], null);
            }
            else
            {
                CurrentIndex--;
            }

        }

        private void btn_Left_Click(object sender, EventArgs e)
        {
            CurrentIndex--;
            if (CurrentIndex >= 0)
            {
                CommonNaviButton_Click(naviButtons[CurrentIndex], null);
            }
            else
            {
                CurrentIndex++;
            }
        }
        #endregion
        #region 窗体拖动
        // 定义鼠标消息常量
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        // 导入 SendMessage 函数
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        // 导入 ReleaseCapture 函数
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        private void TopPanel_MouseDown(object sender, MouseEventArgs e)
        {
            // 释放鼠标捕获
            ReleaseCapture();
            // 发送消息，模拟鼠标在标题栏按下
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }
        #endregion
    }
}