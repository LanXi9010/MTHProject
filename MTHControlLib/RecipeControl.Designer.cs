namespace MTHControlLib
{
    partial class RecipeControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecipeControl));
            this.checkBoxEx2 = new MTHControlLib.CheckBoxEx();
            this.checkBoxEx1 = new MTHControlLib.CheckBoxEx();
            this.textSetEx4 = new MTHControlLib.TextSetEx();
            this.textSetEx3 = new MTHControlLib.TextSetEx();
            this.textSetEx2 = new MTHControlLib.TextSetEx();
            this.textSetEx1 = new MTHControlLib.TextSetEx();
            this.title1 = new MTHControlLib.Title();
            this.SuspendLayout();
            // 
            // checkBoxEx2
            // 
            this.checkBoxEx2.CheckBackColor = System.Drawing.Color.White;
            this.checkBoxEx2.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.checkBoxEx2.DefaultCheckButtonWidth = 20;
            this.checkBoxEx2.ForeColor = System.Drawing.Color.White;
            this.checkBoxEx2.Location = new System.Drawing.Point(180, 282);
            this.checkBoxEx2.Name = "checkBoxEx2";
            this.checkBoxEx2.Size = new System.Drawing.Size(164, 56);
            this.checkBoxEx2.TabIndex = 5;
            this.checkBoxEx2.Text = "湿度报警启用";
            this.checkBoxEx2.UseVisualStyleBackColor = true;
            // 
            // checkBoxEx1
            // 
            this.checkBoxEx1.CheckBackColor = System.Drawing.Color.White;
            this.checkBoxEx1.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.checkBoxEx1.DefaultCheckButtonWidth = 20;
            this.checkBoxEx1.ForeColor = System.Drawing.Color.White;
            this.checkBoxEx1.Location = new System.Drawing.Point(3, 282);
            this.checkBoxEx1.Name = "checkBoxEx1";
            this.checkBoxEx1.Size = new System.Drawing.Size(164, 56);
            this.checkBoxEx1.TabIndex = 5;
            this.checkBoxEx1.Text = "温度报警启用";
            this.checkBoxEx1.UseVisualStyleBackColor = true;
            // 
            // textSetEx4
            // 
            this.textSetEx4.CurrentValue = 0F;
            this.textSetEx4.Location = new System.Drawing.Point(8, 212);
            this.textSetEx4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textSetEx4.Name = "textSetEx4";
            this.textSetEx4.Size = new System.Drawing.Size(347, 51);
            this.textSetEx4.TabIndex = 4;
            this.textSetEx4.TitleName = "1#站点湿度的低限";
            this.textSetEx4.Unit = "%";
            // 
            // textSetEx3
            // 
            this.textSetEx3.CurrentValue = 0F;
            this.textSetEx3.Location = new System.Drawing.Point(9, 160);
            this.textSetEx3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textSetEx3.Name = "textSetEx3";
            this.textSetEx3.Size = new System.Drawing.Size(347, 51);
            this.textSetEx3.TabIndex = 3;
            this.textSetEx3.TitleName = "1#站点湿度的高限";
            this.textSetEx3.Unit = "%";
            // 
            // textSetEx2
            // 
            this.textSetEx2.CurrentValue = 0F;
            this.textSetEx2.Location = new System.Drawing.Point(9, 108);
            this.textSetEx2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textSetEx2.Name = "textSetEx2";
            this.textSetEx2.Size = new System.Drawing.Size(347, 51);
            this.textSetEx2.TabIndex = 2;
            this.textSetEx2.TitleName = "1#站点温度的低限";
            this.textSetEx2.Unit = "C";
            // 
            // textSetEx1
            // 
            this.textSetEx1.CurrentValue = 0F;
            this.textSetEx1.Location = new System.Drawing.Point(9, 58);
            this.textSetEx1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textSetEx1.Name = "textSetEx1";
            this.textSetEx1.Size = new System.Drawing.Size(347, 51);
            this.textSetEx1.TabIndex = 1;
            this.textSetEx1.TitleName = "1#站点温度的高限";
            this.textSetEx1.Unit = "C";
            // 
            // title1
            // 
            this.title1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(30)))), ((int)(((byte)(78)))));
            this.title1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("title1.BackgroundImage")));
            this.title1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.title1.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.title1.Location = new System.Drawing.Point(9, 5);
            this.title1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.title1.Name = "title1";
            this.title1.Size = new System.Drawing.Size(91, 43);
            this.title1.TabIndex = 0;
            this.title1.TitleName = "1#站点";
            // 
            // RecipeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(39)))), ((int)(((byte)(104)))));
            this.Controls.Add(this.checkBoxEx2);
            this.Controls.Add(this.checkBoxEx1);
            this.Controls.Add(this.textSetEx4);
            this.Controls.Add(this.textSetEx3);
            this.Controls.Add(this.textSetEx2);
            this.Controls.Add(this.textSetEx1);
            this.Controls.Add(this.title1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "RecipeControl";
            this.Size = new System.Drawing.Size(347, 353);
            this.ResumeLayout(false);

        }

        #endregion

        private Title title1;
        private TextSetEx textSetEx1;
        private TextSetEx textSetEx2;
        private TextSetEx textSetEx3;
        private TextSetEx textSetEx4;
        private CheckBoxEx checkBoxEx1;
        private CheckBoxEx checkBoxEx2;
    }
}
