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
            LoadDbConfig();
        }
        private void LoadDbConfig()
        {
            CreateToolStripMenuItem();
            ComboBoxDataSource(cbo_dbset, DBInfoModel.F_DBInfo, "ip");
        }
        #region Tool栏db配置加载
        private void CreateToolStripMenuItem()
        {
            var dbList = DBInfoModel.F_DBInfo;
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
            LoadDbConfig();
        }
        private void ts_Add_Click(object sender, EventArgs e)
        {
            EditOrAdd();
        }
        private void EditOrAdd(DBInfoModel model = null)
        {
            DBConfig dBConfig = new DBConfig();
            if (model != null)
            {
                dBConfig.SetUpdate(model);
            }
            if (dBConfig.ShowDialog() == DialogResult.OK)
            {
                LoadDbConfig();
            };
            dBConfig.Activate();
        }

        #endregion Tool栏db配置加载

        /// <summary>
        /// 关闭程序时保存所有数据
        /// </summary>
        private void MIntercross_FormClosing(object sender, FormClosingEventArgs e)
        {
            FileModelBase.Save();
        }
        /// <summary>
        /// DB服务器变化出触发
        /// </summary>
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
                    ComboBoxDataSource(cbo_db, dbList, "name");
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
        /// <summary>
        /// 数据库变化时触发
        /// </summary>
        private void cbo_db_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView model = (DataRowView)cbo_db.SelectedItem;
            DBInfoModel dbInfo = (DBInfoModel)cbo_dbset.SelectedItem;
            dbInfo.def_DB = model[0].ToString();
            DBInfo.SetConnectionString(dbInfo);
            if (tcl_tabList.SelectedTab.Name == tbp_Create.Name)
            {
                LoadCreate(dbInfo);
            }
            else
            {
                LoadDataJb(dbInfo);
            }
        }
        /// <summary>
        /// 保存路径选择
        /// </summary>
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
                if (tcl_tabList.SelectedTab.Name == tbp_Create.Name)
                {
                    txt_Path.Text = dialog.SelectedPath.ConvertString();
                }
                else
                {
                    txt_CPath.Text = dialog.SelectedPath;
                }
            }
        }

        #region 建表
        /// <summary>
        /// 加载面板
        /// </summary>
        private void LoadCreate(DBInfoModel model)
        {
            var dbTable = DBInfo.GetTablesInfo(model.def_DB);
            dgv_Tables.DataSource = dbTable;
            DataTable dt = (DataTable)dgv_Column.DataSource;
            if (dt != null)
            {
                dt.Rows.Clear();
                dgv_Column.DataSource = dt;
            }
            txt_CPath.Text = SavePathModel.F_DBInfo.Path;
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
                string path = txt_Path.Text.ConvertString();
                if (string.IsNullOrEmpty(path))
                {
                    MessageBox.Show("路径不能为空");
                }
                CreateTableLogic.CreateTableSql(list, path);
                SavePathModel savePathModel = new SavePathModel();
                savePathModel.Path = path;
                savePathModel.AddOrUpdate();
                MessageBox.Show("生成成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show("生成失败");
            }
        }
        #endregion 建表

        #region 数据脚本
        private void LoadDataJb(DBInfoModel model)
        {
            var dbTable = DBInfo.GetTablesInfo(model.def_DB);
            ComboBoxDataSource(cbx_TableList, dbTable, "name", isBind: true);
            txt_CPath.Text = SavePathModel.F_DBInfo.Path;
        }
        private void StructureControl()
        {
            var tag = pl_CbConfig.Tag.ConvertInt32();
            pl_CbConfig.Tag = tag + 1;
            var y = 40 * (tag + 1);
            Panel pl = new Panel();
            pl.Location = new System.Drawing.Point(3, y);
            pl.Name = tag.ToString();
            pl.Size = new System.Drawing.Size(580, 33);
            ComboBox table = new ComboBox();
            table.FormattingEnabled = true;
            table.Location = new System.Drawing.Point(30, 5);
            table.Name = "table_" + tag.ToString();
            table.Size = new System.Drawing.Size(200, 20);
            table.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChanged);
            ComboBox cbzd = new ComboBox();
            cbzd.FormattingEnabled = true;
            cbzd.Location = new System.Drawing.Point(259, 5);
            cbzd.Name = "cbzd_" + tag.ToString();
            cbzd.Size = new System.Drawing.Size(80, 20);
            ComboBox zbzd = new ComboBox();
            zbzd.FormattingEnabled = true;
            zbzd.Location = new System.Drawing.Point(372, 5);
            zbzd.Name = "zbzd_" + tag.ToString();
            zbzd.Size = new System.Drawing.Size(80, 20);
            zbzd.Text = cbx_TablePk.Text;
            ComboBoxDataSource(zbzd, cbx_TablePk.DataSource, "COLUMN_NAME", isBind: true);
            Button btn = new Button();
            btn.Location = new System.Drawing.Point(480, 5);
            btn.Name = "btn_" + tag.ToString();
            btn.Size = new System.Drawing.Size(75, 20);
            btn.Text = "删除";
            btn.UseVisualStyleBackColor = true;
            btn.Click += new System.EventHandler(this.DeleteCbPz);
            pl.Controls.AddRange(new Control[] { table, cbzd, zbzd, btn });
            pl_CbConfig.Controls.Add(pl);
        }
        private void SelectedIndexChanged(object sender, EventArgs e)
        {
            var cbx = (ComboBox)sender;
            if (!string.IsNullOrEmpty(cbx.Text.ConvertString()))
            {
                var data = DBInfo.GetTableInfo_DT(cbx.Text.ConvertString());
                ComboBox cbc_kz = null;
                if (cbx.Name == cbx_TableList.Name)
                {
                    cbc_kz = cbx_TablePk;
                }
                else
                {
                    foreach (var item in pl_CbConfig.Controls)
                    {
                    }
                }
                if (cbc_kz != null)
                {
                    ComboBoxDataSource(cbc_kz, data, "COLUMN_NAME", isBind: true);
                    if (string.IsNullOrEmpty(cbc_kz.Text))
                    {
                        var key = data.Select(" IsKey=1");
                        if (key.Length > 0)
                        {
                            cbc_kz.Text = key[0]["COLUMN_NAME"].ConvertString();
                        }
                    }
                }
            }
        }

        private void DeleteCbPz(object sender, EventArgs e)
        {
            this.pl_CbConfig.SuspendLayout();
            Button btn = (Button)sender;
            var tag = btn.Name.Split('_')[1].ConvertInt32();
            pl_CbConfig.Controls.RemoveByKey(tag.ConvertString());
            foreach (var item in pl_CbConfig.Controls)
            {
                if (item is Panel)
                {
                    var pl = (Panel)item;
                    var index = pl.Name.ConvertInt32();
                    if (index > tag)
                    {
                        pl.Name = (index - 1).ConvertString();
                        pl.Location = new System.Drawing.Point(3, 40 * index);
                    }
                }
            }
            pl_CbConfig.Tag = pl_CbConfig.Tag.ConvertInt32() - 1;
            this.pl_CbConfig.ResumeLayout(false);
            this.pl_CbConfig.PerformLayout();
        }

        private void btn_AddConfig_Click(object sender, EventArgs e)
        {
            StructureControl();
        }
        #endregion 数据脚本

        #region 构建搜索类型下拉框
        public void ComboBoxDataSource(ComboBox cbx, object data, string ValueMember, string DisplayMember = "", bool isBind = false)
        {
            if (cbx != null)
            {
                cbx.ValueMember = ValueMember;
                cbx.DisplayMember = string.IsNullOrEmpty(DisplayMember) ? ValueMember : DisplayMember;
                cbx.DataSource = data;
                cbx.Tag = data;
                if (isBind)
                {
                    cbx.KeyUp += new KeyEventHandler(cbo_db_KeyUp);
                }
            }
        }

        private void cbo_db_KeyUp(object sender, KeyEventArgs e)
        {
            var cbx = (ComboBox)sender;
            if (!string.IsNullOrEmpty(cbx.Text))
            {
                string name = cbx.ValueMember;
                var dt = (DataTable)cbx.Tag;
                var dr = dt.Select($" {name} like '%{cbx.Text.ConvertString()}%'");
                if (dr.Length > 0)
                {
                    cbx.DataSource = dr.CopyToDataTable();
                }
                else
                {
                    cbx.DataSource = dt.Clone();
                }
                cbx.DroppedDown = true;
            }
            else
            {
                cbx.DataSource = (DataTable)cbx.Tag;
            }
        }
        #endregion 构建搜索类型下拉框

        private void tcl_tabList_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbo_db_SelectedIndexChanged(null, null);
        }
    }
}
