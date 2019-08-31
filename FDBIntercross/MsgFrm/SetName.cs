using System;
using System.Windows.Forms;

namespace FDBIntercross
{
    public partial class SetName : Form
    {
        public string TValue { set { txt_Name.Text = value; } get { return txt_Name.Text; } }
        private bool flag = false;
        public SetName(bool _flag = false)
        {
            InitializeComponent();
            if (_flag)
            {
                btn_SavePath.Visible = true;
                txt_Name.ReadOnly = true;
            }
            flag = _flag;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_Name.Text))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btn_SavePath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择保存的文件夹";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (string.IsNullOrEmpty(dialog.SelectedPath))
                {
                    MessageBox.Show(this, "文件夹路径不能为空", "提示");
                    return;
                }
                txt_Name.Text = dialog.SelectedPath;
            }
        }
    }
}
