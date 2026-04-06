using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MTHProject
{
    public partial class FrmModify : Form
    {
        public FrmModify(string titleName,string bindVarName,string currentValue)
        {
            InitializeComponent();
            this.lbl_Title.Text = titleName;
            this.lbl_CurrentValue.Text = currentValue;
            this._bindName=bindVarName;
        }
        string _bindName=string.Empty;
        public void btn_SureFunc(Object sender,EventArgs e)
        {
            bool result = CommonMethods.CommonWrite(this._bindName,this.tbk_Modify.Text);
            if (result)
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                new FrmMsgBoxWithoutAck("参数修改失败，请检查参数","参数修改");
            }
        }

        private void btn_Canel_Click(object sender, EventArgs e)
        {
           this.DialogResult = DialogResult.Cancel;
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbk_Modify_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btn_SureFunc(null,null);
            }
        }
    }
}
