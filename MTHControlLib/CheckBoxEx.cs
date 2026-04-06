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
    public partial class CheckBoxEx : CheckBox
    {
        public CheckBoxEx()
        {
            InitializeComponent();
            stringFormat.LineAlignment = StringAlignment.Center;
            stringFormat.Alignment = StringAlignment.Center;

            //设置控件样式
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }
        StringFormat stringFormat=new StringFormat();
        private int defaultCheckButtonWidth=20;//默认确认框是正方形的
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或显示选中框的高度")]
        public int DefaultCheckButtonWidth
        {
            get { return defaultCheckButtonWidth; }
            set
            {
                defaultCheckButtonWidth = value;
                this.Invalidate();
            }
        }
        private Color checkColor = Color.FromArgb(3, 25, 66);
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或显示选中颜色")]
        public Color CheckColor
        {
            get { return checkColor; }
            set
            {
                checkColor = value;
                this.Invalidate();
            }
        }
        private Color checkBackColor = Color.White;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或显示选中框背景颜色")]
        public Color CheckBackColor
        {
            get { return checkBackColor; }
            set
            {
                checkBackColor = value;
                this.Invalidate();
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            base.OnPaintBackground(e);
            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            Rectangle checkRec;
            Rectangle textRec;
            CalculatorRec(out checkRec, out textRec);
            SolidBrush solidBrush = new SolidBrush(checkBackColor);
            graphics.FillRectangle(solidBrush, checkRec);//画实心矩形
            Pen pen = new Pen(Color.LightGray);
            graphics.DrawRectangle(pen, checkRec);//画虚心边框
            if (this.CheckState == CheckState.Checked)//如果已经处于勾选状态
            {
                DrawCheckedFlag(graphics, checkRec, checkColor);
            }
            graphics.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), //画文本
                textRec, this.stringFormat);
        }
        private void CalculatorRec(out Rectangle checkRec, out Rectangle textRec)
        {
            checkRec=new Rectangle(3,(this.Height-defaultCheckButtonWidth)/2,defaultCheckButtonWidth,defaultCheckButtonWidth);
            textRec = new Rectangle(checkRec.Right+3,0,Width-checkRec.Right-6,this.Height);
        }
        private void DrawCheckedFlag(Graphics graphics, Rectangle rectangle, Color color)
        {
            PointF[] pointFs = new PointF[3];

            pointFs[0] = new PointF(rectangle.X + rectangle.Width / 4.5f, rectangle.Y + rectangle.Height / 2.5f);
            pointFs[1] = new PointF(rectangle.X + rectangle.Width / 2.5f, rectangle.Bottom - rectangle.Height / 3.0f);
            pointFs[2] = new PointF(rectangle.Right - rectangle.Width / 4.0f, rectangle.Y + rectangle.Height / 4.5f);

            Pen pen = new Pen(color, 2.0f);
            graphics.DrawLines(pen, pointFs);
        }

    }
}
