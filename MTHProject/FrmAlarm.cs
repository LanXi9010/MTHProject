using MiniExcelLibs;
using MTHBLL;
using MTHHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using thinger.DataConvertLib;

namespace MTHProject
{
    public partial class FrmAlarm : Form
    {
        public FrmAlarm()
        {
            InitializeComponent();
            this.dgv_Main.AutoGenerateColumns=false;
            this.cmb_AlarmType.Items.AddRange(new string[] { "全部", "触发", "消除" });
            this.cmb_AlarmType.SelectedIndex = 0;
            this.dtp_Start.Value = DateTime.Now.AddHours(-2.0f);
            this.dtp_End.Value = DateTime.Now.AddMinutes(1.0f);
        }
        private SysLogManage sysLogManage=new SysLogManage();
        #region 查询按钮事件
        private async void btn_Query_Click(object sender, EventArgs e)
        {
            DateTime start = this.dtp_Start.Value;
            DateTime end = this.dtp_End.Value;
            string alarmType = this.cmb_AlarmType.Text == "全部" ? "" : this.cmb_AlarmType.Text;

            this.btn_Query.Enabled = false;
            try
            {
                OperateResult<DataTable> result = await Task.Run(() =>
                {
                    return QueryProcess(start, end, alarmType);
                });

                if (result.IsSuccess)
                {
                    this.dgv_Main.DataSource = null;
                    this.dgv_Main.DataSource = result.Content;
                }
                else
                {
                    this.dgv_Main.DataSource = null;
                    new FrmMsgBoxWithoutAck("查询失败" + result.Message, "报警查询").Show();
                }
            }
            catch (Exception ex)
            {
                new FrmMsgBoxWithoutAck("查询失败:" + ex.Message, "报警查询").Show();
            }
            finally
            {
                this.btn_Query.Enabled = true;
            }
        }
        #endregion
        #region 数据库查询操作
        public OperateResult<DataTable> QueryProcess(DateTime startTime, DateTime endTime, string alarmType)
        {
            if (startTime>=endTime)
            {
                return OperateResult.CreateFailResult<DataTable>("开始时间不能晚于或等于结束时间");
            }
            TimeSpan timeSpan = endTime - startTime;
            if (timeSpan.TotalDays > 1)
            {
                return OperateResult.CreateFailResult<DataTable>("时间跨度不能超过一天");
            }
            string start = startTime.ToString("yyyy-MM-dd HH:mm:ss");
            string end = endTime.ToString("yyyy-MM-dd HH:mm:ss");
            DataTable dataTable=sysLogManage.QuerySysLogByCondition(start, end, alarmType);
            if (dataTable != null)
            {
                return OperateResult.CreateSuccessResult<DataTable>(dataTable);
            }
            else
            {
                return OperateResult.CreateFailResult<DataTable>("未查询到有效信息");
            }
        }
        #endregion
        #region 给dgv添加行号
        private void dgv_Main_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewHelper.DgvRowPostPaint(sender as DataGridView, e);
        }
        #endregion
        #region 导出历史报警
        private void btn_Export_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "XLSX文件(*.xlsx)|*.xlsx|所有文件|*.*";
            saveFileDialog.Title = "导出历史报警";
            saveFileDialog.FileName = "历史报警" + DateTime.Now.ToString("yyyyMMddHHmmss");
            saveFileDialog.AddExtension = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                MiniExcel.SaveAs(saveFileDialog.FileName, this.dgv_Main.DataSource);

                if (new FrmMsgBoxWithAck("导出报警成功,是否立即打开?", "打开报警记录").ShowDialog() == DialogResult.OK)
                {
                    Process.Start(saveFileDialog.FileName);
                }
            }
        }
        #endregion
    }
}
