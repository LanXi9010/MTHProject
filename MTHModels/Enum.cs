using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTHModels
{
    /// <summary>
    /// 枚举六个模块，名字一定要与FrmMain中的名字一致，临界窗体(当切换到另一个窗体时，小于临界窗体的窗体不关闭)
    /// </summary>
public enum FormNames
    {
        集中监控,
        临界窗体,
        参数设置,
        配方管理,
        报警追溯,
        历史趋势,
        用户管理,
    } 
}
