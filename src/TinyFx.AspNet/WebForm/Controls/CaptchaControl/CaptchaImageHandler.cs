using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.SessionState;
using System.Web.Routing;
using TinyFx.AspNet.WebForm;

namespace TinyFx.AspNet.WebForm.Controls
{
    /// <summary>
    /// 验证码图片生成IHttpHandler
    /// </summary>
    public class CaptchaImageHandler : IHttpHandler, IRequiresSessionState
    {
        /// <summary>
        /// 自定义 HttpHandler 启用 HTTP Web 请求的处理。
        /// </summary>
        /// <param name="context"></param>
        public void ProcessRequest(HttpContext context)
        {
            string id = context.Request.QueryString["id"];
            string input = context.Request.QueryString["input"];

            if (string.IsNullOrEmpty(id))
                WebFormUtil.ResponseFileNotFound();
            //输出验证码
            if (string.IsNullOrEmpty(input))
            {
                CaptchaConfig config = CaptchaControl.GetCachedConfig(id);
                if (config != null)
                {
                    string code = TinyFx.Text.RandomString.Next(config.CharsScope, config.CaptchaLength);
                    CaptchaControl.SetCachedCaptcha(id, new CaptchaData(code));
                    WebFormUtil.ResponseImage(config.Builder.Build(code), context);
                }
                else
                    WebFormUtil.ResponseFileNotFound();
            }
            else { //验证输入的验证码
                var result = CaptchaControl.Validate(id, input);
                context.Response.ClearContent();
                context.Response.Write((int)result);
                //context.Response.End();
                context.ApplicationInstance.CompleteRequest();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsReusable
        {
            get { return true; }
        }
    }

    internal class CaptchaRouteHandler : IRouteHandler
    {
        /// <summary>
        /// 获取处理程序
        /// </summary>
        /// <param name="requestContext"></param>
        /// <returns></returns>
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return new CaptchaImageHandler();
        }
    }

}
