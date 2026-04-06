using MTHBLL;
using MTHControlLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using thinger.DataConvertLib;

namespace MTHProject
{
    public partial class FrmHistory : Form
    {
        public FrmHistory()
        {
            InitializeComponent();
            checkBoxList.Add(this.checkBoxEx1);
            checkBoxList.Add(this.checkBoxEx2);
            checkBoxList.Add(this.checkBoxEx3);
            checkBoxList.Add(this.checkBoxEx4);
            checkBoxList.Add(this.checkBoxEx5);
            checkBoxList.Add(this.checkBoxEx6);
            checkBoxList.Add(this.checkBoxEx7);
            checkBoxList.Add(this.checkBoxEx8);
            checkBoxList.Add(this.checkBoxEx9);
            checkBoxList.Add(this.checkBoxEx10);
            checkBoxList.Add(this.checkBoxEx11);
            checkBoxList.Add(this.checkBoxEx12);

            this.dtp_Start.Value = DateTime.Now.AddHours(-2.0f);
            this.dtp_End.Value = DateTime.Now.AddMinutes(1.0f);

            //设置x轴类型
            this.chart_HistoryTrend.XDataType = SeeSharpTools.JY.GUI.StripChartX.XAxisDataType.String;

            //设置图例
            this.chart_HistoryTrend.LegendVisible = false;
            this.chart_HistoryTrend.DisplayPoints = 100000;

            //Y轴范围
            this.chart_HistoryTrend.AxisY.Minimum = 0.0f;
            this.chart_HistoryTrend.AxisY.Maximum = 100.0f;
            this.chart_HistoryTrend.AxisY.AutoScale = false;



        }
        #region 属性与属性集合
        public Dictionary<string, string> paramList = new Dictionary<string, string>();
        public List<CheckBox> checkBoxList = new List<CheckBox>();
        private ActualDataManage actualDataManage = new ActualDataManage();
        #endregion
        #region 用户选中checkBox的Tag作为key值，传给数据库
        public Dictionary<string, string> GetParamList()
        {
            Dictionary<string, string> paramList = new Dictionary<string, string>();
            foreach (var item in checkBoxList)
            {
                if (item.Tag != null && item.Tag.ToString().Length > 0)
                {
                    if (item.Checked)
                    {
                        paramList.Add(item.Tag.ToString(), item.Text.ToString());
                    }
                }
            }
            return paramList;
        }
        #endregion
        #region 将Tag值作为参数，根据时间节点查询
        private OperateResult<DataTable> QueryProcess(DateTime startTime, DateTime endTime, List<string> columns)
        {
            if (startTime >= endTime)
            {
                return OperateResult.CreateFailResult<DataTable>("开始时间不能大于结束时间");
            }

            TimeSpan timeSpan = endTime - startTime;

            if (timeSpan.TotalDays > 1.0)
            {
                return OperateResult.CreateFailResult<DataTable>("查询时间不能超过1天");
            }

            if (columns == null || columns.Count == 0)
            {
                return OperateResult.CreateFailResult<DataTable>("查询参数不能为空");
            }

            string start = startTime.ToString("yyyy-MM-dd,HH-mm-ss");
            string end = endTime.ToString("yyyy-MM-dd,HH-mm-ss");

            DataTable dataTable = actualDataManage.QueryActualDataByCondition(start, end, columns);

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                return OperateResult.CreateSuccessResult(dataTable);
            }
            else
            {
                return OperateResult.CreateFailResult<DataTable>("未查询到有效数据");
            }
        }
        #endregion
        #region 解析数据库返回的表并绘制到chart
        private void UpdateChart(DataTable dataTable, Dictionary<string, string> selectedParamList)
        {
            //解析DataTable
            int rowcount = dataTable.Rows.Count;
            int columnCount = selectedParamList.Count;

            if (columnCount == 0 || rowcount == 0)
            {
                this.chart_HistoryTrend.Clear();
                this.chart_HistoryTrend.SeriesCount = 0;
                return;
            }

            List<KeyValuePair<string, string>> orderedParams = selectedParamList.ToList();

            //需要设置Chart
            this.chart_HistoryTrend.Clear();
            this.chart_HistoryTrend.SeriesCount = columnCount;

            for (int i = 0; i < columnCount; i++)
            {
                this.chart_HistoryTrend.Series[i].Name = orderedParams[i].Value;
                this.chart_HistoryTrend.Series[i].Width = SeeSharpTools.JY.GUI.StripChartXSeries.LineWidth.Middle;
            }

            double[,] YData = new double[columnCount, rowcount];
            string[] XData = new string[rowcount];

            for (int i = 0; i < rowcount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    string columnName = orderedParams[j].Key;
                    if (!dataTable.Columns.Contains(columnName) || dataTable.Rows[i][columnName] is DBNull)
                    {
                        YData[j, i] = 0.0f;
                    }
                    else
                    {
                        try
                        {
                            YData[j, i] = Convert.ToDouble(dataTable.Rows[i][columnName]);
                        }
                        catch (Exception)
                        {
                            YData[j, i] = 0.0f;
                        }
                    }
                }

                string insertTimeText = dataTable.Rows[i][0].ToString();
                DateTime xTime;
                if (DateTime.TryParse(insertTimeText, out xTime))
                {
                    XData[i] = xTime.ToString("HH:mm:ss");
                }
                else
                {
                    string[] parts = insertTimeText.Split(',');
                    if (parts.Length == 2 && DateTime.TryParse(parts[0] + " " + parts[1].Replace('-', ':'), out xTime))
                    {
                        XData[i] = xTime.ToString("HH:mm:ss");
                    }
                    else
                    {
                        XData[i] = insertTimeText;
                    }
                }
            }
            this.chart_HistoryTrend.Plot(YData, XData);
        }

        #endregion
        #region 快速查询函数
        private void btn_Quick_Click(object sender, EventArgs e)
        {
            this.dtp_Start.Value = DateTime.Now.AddHours(-5.0f);
            this.dtp_End.Value = DateTime.Now.AddMinutes(1.0f);
            this.btn_Query.PerformClick();
        }
        #endregion
        #region 查询按钮函数
        private async void btn_Query_Click(object sender, EventArgs e)
        {
            DateTime start = this.dtp_Start.Value;
            DateTime end = this.dtp_End.Value;
            Dictionary<string, string> selectedParamList = GetParamList();
            if (selectedParamList.Count == 0)
            {
                new FrmMsgBoxWithoutAck("查询参数不能为空", "信息提示").Show();
                return;
            }

            this.btn_Query.Enabled = false;
            this.btn_Quick.Enabled = false;
            try
            {
                OperateResult<DataTable> result = await Task.Run(() =>
                {
                    return QueryProcess(start, end, selectedParamList.Keys.ToList());
                });

                if (result.IsSuccess)
                {
                    paramList = selectedParamList;
                    UpdateChart(result.Content, selectedParamList);
                }
                else
                {
                    this.chart_HistoryTrend.Clear();
                    this.chart_HistoryTrend.SeriesCount = 0;
                    new FrmMsgBoxWithoutAck("查询出错：" + result.Message, "查询出错").Show();
                }
            }
            catch (Exception ex)
            {
                new FrmMsgBoxWithoutAck("查询出错：" + ex.Message, "查询出错").Show();
            }
            finally
            {
                this.btn_Query.Enabled = true;
                this.btn_Quick.Enabled = true;
            }
        }
        #endregion
        #region 保存按钮函数
        private void btn_SaveImage_Click(object sender, EventArgs e)
        {
            if (this.chart_HistoryTrend.SeriesCount == 0)
            {
                new FrmMsgBoxWithoutAck("暂无可保存的趋势数据", "信息提示").Show();
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "图片文件(*.jpg)|*.jpg|所有文件|*.*";
            saveFileDialog.FileName = "历史趋势图片" + DateTime.Now.ToString("yyyyMMddHHmmss");
            saveFileDialog.Title = "历史趋势保存";
            saveFileDialog.DefaultExt = "jpg";
            saveFileDialog.AddExtension = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.chart_HistoryTrend.SaveAsImage(saveFileDialog.FileName);
                if (new FrmMsgBoxWithAck("图片保存成功,是否立即打开?", "打开趋势图片").ShowDialog() == DialogResult.OK)
                {
                    Process.Start(saveFileDialog.FileName);
                }
            }
        }
        #endregion

        #region 导出csv文件

        #endregion
        #region 导出为csv函数
        private void btn_ExportCSV_Click(object sender, EventArgs e)
        {
            if (this.chart_HistoryTrend.SeriesCount == 0)
            {
                new FrmMsgBoxWithoutAck("暂无可导出的趋势数据", "信息提示").Show();
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV(*.csv)|*.csv|所有文件|*.*";
            saveFileDialog.FileName = "历史趋势CSV" + DateTime.Now.ToString("yyyyMMddHHmmss");
            saveFileDialog.Title = "历史趋势CSV";
            saveFileDialog.DefaultExt = "csv";
            saveFileDialog.AddExtension = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.chart_HistoryTrend.SaveAsCsv(saveFileDialog.FileName);
                if (new FrmMsgBoxWithAck("图片保存成功,是否立即打开?", "打开趋势图片").ShowDialog() == DialogResult.OK)
                {
                    Process.Start(saveFileDialog.FileName);
                }
            }
        }
        #endregion
    }
}
