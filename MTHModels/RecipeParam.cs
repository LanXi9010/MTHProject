using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTHModels
{
    public class RecipeParam
    {
        public RecipeParam() { }
        public float TempHighLimit {  get; set; }
        public float TempLowLimit { get; set; }
        public float HumidityHighLimit {  get; set; }
        public float HumidityLowLimit { get;  set; }
        public bool TempAlarmEnable {  get; set; }
        public bool HumidityAlarmDisable { get; set; }
    }
}
