using System;
using System.Windows.Forms;

namespace FDBIntercross
{
    public partial class SetName : Form
    {
        public string TName { set { txt_Name.Text = value; } get { return txt_Name.Text; } }
        public SetName()
        {
            InitializeComponent();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_Name.Text))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
