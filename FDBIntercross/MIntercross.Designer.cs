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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsddb_DBSet = new System.Windows.Forms.ToolStripDropDownButton();
            this.ts_Add = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbo_db = new System.Windows.Forms.ComboBox();
            this.cbo_dbset = new System.Windows.Forms.ComboBox();
            this.tcl_tabList = new System.Windows.Forms.TabControl();
            this.tbp_Create = new System.Windows.Forms.TabPage();
            this.btn_Path = new System.Windows.Forms.Button();
            this.btn_Generate = new System.Windows.Forms.Button();
            this.txt_Path = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgv_Tables = new System.Windows.Forms.DataGridView();
            this.IsSelection = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.表名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_Column = new System.Windows.Forms.DataGridView();
            this.COLUMN_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DATA_TYPE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COLUMN_DEFAULT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsIdentity = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IS_NULLABLE = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsKey = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.toolStrip1.SuspendLayout();
            this.tcl_tabList.SuspendLayout();
            this.tbp_Create.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Tables)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Column)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsddb_DBSet});
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
            this.tcl_tabList.Size = new System.Drawing.Size(990, 458);
            this.tcl_tabList.TabIndex = 6;
            // 
            // tbp_Create
            // 
            this.tbp_Create.Controls.Add(this.btn_Path);
            this.tbp_Create.Controls.Add(this.btn_Generate);
            this.tbp_Create.Controls.Add(this.txt_Path);
            this.tbp_Create.Controls.Add(this.label3);
            this.tbp_Create.Controls.Add(this.splitContainer1);
            this.tbp_Create.Location = new System.Drawing.Point(4, 22);
            this.tbp_Create.Name = "tbp_Create";
            this.tbp_Create.Padding = new System.Windows.Forms.Padding(3);
            this.tbp_Create.Size = new System.Drawing.Size(982, 432);
            this.tbp_Create.TabIndex = 0;
            this.tbp_Create.Text = "建表";
            this.tbp_Create.UseVisualStyleBackColor = true;
            this.tbp_Create.Click += new System.EventHandler(this.tbp_Create_Click);
            // 
            // btn_Path
            // 
            this.btn_Path.Location = new System.Drawing.Point(631, 16);
            this.btn_Path.Name = "btn_Path";
            this.btn_Path.Size = new System.Drawing.Size(100, 25);
            this.btn_Path.TabIndex = 5;
            this.btn_Path.Text = "请选择文件夹";
            this.btn_Path.UseVisualStyleBackColor = true;
            this.btn_Path.Click += new System.EventHandler(this.btn_Path_Click);
            // 
            // btn_Generate
            // 
            this.btn_Generate.Location = new System.Drawing.Point(749, 16);
            this.btn_Generate.Name = "btn_Generate";
            this.btn_Generate.Size = new System.Drawing.Size(100, 25);
            this.btn_Generate.TabIndex = 4;
            this.btn_Generate.Text = "生成表脚本";
            this.btn_Generate.UseVisualStyleBackColor = true;
            this.btn_Generate.Click += new System.EventHandler(this.btn_Generate_Click);
            // 
            // txt_Path
            // 
            this.txt_Path.Location = new System.Drawing.Point(98, 18);
            this.txt_Path.Name = "txt_Path";
            this.txt_Path.Size = new System.Drawing.Size(504, 21);
            this.txt_Path.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "保存路径:";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitContainer1.Location = new System.Drawing.Point(3, 61);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgv_Tables);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgv_Column);
            this.splitContainer1.Size = new System.Drawing.Size(976, 368);
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
            this.表名});
            this.dgv_Tables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Tables.Location = new System.Drawing.Point(0, 0);
            this.dgv_Tables.Name = "dgv_Tables";
            this.dgv_Tables.ReadOnly = true;
            this.dgv_Tables.RowHeadersVisible = false;
            this.dgv_Tables.RowTemplate.Height = 23;
            this.dgv_Tables.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Tables.Size = new System.Drawing.Size(323, 368);
            this.dgv_Tables.TabIndex = 0;
            this.dgv_Tables.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Tables_CellContentDoubleClick);
            // 
            // IsSelection
            // 
            this.IsSelection.HeaderText = "选择";
            this.IsSelection.Name = "IsSelection";
            this.IsSelection.ReadOnly = true;
            this.IsSelection.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsSelection.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IsSelection.Width = 50;
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
            this.dgv_Column.Size = new System.Drawing.Size(649, 368);
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
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(982, 432);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // MIntercross
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 566);
            this.Controls.Add(this.tcl_tabList);
            this.Controls.Add(this.cbo_dbset);
            this.Controls.Add(this.cbo_db);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MIntercross";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Intercross";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MIntercross_FormClosing);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tcl_tabList.ResumeLayout(false);
            this.tbp_Create.ResumeLayout(false);
            this.tbp_Create.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Tables)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Column)).EndInit();
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
        private System.Windows.Forms.DataGridView dgv_Column;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btn_Path;
        private System.Windows.Forms.Button btn_Generate;
        private System.Windows.Forms.TextBox txt_Path;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn COLUMN_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn DATA_TYPE;
        private System.Windows.Forms.DataGridViewTextBoxColumn COLUMN_DEFAULT;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsIdentity;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IS_NULLABLE;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsKey;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsSelection;
        private System.Windows.Forms.DataGridViewTextBoxColumn 表名;
    }
}

