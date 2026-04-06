using MTHControlLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace MTHProject
{
    public partial class FrmMonitor : Form
    {
        public FrmMonitor()
        {
            InitializeComponent();
            SetChart();
            this.lst_Info.Columns[1].Width = this.lst_Info.Width - this.lst_Info.Columns[0].Width - 25;//设置日志的格式
            this.updateTimer.Interval= 500;
            this.updateTimer.Tick += UpdateTimer_Tick;
            this.updateTimer.Start();
            this.FormClosing += (sender, e) => 
            {
                this.updateTimer.Stop();
            };
        }
        public Timer updateTimer = new Timer();
        #region 计时器更新函数
        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            // 设备对象为空或未连接时，不执行UI更新与曲线绘制
            if (CommonMethods.Device == null || !CommonMethods.Device.IsConnected)
            {
                return;
            }

            // 周期刷新每个温湿度控件
            foreach (var item in this.MainPanel.Controls.OfType<THMControl>())
            {
                UpdateTHMControl(item);
            }

            // 刷新实时趋势曲线（温度+湿度）
            PlotSingelLine();
        }
        #endregion
        #region 设置图表
        private void SetChart()
        {
            //设置X轴的数据类型及格式
            this.chart_ActuralTrend.XDataType = SeeSharpTools.JY.GUI.StripChartX.XAxisDataType.TimeStamp;
            this.chart_ActuralTrend.TimeStampFormat = "HH:mm:ss";
            //设置图例
            this.chart_ActuralTrend.LegendVisible = true;
            //设置显示数据点
            this.chart_ActuralTrend.DisplayPoints = 4000;
            //设置Y轴
            this.chart_ActuralTrend.AxisY.Minimum = 0.0f;
            this.chart_ActuralTrend.AxisY.Maximum = 100.0f;
            this.chart_ActuralTrend.AxisY.AutoScale=false;
            //清除曲线
            this.chart_ActuralTrend.Series.Clear();
            //设置曲线数量
            this.chart_ActuralTrend.SeriesCount = 12;
            //设置曲线
            for (int i = 0; i < 12; i++)
            {
                //设置曲线名称
                this.chart_ActuralTrend.Series[i].Name = i % 2 == 0 ? $"{i / 2 + 1}#站点温度" : $"{i / 2 + 1}#站点湿度";
                //设置曲线不可见
                this.chart_ActuralTrend.Series[i].Visible = false;
                //设置曲线的粗细
                this.chart_ActuralTrend.Series[i].Width = SeeSharpTools.JY.GUI.StripChartXSeries.LineWidth.Middle;
                //设置曲线的Y轴
                this.chart_ActuralTrend.Series[i].YPlotAxis = SeeSharpTools.JY.GUI.StripChartXAxis.PlotAxis.Primary;
            }
            this.chk_Temp1.Checked = true;
            this.chk_Humidity1.Checked = true;
        }
        #endregion
        #region 更新数据到UI
        private void UpdateTHMControl(THMControl tHMControl )
        {
            // 温度值更新
            if (CommonMethods.Device[tHMControl.TempVarName] != null)
            {
                tHMControl.Temp = CommonMethods.Device[tHMControl.TempVarName].ToString();
            }

            // 湿度值更新（
            if (CommonMethods.Device[tHMControl.HumidityVarName] != null)
            {
                tHMControl.Humidity = CommonMethods.Device[tHMControl.HumidityVarName].ToString();
            }

            // 模块状态更新
            if (CommonMethods.Device[tHMControl.StateVarName] != null)
            {
                tHMControl.ModuleError = CommonMethods.Device[tHMControl.StateVarName].ToString() == "True";
            }
        }
        #endregion
        #region 获取当前时间
        private string CurrentTime
        {
            get
            { return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); }
        }
        #endregion
        #region 添加日志函数
        public void AddLog(int level,string log)
        {
            if (level < 0)
            {
                level = 0;
            }
            if (level > 2)
            {
                level= 2;
            }
            if (this.InvokeRequired)//判断是否需要多线程
            {
                this.Invoke(new Action<int,string>(AddLog), level,log);
            }
            else
            {
                ListViewItem listViewItem = new ListViewItem("  " + CurrentTime, level);
                listViewItem.SubItems.Add(log);
                this.lst_Info.Items.Add(listViewItem);
                this.lst_Info.Items[this.lst_Info.Items.Count - 1].EnsureVisible();//将最新的日志显示在下面
            }
            
        }
        #endregion
        #region 根据checkBox的勾选状态设置表格的的线可见状态
        private void chk_Common_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBoxEx checkBox)
            {
                if (checkBox.Tag != null && checkBox.Tag.ToString().Length > 0)
                {
                    int index = Convert.ToInt32(checkBox.Tag.ToString());

                    this.chart_ActuralTrend.Series[index].Visible = checkBox.Checked;
                }
            }
        }
        #endregion
        #region 根据数据绘制图标曲线
        private void PlotSingelLine()
        {
            // 按“1#温度、1#湿度、2#温度、2#湿度...”顺序组织数据，与Series顺序保持一致
            List<double> ydata = new List<double>();
            for (int i = 1; i <= 6; i++)
            {
                // 温度
                ydata.Add(GetDeviceDouble($"模块{i}温度"));
                // 湿度（修复变量名错误：原来是"[模块{i}]湿度"，导致湿度曲线无法正常显示）
                ydata.Add(GetDeviceDouble($"模块{i}湿度"));
            }
            this.chart_ActuralTrend.PlotSingle(ydata.ToArray());
        }

        /// <summary>
        /// 从设备变量中安全读取double值，读取失败返回0，避免实时曲线中断。
        /// </summary>
        /// <param name="varName">设备变量名</param>
        /// <returns>转换后的数值</returns>
        private double GetDeviceDouble(string varName)
        {
            object value = CommonMethods.Device[varName];
            if (value == null)
            {
                return 0.0d;
            }

            double result;
            if (double.TryParse(value.ToString(), out result))
            {
                return result;
            }

            return 0.0d;
        }
        #endregion
    }
}
