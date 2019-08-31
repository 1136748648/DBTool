using DBLogic.Util;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace FDBIntercross.UserControls
{
    public partial class DropDownSearch : UserControl
    {
        #region 属性
        private DataTable _DataSource = null;
        /// <summary>
        /// 数据源
        /// </summary>
        public DataTable DataSource
        {
            get { return _DataSource; }
        }
        public string ValueMember
        {
            get { return cbx_DropDown.ValueMember; }
            set { cbx_DropDown.ValueMember = value; }
        }
        public string DisplayMember
        {
            get { return cbx_DropDown.DisplayMember; }
            set { cbx_DropDown.DisplayMember = value; }
        }
        public override string Text
        {
            get { return txt_Search.Text; }
            set { txt_Search.Text = value; }
        }
        public bool DroppedDown
        {
            get { return cbx_DropDown.DroppedDown; }
            set { cbx_DropDown.DroppedDown = value; }
        }
        public int SelectedIndex
        {
            get { return cbx_DropDown.SelectedIndex; }
            set { cbx_DropDown.SelectedIndex = value; }
        }
        #endregion 属性

        #region 事件
        public event EventHandler SelectedIndexChanged;
        #endregion 事件

        public DropDownSearch()
        {
            InitializeComponent();
            txt_Search.KeyUp += cbo_db_KeyUp;
            cbx_DropDown.SelectedIndexChanged += (sender, e) => { SelectedIndexChanged?.Invoke(this, e); };
        }
        /// <summary>
        /// 绑定数据
        /// </summary>
        /// <param name="dt">数据</param>
        /// <param name="ValueMember">实际值</param>
        /// <param name="DisplayMember">显示值</param>
        public void SetDataSource(DataTable dt, string ValueMember, string DisplayMember = "")
        {
            this.cbx_DropDown.ValueMember = ValueMember;
            this.cbx_DropDown.DisplayMember = string.IsNullOrEmpty(DisplayMember) ? ValueMember : DisplayMember;
            this._DataSource = dt;
            this.cbx_DropDown.DataSource = dt;
        }
        private void cbo_db_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                var text = this.Text.ConvertString();
                var dt = this._DataSource;
                if (!string.IsNullOrEmpty(text))
                {
                    string name = this.DisplayMember;
                    var dr = dt.Select($" {name} like '%{this.Text.ConvertString()}%'");
                    if (dr.Length > 0)
                    {
                        this.cbx_DropDown.DataSource = dr.CopyToDataTable();
                    }
                    else
                    {
                        this.cbx_DropDown.DataSource = dt.Clone();
                    }
                    this.cbx_DropDown.DroppedDown = true;
                }
                else
                {
                    this.cbx_DropDown.DataSource = dt;
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void DropDownSearch_SizeChanged(object sender, System.EventArgs e)
        {
            txt_Search.Size = new Size(this.Size.Width - 20, this.Size.Height);
        }

        private void cbx_DropDown_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (!txt_Search.Focused)
            {
                txt_Search.Text = cbx_DropDown.Text.ConvertString();
            }
        }
    }
}
