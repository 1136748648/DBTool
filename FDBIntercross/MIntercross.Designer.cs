namespace FDBIntercross
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
            this.components = new System.ComponentModel.Container();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsddb_DBSet = new System.Windows.Forms.ToolStripDropDownButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbo_db = new System.Windows.Forms.ComboBox();
            this.cbo_dbset = new System.Windows.Forms.ComboBox();
            this.tcl_tabList = new System.Windows.Forms.TabControl();
            this.tbp_Create = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgv_Tables = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ts_Add = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.表名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_Column = new System.Windows.Forms.DataGridView();
            this.COLUMN_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DATA_TYPE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IS_NULLABLE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COLUMN_DEFAULT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.cms_Tables = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.tcl_tabList.SuspendLayout();
            this.tbp_Create.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Tables)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Column)).BeginInit();
            this.cms_Tables.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsddb_DBSet});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(874, 25);
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
            this.cbo_db.FormattingEnabled = true;
            this.cbo_db.Location = new System.Drawing.Point(321, 47);
            this.cbo_db.Name = "cbo_db";
            this.cbo_db.Size = new System.Drawing.Size(165, 20);
            this.cbo_db.TabIndex = 4;
            this.cbo_db.SelectedIndexChanged += new System.EventHandler(this.cbo_db_SelectedIndexChanged);
            // 
            // cbo_dbset
            // 
            this.cbo_dbset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_dbset.FormattingEnabled = true;
            this.cbo_dbset.Location = new System.Drawing.Point(101, 47);
            this.cbo_dbset.Name = "cbo_dbset";
            this.cbo_dbset.Size = new System.Drawing.Size(134, 20);
            this.cbo_dbset.TabIndex = 5;
            this.cbo_dbset.SelectedIndexChanged += new System.EventHandler(this.cbo_dbset_SelectedIndexChanged);
            // 
            // tcl_tabList
            // 
            this.tcl_tabList.Controls.Add(this.tbp_Create);
            this.tcl_tabList.Controls.Add(this.tabPage2);
            this.tcl_tabList.Location = new System.Drawing.Point(12, 96);
            this.tcl_tabList.Name = "tcl_tabList";
            this.tcl_tabList.SelectedIndex = 0;
            this.tcl_tabList.Size = new System.Drawing.Size(850, 458);
            this.tcl_tabList.TabIndex = 6;
            // 
            // tbp_Create
            // 
            this.tbp_Create.Controls.Add(this.splitContainer1);
            this.tbp_Create.Location = new System.Drawing.Point(4, 22);
            this.tbp_Create.Name = "tbp_Create";
            this.tbp_Create.Padding = new System.Windows.Forms.Padding(3);
            this.tbp_Create.Size = new System.Drawing.Size(842, 432);
            this.tbp_Create.TabIndex = 0;
            this.tbp_Create.Text = "建表";
            this.tbp_Create.UseVisualStyleBackColor = true;
            this.tbp_Create.Click += new System.EventHandler(this.tbp_Create_Click);
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
            this.splitContainer1.Size = new System.Drawing.Size(836, 426);
            this.splitContainer1.SplitterDistance = 277;
            this.splitContainer1.TabIndex = 1;
            // 
            // dgv_Tables
            // 
            this.dgv_Tables.AllowUserToAddRows = false;
            this.dgv_Tables.AllowUserToDeleteRows = false;
            this.dgv_Tables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Tables.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.表名});
            this.dgv_Tables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Tables.Location = new System.Drawing.Point(0, 0);
            this.dgv_Tables.Name = "dgv_Tables";
            this.dgv_Tables.ReadOnly = true;
            this.dgv_Tables.RowTemplate.Height = 23;
            this.dgv_Tables.Size = new System.Drawing.Size(277, 426);
            this.dgv_Tables.TabIndex = 0;
            this.dgv_Tables.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Tables_CellContentDoubleClick);
            this.dgv_Tables.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_Tables_CellMouseDown);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(497, 296);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ts_Add
            // 
            this.ts_Add.Name = "ts_Add";
            this.ts_Add.Size = new System.Drawing.Size(180, 22);
            this.ts_Add.Tag = "default";
            this.ts_Add.Text = "新增配置";
            this.ts_Add.Click += new System.EventHandler(this.ts_Add_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            this.toolStripSeparator1.Tag = "default";
            // 
            // 表名
            // 
            this.表名.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.表名.DataPropertyName = "name";
            this.表名.HeaderText = "表名";
            this.表名.Name = "表名";
            this.表名.ReadOnly = true;
            // 
            // dgv_Column
            // 
            this.dgv_Column.AllowUserToAddRows = false;
            this.dgv_Column.AllowUserToDeleteRows = false;
            this.dgv_Column.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Column.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.COLUMN_NAME,
            this.DATA_TYPE,
            this.IS_NULLABLE,
            this.COLUMN_DEFAULT,
            this.IsKey});
            this.dgv_Column.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Column.Location = new System.Drawing.Point(0, 0);
            this.dgv_Column.Name = "dgv_Column";
            this.dgv_Column.ReadOnly = true;
            this.dgv_Column.RowTemplate.Height = 23;
            this.dgv_Column.Size = new System.Drawing.Size(555, 426);
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
            // IS_NULLABLE
            // 
            this.IS_NULLABLE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.IS_NULLABLE.DataPropertyName = "IS_NULLABLE";
            this.IS_NULLABLE.HeaderText = "是否可空";
            this.IS_NULLABLE.Name = "IS_NULLABLE";
            this.IS_NULLABLE.ReadOnly = true;
            // 
            // COLUMN_DEFAULT
            // 
            this.COLUMN_DEFAULT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.COLUMN_DEFAULT.DataPropertyName = "COLUMN_DEFAULT";
            this.COLUMN_DEFAULT.HeaderText = "默认值";
            this.COLUMN_DEFAULT.Name = "COLUMN_DEFAULT";
            this.COLUMN_DEFAULT.ReadOnly = true;
            // 
            // IsKey
            // 
            this.IsKey.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.IsKey.DataPropertyName = "IsKey";
            this.IsKey.HeaderText = "是否主键";
            this.IsKey.Name = "IsKey";
            this.IsKey.ReadOnly = true;
            // 
            // cms_Tables
            // 
            this.cms_Tables.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.cms_Tables.Name = "cms_Tables";
            this.cms_Tables.Size = new System.Drawing.Size(181, 48);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem1.Text = "生成表脚本";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // MIntercross
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 566);
            this.Controls.Add(this.tcl_tabList);
            this.Controls.Add(this.cbo_dbset);
            this.Controls.Add(this.cbo_db);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "MIntercross";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Intercross";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MIntercross_FormClosing);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tcl_tabList.ResumeLayout(false);
            this.tbp_Create.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Tables)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Column)).EndInit();
            this.cms_Tables.ResumeLayout(false);
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
        private System.Windows.Forms.TabPage tbp_Create;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgv_Tables;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ToolStripMenuItem ts_Add;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 表名;
        private System.Windows.Forms.DataGridView dgv_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn COLUMN_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn DATA_TYPE;
        private System.Windows.Forms.DataGridViewTextBoxColumn IS_NULLABLE;
        private System.Windows.Forms.DataGridViewTextBoxColumn COLUMN_DEFAULT;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsKey;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ContextMenuStrip cms_Tables;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}

