using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Reflection;
using System.IO;
using System.Drawing;

namespace TinyFx.AspNet.WebForm.Controls
{
    /// <summary>
    /// Flash嵌入控件
    /// </summary>
    [DefaultProperty("SwfUrl")]
    [ToolboxData("<{0}:SwfObject runat=server></{0}:SwfObject>")]
    [Designer(typeof(SwfObjectDesigner))]
    [ParseChildren(true)]
    [PersistChildren(false)]
    [ToolboxBitmap(typeof(SwfObject), "SwfObject.bmp")]
    public class SwfObject : CompositeControl
    {
        private const string _resourceJs = "TinyFx.AspNet.WebForm.Controls.SwfObject.swfobject.js";
        private const string SWFOBJECT_SETTINGS = "SwfObject Settings";
        #region Properties
        /// <summary>
        /// SWF路径
        /// </summary>
        [Category(SWFOBJECT_SETTINGS)]
        [Description("SWF路径")]
        [Editor(typeof(System.Web.UI.Design.UrlEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string SwfUrl { get; set; }

        /// <summary>
        /// SWF的宽度,单位px
        /// </summary>
        [Category(SWFOBJECT_SETTINGS)]
        [Description("SWF的宽度")]
        public Unit SwfWidth { get; set; }

        /// <summary>
        /// SWF的高度,单位px
        /// </summary>
        [Category(SWFOBJECT_SETTINGS)]
        [Description("SWF的高度")]
        public Unit SwfHeight { get; set; }

        /// <summary>
        /// 所需的flash版本
        /// </summary>
        [Category(SWFOBJECT_SETTINGS)]
        [Description("所需的flash版本")]
        public string FlashVersion { get; set; }

        /// <summary>
        /// 是否自动安装Flash
        /// </summary>
        [Category(SWFOBJECT_SETTINGS)]
        [Description("是否自动安装Flash")]
        public bool ExpressInstall { get; set; }

        /// <summary>
        /// flashvars参数设置
        /// </summary>
        [Category(SWFOBJECT_SETTINGS)]
        [Description("flashvars参数设置")]
        public Dictionary<string, string> FlashVars { get; internal set; }

        /// <summary>
        /// flash player控件的内联参数设置
        /// </summary>
        [Category(SWFOBJECT_SETTINGS)]
        [Description("flash player控件的内联参数设置")]
        public Dictionary<string, string> FlashParams { get; internal set; }

        /// <summary>
        /// flash player控件的属性值设置
        /// </summary>
        [Category(SWFOBJECT_SETTINGS)]
        [Description("flash player控件的属性值设置")]
        public Dictionary<string, string> FlashAttributes { get; internal set; }

        #endregion

        /// <summary>
        /// 构造函数
        /// </summary>
        public SwfObject()
        {
            FlashVersion = "7";
            ExpressInstall = false;
            FlashVars = new Dictionary<string, string>();
            FlashParams = new Dictionary<string, string>();
            FlashAttributes = new Dictionary<string, string>();
        }

        #region Override Methods

        private static string _script = null;
        private static object _lock = new object();
        private static string GetScript()
        {
            if (string.IsNullOrEmpty(_script))
            {
                lock (_lock)
                {
                    if (string.IsNullOrEmpty(_script))
                    {
                        _script = Reflection.ReflectionUtil.GetManifestResourceString(Assembly.GetExecutingAssembly(), _resourceJs);
                    }
                }
            }
            return _script;
        }
        /// <summary>
        /// 引发PreRender事件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreRender(EventArgs e)
        {
            string jsKey = "swfobject.js";
            if (!Page.ClientScript.IsClientScriptBlockRegistered(GetType(), jsKey))
                Page.ClientScript.RegisterClientScriptBlock(GetType(), jsKey, GetScript(), true);
            base.OnPreRender(e);
        }
        /// <summary>
        /// Render
        /// </summary>
        /// <param name="writer"></param>
        protected override void Render(HtmlTextWriter writer)
        {
            string contentId = this.ClientID;
            //

            writer.WriteLine("<div id=\"{0}\"><a href=\"http://www.adobe.com/go/getflash\"><img src=\"http://www.adobe.com/images/shared/download_buttons/get_flash_player.gif\" alt=\"获得 Adobe Flash Player\" /></a><p>此页要求 Flash Player 版本 10或更高版本。</p></div>", contentId);
            writer.WriteLineNoTabs("<script language=\"javascript\" type=\"text/javascript\">");
            writer.WriteLineNoTabs("(function () {");
            writer.WriteLine("document.getElementById(\"{0}\").innerHTML = \"<a href='http://www.adobe.com/go/getflashplayer'><img src='http://www.adobe.com/images/shared/download_buttons/get_flash_player.gif' alt='Get Adobe Flash player' /></a>\";", contentId);
            // flashvars
            writer.WriteLine("var flashvars = {};");
            foreach (KeyValuePair<string, string> item in FlashVars)
            {
                writer.WriteLine("flashvars.{0} = '{1}';", item.Key, item.Value);
            }
            // params
            writer.WriteLine("var params = {};");
            foreach (KeyValuePair<string, string> item in FlashParams)
            {
                writer.WriteLine("params.{0} = '{1}';", item.Key, item.Value);
            }
            // attributes
            writer.WriteLine("var attributes = {};");
            foreach (KeyValuePair<string, string> item in FlashAttributes)
            {
                writer.WriteLine("attributes.{0} = '{1}';", item.Key, item.Value);
            }
            //
            string url = string.Empty;
            if (ExpressInstall)
                //url = WebControlsPathProvider.GetPath("SwfObject/expressInstall.swf");
            //else
                url = "";
            writer.WriteLine("swfobject.embedSWF('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', flashvars, params, attributes);"
                , ResolveUrl(SwfUrl), contentId, SwfWidth, SwfHeight, FlashVersion, url);
            writer.WriteLine("})();");
            writer.WriteLine("</script>");
        }

        #endregion
    }
}
