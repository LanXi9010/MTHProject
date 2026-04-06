namespace MTHProject
{
    partial class FrmHistory
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            SeeSharpTools.JY.GUI.StripChartXSeries stripChartXSeries3 = new SeeSharpTools.JY.GUI.StripChartXSeries();
            this.panelParam = new System.Windows.Forms.Panel();
            this.checkBoxEx6 = new MTHControlLib.CheckBoxEx();
            this.checkBoxEx12 = new MTHControlLib.CheckBoxEx();
            this.checkBoxEx2 = new MTHControlLib.CheckBoxEx();
            this.checkBoxEx11 = new MTHControlLib.CheckBoxEx();
            this.checkBoxEx5 = new MTHControlLib.CheckBoxEx();
            this.checkBoxEx8 = new MTHControlLib.CheckBoxEx();
            this.checkBoxEx1 = new MTHControlLib.CheckBoxEx();
            this.checkBoxEx7 = new MTHControlLib.CheckBoxEx();
            this.checkBoxEx3 = new MTHControlLib.CheckBoxEx();
            this.checkBoxEx10 = new MTHControlLib.CheckBoxEx();
            this.checkBoxEx9 = new MTHControlLib.CheckBoxEx();
            this.checkBoxEx4 = new MTHControlLib.CheckBoxEx();
            this.dtp_End = new System.Windows.Forms.DateTimePicker();
            this.dtp_Start = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_ExportCSV = new System.Windows.Forms.Button();
            this.btn_SaveImage = new System.Windows.Forms.Button();
            this.btn_Quick = new System.Windows.Forms.Button();
            this.btn_Query = new System.Windows.Forms.Button();
            this.chart_HistoryTrend = new SeeSharpTools.JY.GUI.StripChartX();
            this.panelParam.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelParam
            // 
            this.panelParam.BackColor = System.Drawing.Color.Transparent;
            this.panelParam.Controls.Add(this.checkBoxEx6);
            this.panelParam.Controls.Add(this.checkBoxEx12);
            this.panelParam.Controls.Add(this.checkBoxEx2);
            this.panelParam.Controls.Add(this.checkBoxEx11);
            this.panelParam.Controls.Add(this.checkBoxEx5);
            this.panelParam.Controls.Add(this.checkBoxEx8);
            this.panelParam.Controls.Add(this.checkBoxEx1);
            this.panelParam.Controls.Add(this.checkBoxEx7);
            this.panelParam.Controls.Add(this.checkBoxEx3);
            this.panelParam.Controls.Add(this.checkBoxEx10);
            this.panelParam.Controls.Add(this.checkBoxEx9);
            this.panelParam.Controls.Add(this.checkBoxEx4);
            this.panelParam.ForeColor = System.Drawing.Color.White;
            this.panelParam.Location = new System.Drawing.Point(23, 12);
            this.panelParam.Name = "panelParam";
            this.panelParam.Size = new System.Drawing.Size(601, 140);
            this.panelParam.TabIndex = 17;
            // 
            // checkBoxEx6
            // 
            this.checkBoxEx6.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxEx6.CheckBackColor = System.Drawing.Color.White;
            this.checkBoxEx6.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.checkBoxEx6.DefaultCheckButtonWidth = 20;
            this.checkBoxEx6.Font = new System.Drawing.Font("微软雅黑", 11.5F);
            this.checkBoxEx6.ForeColor = System.Drawing.Color.White;
            this.checkBoxEx6.Location = new System.Drawing.Point(167, 56);
            this.checkBoxEx6.Name = "checkBoxEx6";
            this.checkBoxEx6.Size = new System.Drawing.Size(125, 34);
            this.checkBoxEx6.TabIndex = 10;
            this.checkBoxEx6.Tag = "Station3Humidity";
            this.checkBoxEx6.Text = "3#站点湿度";
            this.checkBoxEx6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxEx6.UseVisualStyleBackColor = false;
            // 
            // checkBoxEx12
            // 
            this.checkBoxEx12.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxEx12.CheckBackColor = System.Drawing.Color.White;
            this.checkBoxEx12.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.checkBoxEx12.DefaultCheckButtonWidth = 20;
            this.checkBoxEx12.Font = new System.Drawing.Font("微软雅黑", 11.5F);
            this.checkBoxEx12.ForeColor = System.Drawing.Color.White;
            this.checkBoxEx12.Location = new System.Drawing.Point(463, 93);
            this.checkBoxEx12.Name = "checkBoxEx12";
            this.checkBoxEx12.Size = new System.Drawing.Size(125, 37);
            this.checkBoxEx12.TabIndex = 4;
            this.checkBoxEx12.Tag = "Station6Humidity";
            this.checkBoxEx12.Text = "6#站点湿度";
            this.checkBoxEx12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxEx12.UseVisualStyleBackColor = false;
            // 
            // checkBoxEx2
            // 
            this.checkBoxEx2.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxEx2.CheckBackColor = System.Drawing.Color.White;
            this.checkBoxEx2.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.checkBoxEx2.Checked = true;
            this.checkBoxEx2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxEx2.DefaultCheckButtonWidth = 20;
            this.checkBoxEx2.Font = new System.Drawing.Font("微软雅黑", 11.5F);
            this.checkBoxEx2.ForeColor = System.Drawing.Color.White;
            this.checkBoxEx2.Location = new System.Drawing.Point(167, 16);
            this.checkBoxEx2.Name = "checkBoxEx2";
            this.checkBoxEx2.Size = new System.Drawing.Size(125, 34);
            this.checkBoxEx2.TabIndex = 15;
            this.checkBoxEx2.Tag = "Station1Humidity";
            this.checkBoxEx2.Text = "1#站点湿度";
            this.checkBoxEx2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxEx2.UseVisualStyleBackColor = false;
            // 
            // checkBoxEx11
            // 
            this.checkBoxEx11.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxEx11.CheckBackColor = System.Drawing.Color.White;
            this.checkBoxEx11.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.checkBoxEx11.DefaultCheckButtonWidth = 20;
            this.checkBoxEx11.Font = new System.Drawing.Font("微软雅黑", 11.5F);
            this.checkBoxEx11.ForeColor = System.Drawing.Color.White;
            this.checkBoxEx11.Location = new System.Drawing.Point(315, 93);
            this.checkBoxEx11.Name = "checkBoxEx11";
            this.checkBoxEx11.Size = new System.Drawing.Size(125, 37);
            this.checkBoxEx11.TabIndex = 5;
            this.checkBoxEx11.Tag = "Station6Temp";
            this.checkBoxEx11.Text = "6#站点温度";
            this.checkBoxEx11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxEx11.UseVisualStyleBackColor = false;
            // 
            // checkBoxEx5
            // 
            this.checkBoxEx5.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxEx5.CheckBackColor = System.Drawing.Color.White;
            this.checkBoxEx5.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.checkBoxEx5.DefaultCheckButtonWidth = 20;
            this.checkBoxEx5.Font = new System.Drawing.Font("微软雅黑", 11.5F);
            this.checkBoxEx5.ForeColor = System.Drawing.Color.White;
            this.checkBoxEx5.Location = new System.Drawing.Point(19, 56);
            this.checkBoxEx5.Name = "checkBoxEx5";
            this.checkBoxEx5.Size = new System.Drawing.Size(125, 34);
            this.checkBoxEx5.TabIndex = 14;
            this.checkBoxEx5.Tag = "Station3Temp";
            this.checkBoxEx5.Text = "3#站点温度";
            this.checkBoxEx5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxEx5.UseVisualStyleBackColor = false;
            // 
            // checkBoxEx8
            // 
            this.checkBoxEx8.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxEx8.CheckBackColor = System.Drawing.Color.White;
            this.checkBoxEx8.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.checkBoxEx8.DefaultCheckButtonWidth = 20;
            this.checkBoxEx8.Font = new System.Drawing.Font("微软雅黑", 11.5F);
            this.checkBoxEx8.ForeColor = System.Drawing.Color.White;
            this.checkBoxEx8.Location = new System.Drawing.Point(463, 56);
            this.checkBoxEx8.Name = "checkBoxEx8";
            this.checkBoxEx8.Size = new System.Drawing.Size(125, 34);
            this.checkBoxEx8.TabIndex = 6;
            this.checkBoxEx8.Tag = "Station4Humidity";
            this.checkBoxEx8.Text = "4#站点湿度";
            this.checkBoxEx8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxEx8.UseVisualStyleBackColor = false;
            // 
            // checkBoxEx1
            // 
            this.checkBoxEx1.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxEx1.CheckBackColor = System.Drawing.Color.White;
            this.checkBoxEx1.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.checkBoxEx1.Checked = true;
            this.checkBoxEx1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxEx1.DefaultCheckButtonWidth = 20;
            this.checkBoxEx1.Font = new System.Drawing.Font("微软雅黑", 11.5F);
            this.checkBoxEx1.ForeColor = System.Drawing.Color.White;
            this.checkBoxEx1.Location = new System.Drawing.Point(19, 16);
            this.checkBoxEx1.Name = "checkBoxEx1";
            this.checkBoxEx1.Size = new System.Drawing.Size(125, 34);
            this.checkBoxEx1.TabIndex = 13;
            this.checkBoxEx1.Tag = "Station1Temp";
            this.checkBoxEx1.Text = "1#站点温度";
            this.checkBoxEx1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxEx1.UseVisualStyleBackColor = false;
            // 
            // checkBoxEx7
            // 
            this.checkBoxEx7.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxEx7.CheckBackColor = System.Drawing.Color.White;
            this.checkBoxEx7.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.checkBoxEx7.DefaultCheckButtonWidth = 20;
            this.checkBoxEx7.Font = new System.Drawing.Font("微软雅黑", 11.5F);
            this.checkBoxEx7.ForeColor = System.Drawing.Color.White;
            this.checkBoxEx7.Location = new System.Drawing.Point(315, 56);
            this.checkBoxEx7.Name = "checkBoxEx7";
            this.checkBoxEx7.Size = new System.Drawing.Size(125, 34);
            this.checkBoxEx7.TabIndex = 7;
            this.checkBoxEx7.Tag = "Station4Temp";
            this.checkBoxEx7.Text = "4#站点温度";
            this.checkBoxEx7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxEx7.UseVisualStyleBackColor = false;
            // 
            // checkBoxEx3
            // 
            this.checkBoxEx3.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxEx3.CheckBackColor = System.Drawing.Color.White;
            this.checkBoxEx3.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.checkBoxEx3.DefaultCheckButtonWidth = 20;
            this.checkBoxEx3.Font = new System.Drawing.Font("微软雅黑", 11.5F);
            this.checkBoxEx3.ForeColor = System.Drawing.Color.White;
            this.checkBoxEx3.Location = new System.Drawing.Point(315, 16);
            this.checkBoxEx3.Name = "checkBoxEx3";
            this.checkBoxEx3.Size = new System.Drawing.Size(125, 34);
            this.checkBoxEx3.TabIndex = 12;
            this.checkBoxEx3.Tag = "Station2Temp";
            this.checkBoxEx3.Text = "2#站点温度";
            this.checkBoxEx3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxEx3.UseVisualStyleBackColor = false;
            // 
            // checkBoxEx10
            // 
            this.checkBoxEx10.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxEx10.CheckBackColor = System.Drawing.Color.White;
            this.checkBoxEx10.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.checkBoxEx10.DefaultCheckButtonWidth = 20;
            this.checkBoxEx10.Font = new System.Drawing.Font("微软雅黑", 11.5F);
            this.checkBoxEx10.ForeColor = System.Drawing.Color.White;
            this.checkBoxEx10.Location = new System.Drawing.Point(167, 93);
            this.checkBoxEx10.Name = "checkBoxEx10";
            this.checkBoxEx10.Size = new System.Drawing.Size(125, 37);
            this.checkBoxEx10.TabIndex = 8;
            this.checkBoxEx10.Tag = "Station5Humidity";
            this.checkBoxEx10.Text = "5#站点湿度";
            this.checkBoxEx10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxEx10.UseVisualStyleBackColor = false;
            // 
            // checkBoxEx9
            // 
            this.checkBoxEx9.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxEx9.CheckBackColor = System.Drawing.Color.White;
            this.checkBoxEx9.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.checkBoxEx9.DefaultCheckButtonWidth = 20;
            this.checkBoxEx9.Font = new System.Drawing.Font("微软雅黑", 11.5F);
            this.checkBoxEx9.ForeColor = System.Drawing.Color.White;
            this.checkBoxEx9.Location = new System.Drawing.Point(19, 93);
            this.checkBoxEx9.Name = "checkBoxEx9";
            this.checkBoxEx9.Size = new System.Drawing.Size(125, 37);
            this.checkBoxEx9.TabIndex = 11;
            this.checkBoxEx9.Tag = "Station5Temp";
            this.checkBoxEx9.Text = "5#站点温度";
            this.checkBoxEx9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxEx9.UseVisualStyleBackColor = false;
            // 
            // checkBoxEx4
            // 
            this.checkBoxEx4.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxEx4.CheckBackColor = System.Drawing.Color.White;
            this.checkBoxEx4.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.checkBoxEx4.DefaultCheckButtonWidth = 20;
            this.checkBoxEx4.Font = new System.Drawing.Font("微软雅黑", 11.5F);
            this.checkBoxEx4.ForeColor = System.Drawing.Color.White;
            this.checkBoxEx4.Location = new System.Drawing.Point(463, 16);
            this.checkBoxEx4.Name = "checkBoxEx4";
            this.checkBoxEx4.Size = new System.Drawing.Size(125, 34);
            this.checkBoxEx4.TabIndex = 9;
            this.checkBoxEx4.Tag = "Station2Humidity";
            this.checkBoxEx4.Text = "2#站点湿度";
            this.checkBoxEx4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxEx4.UseVisualStyleBackColor = false;
            // 
            // dtp_End
            // 
            this.dtp_End.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtp_End.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_End.Location = new System.Drawing.Point(1094, 27);
            this.dtp_End.Name = "dtp_End";
            this.dtp_End.Size = new System.Drawing.Size(231, 35);
            this.dtp_End.TabIndex = 23;
            // 
            // dtp_Start
            // 
            this.dtp_Start.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtp_Start.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_Start.Location = new System.Drawing.Point(724, 31);
            this.dtp_Start.Name = "dtp_Start";
            this.dtp_Start.Size = new System.Drawing.Size(252, 35);
            this.dtp_Start.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12.25F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(1010, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 32);
            this.label2.TabIndex = 21;
            this.label2.Text = "结束时间";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12.25F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(640, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 32);
            this.label1.TabIndex = 22;
            this.label1.Text = "开始时间";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_ExportCSV
            // 
            this.btn_ExportCSV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(27)))), ((int)(((byte)(78)))));
            this.btn_ExportCSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ExportCSV.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ExportCSV.ForeColor = System.Drawing.Color.White;
            this.btn_ExportCSV.Location = new System.Drawing.Point(1195, 91);
            this.btn_ExportCSV.Name = "btn_ExportCSV";
            this.btn_ExportCSV.Size = new System.Drawing.Size(144, 42);
            this.btn_ExportCSV.TabIndex = 25;
            this.btn_ExportCSV.Text = "导出CSV";
            this.btn_ExportCSV.UseVisualStyleBackColor = false;
            this.btn_ExportCSV.Click += new System.EventHandler(this.btn_ExportCSV_Click);
            // 
            // btn_SaveImage
            // 
            this.btn_SaveImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(27)))), ((int)(((byte)(78)))));
            this.btn_SaveImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SaveImage.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_SaveImage.ForeColor = System.Drawing.Color.White;
            this.btn_SaveImage.Location = new System.Drawing.Point(1016, 91);
            this.btn_SaveImage.Name = "btn_SaveImage";
            this.btn_SaveImage.Size = new System.Drawing.Size(144, 42);
            this.btn_SaveImage.TabIndex = 26;
            this.btn_SaveImage.Text = "保存IMAGE";
            this.btn_SaveImage.UseVisualStyleBackColor = false;
            this.btn_SaveImage.Click += new System.EventHandler(this.btn_SaveImage_Click);
            // 
            // btn_Quick
            // 
            this.btn_Quick.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(27)))), ((int)(((byte)(78)))));
            this.btn_Quick.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Quick.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Quick.ForeColor = System.Drawing.Color.White;
            this.btn_Quick.Location = new System.Drawing.Point(837, 91);
            this.btn_Quick.Name = "btn_Quick";
            this.btn_Quick.Size = new System.Drawing.Size(144, 42);
            this.btn_Quick.TabIndex = 27;
            this.btn_Quick.Text = "快速查询";
            this.btn_Quick.UseVisualStyleBackColor = false;
            this.btn_Quick.Click += new System.EventHandler(this.btn_Quick_Click);
            // 
            // btn_Query
            // 
            this.btn_Query.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(27)))), ((int)(((byte)(78)))));
            this.btn_Query.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Query.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Query.ForeColor = System.Drawing.Color.White;
            this.btn_Query.Location = new System.Drawing.Point(658, 91);
            this.btn_Query.Name = "btn_Query";
            this.btn_Query.Size = new System.Drawing.Size(144, 42);
            this.btn_Query.TabIndex = 28;
            this.btn_Query.Text = "时间查询";
            this.btn_Query.UseVisualStyleBackColor = false;
            this.btn_Query.Click += new System.EventHandler(this.btn_Query_Click);
            // 
            // chart_HistoryTrend
            // 
            this.chart_HistoryTrend.AxisX.AutoScale = false;
            this.chart_HistoryTrend.AxisX.AutoZoomReset = false;
            this.chart_HistoryTrend.AxisX.Color = System.Drawing.Color.White;
            this.chart_HistoryTrend.AxisX.InitWithScaleView = false;
            this.chart_HistoryTrend.AxisX.IsLogarithmic = false;
            this.chart_HistoryTrend.AxisX.LabelAngle = 0;
            this.chart_HistoryTrend.AxisX.LabelEnabled = true;
            this.chart_HistoryTrend.AxisX.LabelFormat = null;
            this.chart_HistoryTrend.AxisX.MajorGridColor = System.Drawing.Color.White;
            this.chart_HistoryTrend.AxisX.MajorGridCount = 4;
            this.chart_HistoryTrend.AxisX.MajorGridEnabled = true;
            this.chart_HistoryTrend.AxisX.MajorGridType = SeeSharpTools.JY.GUI.StripChartXAxis.GridStyle.Dash;
            this.chart_HistoryTrend.AxisX.Maximum = 1000D;
            this.chart_HistoryTrend.AxisX.Minimum = 0D;
            this.chart_HistoryTrend.AxisX.MinorGridColor = System.Drawing.Color.Black;
            this.chart_HistoryTrend.AxisX.MinorGridEnabled = false;
            this.chart_HistoryTrend.AxisX.MinorGridType = SeeSharpTools.JY.GUI.StripChartXAxis.GridStyle.DashDot;
            this.chart_HistoryTrend.AxisX.TickWidth = 1F;
            this.chart_HistoryTrend.AxisX.Title = "";
            this.chart_HistoryTrend.AxisX.TitleOrientation = SeeSharpTools.JY.GUI.StripChartXAxis.AxisTextOrientation.Auto;
            this.chart_HistoryTrend.AxisX.TitlePosition = SeeSharpTools.JY.GUI.StripChartXAxis.AxisTextPosition.Center;
            this.chart_HistoryTrend.AxisX.ViewMaximum = 1000D;
            this.chart_HistoryTrend.AxisX.ViewMinimum = 0D;
            this.chart_HistoryTrend.AxisX2.AutoScale = false;
            this.chart_HistoryTrend.AxisX2.AutoZoomReset = false;
            this.chart_HistoryTrend.AxisX2.Color = System.Drawing.Color.Black;
            this.chart_HistoryTrend.AxisX2.InitWithScaleView = false;
            this.chart_HistoryTrend.AxisX2.IsLogarithmic = false;
            this.chart_HistoryTrend.AxisX2.LabelAngle = 0;
            this.chart_HistoryTrend.AxisX2.LabelEnabled = true;
            this.chart_HistoryTrend.AxisX2.LabelFormat = null;
            this.chart_HistoryTrend.AxisX2.MajorGridColor = System.Drawing.Color.Black;
            this.chart_HistoryTrend.AxisX2.MajorGridCount = 6;
            this.chart_HistoryTrend.AxisX2.MajorGridEnabled = true;
            this.chart_HistoryTrend.AxisX2.MajorGridType = SeeSharpTools.JY.GUI.StripChartXAxis.GridStyle.Dash;
            this.chart_HistoryTrend.AxisX2.Maximum = 1000D;
            this.chart_HistoryTrend.AxisX2.Minimum = 0D;
            this.chart_HistoryTrend.AxisX2.MinorGridColor = System.Drawing.Color.Black;
            this.chart_HistoryTrend.AxisX2.MinorGridEnabled = false;
            this.chart_HistoryTrend.AxisX2.MinorGridType = SeeSharpTools.JY.GUI.StripChartXAxis.GridStyle.DashDot;
            this.chart_HistoryTrend.AxisX2.TickWidth = 1F;
            this.chart_HistoryTrend.AxisX2.Title = "";
            this.chart_HistoryTrend.AxisX2.TitleOrientation = SeeSharpTools.JY.GUI.StripChartXAxis.AxisTextOrientation.Auto;
            this.chart_HistoryTrend.AxisX2.TitlePosition = SeeSharpTools.JY.GUI.StripChartXAxis.AxisTextPosition.Center;
            this.chart_HistoryTrend.AxisX2.ViewMaximum = 1000D;
            this.chart_HistoryTrend.AxisX2.ViewMinimum = 0D;
            this.chart_HistoryTrend.AxisY.AutoScale = true;
            this.chart_HistoryTrend.AxisY.AutoZoomReset = false;
            this.chart_HistoryTrend.AxisY.Color = System.Drawing.Color.White;
            this.chart_HistoryTrend.AxisY.InitWithScaleView = false;
            this.chart_HistoryTrend.AxisY.IsLogarithmic = false;
            this.chart_HistoryTrend.AxisY.LabelAngle = 0;
            this.chart_HistoryTrend.AxisY.LabelEnabled = true;
            this.chart_HistoryTrend.AxisY.LabelFormat = null;
            this.chart_HistoryTrend.AxisY.MajorGridColor = System.Drawing.Color.White;
            this.chart_HistoryTrend.AxisY.MajorGridCount = 6;
            this.chart_HistoryTrend.AxisY.MajorGridEnabled = true;
            this.chart_HistoryTrend.AxisY.MajorGridType = SeeSharpTools.JY.GUI.StripChartXAxis.GridStyle.Dash;
            this.chart_HistoryTrend.AxisY.Maximum = 3.5D;
            this.chart_HistoryTrend.AxisY.Minimum = 0.5D;
            this.chart_HistoryTrend.AxisY.MinorGridColor = System.Drawing.Color.Black;
            this.chart_HistoryTrend.AxisY.MinorGridEnabled = false;
            this.chart_HistoryTrend.AxisY.MinorGridType = SeeSharpTools.JY.GUI.StripChartXAxis.GridStyle.DashDot;
            this.chart_HistoryTrend.AxisY.TickWidth = 1F;
            this.chart_HistoryTrend.AxisY.Title = "";
            this.chart_HistoryTrend.AxisY.TitleOrientation = SeeSharpTools.JY.GUI.StripChartXAxis.AxisTextOrientation.Auto;
            this.chart_HistoryTrend.AxisY.TitlePosition = SeeSharpTools.JY.GUI.StripChartXAxis.AxisTextPosition.Center;
            this.chart_HistoryTrend.AxisY.ViewMaximum = 3.5D;
            this.chart_HistoryTrend.AxisY.ViewMinimum = 0.5D;
            this.chart_HistoryTrend.AxisY2.AutoScale = true;
            this.chart_HistoryTrend.AxisY2.AutoZoomReset = false;
            this.chart_HistoryTrend.AxisY2.Color = System.Drawing.Color.Black;
            this.chart_HistoryTrend.AxisY2.InitWithScaleView = false;
            this.chart_HistoryTrend.AxisY2.IsLogarithmic = false;
            this.chart_HistoryTrend.AxisY2.LabelAngle = 0;
            this.chart_HistoryTrend.AxisY2.LabelEnabled = true;
            this.chart_HistoryTrend.AxisY2.LabelFormat = null;
            this.chart_HistoryTrend.AxisY2.MajorGridColor = System.Drawing.Color.Black;
            this.chart_HistoryTrend.AxisY2.MajorGridCount = 6;
            this.chart_HistoryTrend.AxisY2.MajorGridEnabled = true;
            this.chart_HistoryTrend.AxisY2.MajorGridType = SeeSharpTools.JY.GUI.StripChartXAxis.GridStyle.Dash;
            this.chart_HistoryTrend.AxisY2.Maximum = 3.5D;
            this.chart_HistoryTrend.AxisY2.Minimum = 0.5D;
            this.chart_HistoryTrend.AxisY2.MinorGridColor = System.Drawing.Color.Black;
            this.chart_HistoryTrend.AxisY2.MinorGridEnabled = false;
            this.chart_HistoryTrend.AxisY2.MinorGridType = SeeSharpTools.JY.GUI.StripChartXAxis.GridStyle.DashDot;
            this.chart_HistoryTrend.AxisY2.TickWidth = 1F;
            this.chart_HistoryTrend.AxisY2.Title = "";
            this.chart_HistoryTrend.AxisY2.TitleOrientation = SeeSharpTools.JY.GUI.StripChartXAxis.AxisTextOrientation.Auto;
            this.chart_HistoryTrend.AxisY2.TitlePosition = SeeSharpTools.JY.GUI.StripChartXAxis.AxisTextPosition.Center;
            this.chart_HistoryTrend.AxisY2.ViewMaximum = 3.5D;
            this.chart_HistoryTrend.AxisY2.ViewMinimum = 0.5D;
            this.chart_HistoryTrend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(28)))), ((int)(((byte)(68)))));
            this.chart_HistoryTrend.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.chart_HistoryTrend.ChartAreaBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(28)))), ((int)(((byte)(68)))));
            this.chart_HistoryTrend.Direction = SeeSharpTools.JY.GUI.StripChartX.ScrollDirection.LeftToRight;
            this.chart_HistoryTrend.DisplayPoints = 4000;
            this.chart_HistoryTrend.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.chart_HistoryTrend.ForeColor = System.Drawing.Color.White;
            this.chart_HistoryTrend.GradientStyle = SeeSharpTools.JY.GUI.StripChartX.ChartGradientStyle.None;
            this.chart_HistoryTrend.LegendBackColor = System.Drawing.Color.Transparent;
            this.chart_HistoryTrend.LegendFont = new System.Drawing.Font("微软雅黑", 11F);
            this.chart_HistoryTrend.LegendForeColor = System.Drawing.Color.White;
            this.chart_HistoryTrend.LegendVisible = true;
            stripChartXSeries3.Color = System.Drawing.Color.Red;
            stripChartXSeries3.Marker = SeeSharpTools.JY.GUI.StripChartXSeries.MarkerType.None;
            stripChartXSeries3.Name = "1#站点温度";
            stripChartXSeries3.Type = SeeSharpTools.JY.GUI.StripChartXSeries.LineType.FastLine;
            stripChartXSeries3.Visible = true;
            stripChartXSeries3.Width = SeeSharpTools.JY.GUI.StripChartXSeries.LineWidth.Thin;
            stripChartXSeries3.XPlotAxis = SeeSharpTools.JY.GUI.StripChartXAxis.PlotAxis.Primary;
            stripChartXSeries3.YPlotAxis = SeeSharpTools.JY.GUI.StripChartXAxis.PlotAxis.Primary;
            this.chart_HistoryTrend.LineSeries.Add(stripChartXSeries3);
            this.chart_HistoryTrend.Location = new System.Drawing.Point(12, 173);
            this.chart_HistoryTrend.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chart_HistoryTrend.Miscellaneous.CheckInfinity = false;
            this.chart_HistoryTrend.Miscellaneous.CheckNaN = false;
            this.chart_HistoryTrend.Miscellaneous.CheckNegtiveOrZero = false;
            this.chart_HistoryTrend.Miscellaneous.DirectionChartCount = 3;
            this.chart_HistoryTrend.Miscellaneous.Fitting = SeeSharpTools.JY.GUI.StripChartX.FitType.Range;
            this.chart_HistoryTrend.Miscellaneous.MaxSeriesCount = 32;
            this.chart_HistoryTrend.Miscellaneous.MaxSeriesPointCount = 4000;
            this.chart_HistoryTrend.Miscellaneous.SplitLayoutColumnInterval = 0F;
            this.chart_HistoryTrend.Miscellaneous.SplitLayoutDirection = SeeSharpTools.JY.GUI.StripChartXUtility.LayoutDirection.LeftToRight;
            this.chart_HistoryTrend.Miscellaneous.SplitLayoutRowInterval = 0F;
            this.chart_HistoryTrend.Miscellaneous.SplitViewAutoLayout = true;
            this.chart_HistoryTrend.Name = "chart_HistoryTrend";
            this.chart_HistoryTrend.NextTimeStamp = new System.DateTime(((long)(0)));
            this.chart_HistoryTrend.ScrollType = SeeSharpTools.JY.GUI.StripChartX.StripScrollType.Cumulation;
            this.chart_HistoryTrend.SeriesCount = 1;
            this.chart_HistoryTrend.Size = new System.Drawing.Size(1359, 537);
            this.chart_HistoryTrend.SplitView = false;
            this.chart_HistoryTrend.StartIndex = 0;
            this.chart_HistoryTrend.TabIndex = 29;
            this.chart_HistoryTrend.TimeInterval = System.TimeSpan.Parse("00:00:00");
            this.chart_HistoryTrend.TimeStampFormat = null;
            this.chart_HistoryTrend.XCursor.AutoInterval = true;
            this.chart_HistoryTrend.XCursor.Color = System.Drawing.Color.DeepSkyBlue;
            this.chart_HistoryTrend.XCursor.Interval = 0.001D;
            this.chart_HistoryTrend.XCursor.Mode = SeeSharpTools.JY.GUI.StripChartXCursor.CursorMode.Zoom;
            this.chart_HistoryTrend.XCursor.SelectionColor = System.Drawing.Color.LightGray;
            this.chart_HistoryTrend.XCursor.Value = double.NaN;
            this.chart_HistoryTrend.XDataType = SeeSharpTools.JY.GUI.StripChartX.XAxisDataType.Index;
            this.chart_HistoryTrend.YCursor.AutoInterval = true;
            this.chart_HistoryTrend.YCursor.Color = System.Drawing.Color.DeepSkyBlue;
            this.chart_HistoryTrend.YCursor.Interval = 0.001D;
            this.chart_HistoryTrend.YCursor.Mode = SeeSharpTools.JY.GUI.StripChartXCursor.CursorMode.Disabled;
            this.chart_HistoryTrend.YCursor.SelectionColor = System.Drawing.Color.LightGray;
            this.chart_HistoryTrend.YCursor.Value = double.NaN;
            // 
            // FrmHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MTHProject.Properties.Resources.BackGround;
            this.ClientSize = new System.Drawing.Size(1394, 736);
            this.Controls.Add(this.chart_HistoryTrend);
            this.Controls.Add(this.btn_ExportCSV);
            this.Controls.Add(this.btn_SaveImage);
            this.Controls.Add(this.btn_Quick);
            this.Controls.Add(this.btn_Query);
            this.Controls.Add(this.dtp_End);
            this.Controls.Add(this.dtp_Start);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelParam);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmHistory";
            this.Text = "历史趋势";
            this.panelParam.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelParam;
        private MTHControlLib.CheckBoxEx checkBoxEx6;
        private MTHControlLib.CheckBoxEx checkBoxEx12;
        private MTHControlLib.CheckBoxEx checkBoxEx2;
        private MTHControlLib.CheckBoxEx checkBoxEx11;
        private MTHControlLib.CheckBoxEx checkBoxEx5;
        private MTHControlLib.CheckBoxEx checkBoxEx8;
        private MTHControlLib.CheckBoxEx checkBoxEx1;
        private MTHControlLib.CheckBoxEx checkBoxEx7;
        private MTHControlLib.CheckBoxEx checkBoxEx3;
        private MTHControlLib.CheckBoxEx checkBoxEx10;
        private MTHControlLib.CheckBoxEx checkBoxEx9;
        private MTHControlLib.CheckBoxEx checkBoxEx4;
        private System.Windows.Forms.DateTimePicker dtp_End;
        private System.Windows.Forms.DateTimePicker dtp_Start;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_ExportCSV;
        private System.Windows.Forms.Button btn_SaveImage;
        private System.Windows.Forms.Button btn_Quick;
        private System.Windows.Forms.Button btn_Query;
        private SeeSharpTools.JY.GUI.StripChartX chart_HistoryTrend;
    }
}