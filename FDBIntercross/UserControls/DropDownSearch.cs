using DBLogic.Util;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FDBIntercross.UserControls
{
    public partial class DropDownSearch : UserControl
    {
        #region 属性
        /// <summary>
        /// 数据源
        /// </summary>
        public object DataSource
        {
            get { return cbx_DropDown.DataSource; }
            set { cbx_DropDown.DataSource = value; }
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
        #endregion 属性

        #region 事件
        public new event KeyEventHandler KeyUp;
        public event EventHandler SelectedIndexChanged;
        #endregion 事件

        public DropDownSearch()
        {
            InitializeComponent();
            txt_Search.KeyUp += (sender, e) => { KeyUp?.Invoke(this, e); };
            cbx_DropDown.SelectedIndexChanged += (sender, e) => { SelectedIndexChanged?.Invoke(this, e); };
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
