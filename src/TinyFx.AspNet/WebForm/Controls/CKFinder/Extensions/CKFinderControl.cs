using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;

namespace TinyFx.AspNet.WebForm.Controls
{
    [ToolboxData("<{0}:CKFinderControl runat=server></{0}:CKFinderControl>")]
    public class CKFinderControl:System.Web.UI.Control
    {
        #region Properties
        /// <summary>
        /// CKFinder 默认客户端路径
        /// </summary>
        public string CKFINDER_DEFAULT_BASEPATH => ResolveClientUrl("~/scripts/ckfinder/");
        /// <summary>
        /// 保存在客户端Cookie的ConfigFile配置信息：
        ///     CKFinderId:ConnectorTypeName1|CKFinderId:ConnectorTypeName1
        /// </summary>
        public const string CKFINDER_COOKIE_NAME = "CKFinder_Configs";
        private const string CKFINDER_BASIC_SETTINGS = "CKFinder Basic Settings";
        public const string CKFINDER_CONFIG_DEFAULT = "TinyFx.AspNet.WebForm.Controls.CKFinder.DefaultConfigFile";

        [Category(CKFINDER_BASIC_SETTINGS)]
        public string CKFinderId
        {
            get
            {
                object o = ViewState["CKFinderId"];
                if (o == null)
                {
                    string value = "CK_" + Security.SecurityUtil.MD5Hash($"{HttpContext.Current.Request.Path}_{this.ClientID}", null, Security.CipherEncode.Hex);
                    ViewState["CKFinderId"] = value;
                }
                return ViewState["CKFinderId"] as string;
            }
            set { ViewState["CKFinderId"] = value; }
        }

        /// <summary>
        /// CKFinder客户端文件所在路径。如: /scripts/ckfinder/
        /// 搜索顺序：用户自定义 => AppSettings["CKFinder:BasePath"] => 默认："/ckfinder/"
        /// </summary>
        [Category(CKFINDER_BASIC_SETTINGS)]
        public string BasePath
        {
            get
            {
                object o = ViewState["BasePath"];
                if (o == null)
                    o = ConfigurationManager.AppSettings["CKFinder:BasePath"];
                
                return (o == null ? CKFINDER_DEFAULT_BASEPATH : (string)o);
            }
            set
            {
                var path = value;
                if (value.StartsWith("~/"))
                    path = ResolveClientUrl(path);
                ViewState["BasePath"] = path;
            }
        }
        /// <summary>
        /// 默认起始路径
        /// </summary>
        [Category(CKFINDER_BASIC_SETTINGS)]
        public string StartupPath
        {
            get { return ViewState["StartupPath"] as string; }
            set { ViewState["StartupPath"] = value; }
        }
        /// <summary>
        /// 选择文件后调用的JS函数名
        /// </summary>
        [Category(CKFINDER_BASIC_SETTINGS)]
        public string SelectActionFunction
        {
            get { return ViewState["SelectActionFunction"] as string; }
            set { ViewState["SelectActionFunction"] = value; }
        }
        /// <summary>
        /// 选择文件后调用JS函数时传入的第二个参数
        /// </summary>
        [Category(CKFINDER_BASIC_SETTINGS)]
        public string SelectActionData
        {
            get { return ViewState["SelectActionData"] as string; }
            set { ViewState["SelectActionData"] = value; }
        }

        [Category(CKFINDER_BASIC_SETTINGS)]
        public string SelectThumbnailActionFunction
        {
            get { return ViewState["SelectThumbnailActionFunction"] as string; }
            set { ViewState["SelectThumbnailActionFunction"] = value; }
        }
        /*
        public string SelectThumbnailFunctionData
        {
            get { return ViewState["SelectThumbnailFunctionData"] as string; }
            set { ViewState["SelectThumbnailFunctionData"] = value; }
        }
        public bool DisableThumbnailSelection
        {
            get { return ViewState["DisableThumbnailSelection"] == null ? false : (bool)ViewState["DisableThumbnailSelection"]; }
            set { ViewState["DisableThumbnailSelection"] = value; }
        }
        */

        /// <summary>
        /// 
        /// </summary>
        [Category(CKFINDER_BASIC_SETTINGS)]
        public string ResourceType
        {
            get { return ViewState["ResourceType"] as string; }
            set { ViewState["ResourceType"] = value; }
        }
        [Category(CKFINDER_BASIC_SETTINGS)]
        [DefaultValue(true)]
        public bool RememberLastFolder
        {
            get { return ViewState["RememberLastFolder"] == null ? true : (bool)ViewState["RememberLastFolder"]; }
            set { ViewState["RememberLastFolder"] = value; }
        }

        [Category(CKFINDER_BASIC_SETTINGS)]
        [DefaultValue(true)]
        public bool StartupFolderExpanded
        {
            get { return ViewState["StartupFolderExpanded"] == null ? false : (bool)ViewState["StartupFolderExpanded"]; }
            set { ViewState["StartupFolderExpanded"] = value; }
        }
        /// <summary>
        /// 对应的配置文件类名称,必须定义
        /// </summary>
        [Category(CKFINDER_BASIC_SETTINGS)]
        [DefaultValue(CKFINDER_CONFIG_DEFAULT)]
        public string ConfigFileTypeName
        {
            get { return ViewState["ConfigFileTypeName"] as string; }
            set { ViewState["ConfigFileTypeName"] = value; }
        }
        /// <summary>
        /// 浏览的服务器基础路径
        /// </summary>
        [Category(CKFINDER_BASIC_SETTINGS)]
        public string ServerBaseUrl
        {
            get { return ViewState["ServerBaseUrl"] as string; }
            set { ViewState["ServerBaseUrl"] = value; }
        }
        /// <summary>
        /// 允许显示上传的文件扩展名
        /// </summary>
        public string AllowedExtensions
        {
            get { return ViewState["AllowedExtensions"] as string; }
            set { ViewState["AllowedExtensions"] = value; }
        }
        /// <summary>
        /// 隐藏的目录名
        /// </summary>
        public string HideFolders
        {
            get { return ViewState["HideFolders"] as string; }
            set { ViewState["HideFolders"] = value; }
        }
        [DefaultValue(1000)]
        [Category(CKFINDER_BASIC_SETTINGS)]
        public string Width
        {
            get { return ViewState["Width"] as string; }
            set { ViewState["Width"] = value; }
        }
        [DefaultValue(700)]
        [Category(CKFINDER_BASIC_SETTINGS)]
        public string Height
        {
            get { return ViewState["Height"] as string; }
            set { ViewState["Height"] = value; }
        }
        /// <summary>
        /// 客户端获取CKFinder配置的js方法名
        /// </summary>
        public string ClientCKFinderFunction => $"{this.CKFinderId}_CKFinder";
        public string ClientPopupFunction => $"{this.CKFinderId}_Popup";
        //public string ClientWidgetFunction => $"{this.CKFinderId}_Widget";
        //public string ClientSetupCKEditorFunction => $"{this.CKFinderId}_SetupCKEditor";
        #endregion

        protected override void OnPreRender(EventArgs e)
        {
            var jsCkfinder = "ckfinder.js";
            if (!Page.ClientScript.IsClientScriptIncludeRegistered(jsCkfinder))
                Page.ClientScript.RegisterClientScriptInclude(GetType(), jsCkfinder, $"{BasePath}ckfinder.js");
            var jsKey = CKFinderId;
            if (!Page.ClientScript.IsClientScriptBlockRegistered(GetType(), jsKey))
                Page.ClientScript.RegisterClientScriptBlock(GetType(), jsKey, GetScript(), true);
            SetCookie();
            base.OnPreRender(e);
        }

        private void SetCookie()
        {
            //string key = "CK_" + Security.SecurityUtil.MD5Hash($"{HttpContext.Current.Request.Path}_{this.ClientID}", null, Security.CipherEncode.Hex);
            var cookies = HttpContext.Current.Request.Cookies;
            var cookie = cookies[CKFINDER_COOKIE_NAME] ?? new HttpCookie(CKFINDER_COOKIE_NAME);
            var serverPath = ServerBaseUrl;
            if (ServerBaseUrl.StartsWith("~/"))
                serverPath = HttpContext.Current.Request.ApplicationPath + ServerBaseUrl.TrimStart("~");
            cookie.Values[CKFinderId] = $"{ConfigFileTypeName}|{serverPath}|{AllowedExtensions}|{HideFolders}" ;
            HttpContext.Current.Response.AppendCookie(cookie);
        }
        private string GetScript()
        {
            // ClientCKFinderFunction
            var sb = new StringBuilder();
            sb.AppendLine($"function {ClientCKFinderFunction}(){{");
            sb.AppendLine("    var finder = new CKFinder();");
            sb.AppendLine($"    finder.id = '{CKFinderId}';");
            sb.AppendLine($"    finder.basePath = '{BasePath}';");
            if (!string.IsNullOrEmpty(StartupPath))
                sb.AppendLine($"    finder.startupPath = '{StartupPath}';");
            if (!string.IsNullOrEmpty(ResourceType))
                sb.AppendLine($"    finder.resourceType = '{ResourceType}';");
            sb.AppendLine($"    finder.rememberLastFolder = {RememberLastFolder.ToString().ToLower()};");
            sb.AppendLine($"    finder.startupFolderExpanded = {StartupFolderExpanded.ToString().ToLower()};");
            if (!string.IsNullOrEmpty(SelectActionFunction))
                sb.AppendLine($"    finder.selectActionFunction = {SelectActionFunction};");
            if (!string.IsNullOrEmpty(SelectActionData))
                sb.AppendLine($"    finder.selectActionData = {SelectActionData};");
            if (!string.IsNullOrEmpty(SelectThumbnailActionFunction))
                sb.AppendLine($"    finder.selectThumbnailActionFunction = {SelectThumbnailActionFunction};");
            sb.AppendLine("    return finder;");
            sb.AppendLine("}");
            // ClientPopupFunction
            sb.AppendLine($"function {ClientPopupFunction}(){{");
            sb.AppendLine("    var config = {};");
            if (!string.IsNullOrEmpty(Width))
            {
                if (int.TryParse(Width, out int width))
                    sb.AppendLine($"    config.width = {Width};");
                else
                    sb.AppendLine($"    config.width = '{Width}';");
            }
            if (!string.IsNullOrEmpty(Height))
            {
                if (int.TryParse(Height, out int height))
                    sb.AppendLine($"    config.height = {Height};");
                else
                    sb.AppendLine($"    config.height = '{Height}';");
            }
            sb.AppendLine($"    return {ClientCKFinderFunction}().popup(config);");
            sb.AppendLine("}");
            //sb.AppendLine($"function {ClientWidgetFunction}(id){{ return {ClientCKFinderFunction}().modal(); }}");
            //sb.AppendLine($"function {ClientSetupCKEditorFunction}(ckeditor){{ return {ClientSetupCKEditorFunction}().setupCKEditor(ckeditor); }}");
            return sb.ToString();
        }
    }
}
