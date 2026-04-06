using MTHModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace MTHControlLib
{
    public partial class RecipeControl : UserControl
    {
        public RecipeControl()
        {
            InitializeComponent();
            //设置控件样式
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }
        private string devName = "1#站点";
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("显示或设置设备名称")]
        public string DevName
        {
            get { return devName; }
            set
            {
                devName = value;
                this.title1.TitleName = devName;
                this.textSetEx1.TitleName = devName + "温度高限";
                this.textSetEx2.TitleName = devName + "温度低限";
                this.textSetEx3.TitleName = devName + "湿度高限";
                this.textSetEx4.TitleName = devName + "湿度低限";
            }
        }
        private RecipeParam recipeParam = new RecipeParam();
        [Browsable(false)]
        public RecipeParam RecipeParam
        {
            get 
            {
                recipeParam = GetRecipeParams();
                return recipeParam;
            }
            set
            {
                recipeParam = value;
                SetRecipeParams(recipeParam);
            }
        }
        //将后台数据修改到UI
        public void SetRecipeParams(RecipeParam reParam)
        {
            this.textSetEx1.CurrentValue = reParam.TempHighLimit;
            this.textSetEx2.CurrentValue = reParam.TempLowLimit;
            this.textSetEx3.CurrentValue = reParam.HumidityHighLimit;
            this.textSetEx4.CurrentValue = reParam.HumidityLowLimit;
            this.checkBoxEx1.Checked = reParam.TempAlarmEnable;
            this.checkBoxEx2.Checked = reParam.HumidityAlarmDisable;
        }
        //将前端UI数据读取到后台
        public RecipeParam GetRecipeParams()
        {
            return new RecipeParam()
            {
                TempHighLimit = this.textSetEx1.CurrentValue,
                TempLowLimit = this.textSetEx2.CurrentValue,
                HumidityHighLimit = this.textSetEx3.CurrentValue,
                HumidityLowLimit = this.textSetEx4.CurrentValue,
                TempAlarmEnable = this.checkBoxEx1.Checked,
                HumidityAlarmDisable = this.checkBoxEx2.Checked,
            };
        }
    }
}
