using DBLogic;
using DBLogic.Logic;
using DBLogic.Model;
using DBLogic.Util;
using FDBIntercross.UserControls;
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
            cbo_dbset.ValueMember = "ip";
            cbo_dbset.DisplayMember = "ip";
            cbo_dbset.DataSource = DBInfoModel.F_DBInfo;
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
                string def_DB = model.def_DB;
                DBInfo.SetConnectionString(model);
                var dbList = DBInfo.GetDBsInfo();
                if (dbList != null)
                {
                    cbo_db.ValueMember = "name";
                    cbo_db.DisplayMember = "name";
                    cbo_db.DataSource = dbList;
                    cbo_db.SelectedValue = def_DB;
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
            if (model != null)
            {
                dbInfo.def_DB = model[0].ToString();
                dbInfo.AddOrUpdate();
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
            txt_Path.Text = SavePathModel.F_DBInfo.Path;
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
            cbx_ConfigDataSource();
            pl_CbConfigClear();
        }
        private object tempData = null;
        private Panel StructureControl()
        {
            var tag = pl_CbConfig.Tag.ConvertInt32();
            pl_CbConfig.Tag = tag + 1;
            var y = 40 * (tag + 1);
            Panel pl = new Panel();
            pl.Location = new System.Drawing.Point(3, y);
            pl.Name = tag.ToString();
            pl.Size = new System.Drawing.Size(580, 33);
            DropDownSearch table = new DropDownSearch();
            table.Location = new System.Drawing.Point(30, 5);
            table.Name = "table";
            table.Size = new System.Drawing.Size(200, 20);
            table.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChanged);
            DropDownSearch cbzd = new DropDownSearch();
            cbzd.Location = new System.Drawing.Point(259, 5);
            cbzd.Name = "cbzd";
            cbzd.Size = new System.Drawing.Size(80, 20);
            DropDownSearch zbzd = new DropDownSearch();
            zbzd.Location = new System.Drawing.Point(372, 5);
            zbzd.Name = "zbzd";
            zbzd.Size = new System.Drawing.Size(80, 20);
            zbzd.Text = cbx_TablePk.Text;
            Button btn = new Button();
            btn.Location = new System.Drawing.Point(480, 5);
            btn.Name = "btn_" + tag.ToString();
            btn.Size = new System.Drawing.Size(75, 20);
            btn.Text = "删除";
            btn.UseVisualStyleBackColor = true;
            btn.Click += new System.EventHandler(this.DeleteCbPz);
            pl.Controls.AddRange(new Control[] { table, cbzd, zbzd, btn });
            pl_CbConfig.Controls.Add(pl);
            if (tempData == null)
            {
                tempData = (cbx_TableList.DataSource as DataTable).Select($" name<>'{cbx_TableList.Text.ConvertString()}'").CopyToDataTable();
            }
            ComboBoxDataSource(table, tempData, "name", isBind: true);
            ComboBoxDataSource(cbzd, DBInfo.GetTableInfo_DT(table.Text.ConvertString()), "COLUMN_NAME", isBind: true);
            ComboBoxDataSource(zbzd, cbx_TablePk.DataSource, "COLUMN_NAME", isBind: true);
            return pl;
        }
        private void SelectedIndexChanged(object sender, EventArgs e)
        {
            var cbx = (DropDownSearch)sender;
            if (!string.IsNullOrEmpty(cbx.Text.ConvertString()))
            {
                var data = DBInfo.GetTableInfo_DT(cbx.Text.ConvertString());
                DropDownSearch cbc_kz = null;
                if (cbx.Name == cbx_TableList.Name)
                {
                    cbc_kz = cbx_TablePk;
                }
                else
                {
                    cbc_kz = cbx.Parent.Controls["cbzd"] as DropDownSearch;
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
                if (cbx.Name == cbx_TableList.Name)
                {
                    tempData = (cbx_TableList.Tag as DataTable).Select($" name<>'{cbx_TableList.Text.ConvertString()}'").CopyToDataTable();
                    foreach (var item in pl_CbConfig.Controls)
                    {
                        if (item is Panel)
                        {
                            var _temp = (item as Panel).Controls["zbzd"] as DropDownSearch;
                            ComboBoxDataSource(_temp, data, "COLUMN_NAME", isBind: true);
                            _temp.Text = cbx.Text;
                            var _temp2 = (item as Panel).Controls["table"] as DropDownSearch;
                            _temp2.DataSource = tempData;
                        }
                    }
                }
            }
        }

        private void pl_CbConfigClear()
        {
            foreach (Control item in pl_CbConfig.Controls)
            {
                if (item is Panel)
                {
                    pl_CbConfig.Controls.Remove(item);
                }
            }
        }
        private void DeleteCbPz(object sender, EventArgs e)
        {
            this.pl_CbConfig.SuspendLayout();
            Button btn = (Button)sender;
            var tag = btn.Parent.Name.ConvertInt32();
            pl_CbConfig.Controls.RemoveByKey(btn.Parent.Name);
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
        private void btn_GenerateData_Click(object sender, EventArgs e)
        {
            try
            {
                DataConfigModel model = cbx_Config.SelectedItem as DataConfigModel;
                model.CbInfo = new List<DataConfig_CbModel>();
                model.Path = txt_CPath.Text.ConvertString();
                model.IsPcZzl = ckb_IsPcZzl.Checked;
                model.ZTableName = cbx_TableList.Text.ConvertString();
                model.ZTablePk = cbx_TablePk.Text.ConvertString();
                model.Sql = txt_DbSql.Text.ConvertString();
                if (!ckb_IsName.Checked)
                {
                    SetName sName = new SetName();
                    sName.TName = model.Name == "--新增配置--" ? "" : model.Name;
                    if (sName.ShowDialog() == DialogResult.OK)
                    {
                        model.Name = sName.TName.ConvertString();
                    }
                    sName.Activate();
                }
                else
                {
                    model.Name = model.ZTableName;
                }
                foreach (var item in pl_CbConfig.Controls)
                {
                    if (item is Panel)
                    {
                        var pl = item as Panel;
                        model.CbInfo.Add(new DataConfig_CbModel()
                        {
                            TableName = (pl.Controls["table"] as DropDownSearch).Text.ConvertString(),
                            CBZD = (pl.Controls["cbzd"] as DropDownSearch).Text.ConvertString(),
                            ZBZD = (pl.Controls["zbzd"] as DropDownSearch).Text.ConvertString()
                        });
                    }
                }
                GenerateDataLogic.GenerateData(model);
                model.AddOrUpdate();
                string tempText = cbx_Config.Text.ConvertString();
                cbx_ConfigDataSource();
                pl_CbConfigClear();
                cbx_Config.SelectedValue = tempText;
                MessageBox.Show("生成成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show("生成失败");
            }
        }
        private void cbx_ConfigDataSource()
        {
            var list = DataConfigModel.F_DBInfo;
            list.Insert(0, new DataConfigModel() { Name = "--新增配置--" });
            cbx_Config.ValueMember = "Name";
            cbx_Config.DisplayMember = "Name";
            cbx_Config.DataSource = list;
        }
        private void cbx_Config_SelectedIndexChanged(object sender, EventArgs e)
        {
            var model = cbx_Config.SelectedItem as DataConfigModel;
            txt_CPath.Text = model.Path;
            ckb_IsPcZzl.Checked = model.IsPcZzl;
            cbx_TableList.Text = model.ZTableName;
            cbx_TablePk.Text = model.ZTablePk;
            txt_DbSql.Text = model.Sql;
            if (model.CbInfo != null && model.CbInfo.Count > 0)
            {
                pl_CbConfigClear();
                pl_CbConfig.Tag = 0;
                foreach (var item in model.CbInfo)
                {
                    var pl = StructureControl();
                    (pl.Controls["table"] as DropDownSearch).Text = item.TableName;
                    (pl.Controls["cbzd"] as DropDownSearch).Text = item.CBZD;
                    (pl.Controls["zbzd"] as DropDownSearch).Text = item.ZBZD;
                }
            }
        }
        #endregion 数据脚本

        #region 构建搜索类型下拉框
        public void ComboBoxDataSource(DropDownSearch cbx, object data, string ValueMember, string DisplayMember = "", bool isBind = false)
        {
            if (cbx != null)
            {
                cbx.ValueMember = ValueMember;
                cbx.DisplayMember = string.IsNullOrEmpty(DisplayMember) ? ValueMember : DisplayMember;
                cbx.Tag = data;
                cbx.DataSource = data;
                if (isBind)
                {
                    cbx.KeyUp -= new KeyEventHandler(cbo_db_KeyUp);
                    cbx.KeyUp += new KeyEventHandler(cbo_db_KeyUp);
                }
            }
        }

        private void cbo_db_KeyUp(object sender, KeyEventArgs e)
        {
            var cbx = (DropDownSearch)sender;
            var text = cbx.Text.ConvertString();
            if (!string.IsNullOrEmpty(text))
            {
                string name = cbx.ValueMember;
                var dt = (DataTable)cbx.Tag;
                var temp = (cbx.DataSource as DataTable);
                var dr = dt.Select($" {name} like '%{cbx.Text.ConvertString()}%'");
                if (dr.Length > 0)
                {
                    //temp = dr.CopyToDataTable();
                    cbx.DataSource = dr.CopyToDataTable();
                }
                else
                {
                    //temp = dt.Clone();
                    cbx.DataSource = dt.Clone();
                }
                cbx.DroppedDown = true;
                // cbx.Text = text;
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
