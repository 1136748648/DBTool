using DBLogic;
using DBLogic.Logic;
using DBLogic.Model;
using DBLogic.Util;
using FDBIntercross.UserControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace FDBIntercross
{
    public partial class MIntercross : Form
    {
        public MIntercross()
        {
            FileBaseModel.Load();
            InitializeComponent();
            LoadData();
        }

        #region 程序主体
        /// <summary>
        /// 加载数据
        /// </summary>
        private void LoadData()
        {
            LoadToolData();
            cbo_dbset.ValueMember = "_Id_";
            cbo_dbset.DisplayMember = "ip";
            cbo_dbset.DataSource = DBConfigModel.F_DBInfo;
        }
        /// <summary>
        /// 加载数配置下拉框变化触发
        /// </summary>
        private void cbo_dbset_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DBConfigModel model = (DBConfigModel)cbo_dbset.SelectedItem;
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
            DBConfigModel dbInfo = (DBConfigModel)cbo_dbset.SelectedItem;
            if (model != null)
            {
                dbInfo.def_DB = model[0].ToString();
                dbInfo.AddOrUpdate();
                DBInfo.SetConnectionString(dbInfo);
                if (tcl_tabList.SelectedTab.Name == tbp_TableScript.Name)
                {
                    LoadCreate(dbInfo);
                }
                else
                {
                    LoadDataJb(dbInfo);
                }
            }
        }

        private void btn_GenerateData_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SysConfigModel.F_DBInfo.Path))
            {
                SysConfigModel sysConfigModel = new SysConfigModel()
                {
                    Path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
                };
                sysConfigModel.AddOrUpdate();
            }
            if (tcl_tabList.SelectedTab.Name == tbp_TableScript.Name)
            {
                TableScript_Generate();
            }
            else
            {
                DataScript_Generate();
            }
        }

        private void MIntercross_FormClosing(object sender, FormClosingEventArgs e)
        {
            TableConfigModel tableConfigModel = new TableConfigModel()
            {
                IsToUpper = ts_ts_IsToUpper.Checked
            };
            DataScriptConfigModel dataScriptConfigModel = new DataScriptConfigModel()
            {
                IsPcZzl = ts_ds_IsPcZzl.Checked,
                IsTName = ts_ds_IsTName.Checked
            };
            tableConfigModel.AddOrUpdate();
            dataScriptConfigModel.AddOrUpdate();
        }
        #endregion 程序主体

        #region Tool栏db配置加载
        private void LoadToolData()
        {
            ts_ts_IsToUpper.Checked = TableConfigModel.F_DBInfo.IsToUpper;
            ts_ds_IsPcZzl.Checked = DataScriptConfigModel.F_DBInfo.IsPcZzl;
            ts_ds_IsTName.Checked = DataScriptConfigModel.F_DBInfo.IsTName;
            CreateToolStripMenuItem();
            LoadJbTs();
        }
        #region 数据库配置
        private void CreateToolStripMenuItem()
        {
            var dbList = DBConfigModel.F_DBInfo;
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
            EditOrAdd((DBConfigModel)edit.Tag);
        }
        private void ts_Delete_Click(object sender, EventArgs e)
        {
            var edit = (ToolStripMenuItem)sender;
            var item = (DBConfigModel)edit.Tag;
            item.Delete();
            LoadData();
        }
        private void ts_Add_Click(object sender, EventArgs e)
        {
            EditOrAdd();
        }
        private void EditOrAdd(DBConfigModel model = null)
        {
            DBConfig dBConfig = new DBConfig();
            if (model != null)
            {
                dBConfig.SetUpdate(model);
            }
            if (dBConfig.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            };
            dBConfig.Activate();
        }
        #endregion 数据库配置

        #region 系统配置
        private void ts_SetPath_Click(object sender, EventArgs e)
        {
            SetName setName = new SetName(true);
            var model = SysConfigModel.F_DBInfo;
            if (!string.IsNullOrEmpty(model.Path))
            {
                setName.TValue = model.Path.ConvertString();
            }
            if (setName.ShowDialog() == DialogResult.OK)
            {
                SysConfigModel savePathModel = new SysConfigModel();
                savePathModel.Path = setName.TValue.ConvertString();
                savePathModel.AddOrUpdate();
            }
        }
        #endregion 系统配置

        #region 数据脚本配置
        private void LoadJbTs()
        {
            for (int i = tsddb_DataScript.DropDownItems.Count - 1; i >= 0; i--)
            {
                if (string.IsNullOrEmpty(tsddb_DataScript.DropDownItems[i].Name))
                {
                    tsddb_DataScript.DropDownItems.RemoveAt(i);
                }
            }
            foreach (var item in DataScriptModel.F_DBInfo)
            {
                ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
                toolStripMenuItem.Text = item.Name.ConvertString();
                ToolStripMenuItem Edit = new ToolStripMenuItem();
                Edit.Text = "使用";
                Edit.Tag = item;
                Edit.Click += (sender, e) =>
                {
                    CbConfigClear();
                    var model = ((sender as ToolStripMenuItem).Tag as DataScriptModel);
                    cbx_TableList.Text = model.ZTableName;
                    cbx_TablePk.Text = model.ZTablePk;
                    txt_DbSql.Text = model.Sql;
                    if (model.CbInfo != null && model.CbInfo.Count > 0)
                    {
                        foreach (var i in model.CbInfo)
                        {
                            var pl = StructureControl();
                            (pl.Controls["table"] as DropDownSearch).Text = i.TableName;
                            (pl.Controls["cbzd"] as DropDownSearch).Text = i.CBZD;
                            (pl.Controls["zbzd"] as DropDownSearch).Text = i.ZBZD;
                        }
                    }
                    DataScriptCurrentModel = model;
                };
                ToolStripMenuItem Delete = new ToolStripMenuItem();
                Delete.Text = "删除";
                Delete.Tag = item;
                Delete.Click += (sender, e) =>
                {
                    ((sender as ToolStripMenuItem).Tag as DataScriptModel).Delete();
                    LoadJbTs();
                };
                toolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { Edit, Delete });
                this.tsddb_DataScript.DropDownItems.Add(toolStripMenuItem);
            }
        }
        private void ts_AddDataJb_Click(object sender, EventArgs e)
        {
            if (tcl_tabList.SelectedTab.Name == tbp_DataScript.Name)
            {
                DataScriptCurrentModel = new DataScriptModel();
                CbConfigClear();
            }
        }

        #endregion 数据脚本配置

        #endregion Tool栏db配置加载

        #region 建表
        /// <summary>
        /// 加载面板
        /// </summary>
        private void LoadCreate(DBConfigModel model)
        {
            var dbTable = DBInfo.GetTablesInfo(model.def_DB);
            dgv_TablesDataSource(dbTable);
            DataTable dt = (DataTable)dgv_Column.DataSource;
            if (dt != null)
            {
                dt.Rows.Clear();
                dgv_Column.DataSource = dt;
            }
        }
        private void dgv_TablesDataSource(DataTable dbTable, string str = "")
        {
            var dr = dbTable.NewRow();
            dr[0] = str;
            dbTable.Rows.InsertAt(dr, 0);
            dgv_Tables.DataSource = dbTable;
            dgv_Tables.Tag = dbTable;
        }
        private string dgv_Tables_SelectName = string.Empty;
        private void dgv_Tables_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var flag = dgv_Tables.Rows[e.RowIndex].Cells[0].Value != null && dgv_Tables.Rows[e.RowIndex].Cells[0].Value.ConvertBoolean() ? false : true;
            if (e.RowIndex == 0)
            {
                if (e.ColumnIndex == 0)
                {
                    dgv_Tables.Rows[e.RowIndex].Cells["IsSelection"].Value = flag;
                    for (int i = 1; i < dgv_Tables.Rows.Count; i++)
                    {
                        var item = dgv_Tables.Rows[i];
                        item.Cells["IsSelection"].Value = dgv_Tables.Rows[0].Cells[0].Value;
                    }
                }
                else
                {
                    dgv_Tables.ReadOnly = false;
                    dgv_Tables.Columns["name"].DefaultCellStyle.BackColor = Color.White;
                    DataGridViewCell cell = dgv_Tables.Rows[0].Cells["name"];
                    dgv_Tables.CurrentCell = cell;
                    dgv_Tables.BeginEdit(true);
                }
                return;
            }
            else
            {
                dgv_Tables.ReadOnly = true;
            }
            dgv_Tables.Rows[e.RowIndex].Cells[0].Value = flag;
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
        /// <summary>
        /// 生成脚本
        /// </summary>
        private void TableScript_Generate()
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
                TableScriptLogic.CreateTableSql(list, ts_ts_IsToUpper.Checked);
                MessageBox.Show("生成成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show("生成失败");
            }
        }

        private void dgv_Tables_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (!dgv_Tables.ReadOnly)
            {
                var txtBox = ((TextBox)e.Control);
                txtBox.KeyUp -= new KeyEventHandler(dgv_Tables_KeyUp);
                txtBox.KeyUp += new KeyEventHandler(dgv_Tables_KeyUp);
            }
        }
        private void dgv_Tables_KeyUp(object sender, KeyEventArgs e)
        {
            if (!dgv_Tables.ReadOnly)
            {
                var txtStr = dgv_Tables.CurrentCell.EditedFormattedValue.ConvertString().ToLower();
                for (int i = 1; i < dgv_Tables.Rows.Count; i++)
                {
                    var item = dgv_Tables.Rows[i];
                    item.Visible = true;
                    item.Cells["IsSelection"].Value = false;
                    if (!item.Cells["name"].Value.ConvertString().ToLower().Contains(txtStr))
                    {
                        item.Visible = false;
                    }
                    else
                    {
                        item.Cells["IsSelection"].Value = dgv_Tables.Rows[0].Cells[0].Value;
                    }
                }
            }
        }

        private void dgv_Tables_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgv_Tables.CurrentRow != null)
            {
                dgv_Tables.Rows[0].Tag = "All";
                this.dgv_Tables.CurrentRow.Selected = false;
            }
        }

        private void dgv_Tables_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.Row.Tag.ConvertString().Equals("All"))
            {
                e.Row.Selected = false;
            }
        }
        #endregion 建表

        #region 数据脚本
        /// <summary>
        /// 当前处于活动的model
        /// </summary>
        private DataScriptModel DataScriptCurrentModel { get; set; } = new DataScriptModel();
        private void LoadDataJb(DBConfigModel model)
        {
            var dbTable = DBInfo.GetTablesInfo(model.def_DB);
            cbx_TableList.SetDataSource(dbTable, "name");
            CbConfigClear();
        }
        private DataTable tempData = null;
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
            table.SetDataSource(tempData, "name");
            cbzd.SetDataSource(DBInfo.GetTableInfo_DT(table.Text.ConvertString()), "COLUMN_NAME");
            zbzd.SetDataSource(cbx_TablePk.DataSource, "COLUMN_NAME");
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
                    cbc_kz.SetDataSource(data, "COLUMN_NAME");
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
                    tempData = cbx_TableList.DataSource.Select($" name<>'{cbx_TableList.Text.ConvertString()}'").CopyToDataTable();
                    foreach (var item in pl_CbConfig.Controls)
                    {
                        if (item is Panel)
                        {
                            var _temp = (item as Panel).Controls["zbzd"] as DropDownSearch;
                            _temp.SetDataSource(data, "COLUMN_NAME");
                            _temp.Text = cbx.Text;
                            var _temp2 = (item as Panel).Controls["table"] as DropDownSearch;
                            _temp2.SetDataSource(tempData, "name");
                        }
                    }
                }
            }
        }

        private void CbConfigClear()
        {
            for (int i = pl_CbConfig.Controls.Count - 1; i >= 0; i--)
            {
                var item = pl_CbConfig.Controls[i];
                if (item is Panel)
                {
                    pl_CbConfig.Controls.Remove(item);
                }
            }
            pl_CbConfig.Tag = 0;
            txt_DbSql.Text = string.Empty;
            cbx_TableList.Text = string.Empty;
            cbx_TablePk.Text = string.Empty;
        }
        private void DeleteCbPz(object sender, EventArgs e)
        {
            this.pl_CbConfig.SuspendLayout();
            Button btn = (Button)sender;
            var tag = btn.Parent.Name.ConvertInt32();
            pl_CbConfig.Controls.RemoveByKey(btn.Parent.Name);
            foreach (var item in pl_CbConfig.Controls)
            {
                if (item is Panel pl)
                {
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

        /// <summary>
        /// 生成脚本
        /// </summary>
        private void DataScript_Generate()
        {
            try
            {
                DataScriptModel model = DataScriptCurrentModel;
                model.CbInfo = new List<DataConfig_CbModel>();
                model.ZTableName = cbx_TableList.Text.ConvertString();
                model.ZTablePk = cbx_TablePk.Text.ConvertString();
                model.Sql = txt_DbSql.Text.ConvertString();
                if (!ts_ds_IsTName.Checked)
                {
                    SetName sName = new SetName();
                    sName.TValue = model.Name;
                    if (sName.ShowDialog() == DialogResult.OK)
                    {
                        model.Name = sName.TValue.ConvertString();
                    }
                    else
                    {
                        return;
                    }
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
                DataScriptLogic.GenerateData(model, ts_ds_IsPcZzl.Checked, ts_ds_OneFiled.Checked);
                model.AddOrUpdate();
                MessageBox.Show("生成成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show("生成失败");
            }
        }
        private void tcl_tabList_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbo_db_SelectedIndexChanged(null, null);
        }
        #endregion 数据脚本

    }
}
