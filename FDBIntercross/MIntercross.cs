using DBLogic;
using DBLogic.Model;
using DBLogic.Util;
using System;
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

        private string dgv_Tables_SelectName = string.Empty;
        private void dgv_Tables_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var name = dgv_Tables.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();
            if (!string.IsNullOrEmpty(name))
            {
                if (dgv_Tables_SelectName.Equals(name)) return;
                dgv_Tables_SelectName = name;
                dgv_Column.DataSource = GetTableInfo(name);
            }
        }
        private DataTable GetTableInfo(string name)
        {
            var ds = DBInfo.GetTableInfo(name);
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("COLUMN_NAME", typeof(string));
            dataTable.Columns.Add("DATA_TYPE", typeof(string));
            dataTable.Columns.Add("IS_NULLABLE", typeof(string));
            dataTable.Columns.Add("COLUMN_DEFAULT", typeof(string));
            dataTable.Columns.Add("IsKey", typeof(string));
            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    string DATA_TYPE = item["DATA_TYPE"].ToString().Trim();
                    string CHARACTER_MAXIMUM_LENGTH = item["CHARACTER_MAXIMUM_LENGTH"].ToString().Trim();
                    string NUMERIC_PRECISION = item["NUMERIC_PRECISION"].ToString().Trim();
                    string NUMERIC_SCALE = item["NUMERIC_SCALE"].ToString().Trim();
                    string COLUMN_DEFAULT = item["COLUMN_DEFAULT"].ToString().Trim();
                    if (!string.IsNullOrEmpty(CHARACTER_MAXIMUM_LENGTH))
                    {
                        DATA_TYPE = $"{DATA_TYPE}({CHARACTER_MAXIMUM_LENGTH})";
                    }
                    else if (!string.IsNullOrEmpty(NUMERIC_PRECISION) && !string.IsNullOrEmpty(NUMERIC_SCALE))
                    {
                        DATA_TYPE = $"{DATA_TYPE}({NUMERIC_PRECISION},{NUMERIC_SCALE})";
                    }
                    COLUMN_DEFAULT = COLUMN_DEFAULT.Replace("(", "").Replace(")", "");
                    string isKey = "";
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        foreach (DataRow kdr in ds.Tables[1].Rows)
                        {
                            if (kdr["name"].ToString().Trim().Equals(item["COLUMN_NAME"].ToString()))
                            {
                                isKey = "YES";
                            }
                        }
                    }
                    dataTable.Rows.Add(item["COLUMN_NAME"].ToString(), DATA_TYPE, item["IS_NULLABLE"].ToString(), COLUMN_DEFAULT, isKey);
                }
            }
            return dataTable;
        }

        private void dgv_Tables_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    //若行已是选中状态就不再进行设置
                    //if (dataGridView1.Rows[e.RowIndex].Selected == false)
                    //{
                    //    dataGridView1.ClearSelection();
                    //    dataGridView1.Rows[e.RowIndex].Selected = true;
                    //}
                    ////只选中一行时设置活动单元格
                    //if (dataGridView1.SelectedRows.Count == 1)
                    //{
                    //    dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    //}
                    //弹出操作菜单
                    cms_Tables.Show(MousePosition.X, MousePosition.Y);
                }
            }

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }
}
