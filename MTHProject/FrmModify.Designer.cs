namespace MTHProject
{
    partial class FrmModify
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
            this.panelMain = new MTHControlLib.PanelEnhanced();
            this.panelEx1 = new MTHControlLib.PanelEx();
            this.panelEx2 = new MTHControlLib.PanelEx();
            this.btn_Close = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_Canel = new System.Windows.Forms.Button();
            this.btn_Sure = new System.Windows.Forms.Button();
            this.tbk_Modify = new System.Windows.Forms.TextBox();
            this.lbl_CurrentValue = new System.Windows.Forms.Label();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_TitleN = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.panelEx1.SuspendLayout();
            this.panelEx2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.SystemColors.Control;
            this.panelMain.BackgroundImage = global::MTHProject.Properties.Resources.BackGround;
            this.panelMain.Controls.Add(this.panelEx1);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.ForeColor = System.Drawing.Color.White;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(559, 426);
            this.panelMain.TabIndex = 0;
            // 
            // panelEx1
            // 
            this.panelEx1.BackColor = System.Drawing.Color.Transparent;
            this.panelEx1.BackgroundImage = global::MTHProject.Properties.Resources.BackGround;
            this.panelEx1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panelEx1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(79)))), ((int)(((byte)(150)))));
            this.panelEx1.BorderWidth = 2;
            this.panelEx1.BottomGap = 1;
            this.panelEx1.Controls.Add(this.panelEx2);
            this.panelEx1.Controls.Add(this.btn_Canel);
            this.panelEx1.Controls.Add(this.btn_Sure);
            this.panelEx1.Controls.Add(this.tbk_Modify);
            this.panelEx1.Controls.Add(this.lbl_CurrentValue);
            this.panelEx1.Controls.Add(this.lbl_Title);
            this.panelEx1.Controls.Add(this.label3);
            this.panelEx1.Controls.Add(this.label1);
            this.panelEx1.Controls.Add(this.lbl_TitleN);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Font = new System.Drawing.Font("微软雅黑", 11.5F);
            this.panelEx1.LeftGap = 1;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.RightGap = 1;
            this.panelEx1.Size = new System.Drawing.Size(559, 426);
            this.panelEx1.TabIndex = 0;
            this.panelEx1.TopGap = 1;
            // 
            // panelEx2
            // 
            this.panelEx2.BorderColor = System.Drawing.Color.Empty;
            this.panelEx2.BorderWidth = 2;
            this.panelEx2.BottomGap = 1;
            this.panelEx2.Controls.Add(this.btn_Close);
            this.panelEx2.Controls.Add(this.label4);
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx2.LeftGap = 1;
            this.panelEx2.Location = new System.Drawing.Point(0, 0);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.RightGap = 1;
            this.panelEx2.Size = new System.Drawing.Size(559, 71);
            this.panelEx2.TabIndex = 5;
            this.panelEx2.TopGap = 1;
            // 
            // btn_Close
            // 
            this.btn_Close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.ForeColor = System.Drawing.Color.White;
            this.btn_Close.Location = new System.Drawing.Point(491, 10);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(56, 55);
            this.btn_Close.TabIndex = 1;
            this.btn_Close.Text = "X";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(21, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 37);
            this.label4.TabIndex = 0;
            this.label4.Text = "参数设置";
            // 
            // btn_Canel
            // 
            this.btn_Canel.BackgroundImage = global::MTHProject.Properties.Resources.bg;
            this.btn_Canel.Location = new System.Drawing.Point(313, 303);
            this.btn_Canel.Name = "btn_Canel";
            this.btn_Canel.Size = new System.Drawing.Size(132, 53);
            this.btn_Canel.TabIndex = 2;
            this.btn_Canel.Text = "取消";
            this.btn_Canel.UseVisualStyleBackColor = true;
            this.btn_Canel.Click += new System.EventHandler(this.btn_Canel_Click);
            // 
            // btn_Sure
            // 
            this.btn_Sure.BackgroundImage = global::MTHProject.Properties.Resources.bg;
            this.btn_Sure.Location = new System.Drawing.Point(77, 303);
            this.btn_Sure.Name = "btn_Sure";
            this.btn_Sure.Size = new System.Drawing.Size(132, 53);
            this.btn_Sure.TabIndex = 1;
            this.btn_Sure.Text = "确定";
            this.btn_Sure.UseVisualStyleBackColor = true;
            this.btn_Sure.Click += new System.EventHandler(this.btn_SureFunc);
            // 
            // tbk_Modify
            // 
            this.tbk_Modify.Location = new System.Drawing.Point(254, 243);
            this.tbk_Modify.Name = "tbk_Modify";
            this.tbk_Modify.Size = new System.Drawing.Size(167, 38);
            this.tbk_Modify.TabIndex = 0;
            this.tbk_Modify.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbk_Modify_KeyDown);
            // 
            // lbl_CurrentValue
            // 
            this.lbl_CurrentValue.AutoSize = true;
            this.lbl_CurrentValue.Location = new System.Drawing.Point(308, 164);
            this.lbl_CurrentValue.Name = "lbl_CurrentValue";
            this.lbl_CurrentValue.Size = new System.Drawing.Size(45, 30);
            this.lbl_CurrentValue.TabIndex = 2;
            this.lbl_CurrentValue.Text = "0.0";
            // 
            // lbl_Title
            // 
            this.lbl_Title.AutoSize = true;
            this.lbl_Title.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Title.Location = new System.Drawing.Point(248, 89);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(188, 31);
            this.lbl_Title.TabIndex = 1;
            this.lbl_Title.Text = "1#站点温度高限";
            this.lbl_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(82, 238);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 43);
            this.label3.TabIndex = 0;
            this.label3.Text = "修改值:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(91, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 43);
            this.label1.TabIndex = 0;
            this.label1.Text = "当前值：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_TitleN
            // 
            this.lbl_TitleN.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_TitleN.Location = new System.Drawing.Point(91, 83);
            this.lbl_TitleN.Name = "lbl_TitleN";
            this.lbl_TitleN.Size = new System.Drawing.Size(138, 43);
            this.lbl_TitleN.TabIndex = 0;
            this.lbl_TitleN.Text = "参数名称:";
            this.lbl_TitleN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmModify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(559, 426);
            this.Controls.Add(this.panelMain);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FrmModify";
            this.Text = "修改数据";
            this.panelMain.ResumeLayout(false);
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            this.panelEx2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MTHControlLib.PanelEnhanced panelMain;
        private MTHControlLib.PanelEx panelEx1;
        private System.Windows.Forms.Label lbl_TitleN;
        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_CurrentValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_Sure;
        private System.Windows.Forms.TextBox tbk_Modify;
        private System.Windows.Forms.Button btn_Canel;
        private MTHControlLib.PanelEx panelEx2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_Close;
    }
}