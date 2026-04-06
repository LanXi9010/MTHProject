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
    //设置点击控件出现的默认事件，自定义控件同窗体一样，默认出现的是Load事件
    [DefaultEvent("Click")]
    public partial class NaviButton : UserControl
    {
        
        public NaviButton()
        {
            InitializeComponent();
        }
        private bool isSelected = false;//这里要与UI一致
        [Browsable(true)]//可浏览的
        [Category("自定义属性")]//类别
        [Description("设置或显示导航按钮是否选中")]//属性作用描述
        public bool IsSelected
        {
            get { return isSelected; }
            set {
                isSelected = value;
            UpdateImage(); }

        }
        private bool isLeft = true;//这里要与UI一致
        [Browsable(true)]//可浏览的
        [Category("自定义属性")]//类别
        [Description("设置或显示导航按钮是否为左边")]//属性作用描述
        public bool IsLeft
        {
            get { return isLeft; }
            set { isLeft = value;
                UpdateImage();
            }
        }
        private string titleName = "导航按钮";
        [Browsable(true)]//可浏览的
        [Category("自定义属性")]//类别
        [Description("设置或显示导航按钮文本内容")]//属性作用描述
        public string TitleName
        {
            get { return titleName; }
            set { titleName = value;
            lbl_Title.Text = titleName;
            }
        }
        /// <summary>
        /// 更新Image
        /// </summary>
        private void UpdateImage()
        {
            if (IsLeft)
            {
                BackgroundImage = isSelected ? Properties.Resources.LeftSelected : Properties.Resources.LeftUnSelected;
            }
            else 
            {
                BackgroundImage= isSelected ? Properties.Resources.RightSelected :Properties.Resources.RightUnSelected;
            }
        }
        [Browsable(true)]//可浏览的
        [Category("自定义事件")]//类别
        [Description("设置导航按钮的事件")]//事件作用描述
        
        public new EventHandler Click; 
        //Label覆盖在Button上，用Label的事件传递到Button事件，点击Label即点击Button
        private void lbl_Title_Click(object sender, EventArgs e)
        {
            this.Click(this, e);   
        }
    }
}
