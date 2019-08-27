using DBLogic;
using DBLogic.Model;
using System;
using System.Windows.Forms;

namespace FDBIntercross
{
    public partial class DBConfig : Form
    {
        private DBInfoModel dBInfoModel = null;
        private bool isUpdate = false;
        public DBConfig()
        {
            InitializeComponent();
            dBInfoModel = new DBInfoModel();
        }
        public void SetUpdate(DBInfoModel _dBInfoModel)
        {
            isUpdate = true;
            dBInfoModel = _dBInfoModel;
            this.txb_Ip.Text = dBInfoModel.Ip;
            this.txb_User.Text = dBInfoModel.User;
            this.txb_Pwd.Text = dBInfoModel.pwd;
            this.cbx_DbDefault.Text = dBInfoModel.def_DB;
        }

        private void btn_Test_Click(object sender, EventArgs e)
        {
            try
            {
                DBInfo.SetConnectionString(GetModelInfo());
                var dbList = DBInfo.GetDBsInfo();
                if (dbList != null)
                {
                    MessageBox.Show("连接成功!");
                    cbx_DbDefault.ValueMember = "name";
                    cbx_DbDefault.DisplayMember = "name";
                    cbx_DbDefault.DataSource = dbList;
                }
                else
                {
                    MessageBox.Show("连接失败!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("连接失败!");
            }
        }
        private DBInfoModel GetModelInfo()
        {
            dBInfoModel.Ip = this.txb_Ip.Text.Trim();
            dBInfoModel.User = this.txb_User.Text.Trim();
            dBInfoModel.pwd = this.txb_Pwd.Text.Trim();
            if (!string.IsNullOrEmpty(this.cbx_DbDefault.Text))
            {
                dBInfoModel.def_DB = this.cbx_DbDefault.Text.Trim();
            }
            return dBInfoModel;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            GetModelInfo();
            dBInfoModel.AddOrUpdate();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
