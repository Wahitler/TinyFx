using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace TinyFx.Net
{
    /// <summary>
    /// SmtpClient封装扩展
    /// </summary>
    public class SmtpClientEx: SmtpClient
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="host"></param>
        /// <param name="port"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public SmtpClientEx(string host, int port, string userName=null, string password=null)
        {
            Host = host;
            Port = port;
            EnableSsl = true;
            Credentials = new NetworkCredential(userName, password);
        }
    }
}
