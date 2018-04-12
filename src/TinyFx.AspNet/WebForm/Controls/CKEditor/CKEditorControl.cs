using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TinyFx.AspNet.WebForm.Controls
{
    /// <summary>
    /// CKEditor Asp.net控件
    /// </summary>
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:CKEditorControl runat=server></{0}:CKEditorControl>")]
    [ParseChildren(false)]
    [Designer("TinyFx.AspNet.WebForm.Controls.CKEditorControlDesigner")]
    [System.Drawing.ToolboxBitmap(typeof(CKEditorControl), "CKEditor.bmp")]
    public class CKEditorControl: TextBox, IPostBackDataHandler
    {
        public CKEditorControl()
        {
            base.TextMode = TextBoxMode.MultiLine;
        }

        #region Properties
        private bool _isChanged = false;
        private const string CKEDITOR_BASIC_SETTINGS = "CKEditor Basic Settings";

        [Category(CKEDITOR_BASIC_SETTINGS)]
        [DefaultValue("/scripts/ckeditor")]
        public string BasePath
        {
            get
            {
                object obj = ViewState["BasePath"];
                if (obj == null)
                {
                    obj = System.Configuration.ConfigurationManager.AppSettings["CKeditor:BasePath"];
                    ViewState["BasePath"] = (obj == null ? "/scripts/ckeditor" : (string)obj);
                }
                var value = (string)ViewState["BasePath"];
                return value.TrimEnd('/');
            }
            set
            {
                if (value.EndsWith("/"))
                    value = value.Remove(value.Length - 1);
                ViewState["BasePath"] = value;
            }
        }

        /// <summary>
        /// 配置信息
        /// </summary>
		[Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //[EditorBrowsable(EditorBrowsableState.Never)]
        public CKEditorConfig Config
        {
            get
            {
                if (ViewState["CKEditorConfig"] == null)
                    ViewState["CKEditorConfig"] = new CKEditorConfig();
                return (CKEditorConfig)ViewState["CKEditorConfig"];
            }
            set { ViewState["CKEditorConfig"] = value; }
        }

        /// <summary>
        /// CKEditor的自定义配置字符串
        /// </summary>
        [Category(CKEDITOR_BASIC_SETTINGS)]
        public string ConfigJson
        {
            get
            {
                return Convert.ToString(ViewState["ConfigJson"]);
            }
            set
            {
                ViewState["ConfigJson"] = value;
                Config.IsValid = false;
            }
        }
        #endregion

        #region Override Properties

        [DefaultValue(false)]
        public override bool ReadOnly
        {
            get {
                bool ret = false;
                if (Config.readOnly.HasValue)
                    ret = Config.readOnly.Value;
                return ret;
            } 
            set => Config.readOnly = base.ReadOnly = value;
        }

        /// <summary>
        /// 编辑区域（内容）的高度，相对或绝对的高度。 30px，5em。 注意：不支持百分比单位。30％
        /// </summary>
        [Category(CKEDITOR_BASIC_SETTINGS)]
        [Description("编辑区域（内容）的高度，相对或绝对的高度。 30px，5em。 注意：不支持百分比单位。30％")]
        [DefaultValue(typeof(Unit), "200px")]
        public override Unit Height
        {
            get
            {
                Unit result = new Unit(string.Empty);
                try
                {
                    result = Unit.Parse(Config.height);
                    base.Height = result;
                }
                catch { }
                return result;
            }
            set
            {
                Unit result = new Unit(string.Empty);
                try
                {
                    result = value;
                    base.Height = result;
                }
                catch { }
                Config.height = value.ToString().Replace("px", string.Empty);
            }
        }

        /// <summary>
        /// 编辑器宽度为CSS大小格式或像素整数
        /// </summary>
        [Category(CKEDITOR_BASIC_SETTINGS)]
        [Description("编辑器宽度为CSS大小格式或像素整数")]
        [DefaultValue(typeof(Unit), "100%")]
        public override Unit Width
        {
            get
            {
                Unit result = new Unit(string.Empty);
                try
                {
                    result = Unit.Parse(Config.width);
                    base.Width = result;
                }
                catch { }
                return result;
            }
            set
            {
                Unit result = new Unit(string.Empty);
                try
                {
                    result = value;
                    base.Width = result;
                }
                catch { }
                Config.width = value.ToString().Replace("px", string.Empty);
            }
        }

        [Category(CKEDITOR_BASIC_SETTINGS)]
        public override short TabIndex
        {
            get
            {
                short ret = 0;
                if (Config.tabIndex.HasValue)
                    ret = Config.tabIndex.Value;
                return ret;
            }
            set => Config.tabIndex = value;
        }

        #endregion

        #region Override Method
        public override void Focus()
        {
            base.Focus();
            this.Config.startupFocus = true;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.Config = (ViewState["CKEditorConfig"] != null)
                ? (CKEditorConfig)ViewState["CKEditorConfig"]
                : new CKEditorConfig();
        }
        //private string timestamp = "?t=C6HH5UF";
        private string timestamp = "";
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            string jsfile = $"{this.ResolveUrl(BasePath)}/ckeditor.js"+timestamp;
            if (!Page.ClientScript.IsClientScriptIncludeRegistered(GetType(), "ckeditor.js"))
                Page.ClientScript.RegisterClientScriptInclude(GetType(), "ckeditor.js", jsfile);
            if (!Page.ClientScript.IsStartupScriptRegistered(GetType(), this.ClientID))
                Page.ClientScript.RegisterStartupScript(GetType(), this.ClientID, GetScript(), true);
            if (_isChanged) OnTextChanged(e);
        }
        private string GetScript()
        {
            var sb = new StringBuilder();
            sb.AppendLine("var config = {");
            #region configs
            #region 基础配置
            if (Config.customConfig != null)
                sb.AppendLine($"    customConfig: '{Config.customConfig}',");
            if (Config.readOnly.HasValue)
                sb.AppendLine($"    readOnly: {Config.readOnly.Value.ToString().ToLower()},");
            if (Config.toolbar != null)
                sb.AppendLine($"    toolbar: {Config.toolbar},");
            if (Config.height != null)
                sb.AppendLine($"    height: {Config.height},");
            if (Config.width != null)
                sb.AppendLine($"    width: {Config.width},");
            if (Config.tabIndex.HasValue)
                sb.AppendLine($"    tabIndex: {Config.tabIndex.Value},");
            if (Config.extraPlugins != null)
                sb.AppendLine($"    extraPlugins: '{Config.extraPlugins}',");
            else
            {
                if (Config.Plugins.Count > 0) {
                    var plugins = string.Join(",", Config.Plugins);
                    sb.AppendLine($"    extraPlugins: '{plugins}',");
                }
            }
            if (Config.contentsCss != null)
                sb.AppendLine($"    contentsCss: '{Config.contentsCss}',");
            if (Config.uiColor != null)
                sb.AppendLine($"    uiColor: '{Config.uiColor}',");
            if (Config.language != null)
                sb.AppendLine($"    language: '{Config.language}',");
            if (Config.startupFocus.HasValue)
                sb.AppendLine($"    startupFocus: {Config.startupFocus.Value},");
            #endregion
            #region plugins
            if (Config.codeSnippet_theme != null)
                sb.AppendLine($"    codeSnippet_theme: '{Config.codeSnippet_theme}',");
            if (Config.mathJaxLib != null)
                sb.AppendLine($"    mathJaxLib: '{Config.mathJaxLib}',");
            #endregion
            #region resize
            if (Config.resize_dir != null)
                sb.AppendLine($"    resize_dir: '{Config.resize_dir}',");
            if (Config.resize_minWidth != null)
                sb.AppendLine($"    resize_minWidth: {Config.resize_minWidth},");
            if (Config.resize_minHeight != null)
                sb.AppendLine($"    resize_minHeight: {Config.resize_minHeight},");
            if (Config.resize_maxWidth != null)
                sb.AppendLine($"    resize_maxWidth: {Config.resize_maxWidth},");
            #endregion
            #region autoGrow
            if (Config.autoGrow_minHeight != null)
                sb.AppendLine($"    autoGrow_minHeight: {Config.autoGrow_minHeight},");
            if (Config.autoGrow_maxHeight != null)
                sb.AppendLine($"    autoGrow_maxHeight: {Config.autoGrow_maxHeight},");
            if (Config.autoGrow_bottomSpace != null)
                sb.AppendLine($"    autoGrow_bottomSpace: {Config.autoGrow_bottomSpace},");
            #endregion
            #region ckfinder
            if (Config.filebrowserBrowseUrl != null)
                sb.AppendLine($"    filebrowserBrowseUrl: '{Config.filebrowserBrowseUrl}',");
            if (Config.filebrowserUploadUrl != null)
                sb.AppendLine($"    filebrowserUploadUrl: '{Config.filebrowserUploadUrl}',");
            if (Config.filebrowserImageBrowseUrl != null)
                sb.AppendLine($"    filebrowserImageBrowseUrl: '{Config.filebrowserImageBrowseUrl}',");
            if (Config.filebrowserImageUploadUrl != null)
                sb.AppendLine($"    filebrowserImageUploadUrl: '{Config.filebrowserImageUploadUrl}',");
            if (Config.filebrowserFlashBrowseUrl != null)
                sb.AppendLine($"    filebrowserFlashBrowseUrl: '{Config.filebrowserFlashBrowseUrl}',");
            if (Config.filebrowserFlashUploadUrl != null)
                sb.AppendLine($"    filebrowserFlashUploadUrl: '{Config.filebrowserFlashUploadUrl}',");
            #endregion
            foreach (var key in Config.CustomConfigs.Keys)
            {
                sb.AppendLine($"    {key}: {Config.CustomConfigs[key]},");
            }
            #endregion
            sb.AppendLine("};");
            sb.AppendLine($"CKEDITOR.replace('{this.ClientID}', config);");
            return sb.ToString();
        }
        #endregion
        public void SetupCKFinder(CKFinderControl ckfinder)
        {
            try
            {
                string url = ckfinder.BasePath.EndsWith("/") ? ckfinder.BasePath.TrimEnd('/') : ckfinder.BasePath;
                this.Config.filebrowserBrowseUrl = $"{url}/ckfinder.html?id={ckfinder.CKFinderId}";
                this.Config.filebrowserImageBrowseUrl = $"{url}/ckfinder.html?id={ckfinder.CKFinderId}";
                this.Config.filebrowserFlashBrowseUrl = $"{url}/ckfinder.html?id={ckfinder.CKFinderId}";
                this.Config.filebrowserUploadUrl = $"{url}/core/connector/aspx/connector.aspx?command=QuickUpload&id={ckfinder.CKFinderId}";
                this.Config.filebrowserImageUploadUrl = $"{url}/core/connector/aspx/connector.aspx?command=QuickUpload&id={ckfinder.CKFinderId}";
                this.Config.filebrowserFlashUploadUrl = $"{url}/core/connector/aspx/connector.aspx?command=QuickUpload&id={ckfinder.CKFinderId}";
            }
            catch
            {
                // If the above reflection procedure didn't work, we probably
                // didn't received the apropriate CKEditor type object.
                throw (new ApplicationException("SetupCKEditor expects an CKEditor instance object."));
            }
        }

        #region IPostBackDataHandler

        bool IPostBackDataHandler.LoadPostData(string postDataKey, NameValueCollection postCollection)
        {
            string postedValue = HttpUtility.HtmlDecode(postCollection[postDataKey]);
            if (this.Text != postedValue)
            {
                _isChanged = true;
                this.Text = postedValue;
                return true;
            }
            return false;
        }

        void IPostBackDataHandler.RaisePostDataChangedEvent() { }

        #endregion
    }
}
