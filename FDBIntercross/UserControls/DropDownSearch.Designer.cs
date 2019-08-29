namespace FDBIntercross.UserControls
{
    partial class DropDownSearch
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.cbx_DropDown = new System.Windows.Forms.ComboBox();
            this.txt_Search = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cbx_DropDown
            // 
            this.cbx_DropDown.BackColor = System.Drawing.SystemColors.Window;
            this.cbx_DropDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbx_DropDown.FormattingEnabled = true;
            this.cbx_DropDown.Location = new System.Drawing.Point(0, 0);
            this.cbx_DropDown.Name = "cbx_DropDown";
            this.cbx_DropDown.Size = new System.Drawing.Size(160, 20);
            this.cbx_DropDown.TabIndex = 0;
            this.cbx_DropDown.SelectedIndexChanged += new System.EventHandler(this.cbx_DropDown_SelectedIndexChanged);
            // 
            // txt_Search
            // 
            this.txt_Search.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Search.Location = new System.Drawing.Point(1, 3);
            this.txt_Search.Name = "txt_Search";
            this.txt_Search.Size = new System.Drawing.Size(140, 14);
            this.txt_Search.TabIndex = 1;
            // 
            // DropDownSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txt_Search);
            this.Controls.Add(this.cbx_DropDown);
            this.Name = "DropDownSearch";
            this.Size = new System.Drawing.Size(160, 20);
            this.SizeChanged += new System.EventHandler(this.DropDownSearch_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbx_DropDown;
        private System.Windows.Forms.TextBox txt_Search;
    }
}
