using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTHModels
{
    public class RecipeInfo
    {
        public RecipeInfo() { }
        public string RecipeName {  get; set; }
        public List<RecipeParam>RecipeParams { get; set; }=new List<RecipeParam>();
    }
}
