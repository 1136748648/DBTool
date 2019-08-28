using DBLogic;
using DBLogic.Logic;
using DBLogic.Model;
using DBLogic.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace FDBIntercross
{
    public partial class MIntercross : Form
    {
        public MIntercross()
        {
            FileModelBase.Load();
            InitializeComponent();
            CreateToolStripMenuItem();
            DBSetList();
        }

        private void CreateToolStripMenuItem()
        {
            var dbList = DBInfoModel.F_DBList;
            var a = tsddb_DBSet.DropDownItems[0];
            for (int i = tsddb_DBSet.DropDownItems.Count - 1; i >= 0; i--)
            {
                var tag = (string)tsddb_DBSet.DropDownItems[i].Tag;
                if (tag == null || !tag.Equals("default"))
                {
                    tsddb_DBSet.DropDownItems.RemoveAt(i);
                }
            }
            foreach (var model in dbList)
            {
                ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem
                {
                    Text = model.Ip
                };
                ToolStripMenuItem Edit = new ToolStripMenuItem();
                Edit.Text = "编辑";
                Edit.Tag = model;
                Edit.Click += new System.EventHandler(this.ts_Edit_Click);
                ToolStripMenuItem Delete = new ToolStripMenuItem();
                Delete.Text = "删除";
                Delete.Tag = model;
                Delete.Click += new System.EventHandler(this.ts_Delete_Click);
                toolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { Edit, Delete });
                this.tsddb_DBSet.DropDownItems.Add(toolStripMenuItem);
            }
        }
        public void DBSetList()
        {
            cbo_dbset.ValueMember = "ip";
            cbo_dbset.DisplayMember = "ip";
            cbo_dbset.DataSource = DBInfoModel.F_DBList;
        }
        private void tbp_Create_Click(object sender, EventArgs e)
        {
            var a = DBInfoModel.F_DBList;
        }

        private void ts_Edit_Click(object sender, EventArgs e)
        {
            var edit = (ToolStripMenuItem)sender;
            EditOrAdd((DBInfoModel)edit.Tag);
        }
        private void ts_Delete_Click(object sender, EventArgs e)
        {
            var edit = (ToolStripMenuItem)sender;
            var item = (DBInfoModel)edit.Tag;
            item.Delete();
            CreateToolStripMenuItem();
            DBSetList();
        }
        private void ts_Add_Click(object sender, EventArgs e)
        {
            EditOrAdd();
        }

        public void EditOrAdd(DBInfoModel model = null)
        {
            DBConfig dBConfig = new DBConfig();
            if (model != null)
            {
                dBConfig.SetUpdate(model);
            }
            if (dBConfig.ShowDialog() == DialogResult.OK)
            {
                CreateToolStripMenuItem();
                DBSetList();
            };
            dBConfig.Activate();
        }

        private void MIntercross_FormClosing(object sender, FormClosingEventArgs e)
        {
            FileModelBase.Save();
        }

        private void cbo_dbset_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DBInfoModel model = (DBInfoModel)cbo_dbset.SelectedItem;
                cbo_db.Text = model.def_DB;
                DBInfo.SetConnectionString(model);
                var dbList = DBInfo.GetDBsInfo();
                if (dbList != null)
                {
                    cbo_db.ValueMember = "name";
                    cbo_db.DisplayMember = "name";
                    cbo_db.DataSource = dbList;
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

        private void cbo_db_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView model = (DataRowView)cbo_db.SelectedItem;
            if (tcl_tabList.SelectedTab.Name == tbp_Create.Name)
            {
                DBInfoModel dbInfo = (DBInfoModel)cbo_dbset.SelectedItem;
                dbInfo.def_DB = model[0].ToString();
                DBInfo.SetConnectionString(dbInfo);
                var dbTable = DBInfo.GetTablesInfo(model[0].ToString());
                dgv_Tables.DataSource = dbTable;
                DataTable dt = (DataTable)dgv_Column.DataSource;
                if (dt != null)
                {
                    dt.Rows.Clear();
                    dgv_Column.DataSource = dt;
                    //dgv_Column.DataSource = null;
                }
            }
        }

        private string dgv_Tables_SelectName = string.Empty;
        private void dgv_Tables_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var flag = dgv_Tables.Rows[e.RowIndex].Cells[0].Value;
            dgv_Tables.Rows[e.RowIndex].Cells[0].Value = flag != null && flag.ConvertBoolean() ? false : true;
            var name = dgv_Tables.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
            if (!string.IsNullOrEmpty(name))
            {
                if (dgv_Tables_SelectName.Equals(name)) return;
                DataTable dt = (DataTable)dgv_Column.DataSource;
                if (dt != null)
                {
                    dt.Rows.Clear();
                    dgv_Column.DataSource = dt;
                }
                dgv_Tables_SelectName = name;
                dgv_Column.DataSource = DBInfo.GetTableInfo_DT(name);
            }
        }

        private void btn_Path_Click(object sender, EventArgs e)
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
                txt_Path.Text = dialog.SelectedPath;
            }
        }

        private void btn_Generate_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> list = new List<string>();
                foreach (DataGridViewRow item in dgv_Tables.Rows)
                {
                    if (item.Cells[0].Value.ConvertBoolean() == true)
                    {
                        list.Add(item.Cells[1].Value.ConvertString());
                    }
                }
                string path = txt_Path.Text;
                if (string.IsNullOrEmpty(path))
                {
                    MessageBox.Show("路径不能为空");
                }
                CreateTableLogic.CreateTableSql(list, path);
                MessageBox.Show("生成成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show("生成失败");
            }
        }
    }
}
