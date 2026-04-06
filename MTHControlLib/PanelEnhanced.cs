using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MTHControlLib
{
    public partial class PanelEnhanced : Panel
    {
        public PanelEnhanced()
        {
            InitializeComponent();
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //重载基类的背景擦除方法

            //解决窗体刷新，放大和闪烁
            return;
        }
        protected override void OnPaint(PaintEventArgs e)
        { 
            
            this.DoubleBuffered = true;//使用双缓冲
            if (this.BackgroundImage != null)
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;//抗锯齿
                e.Graphics.DrawImage(this.BackgroundImage, new Rectangle(0, 0, this.Width, this.Height), 0, 0, this.BackgroundImage.Width, this.BackgroundImage.Height, GraphicsUnit.Pixel);//绘制图像
            }
            base.OnPaint(e);
        }
    }
}
