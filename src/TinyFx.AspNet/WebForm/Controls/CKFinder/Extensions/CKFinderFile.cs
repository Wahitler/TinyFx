using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TinyFx.AspNet.WebForm.Controls
{
    [ToolboxData("<{0}:CKFinderFile runat=server></{0}:CKFinderFile>")]
    public class CKFinderFile : CompositeControl
    {
        //public CKFinderControl CKFinder = new CKFinderControl();
        private System.Web.UI.WebControls.TextBox _textBox;
        private System.Web.UI.HtmlControls.HtmlInputButton _button;
        public override string ClientID => _textBox.ClientID;
        private string SelectActionFunction
        {
            get {
                return $"{CKFinder.CKFinderId}_SelectAction"; 
            }
        }

        public string CKFinderControlId
        {
            get { return ViewState["CKFinderControlId"] as string; }
            set { ViewState["CKFinderControlId"] = value; }
        }
        public CKFinderControl CKFinder
        {
            get {
                return Page.FindControl(CKFinderControlId) as CKFinderControl;
            }
        }

        #region TextBox属性
        /// <summary>
        /// 输入框宽度
        /// </summary>
        [Description("输入框宽度")]
        public override Unit Width
        {
            get
            {
                EnsureChildControls();
                return _textBox.Width;
            }
            set
            {
                EnsureChildControls();
                _textBox.Width = value;
            }
        }

        /// <summary>
        /// 获取或设置文本框CSS类
        /// </summary>
        [Description("获取或设置文本框CSS类")]
        public override string CssClass
        {
            get
            {
                EnsureChildControls();
                return _textBox.CssClass;
            }
            set
            {
                EnsureChildControls();
                _textBox.CssClass = value;
            }
        }

        /// <summary>
        /// 获取样式特性集合
        /// </summary>
        [Description("获取样式特性集合")]
        public new CssStyleCollection Style
        {
            get
            {
                EnsureChildControls();
                return _textBox.Style;
            }
        }
        #endregion
        protected override void OnLoad(EventArgs e)
        {
            CKFinder.SelectActionFunction = SelectActionFunction;
            base.OnLoad(e);
        }
        protected override void RecreateChildControls()
        {
            EnsureChildControls();
        }
        protected override void CreateChildControls()
        {
            this.Controls.Clear();
            //CKFinder = new CKFinderControl();
            //CKFinder.ID = "finder";
            //this.Controls.Add(CKFinder);
            _textBox = new TextBox();
            _textBox.ID = "txt";
            _textBox.ReadOnly = true;
            this.Controls.Add(_textBox);

            _button = new System.Web.UI.HtmlControls.HtmlInputButton();
            _button.ID = "btn";
            _button.Value = "浏览..";
            this.Controls.Add(_button);
        }
        protected override void OnPreRender(EventArgs e)
        {
            var jsKey = ClientID;
            if (!Page.ClientScript.IsClientScriptBlockRegistered(GetType(), jsKey))
                Page.ClientScript.RegisterClientScriptBlock(GetType(), jsKey, GetScript(), true);

            _button.Attributes.Add("onclick",$"{CKFinder.ClientPopupFunction}();");

            base.OnPreRender(e);
        }
        private string GetScript()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"function {SelectActionFunction}(url){{");
            sb.AppendLine($"    document.getElementById('{_textBox.ClientID}').value=url;");
            sb.AppendLine("}");
            return sb.ToString();
        }
        protected override void Render(HtmlTextWriter writer)
        {
            //this.CKFinder.RenderControl(writer);
            this._textBox.RenderControl(writer);
            this._button.RenderControl(writer);
            //base.Render(writer);
        }
    }
}
