﻿namespace FDBIntercross
{
    partial class MIntercross
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MIntercross));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsddb_DBSet = new System.Windows.Forms.ToolStripDropDownButton();
            this.ts_Add = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsddb_TableScript = new System.Windows.Forms.ToolStripDropDownButton();
            this.ts_ts_IsToUpper = new System.Windows.Forms.ToolStripMenuItem();
            this.tsddb_DataScript = new System.Windows.Forms.ToolStripDropDownButton();
            this.ts_ds_IsPcZzl = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_ds_IsTName = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_ds_OneFiled = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ts_ds_AddDataJb = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSplitButton3 = new System.Windows.Forms.ToolStripDropDownButton();
            this.ts_SetPath = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbo_db = new System.Windows.Forms.ComboBox();
            this.cbo_dbset = new System.Windows.Forms.ComboBox();
            this.tcl_tabList = new System.Windows.Forms.TabControl();
            this.tbp_TableScript = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgv_Tables = new System.Windows.Forms.DataGridView();
            this.IsSelection = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_Column = new System.Windows.Forms.DataGridView();
            this.COLUMN_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DATA_TYPE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COLUMN_DEFAULT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsIdentity = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IS_NULLABLE = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsKey = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tbp_DataScript = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_AddConfig = new System.Windows.Forms.Button();
            this.pl_CbConfig = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_DbSql = new System.Windows.Forms.TextBox();
            this.cbx_TablePk = new FDBIntercross.UserControls.DropDownSearch();
            this.label7 = new System.Windows.Forms.Label();
            this.cbx_TableList = new FDBIntercross.UserControls.DropDownSearch();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_GenerateData = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.toolStrip1.SuspendLayout();
            this.tcl_tabList.SuspendLayout();
            this.tbp_TableScript.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Tables)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Column)).BeginInit();
            this.tbp_DataScript.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.pl_CbConfig.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsddb_DBSet,
            this.tsddb_TableScript,
            this.tsddb_DataScript,
            this.toolStripSplitButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1014, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsddb_DBSet
            // 
            this.tsddb_DBSet.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsddb_DBSet.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_Add,
            this.toolStripSeparator1});
            this.tsddb_DBSet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsddb_DBSet.Name = "tsddb_DBSet";
            this.tsddb_DBSet.Size = new System.Drawing.Size(81, 22);
            this.tsddb_DBSet.Text = "数据库配置";
            // 
            // ts_Add
            // 
            this.ts_Add.Name = "ts_Add";
            this.ts_Add.Size = new System.Drawing.Size(124, 22);
            this.ts_Add.Tag = "default";
            this.ts_Add.Text = "新增配置";
            this.ts_Add.Click += new System.EventHandler(this.ts_Add_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(121, 6);
            this.toolStripSeparator1.Tag = "default";
            // 
            // tsddb_TableScript
            // 
            this.tsddb_TableScript.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsddb_TableScript.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_ts_IsToUpper});
            this.tsddb_TableScript.Image = ((System.Drawing.Image)(resources.GetObject("tsddb_TableScript.Image")));
            this.tsddb_TableScript.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsddb_TableScript.Name = "tsddb_TableScript";
            this.tsddb_TableScript.Size = new System.Drawing.Size(81, 22);
            this.tsddb_TableScript.Text = "表脚本配置";
            // 
            // ts_ts_IsToUpper
            // 
            this.ts_ts_IsToUpper.CheckOnClick = true;
            this.ts_ts_IsToUpper.Name = "ts_ts_IsToUpper";
            this.ts_ts_IsToUpper.Size = new System.Drawing.Size(160, 22);
            this.ts_ts_IsToUpper.Text = "列名称是否大写";
            // 
            // tsddb_DataScript
            // 
            this.tsddb_DataScript.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsddb_DataScript.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_ds_IsPcZzl,
            this.ts_ds_IsTName,
            this.ts_ds_OneFiled,
            this.toolStripSeparator2,
            this.ts_ds_AddDataJb});
            this.tsddb_DataScript.Image = ((System.Drawing.Image)(resources.GetObject("tsddb_DataScript.Image")));
            this.tsddb_DataScript.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsddb_DataScript.Name = "tsddb_DataScript";
            this.tsddb_DataScript.Size = new System.Drawing.Size(93, 22);
            this.tsddb_DataScript.Text = "数据脚本配置";
            // 
            // ts_ds_IsPcZzl
            // 
            this.ts_ds_IsPcZzl.CheckOnClick = true;
            this.ts_ds_IsPcZzl.Name = "ts_ds_IsPcZzl";
            this.ts_ds_IsPcZzl.Size = new System.Drawing.Size(148, 22);
            this.ts_ds_IsPcZzl.Text = "排除自增列";
            // 
            // ts_ds_IsTName
            // 
            this.ts_ds_IsTName.CheckOnClick = true;
            this.ts_ds_IsTName.Name = "ts_ds_IsTName";
            this.ts_ds_IsTName.Size = new System.Drawing.Size(148, 22);
            this.ts_ds_IsTName.Text = "表名为文件名";
            // 
            // ts_ds_OneFiled
            // 
            this.ts_ds_OneFiled.Checked = true;
            this.ts_ds_OneFiled.CheckOnClick = true;
            this.ts_ds_OneFiled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ts_ds_OneFiled.Name = "ts_ds_OneFiled";
            this.ts_ds_OneFiled.Size = new System.Drawing.Size(148, 22);
            this.ts_ds_OneFiled.Text = "生成一个文件";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(145, 6);
            // 
            // ts_ds_AddDataJb
            // 
            this.ts_ds_AddDataJb.Name = "ts_ds_AddDataJb";
            this.ts_ds_AddDataJb.Size = new System.Drawing.Size(148, 22);
            this.ts_ds_AddDataJb.Text = "新建数据脚本";
            this.ts_ds_AddDataJb.Click += new System.EventHandler(this.ts_AddDataJb_Click);
            // 
            // toolStripSplitButton3
            // 
            this.toolStripSplitButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSplitButton3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_SetPath});
            this.toolStripSplitButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton3.Image")));
            this.toolStripSplitButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton3.Name = "toolStripSplitButton3";
            this.toolStripSplitButton3.Size = new System.Drawing.Size(69, 22);
            this.toolStripSplitButton3.Text = "系统配置";
            // 
            // ts_SetPath
            // 
            this.ts_SetPath.Name = "ts_SetPath";
            this.ts_SetPath.Size = new System.Drawing.Size(148, 22);
            this.ts_SetPath.Text = "文件保存路径";
            this.ts_SetPath.Click += new System.EventHandler(this.ts_SetPath_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "数据库配置:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(268, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "数据库:";
            // 
            // cbo_db
            // 
            this.cbo_db.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_db.FormattingEnabled = true;
            this.cbo_db.Location = new System.Drawing.Point(321, 46);
            this.cbo_db.Name = "cbo_db";
            this.cbo_db.Size = new System.Drawing.Size(165, 20);
            this.cbo_db.TabIndex = 4;
            this.cbo_db.SelectedIndexChanged += new System.EventHandler(this.cbo_db_SelectedIndexChanged);
            // 
            // cbo_dbset
            // 
            this.cbo_dbset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_dbset.FormattingEnabled = true;
            this.cbo_dbset.Location = new System.Drawing.Point(101, 46);
            this.cbo_dbset.Name = "cbo_dbset";
            this.cbo_dbset.Size = new System.Drawing.Size(134, 20);
            this.cbo_dbset.TabIndex = 5;
            this.cbo_dbset.SelectedIndexChanged += new System.EventHandler(this.cbo_dbset_SelectedIndexChanged);
            // 
            // tcl_tabList
            // 
            this.tcl_tabList.Controls.Add(this.tbp_TableScript);
            this.tcl_tabList.Controls.Add(this.tbp_DataScript);
            this.tcl_tabList.Location = new System.Drawing.Point(12, 96);
            this.tcl_tabList.Name = "tcl_tabList";
            this.tcl_tabList.SelectedIndex = 0;
            this.tcl_tabList.Size = new System.Drawing.Size(990, 458);
            this.tcl_tabList.TabIndex = 6;
            this.tcl_tabList.SelectedIndexChanged += new System.EventHandler(this.tcl_tabList_SelectedIndexChanged);
            // 
            // tbp_TableScript
            // 
            this.tbp_TableScript.Controls.Add(this.splitContainer1);
            this.tbp_TableScript.Location = new System.Drawing.Point(4, 22);
            this.tbp_TableScript.Name = "tbp_TableScript";
            this.tbp_TableScript.Padding = new System.Windows.Forms.Padding(3);
            this.tbp_TableScript.Size = new System.Drawing.Size(982, 432);
            this.tbp_TableScript.TabIndex = 0;
            this.tbp_TableScript.Text = "表脚本";
            this.tbp_TableScript.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgv_Tables);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgv_Column);
            this.splitContainer1.Size = new System.Drawing.Size(976, 426);
            this.splitContainer1.SplitterDistance = 323;
            this.splitContainer1.TabIndex = 1;
            // 
            // dgv_Tables
            // 
            this.dgv_Tables.AllowUserToAddRows = false;
            this.dgv_Tables.AllowUserToDeleteRows = false;
            this.dgv_Tables.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgv_Tables.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Tables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Tables.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IsSelection,
            this.name});
            this.dgv_Tables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Tables.Location = new System.Drawing.Point(0, 0);
            this.dgv_Tables.MultiSelect = false;
            this.dgv_Tables.Name = "dgv_Tables";
            this.dgv_Tables.ReadOnly = true;
            this.dgv_Tables.RowHeadersVisible = false;
            this.dgv_Tables.RowTemplate.Height = 23;
            this.dgv_Tables.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Tables.Size = new System.Drawing.Size(323, 426);
            this.dgv_Tables.TabIndex = 0;
            this.dgv_Tables.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Tables_CellContentDoubleClick);
            this.dgv_Tables.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgv_Tables_DataBindingComplete);
            this.dgv_Tables.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgv_Tables_EditingControlShowing);
            this.dgv_Tables.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgv_Tables_RowStateChanged);
            this.dgv_Tables.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgv_Tables_KeyUp);
            // 
            // IsSelection
            // 
            this.IsSelection.HeaderText = "选择";
            this.IsSelection.Name = "IsSelection";
            this.IsSelection.ReadOnly = true;
            this.IsSelection.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsSelection.Width = 50;
            // 
            // name
            // 
            this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "表名";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dgv_Column
            // 
            this.dgv_Column.AllowUserToAddRows = false;
            this.dgv_Column.AllowUserToDeleteRows = false;
            this.dgv_Column.AllowUserToResizeRows = false;
            this.dgv_Column.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Column.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.COLUMN_NAME,
            this.DATA_TYPE,
            this.COLUMN_DEFAULT,
            this.IsIdentity,
            this.IS_NULLABLE,
            this.IsKey});
            this.dgv_Column.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Column.Location = new System.Drawing.Point(0, 0);
            this.dgv_Column.MultiSelect = false;
            this.dgv_Column.Name = "dgv_Column";
            this.dgv_Column.ReadOnly = true;
            this.dgv_Column.RowHeadersVisible = false;
            this.dgv_Column.RowTemplate.Height = 23;
            this.dgv_Column.Size = new System.Drawing.Size(649, 426);
            this.dgv_Column.TabIndex = 0;
            // 
            // COLUMN_NAME
            // 
            this.COLUMN_NAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.COLUMN_NAME.DataPropertyName = "COLUMN_NAME";
            this.COLUMN_NAME.HeaderText = "字段名称";
            this.COLUMN_NAME.Name = "COLUMN_NAME";
            this.COLUMN_NAME.ReadOnly = true;
            // 
            // DATA_TYPE
            // 
            this.DATA_TYPE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DATA_TYPE.DataPropertyName = "DATA_TYPE";
            this.DATA_TYPE.HeaderText = "类型";
            this.DATA_TYPE.Name = "DATA_TYPE";
            this.DATA_TYPE.ReadOnly = true;
            // 
            // COLUMN_DEFAULT
            // 
            this.COLUMN_DEFAULT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.COLUMN_DEFAULT.DataPropertyName = "COLUMN_DEFAULT";
            this.COLUMN_DEFAULT.HeaderText = "默认值";
            this.COLUMN_DEFAULT.Name = "COLUMN_DEFAULT";
            this.COLUMN_DEFAULT.ReadOnly = true;
            // 
            // IsIdentity
            // 
            this.IsIdentity.HeaderText = "是否自增";
            this.IsIdentity.Name = "IsIdentity";
            this.IsIdentity.ReadOnly = true;
            this.IsIdentity.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsIdentity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // IS_NULLABLE
            // 
            this.IS_NULLABLE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.IS_NULLABLE.DataPropertyName = "IS_NULLABLE";
            this.IS_NULLABLE.HeaderText = "是否可空";
            this.IS_NULLABLE.Name = "IS_NULLABLE";
            this.IS_NULLABLE.ReadOnly = true;
            this.IS_NULLABLE.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IS_NULLABLE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // IsKey
            // 
            this.IsKey.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.IsKey.DataPropertyName = "IsKey";
            this.IsKey.HeaderText = "是否主键";
            this.IsKey.Name = "IsKey";
            this.IsKey.ReadOnly = true;
            this.IsKey.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsKey.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // tbp_DataScript
            // 
            this.tbp_DataScript.Controls.Add(this.groupBox2);
            this.tbp_DataScript.Controls.Add(this.groupBox1);
            this.tbp_DataScript.Location = new System.Drawing.Point(4, 22);
            this.tbp_DataScript.Name = "tbp_DataScript";
            this.tbp_DataScript.Padding = new System.Windows.Forms.Padding(3);
            this.tbp_DataScript.Size = new System.Drawing.Size(982, 432);
            this.tbp_DataScript.TabIndex = 1;
            this.tbp_DataScript.Text = "数据脚本";
            this.tbp_DataScript.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_AddConfig);
            this.groupBox2.Controls.Add(this.pl_CbConfig);
            this.groupBox2.Location = new System.Drawing.Point(381, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(600, 426);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "从表";
            // 
            // btn_AddConfig
            // 
            this.btn_AddConfig.Location = new System.Drawing.Point(6, 395);
            this.btn_AddConfig.Name = "btn_AddConfig";
            this.btn_AddConfig.Size = new System.Drawing.Size(588, 23);
            this.btn_AddConfig.TabIndex = 1;
            this.btn_AddConfig.Text = "新增";
            this.btn_AddConfig.UseVisualStyleBackColor = true;
            this.btn_AddConfig.Click += new System.EventHandler(this.btn_AddConfig_Click);
            // 
            // pl_CbConfig
            // 
            this.pl_CbConfig.AutoScroll = true;
            this.pl_CbConfig.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pl_CbConfig.Controls.Add(this.label11);
            this.pl_CbConfig.Controls.Add(this.label10);
            this.pl_CbConfig.Controls.Add(this.label9);
            this.pl_CbConfig.Location = new System.Drawing.Point(6, 20);
            this.pl_CbConfig.Name = "pl_CbConfig";
            this.pl_CbConfig.Size = new System.Drawing.Size(588, 369);
            this.pl_CbConfig.TabIndex = 0;
            this.pl_CbConfig.Tag = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(388, 15);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 3;
            this.label11.Text = "主表字段";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(273, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 2;
            this.label10.Text = "从表字段";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(100, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "从表名称";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txt_DbSql);
            this.groupBox1.Controls.Add(this.cbx_TablePk);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cbx_TableList);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(0, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(375, 426);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "主表";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(28, 115);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 5;
            this.label8.Text = "查询Sql:";
            // 
            // txt_DbSql
            // 
            this.txt_DbSql.Location = new System.Drawing.Point(28, 148);
            this.txt_DbSql.Multiline = true;
            this.txt_DbSql.Name = "txt_DbSql";
            this.txt_DbSql.Size = new System.Drawing.Size(329, 255);
            this.txt_DbSql.TabIndex = 4;
            // 
            // cbx_TablePk
            // 
            this.cbx_TablePk.DisplayMember = "";
            this.cbx_TablePk.DroppedDown = false;
            this.cbx_TablePk.Location = new System.Drawing.Point(85, 76);
            this.cbx_TablePk.Name = "cbx_TablePk";
            this.cbx_TablePk.SelectedIndex = -1;
            this.cbx_TablePk.Size = new System.Drawing.Size(258, 20);
            this.cbx_TablePk.TabIndex = 3;
            this.cbx_TablePk.ValueMember = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 12);
            this.label7.TabIndex = 2;
            this.label7.Text = "主键:";
            // 
            // cbx_TableList
            // 
            this.cbx_TableList.DisplayMember = "";
            this.cbx_TableList.DroppedDown = false;
            this.cbx_TableList.Location = new System.Drawing.Point(85, 36);
            this.cbx_TableList.Name = "cbx_TableList";
            this.cbx_TableList.SelectedIndex = -1;
            this.cbx_TableList.Size = new System.Drawing.Size(258, 20);
            this.cbx_TableList.TabIndex = 1;
            this.cbx_TableList.ValueMember = "";
            this.cbx_TableList.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "表名:";
            // 
            // btn_GenerateData
            // 
            this.btn_GenerateData.Location = new System.Drawing.Point(569, 45);
            this.btn_GenerateData.Name = "btn_GenerateData";
            this.btn_GenerateData.Size = new System.Drawing.Size(90, 23);
            this.btn_GenerateData.TabIndex = 7;
            this.btn_GenerateData.Text = "生成脚本";
            this.btn_GenerateData.UseVisualStyleBackColor = true;
            this.btn_GenerateData.Click += new System.EventHandler(this.btn_GenerateData_Click);
            // 
            // MIntercross
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 566);
            this.Controls.Add(this.btn_GenerateData);
            this.Controls.Add(this.tcl_tabList);
            this.Controls.Add(this.cbo_dbset);
            this.Controls.Add(this.cbo_db);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MIntercross";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Intercross";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MIntercross_FormClosing);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tcl_tabList.ResumeLayout(false);
            this.tbp_TableScript.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Tables)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Column)).EndInit();
            this.tbp_DataScript.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.pl_CbConfig.ResumeLayout(false);
            this.pl_CbConfig.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton tsddb_DBSet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbo_db;
        private System.Windows.Forms.ComboBox cbo_dbset;
        private System.Windows.Forms.TabControl tcl_tabList;
        private System.Windows.Forms.TabPage tbp_TableScript;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgv_Tables;
        private System.Windows.Forms.TabPage tbp_DataScript;
        private System.Windows.Forms.ToolStripMenuItem ts_Add;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.DataGridView dgv_Column;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataGridViewTextBoxColumn COLUMN_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn DATA_TYPE;
        private System.Windows.Forms.DataGridViewTextBoxColumn COLUMN_DEFAULT;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsIdentity;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IS_NULLABLE;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsKey;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_GenerateData;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_DbSql;
        private UserControls.DropDownSearch cbx_TablePk;
        private System.Windows.Forms.Label label7;
        private UserControls.DropDownSearch cbx_TableList;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_AddConfig;
        private System.Windows.Forms.Panel pl_CbConfig;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsSelection;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.ToolStripDropDownButton tsddb_TableScript;
        private System.Windows.Forms.ToolStripMenuItem ts_ts_IsToUpper;
        private System.Windows.Forms.ToolStripDropDownButton tsddb_DataScript;
        private System.Windows.Forms.ToolStripMenuItem ts_ds_IsPcZzl;
        private System.Windows.Forms.ToolStripMenuItem ts_ds_IsTName;
        private System.Windows.Forms.ToolStripMenuItem ts_ds_OneFiled;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem ts_ds_AddDataJb;
        private System.Windows.Forms.ToolStripDropDownButton toolStripSplitButton3;
        private System.Windows.Forms.ToolStripMenuItem ts_SetPath;
    }
}

