using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MTHControlLib
{
    public partial class PanelEx : Panel    
    {
        //Invalidate函数是让修改立即生效
        public PanelEx()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint,true);//仅在Windows处理期间绘制
            SetStyle(ControlStyles.DoubleBuffer, true);//先在内存中绘制，而不是一笔一笔的绘制的屏幕上
            SetStyle(ControlStyles.ResizeRedraw, true);//空间大小改变，自动重绘
            SetStyle(ControlStyles.Selectable, true);//支持接入设备焦点，如Tab键
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);//设置为透明色
        }
        [Browsable(true)]//可浏览的
        [Category("自定义属性")]//类别
        [Description("设置或显示上面间隙")]//属性作用描述
        private int topGap=1;
        public int TopGap
        {
            get { return topGap; }
            set { topGap = value; Invalidate(); }
        }
        [Browsable(true)]//可浏览的
        [Category("自定义属性")]//类别
        [Description("设置或显示底面间隙")]//属性作用描述
        private int bottomGap = 1;

        public int BottomGap
        {
            get { return bottomGap; }
            set { bottomGap = value; Invalidate(); }
        }
        [Browsable(true)]//可浏览的
        [Category("自定义属性")]//类别
        [Description("设置或显示左边间隙")]//属性作用描述
        private int leftGap=1;

        public int LeftGap
        {
            get { return leftGap; }
            set { leftGap = value; Invalidate(); }
        }
        [Browsable(true)]//可浏览的
        [Category("自定义属性")]//类别
        [Description("设置或显示右面间隙")]//属性作用描述
        private int rightGap=1;

        public int RightGap 
        {
            get { return rightGap; }
            set { rightGap = value; Invalidate(); }
        }
        [Browsable(true)]//可浏览的
        [Category("自定义属性")]//类别
        [Description("设置或显示边界的宽度")]//属性作用描述
        private int borderWidth=2;

        public int BorderWidth
        {
            get { return borderWidth; }
            set { borderWidth = value; Invalidate(); }
        }
        [Browsable(true)]//可浏览的
        [Category("自定义属性")]//类别
        [Description("设置或显示边界的颜色")]//属性作用描述
        private Color borderColor;

        public Color BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; Invalidate(); }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graphics = e.Graphics;
            Pen pen = new Pen(borderColor,BorderWidth);
            float x = leftGap + BorderWidth *0.5f ;//这样做的目的是让边框的 ​​中心线​​ 对齐控件的边缘
                                                  //（而不是边框的外边缘对齐），从而实现更精确的绘制。
            float y = topGap + BorderWidth *0.5f;
            float width=this.Width-leftGap-rightGap-borderWidth;//这样计算出的 width 和 height
                                                                //是 ​​矩形内部的实际可用区域​​（减去边框和边距后的部分）。
            float height=this.Height-topGap-bottomGap-borderWidth;
            graphics.DrawRectangle(pen,x,y,width,height);
        }
    }
}
