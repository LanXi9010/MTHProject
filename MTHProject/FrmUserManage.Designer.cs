namespace MTHProject
{
    partial class FrmUserManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUserManage));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txt_LoginName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.title1 = new MTHControlLib.Title();
            this.txt_LoginPwd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_LoginPwd2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_SelectAll = new System.Windows.Forms.Button();
            this.chk_HistoryTrend = new System.Windows.Forms.CheckBox();
            this.chk_UserManage = new System.Windows.Forms.CheckBox();
            this.chk_HistoryLog = new System.Windows.Forms.CheckBox();
            this.chk_Recipe = new System.Windows.Forms.CheckBox();
            this.chk_ParamSet = new System.Windows.Forms.CheckBox();
            this.title2 = new MTHControlLib.Title();
            this.dgv_UserManage = new System.Windows.Forms.DataGridView();
            this.LoginName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoginPwd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ParamSet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Recipe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HistoryLog = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HistoryTrend = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserManage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoginId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_Modify = new System.Windows.Forms.Button();
            this.btn_Add = new System.Windows.Forms.Button();
            this.title3 = new MTHControlLib.Title();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_UserManage)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_LoginName
            // 
            this.txt_LoginName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(29)))), ((int)(((byte)(85)))));
            this.txt_LoginName.Font = new System.Drawing.Font("微软雅黑", 12.5F, System.Drawing.FontStyle.Bold);
            this.txt_LoginName.ForeColor = System.Drawing.Color.White;
            this.txt_LoginName.Location = new System.Drawing.Point(109, 73);
            this.txt_LoginName.Name = "txt_LoginName";
            this.txt_LoginName.Size = new System.Drawing.Size(149, 40);
            this.txt_LoginName.TabIndex = 7;
            this.txt_LoginName.Text = "Admin";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 12.25F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(21, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 32);
            this.label5.TabIndex = 6;
            this.label5.Text = "用户名称:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // title1
            // 
            this.title1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(30)))), ((int)(((byte)(78)))));
            this.title1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("title1.BackgroundImage")));
            this.title1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.title1.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.title1.Location = new System.Drawing.Point(27, 9);
            this.title1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.title1.Name = "title1";
            this.title1.Size = new System.Drawing.Size(154, 43);
            this.title1.TabIndex = 8;
            this.title1.TitleName = "用户管理";
            // 
            // txt_LoginPwd
            // 
            this.txt_LoginPwd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(29)))), ((int)(((byte)(85)))));
            this.txt_LoginPwd.Font = new System.Drawing.Font("微软雅黑", 12.5F, System.Drawing.FontStyle.Bold);
            this.txt_LoginPwd.ForeColor = System.Drawing.Color.White;
            this.txt_LoginPwd.Location = new System.Drawing.Point(109, 131);
            this.txt_LoginPwd.Name = "txt_LoginPwd";
            this.txt_LoginPwd.PasswordChar = '*';
            this.txt_LoginPwd.Size = new System.Drawing.Size(149, 40);
            this.txt_LoginPwd.TabIndex = 10;
            this.txt_LoginPwd.Text = "123";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12.25F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(21, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 32);
            this.label1.TabIndex = 9;
            this.label1.Text = "用户密码:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_LoginPwd2
            // 
            this.txt_LoginPwd2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(29)))), ((int)(((byte)(85)))));
            this.txt_LoginPwd2.Font = new System.Drawing.Font("微软雅黑", 12.5F, System.Drawing.FontStyle.Bold);
            this.txt_LoginPwd2.ForeColor = System.Drawing.Color.White;
            this.txt_LoginPwd2.Location = new System.Drawing.Point(109, 191);
            this.txt_LoginPwd2.Name = "txt_LoginPwd2";
            this.txt_LoginPwd2.PasswordChar = '*';
            this.txt_LoginPwd2.Size = new System.Drawing.Size(149, 40);
            this.txt_LoginPwd2.TabIndex = 12;
            this.txt_LoginPwd2.Text = "123";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12.25F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(21, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 32);
            this.label2.TabIndex = 11;
            this.label2.Text = "确认密码:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_SelectAll
            // 
            this.btn_SelectAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(27)))), ((int)(((byte)(78)))));
            this.btn_SelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SelectAll.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_SelectAll.ForeColor = System.Drawing.Color.White;
            this.btn_SelectAll.Location = new System.Drawing.Point(168, 441);
            this.btn_SelectAll.Name = "btn_SelectAll";
            this.btn_SelectAll.Size = new System.Drawing.Size(105, 42);
            this.btn_SelectAll.TabIndex = 29;
            this.btn_SelectAll.Text = "全选/全不选";
            this.btn_SelectAll.UseVisualStyleBackColor = false;
            this.btn_SelectAll.Click += new System.EventHandler(this.btn_SelectAll_Click);
            // 
            // chk_HistoryTrend
            // 
            this.chk_HistoryTrend.BackColor = System.Drawing.Color.Transparent;
            this.chk_HistoryTrend.Checked = true;
            this.chk_HistoryTrend.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_HistoryTrend.Font = new System.Drawing.Font("微软雅黑", 11.5F);
            this.chk_HistoryTrend.ForeColor = System.Drawing.Color.White;
            this.chk_HistoryTrend.Location = new System.Drawing.Point(168, 378);
            this.chk_HistoryTrend.Name = "chk_HistoryTrend";
            this.chk_HistoryTrend.Size = new System.Drawing.Size(105, 39);
            this.chk_HistoryTrend.TabIndex = 24;
            this.chk_HistoryTrend.Text = "历史曲线";
            this.chk_HistoryTrend.UseVisualStyleBackColor = false;
            // 
            // chk_UserManage
            // 
            this.chk_UserManage.BackColor = System.Drawing.Color.Transparent;
            this.chk_UserManage.Checked = true;
            this.chk_UserManage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_UserManage.Font = new System.Drawing.Font("微软雅黑", 11.5F);
            this.chk_UserManage.ForeColor = System.Drawing.Color.White;
            this.chk_UserManage.Location = new System.Drawing.Point(40, 444);
            this.chk_UserManage.Name = "chk_UserManage";
            this.chk_UserManage.Size = new System.Drawing.Size(105, 39);
            this.chk_UserManage.TabIndex = 25;
            this.chk_UserManage.Text = "用户管理";
            this.chk_UserManage.UseVisualStyleBackColor = false;
            // 
            // chk_HistoryLog
            // 
            this.chk_HistoryLog.BackColor = System.Drawing.Color.Transparent;
            this.chk_HistoryLog.Checked = true;
            this.chk_HistoryLog.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_HistoryLog.Font = new System.Drawing.Font("微软雅黑", 11.5F);
            this.chk_HistoryLog.ForeColor = System.Drawing.Color.White;
            this.chk_HistoryLog.Location = new System.Drawing.Point(40, 378);
            this.chk_HistoryLog.Name = "chk_HistoryLog";
            this.chk_HistoryLog.Size = new System.Drawing.Size(105, 39);
            this.chk_HistoryLog.TabIndex = 26;
            this.chk_HistoryLog.Text = "报警追溯";
            this.chk_HistoryLog.UseVisualStyleBackColor = false;
            // 
            // chk_Recipe
            // 
            this.chk_Recipe.BackColor = System.Drawing.Color.Transparent;
            this.chk_Recipe.Checked = true;
            this.chk_Recipe.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_Recipe.Font = new System.Drawing.Font("微软雅黑", 11.5F);
            this.chk_Recipe.ForeColor = System.Drawing.Color.White;
            this.chk_Recipe.Location = new System.Drawing.Point(168, 314);
            this.chk_Recipe.Name = "chk_Recipe";
            this.chk_Recipe.Size = new System.Drawing.Size(105, 39);
            this.chk_Recipe.TabIndex = 27;
            this.chk_Recipe.Text = "配方管理";
            this.chk_Recipe.UseVisualStyleBackColor = false;
            // 
            // chk_ParamSet
            // 
            this.chk_ParamSet.BackColor = System.Drawing.Color.Transparent;
            this.chk_ParamSet.Checked = true;
            this.chk_ParamSet.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_ParamSet.Font = new System.Drawing.Font("微软雅黑", 11.5F);
            this.chk_ParamSet.ForeColor = System.Drawing.Color.White;
            this.chk_ParamSet.Location = new System.Drawing.Point(40, 314);
            this.chk_ParamSet.Name = "chk_ParamSet";
            this.chk_ParamSet.Size = new System.Drawing.Size(105, 39);
            this.chk_ParamSet.TabIndex = 28;
            this.chk_ParamSet.Text = "参数设置";
            this.chk_ParamSet.UseVisualStyleBackColor = false;
            // 
            // title2
            // 
            this.title2.BackColor = System.Drawing.Color.Transparent;
            this.title2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("title2.BackgroundImage")));
            this.title2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.title2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.title2.Location = new System.Drawing.Point(27, 266);
            this.title2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.title2.Name = "title2";
            this.title2.Size = new System.Drawing.Size(109, 31);
            this.title2.TabIndex = 23;
            this.title2.TitleName = "权限配置";
            // 
            // dgv_UserManage
            // 
            this.dgv_UserManage.AllowUserToAddRows = false;
            this.dgv_UserManage.AllowUserToDeleteRows = false;
            this.dgv_UserManage.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(30)))), ((int)(((byte)(78)))));
            this.dgv_UserManage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_UserManage.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(30)))), ((int)(((byte)(78)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_UserManage.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_UserManage.ColumnHeadersHeight = 45;
            this.dgv_UserManage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_UserManage.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LoginName,
            this.LoginPwd,
            this.ParamSet,
            this.Recipe,
            this.HistoryLog,
            this.HistoryTrend,
            this.UserManage,
            this.LoginId});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(40)))), ((int)(((byte)(86)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_UserManage.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_UserManage.EnableHeadersVisualStyles = false;
            this.dgv_UserManage.Location = new System.Drawing.Point(297, 20);
            this.dgv_UserManage.Name = "dgv_UserManage";
            this.dgv_UserManage.ReadOnly = true;
            this.dgv_UserManage.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(40)))), ((int)(((byte)(86)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(40)))), ((int)(((byte)(86)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_UserManage.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_UserManage.RowHeadersWidth = 55;
            this.dgv_UserManage.RowTemplate.Height = 40;
            this.dgv_UserManage.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_UserManage.ShowCellErrors = false;
            this.dgv_UserManage.Size = new System.Drawing.Size(1079, 697);
            this.dgv_UserManage.TabIndex = 35;
            this.dgv_UserManage.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_UserManage_CellClick);
            this.dgv_UserManage.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_UserManage_CellFormatting);
            this.dgv_UserManage.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_UserManage_RowPostPaint);
            // 
            // LoginName
            // 
            this.LoginName.DataPropertyName = "LoginName";
            this.LoginName.HeaderText = "用户名";
            this.LoginName.MinimumWidth = 6;
            this.LoginName.Name = "LoginName";
            this.LoginName.ReadOnly = true;
            this.LoginName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.LoginName.Width = 170;
            // 
            // LoginPwd
            // 
            this.LoginPwd.DataPropertyName = "LoginPwd";
            this.LoginPwd.HeaderText = "用户密码";
            this.LoginPwd.MinimumWidth = 6;
            this.LoginPwd.Name = "LoginPwd";
            this.LoginPwd.ReadOnly = true;
            this.LoginPwd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.LoginPwd.Width = 130;
            // 
            // ParamSet
            // 
            this.ParamSet.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ParamSet.DataPropertyName = "ParamSet";
            this.ParamSet.HeaderText = "参数设置";
            this.ParamSet.MinimumWidth = 6;
            this.ParamSet.Name = "ParamSet";
            this.ParamSet.ReadOnly = true;
            this.ParamSet.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Recipe
            // 
            this.Recipe.DataPropertyName = "Recipe";
            this.Recipe.HeaderText = "配方管理";
            this.Recipe.MinimumWidth = 6;
            this.Recipe.Name = "Recipe";
            this.Recipe.ReadOnly = true;
            this.Recipe.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Recipe.Width = 130;
            // 
            // HistoryLog
            // 
            this.HistoryLog.DataPropertyName = "HistoryLog";
            this.HistoryLog.HeaderText = "报警追溯";
            this.HistoryLog.MinimumWidth = 6;
            this.HistoryLog.Name = "HistoryLog";
            this.HistoryLog.ReadOnly = true;
            this.HistoryLog.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.HistoryLog.Width = 130;
            // 
            // HistoryTrend
            // 
            this.HistoryTrend.DataPropertyName = "HistoryTrend";
            this.HistoryTrend.HeaderText = "历史趋势";
            this.HistoryTrend.MinimumWidth = 6;
            this.HistoryTrend.Name = "HistoryTrend";
            this.HistoryTrend.ReadOnly = true;
            this.HistoryTrend.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.HistoryTrend.Width = 130;
            // 
            // UserManage
            // 
            this.UserManage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.UserManage.DataPropertyName = "UserManage";
            this.UserManage.HeaderText = "用户管理";
            this.UserManage.MinimumWidth = 6;
            this.UserManage.Name = "UserManage";
            this.UserManage.ReadOnly = true;
            this.UserManage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // LoginId
            // 
            this.LoginId.DataPropertyName = "LoginId";
            this.LoginId.HeaderText = "用户ID";
            this.LoginId.MinimumWidth = 6;
            this.LoginId.Name = "LoginId";
            this.LoginId.ReadOnly = true;
            this.LoginId.Visible = false;
            this.LoginId.Width = 125;
            // 
            // btn_Clear
            // 
            this.btn_Clear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(27)))), ((int)(((byte)(78)))));
            this.btn_Clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Clear.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Clear.ForeColor = System.Drawing.Color.White;
            this.btn_Clear.Location = new System.Drawing.Point(163, 662);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(105, 42);
            this.btn_Clear.TabIndex = 31;
            this.btn_Clear.Text = "清空信息";
            this.btn_Clear.UseVisualStyleBackColor = false;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(27)))), ((int)(((byte)(78)))));
            this.btn_Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Delete.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Delete.ForeColor = System.Drawing.Color.White;
            this.btn_Delete.Location = new System.Drawing.Point(22, 662);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(105, 42);
            this.btn_Delete.TabIndex = 32;
            this.btn_Delete.Text = "删除用户";
            this.btn_Delete.UseVisualStyleBackColor = false;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_Modify
            // 
            this.btn_Modify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(27)))), ((int)(((byte)(78)))));
            this.btn_Modify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Modify.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Modify.ForeColor = System.Drawing.Color.White;
            this.btn_Modify.Location = new System.Drawing.Point(163, 589);
            this.btn_Modify.Name = "btn_Modify";
            this.btn_Modify.Size = new System.Drawing.Size(105, 42);
            this.btn_Modify.TabIndex = 33;
            this.btn_Modify.Text = "修改用户";
            this.btn_Modify.UseVisualStyleBackColor = false;
            this.btn_Modify.Click += new System.EventHandler(this.btn_Modify_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(27)))), ((int)(((byte)(78)))));
            this.btn_Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Add.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Add.ForeColor = System.Drawing.Color.White;
            this.btn_Add.Location = new System.Drawing.Point(22, 589);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(105, 42);
            this.btn_Add.TabIndex = 34;
            this.btn_Add.Text = "添加用户";
            this.btn_Add.UseVisualStyleBackColor = false;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // title3
            // 
            this.title3.BackColor = System.Drawing.Color.Transparent;
            this.title3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("title3.BackgroundImage")));
            this.title3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.title3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.title3.Location = new System.Drawing.Point(18, 537);
            this.title3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.title3.Name = "title3";
            this.title3.Size = new System.Drawing.Size(109, 31);
            this.title3.TabIndex = 30;
            this.title3.TitleName = "用户操作";
            // 
            // FrmUserManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MTHProject.Properties.Resources.BackGround;
            this.ClientSize = new System.Drawing.Size(1394, 736);
            this.Controls.Add(this.dgv_UserManage);
            this.Controls.Add(this.btn_Clear);
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.btn_Modify);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.title3);
            this.Controls.Add(this.btn_SelectAll);
            this.Controls.Add(this.chk_HistoryTrend);
            this.Controls.Add(this.chk_UserManage);
            this.Controls.Add(this.chk_HistoryLog);
            this.Controls.Add(this.chk_Recipe);
            this.Controls.Add(this.chk_ParamSet);
            this.Controls.Add(this.title2);
            this.Controls.Add(this.txt_LoginPwd2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_LoginPwd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.title1);
            this.Controls.Add(this.txt_LoginName);
            this.Controls.Add(this.label5);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmUserManage";
            this.Text = "用户管理";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_UserManage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_LoginName;
        private System.Windows.Forms.Label label5;
        private MTHControlLib.Title title1;
        private System.Windows.Forms.TextBox txt_LoginPwd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_LoginPwd2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_SelectAll;
        private System.Windows.Forms.CheckBox chk_HistoryTrend;
        private System.Windows.Forms.CheckBox chk_UserManage;
        private System.Windows.Forms.CheckBox chk_HistoryLog;
        private System.Windows.Forms.CheckBox chk_Recipe;
        private System.Windows.Forms.CheckBox chk_ParamSet;
        private MTHControlLib.Title title2;
        private System.Windows.Forms.DataGridView dgv_UserManage;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoginName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoginPwd;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParamSet;
        private System.Windows.Forms.DataGridViewTextBoxColumn Recipe;
        private System.Windows.Forms.DataGridViewTextBoxColumn HistoryLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn HistoryTrend;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserManage;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoginId;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btn_Modify;
        private System.Windows.Forms.Button btn_Add;
        private MTHControlLib.Title title3;
    }
}