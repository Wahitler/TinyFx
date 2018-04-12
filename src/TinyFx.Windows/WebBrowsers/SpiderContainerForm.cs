using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TinyFx.Windows.WebBrowsers
{
    /// <summary>
    /// Spider容器窗口
    /// </summary>
    public partial class SpiderContainerForm : Form
    {
        /// <summary>
        /// Browser
        /// </summary>
        public ExtendedWebBrowser Browser { get; set; }
        /// <summary>
        /// 构造函数
        /// </summary>
        public SpiderContainerForm()
        {
            InitializeComponent();

            ((Bitmap)btnGo.Image).MakeTransparent(Color.Magenta);
        }
        #region Utils
        /// <summary>
        /// 添加WebBrowser控件
        /// </summary>
        /// <param name="control"></param>
        public void AddWebBrowser(System.Windows.Forms.WebBrowser control)
        {
            this.pnlContainer.Controls.Add(control);
            Browser = control as ExtendedWebBrowser;
        }
        /// <summary>
        /// 设置地址
        /// </summary>
        /// <param name="text"></param>
        public void SetAddressText(string text)
        {
            this.txtAddress.Text = text;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        public void SetText(string text)
        {
            this.Text = text;
        }
        /// <summary>
        /// 设置状态文本
        /// </summary>
        /// <param name="text"></param>
        public void SetStatusText(string text)
        {
            this.toolStripStatusLabel.Text = text;
        }
        #endregion

        #region Controls Events
        private void Navigate()
        {
            Browser.Navigate(this.txtAddress.Text);
        }
        private void btnGo_Click(object sender, EventArgs e)
        {
            Navigate();
        }

        private void txtAddress_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                Navigate();
            }
        }
        #endregion

    }
}
