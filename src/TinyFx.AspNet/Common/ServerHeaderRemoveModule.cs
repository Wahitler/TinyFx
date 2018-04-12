using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TinyFx.AspNet
{
    /// <summary>
    /// 移除ServerHeader
    /// </summary>
    public class ServerHeaderRemoveModule : IHttpModule
    {
        public void Dispose()
        {

        }

        public void Init(HttpApplication context)
        {
            context.PreSendRequestHeaders += Context_PreSendRequestHeaders;
        }

        private void Context_PreSendRequestHeaders(object sender, EventArgs e)
        {
            if (HttpContext.Current != null)
                HttpContext.Current.Response.Headers.Remove("Server");
        }
    }

}
