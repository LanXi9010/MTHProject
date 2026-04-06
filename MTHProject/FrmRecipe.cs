using MTHHelper;
using MTHModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using thinger.DataConvertLib;

namespace MTHProject
{
    public partial class FrmRecipe : Form
    {
        public FrmRecipe(string devPath )
        {
            InitializeComponent();

            this.lbl_CurrentRecipe.Text = CommonMethods.Device.CurrentRecipe;
            this.txt_RecipeName.Text = CommonMethods.Device.CurrentRecipe;
            RefreshUI();
            this.devPath = devPath;
        }
        string devPath=string.Empty;
        string basePath=Application.StartupPath+"\\Recipe";
        List<RecipeInfo> recipeInfos = new List<RecipeInfo>();
        #region 从UI中获取配方实体,为添加配方做准备
        private RecipeInfo GetRecipeInfoFromUI()
        {
            return new RecipeInfo()
            {
                RecipeName = this.txt_RecipeName.Text.Trim(),
                RecipeParams = new List<RecipeParam>
                {
                    this.recipeControl1.RecipeParam,
                    this.recipeControl2.RecipeParam,
                    this.recipeControl3.RecipeParam,
                    this.recipeControl4.RecipeParam,
                    this.recipeControl5.RecipeParam,
                    this.recipeControl6.RecipeParam,
                }
            };
        }
        #endregion
        #region 将配方实体转化为字符串写入文件
        private bool WriteRecipeToFile(RecipeInfo recipeInfo)
        {
            string filePath = basePath + "\\" + recipeInfo.RecipeName + ".ini";
            return IniConfigHelper.WriteIniData("配方","参数",JsonHelper.EntityToJSON(recipeInfo),filePath);
        }
        #endregion
        #region 从文件里面读取配方字符串并转化为实体类
        public RecipeInfo ReadRecipeFromFile(string filePath)
        {
            return JsonHelper.JSONToEntity<RecipeInfo>(IniConfigHelper.ReadIniData("配方","参数","",filePath));
        }
        #endregion
        #region 更新配方数据到UI界面
        private void UpdateUI(RecipeInfo recipeInfo)
        {
            this.txt_RecipeName.Text=recipeInfo.RecipeName;
            this.recipeControl1.RecipeParam = recipeInfo.RecipeParams[0];
            this.recipeControl2.RecipeParam = recipeInfo.RecipeParams[1];
            this.recipeControl3.RecipeParam = recipeInfo.RecipeParams[2];
            this.recipeControl4.RecipeParam = recipeInfo.RecipeParams[3];
            this.recipeControl5.RecipeParam = recipeInfo.RecipeParams[4];
            this.recipeControl6.RecipeParam = recipeInfo.RecipeParams[5];
        }
        #endregion
        #region 从文件中获取所有配方
        private List<RecipeInfo> GetAllRecipe()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(basePath);
            List<FileInfo> files = directoryInfo.GetFiles("*.ini").ToList();
            List<RecipeInfo> recipeInfos = new List<RecipeInfo>();
            foreach (var item in files)
            {
                recipeInfos.Add(ReadRecipeFromFile(item.FullName));
            }
            return recipeInfos;
        }
        #endregion
        #region 刷新UI
        private void RefreshUI()
        {
            recipeInfos = GetAllRecipe();
            if (recipeInfos.Count > 0  )
            {
                this.dgv_Main.Rows.Clear();//每次都是先清除
                for (int i = 0; i < recipeInfos.Count; i++)
                {
                    this.dgv_Main.Rows.Add();
                    this.dgv_Main.Rows[i].Cells[0].Value = (i+1).ToString();
                    this.dgv_Main.Rows[i].Cells[1].Value = recipeInfos[i].RecipeName;
                    if (this.txt_RecipeName.Text == recipeInfos[i].RecipeName)
                    {
                        this.dgv_Main.Rows[i].Selected = true;
                    }
                    else
                    {
                        this.dgv_Main.Rows [i].Selected = false;
                    }
                }
                if (this.dgv_Main.SelectedRows.Count > 0)
                {
                    UpdateUI(recipeInfos[this.dgv_Main.SelectedRows[0].Index]);
                }
            }
        }
        #endregion
        #region 删除配方文件
        private bool DeleteRecipeFromFile(string recipeName)
        {
            try
            {
                File.Delete(basePath + "\\" + recipeName + ".ini");
            }
            catch(Exception e)
            {
                return false;
            }
            return true;
        }
        #endregion
        #region 添加配方函数
        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (txt_RecipeName.Text.Trim().Length==0)
            {
                new FrmMsgBoxWithoutAck("配方名称不能为空","添加配方").Show();
                return;
            }
            var info=recipeInfos.Where(r=>r.RecipeName==this.txt_RecipeName.Text).FirstOrDefault();
            if (info!=null)
            {
                new FrmMsgBoxWithoutAck("配方名称已经存在","添加配方").Show();
                return;
            }
            var recipeInfo = GetRecipeInfoFromUI();
            bool result=WriteRecipeToFile(recipeInfo);
            if (result)
            {
                 RefreshUI();
                 new FrmMsgBoxWithoutAck("配方添加成功", "添加配方").Show();
            }
            else
            {
                 new FrmMsgBoxWithoutAck("配方添加失败", "添加配方").Show();
            }
        }
        #endregion
        #region 修改配方函数
        private void btn_Modify_Click(object sender, EventArgs e)
        {
            if (txt_RecipeName.Text.Trim().Length == 0)
            {
                new FrmMsgBoxWithoutAck("配方名称不能为空", "修改配方").Show();
                return;
            }
            var info = recipeInfos.Where(r => r.RecipeName == this.txt_RecipeName.Text).FirstOrDefault();
            if (info == null)
            {
                new FrmMsgBoxWithoutAck("配方名称不存在", "修改配方").Show();
                return;
            }
            var recipeinfo = GetRecipeInfoFromUI();
            bool result = WriteRecipeToFile(recipeinfo);
            if (result)
            {
                RefreshUI();
                new FrmMsgBoxWithoutAck("修改配方成功","修改配方").Show();
            }
            else
            {
                new FrmMsgBoxWithoutAck("配方添加失败", "修改配方").Show();
            }
        }
        #endregion
        #region 删除配方函数
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (txt_RecipeName.Text.Trim().Length == 0)
            {
                new FrmMsgBoxWithoutAck("配方名称不能为空", "删除配方").Show();
                return;
            }
            var info = recipeInfos.Where(r => r.RecipeName == this.txt_RecipeName.Text).FirstOrDefault();
            if (info == null)
            {
                new FrmMsgBoxWithoutAck("配方名称不存在", "删除配方").Show();
                return;
            }
            DialogResult dialogresult = new FrmMsgBoxWithAck("确认删除配方?","删除配方").ShowDialog();
            if (dialogresult == DialogResult.OK)
            {
                bool result = DeleteRecipeFromFile(this.txt_RecipeName.Text.Trim());
                if (result)
                {
                    RefreshUI();
                    new FrmMsgBoxWithoutAck("配方删除成功","删除配方").Show();
                }
                else
                {
                    new FrmMsgBoxWithoutAck("配方删除失败", "删除配方").Show();
                }
            }
        }
        #endregion
        #region 应用配方函数
        private void btn_Apply_Click(object sender, EventArgs e)
        {
            if (txt_RecipeName.Text.Trim().Length == 0)
            {
                new FrmMsgBoxWithoutAck("配方名称不能为空", "应用配方").Show();
                return;
            }
            var info = recipeInfos.Where(r => r.RecipeName == this.txt_RecipeName.Text).FirstOrDefault();
            if (info == null)
            {
                new FrmMsgBoxWithoutAck("配方名称不存在", "应用配方").Show();
                return;
            }
            if (!CommonMethods.Device.IsConnected) 
            {
                new FrmMsgBoxWithoutAck("请检查设备是否连接正常","应用配方").Show();
                return;
            }
            if (info.RecipeParams.Count == 6)
            {
                List<short> values= new List<short>();
                //写温湿度配方
                for (int i = 0; i < 6; i++)
                {
                    values.Add(Convert.ToInt16(info.RecipeParams[i].TempHighLimit*10));
                    values.Add(Convert.ToInt16(info.RecipeParams[i].TempLowLimit*10));
                    values.Add(Convert.ToInt16(info.RecipeParams[i].HumidityHighLimit * 10));
                    values.Add(Convert.ToInt16(info.RecipeParams[i].HumidityLowLimit * 10));
                }
                //留一些闲置地址
                for (int i = 0;i < 6; i++)
                {
                    values.Add(0);
                }
                //再写报警配方
                for(int i = 0; i < 6; i++)
                {
                    values.Add(info.RecipeParams[i].TempAlarmEnable ? (short)1 : (short)0);
                    values.Add(info.RecipeParams[i].HumidityAlarmDisable ? (short)1 : (short)0);
                }
              bool result=  CommonMethods.modbus.PreSetMultiRegisters(36,ByteArrayLib.GetByteArrayFromShortArray(values.ToArray()));
                if (result)
                {
                    string recipeName=this.txt_RecipeName.Text.Trim();

                    IniConfigHelper.WriteIniData("配方参数", "当前配方", recipeName, this.devPath);
                    CommonMethods.Device.CurrentRecipe = recipeName;
                    this.lbl_CurrentRecipe.Text = recipeName;
                    new FrmMsgBoxWithoutAck("配方应用成功","应用配方").Show();
                }
                else
                {
                    new FrmMsgBoxWithoutAck("配方应用失败", "应用配方").Show();
                }
            }
            else
            {
                new FrmMsgBoxWithoutAck("配方参数不完整，请检查!", "应用配方").Show();
            }
        }
        #endregion
        #region dgv点击事件
        private void dgv_Main_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex>=0)
            {
                var info=recipeInfos[e.RowIndex];
                UpdateUI(info);
            }
        }
        #endregion
    }
}
