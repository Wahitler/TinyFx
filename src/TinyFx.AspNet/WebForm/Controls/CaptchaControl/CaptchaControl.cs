using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Web.UI;
using System.Web;
using System.Web.Routing;
using System.Reflection;
using System.IO;
using TinyFx.Reflection;
using TinyFx.Web;

namespace TinyFx.AspNet.WebForm.Controls
{
    /// <summary>
    /// 验证码控件。负载环境下情必须保证Session共享
    /// </summary>
    [ToolboxData("<{0}:CaptchaControl runat=server></{0}:CaptchaControl>")]
    [DefaultProperty("InputControlId")]
    [Designer(typeof(CaptchaDesigner))]
    [System.Drawing.ToolboxBitmap(typeof(CaptchaControl), "CaptchaControl.bmp")]
    public class CaptchaControl : Image
    {
        #region 注册Handler
        private const string _resourceJs = "TinyFx.AspNet.WebForm.Controls.CaptchaControl.CaptchaControl.js";
        private const string _handlerName = "CaptchaImageHandler.ashx";
        private static Route _handerRoute = new Route(_handlerName, new CaptchaRouteHandler());
        private const string CAPTCHA_SETTINGS = "Captcha Settings";
        private static object _lock = new object();

        static CaptchaControl()
        {
            //注册路由，等同web.config注册
            if (!RouteTable.Routes.Contains(_handerRoute))
            {
                lock (_lock)
                {
                    if (!RouteTable.Routes.Contains(_handerRoute))
                    {
                        RouteTable.Routes.Add(_handerRoute);
                    }
                }
            }
        }
        #endregion

        //验证码配置
        private static HashSet<string> _hasConfigs = new HashSet<string>();

        #region Properties

        /// <summary>
        /// 验证码长度
        /// </summary>
        [Category(CAPTCHA_SETTINGS)]
        [Description("验证码长度"), DefaultValue(4)]
        public int CaptchaLength { get; set; }

        /// <summary>
        /// 验证码范围
        /// </summary>
        [Category(CAPTCHA_SETTINGS)]
        [Description("验证码范围"), DefaultValue("ACDEFGHJKLNPQRTUVXYZ2346789")]
        public string CharsScope { get; set; }

        /// <summary>
        /// 验证码样式
        /// </summary>
        [Category(CAPTCHA_SETTINGS)]
        [Description("验证码样式"), DefaultValue((int)CaptchaImageStyles.Style1)]
        public CaptchaImageStyles ImageStyles { get; set; }

        /// <summary>
        /// 自定义验证码生成类的类型名称
        /// </summary>
        [Category(CAPTCHA_SETTINGS)]
        [Description("自定义验证码生成类的类型名称")]
        public string CaptchaBuilderTypeName { get; set; }

        /// <summary>
        /// 验证码提交最小间隔，0表示不限制，单位秒
        /// </summary>
        [Category(CAPTCHA_SETTINGS)]
        [Description("验证码提交最小间隔，0表示不限制，单位秒"), DefaultValue(5)]
        public int MinInterval { get; set; }

        /// <summary>
        /// 是否区分大小写 true:忽略大小写
        /// </summary>
        [Category(CAPTCHA_SETTINGS)]
        [Description("是否区分大小写 true:忽略大小写"), DefaultValue(true)]
        public bool IgnoreCase { get; set; }

        /// <summary>
        /// 验证码关联的输入控件ID
        /// </summary>
        [Category(CAPTCHA_SETTINGS)]
        [Description("验证码关联的输入控件ID")]
        public string InputControlId { get; set; }

        /// <summary>
        /// 获取或设置验证码关联的刷新控件ID，可为空
        /// </summary>
        [Category(CAPTCHA_SETTINGS)]
        [Description("验证码关联的刷新控件ID")]
        public string RefreshControlId { get; set; }

        /// <summary>
        /// 自动刷新验证码间隔时间（分钟），0表示不刷新
        /// </summary>
        [Category(CAPTCHA_SETTINGS)]
        [Description("验证码关联的刷新控件ID"), DefaultValue(0)]
        public int RefreshInterval { get; set; }

        /// <summary>
        /// 获取或设置 Web 服务器控件的边框宽度。
        /// </summary>
        [Description("获取或设置 Web 服务器控件的边框宽度。"), DefaultValue(0)]
        public override Unit BorderWidth
        {
            get
            {
                return base.BorderWidth;
            }
            set
            {
                base.BorderWidth = value;
            }
        }

        /// <summary>
        /// 获取或设置为要在 TinyFx.Web.Controls.CaptchaControl 控件中显示的验证码图像提供路径的 URL。
        /// </summary>
        [Browsable(false)]
        public override string ImageUrl
        {
            get
            {
                return base.ImageUrl;
            }
        }
        
        /// <summary>
        /// 获取验证的详细结果(需要先执行Validate方法)
        /// </summary>
        [Browsable(false), Description("获取验证的详细结果(需要先执行Validate方法)")]
        public CaptchaValidateResult ValidateResult { get; internal set; }

        /// <summary>
        /// 获取错误消息
        /// </summary>
        [Browsable(false), Description("错误消息")]
        public string ErrorMessage { get; internal set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public CaptchaControl()
        {
            CaptchaLength = 4;
            CharsScope = "ACDEFGHJKLNPQRTUVXYZ2346789";

            IgnoreCase = true;
            ValidateResult = CaptchaValidateResult.Success;
            MinInterval = 5;
            Width = 100;
            Height = 30;
            BorderWidth = 0;
            RefreshInterval = 0;
        }

        #endregion

        #region Utils
        //获得Id
        private string GetId()
        {
            string ret = string.Format("{0}|{1}", this.ID, HttpContext.Current.Request.Url.ToString());
            return StringUtil.ToBase64String(ret);
        }
        //从Id中获取Url
        private static string GetUrlById(string id)
        {
            id = StringUtil.FromBase64String(id);
            return id.Substring(id.IndexOf('|') + 1);
        }
        //访问Url
        private static void ActionUrl(string url)
        {
            UriBuilderEx builder = new UriBuilderEx(url);
            builder.Host = "localhost";
            new TinyFx.Net.HttpGetRequest(builder.ToString()).GetResponse();
        }
        #endregion

        #region CaptchaConfig
        
        //注册验证码配置信息
        private static void SetCachedConfig(string id, CaptchaConfig config)
        {
            HttpContext.Current.Application[id] = config;
        }

        //获取验证码配置信息
        internal static CaptchaConfig GetCachedConfig(string id)
        {
            CaptchaConfig config = HttpContext.Current.Application[id] as CaptchaConfig;
            if (config == null)
            {
                string url = GetUrlById(id);
                ActionUrl(url);
                config = HttpContext.Current.Application[id] as CaptchaConfig;
            }
            return config;
        }

        private CaptchaConfig CreateConfig()
        {
            CaptchaConfig ret = new CaptchaConfig();
            ret.CharsScope = CharsScope.ToArray<char>();
            ret.CaptchaLength = CaptchaLength;
            ret.IgnoreCase = IgnoreCase;
            ret.MinInterval = MinInterval;
            if (string.IsNullOrEmpty(CaptchaBuilderTypeName))
            {
                ret.Builder = CaptchaBuilder.Create(ImageStyles);
            }
            else
            {
                ret.Builder = (CaptchaBuilder)DynamicCompiler.CreateBuilder(CaptchaBuilderTypeName)();
            }
            ret.Builder.Width = int.Parse(Width.Value.ToString());
            ret.Builder.Height = int.Parse(Height.Value.ToString());

            return ret;
        }
        #endregion

        #region CaptchaData
        //Session中存储CaptchaData
        internal static void SetCachedCaptcha(string id, CaptchaData captcha)
        {
            HttpContext.Current.Session[id] = captcha;
        }
        //从Session中获取CaptchaData
        private static CaptchaData GetCachedCaptcha(string id)
        {
            return HttpContext.Current.Session[id] as CaptchaData;
        }
        //Session中移除CaptchaData
        private static void RemoveCachedCaptcha(string id)
        {
            HttpContext.Current.Session.Remove(id);
        }
        #endregion

        #region Validate
        /// <summary>
        /// 输入验证
        /// </summary>
        /// <param name="input">如果为null则使用InputControlId属性关联的控件值</param>
        /// <returns></returns>
        public bool Validate(string input = null)
        {
            //1.控件不可见或禁用
            if (!Visible | !IsEnabled) return true;

            //2.Session已过期或不存在
            string id = GetId();
            CaptchaData captcha = GetCachedCaptcha(id);
            if (captcha == null)
            {
                ValidateResult = CaptchaValidateResult.Timeout;
                ErrorMessage = "验证码已过期。";
                return false;
            }

            //3.验证太频繁
            if (MinInterval > 0)
            {
                if (captcha.RenderedAt.AddSeconds(MinInterval) > DateTime.Now)
                {
                    ValidateResult = CaptchaValidateResult.TooQuickly;
                    ErrorMessage = string.Format("尝试验证太频繁，请最少间隔等待{0}秒。", MinInterval);
                    RemoveCachedCaptcha(id);
                    return false;
                }
            }
            //4.输入不匹配
            input = string.IsNullOrEmpty(input) ? Page.Request.Params[InputControlId] : input;
            if (string.Compare(input, captcha.Code, IgnoreCase) != 0)
            {
                ValidateResult = CaptchaValidateResult.NotMatch;
                ErrorMessage = "验证码不匹配。";
                RemoveCachedCaptcha(id);
                return false;
            }
            //5.正确
            RemoveCachedCaptcha(id);
            return true;
        }

        /// <summary>
        /// 验证码输入验证
        /// </summary>
        /// <param name="id">验证ID,验证码Image的URL中的ID</param>
        /// <param name="input">输入</param>
        /// <returns></returns>
        public static CaptchaValidateResult Validate(string id, string input)
        {
            CaptchaConfig config = GetCachedConfig(id);
            //1.缓存中不存在此验证码ID对应的配置信息
            if (config == null)
            {
                return CaptchaValidateResult.ConfigNotExist;
            }

            CaptchaData captcha = GetCachedCaptcha(id);
            //2.Session已过期或不存在
            if (captcha == null)
            {
                return CaptchaValidateResult.Timeout;
            }

            //3.验证太频繁
            if (captcha.RenderedAt.AddSeconds(config.MinInterval) > DateTime.Now)
                {
                    RemoveCachedCaptcha(id);
                    return CaptchaValidateResult.TooQuickly;
                }
            //4.输入不匹配
            if (string.Compare(input, captcha.Code, config.IgnoreCase) != 0)
            {
                RemoveCachedCaptcha(id);
                return CaptchaValidateResult.NotMatch;
            }
            //5.正确
            RemoveCachedCaptcha(id);
            return CaptchaValidateResult.Success;
        }
        #endregion


        #region Override Methods
        private static string _script = null;
        private static string GetScript()
        {
            if (string.IsNullOrEmpty(_script))
            {
                lock (_lock)
                {
                    if (string.IsNullOrEmpty(_script))
                    {
                        Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(_resourceJs);
                        using (var reader = new StreamReader(stream))
                        {
                            string url = VirtualPathUtility.ToAbsolute("~/" + _handlerName);
                            _script = reader.ReadToEnd().Replace("#CaptchaImageHandler#", url);
                        }
                    }
                }
            }
            return _script;
        }
        /// <summary>
        /// PreRender事件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreRender(EventArgs e)
        {
            string id = GetId();
            if (!_hasConfigs.Contains(id))
            {
                CaptchaConfig config = CreateConfig();
                SetCachedConfig(id, config);
                lock (_lock)
                {
                    if (!_hasConfigs.Contains(id))
                        _hasConfigs.Add(id);
                }
            }

            //添加更新验证码脚本
            string jsKey = "Captcha";
            if (!Page.ClientScript.IsClientScriptBlockRegistered(GetType(), jsKey))
                Page.ClientScript.RegisterClientScriptBlock(GetType(), jsKey, GetScript(), true);

            jsKey = ClientID;
            if (!Page.ClientScript.IsClientScriptBlockRegistered(GetType(), jsKey))
            {
                string script = string.Format("var {0} = new Captcha('{1}', '{2}', '{3}', '{4}');" + Environment.NewLine
                    , ClientID, GetId(), ClientID, this.InputControlId, this.RefreshControlId);
                Page.ClientScript.RegisterClientScriptBlock(GetType(), jsKey, script, true);
            }

            jsKey = "Captcha_Show_" + ClientID;
            if (string.IsNullOrEmpty(base.ImageUrl))
            {
                string script = string.Format("{0}.flash();" + Environment.NewLine, ClientID);
                if (!Page.ClientScript.IsStartupScriptRegistered(GetType(), jsKey))
                    Page.ClientScript.RegisterStartupScript(GetType(), jsKey, script, true);
            }
            // 点击刷新
            if (string.IsNullOrEmpty(RefreshControlId))
                base.Style[HtmlTextWriterStyle.Cursor] = "pointer";
            jsKey = "Captcha_Reg_" + ClientID;
            if (!Page.ClientScript.IsStartupScriptRegistered(GetType(), jsKey))
            {
                string script = string.Format("{0}.regClick({0});" + Environment.NewLine, ClientID);
                Page.ClientScript.RegisterStartupScript(GetType(), jsKey, script, true);
            }
            // 定时刷新
            if (RefreshInterval != 0)
            {
                jsKey = "Captcha_Refresh_" + ClientID;
                string script = string.Format("setInterval('{0}.flash()', {1});" + Environment.NewLine
                        , ClientID, RefreshInterval * 60000);
                if (!Page.ClientScript.IsStartupScriptRegistered(GetType(), jsKey))
                    Page.ClientScript.RegisterStartupScript(GetType(), jsKey, script, true);
            }

            base.OnPreRender(e);
        }

        #endregion
    }

    /// <summary>
    /// 验证码错误类别
    /// </summary>
    public enum CaptchaValidateResult
    {
        /// <summary>
        /// 验证成功
        /// </summary>
        Success = 0,

        /// <summary>
        /// 验证码已过期
        /// </summary>
        Timeout = 1,

        /// <summary>
        /// 验证太频繁
        /// </summary>
        TooQuickly = 2,

        /// <summary>
        /// 验证码不匹配
        /// </summary>
        NotMatch = 3,
        
        /// <summary>
        /// Application中不存在此ID对应的验证码配置信息
        /// </summary>
        ConfigNotExist = 4
    }
}