using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TinyFx.Windows
{
    /// <summary>
    /// ADSL连接辅助器
    /// </summary>
    public class AdslConnector
    {
        /// <summary>
        /// 宽带连接名
        /// </summary>
        public string ConnectName { get; set; }
        /// <summary>
        /// 账号
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 重连间隔
        /// </summary>
        public int Interval { get; set; } = 3000;
        /// <summary>
        /// 连接
        /// </summary>
        public void Connect()
        {
            var cmd = $"rasdial \"{ConnectName}\" {UserName} {Password}";
            InvokeCmd(cmd);
        }
        /// <summary>
        /// 断开
        /// </summary>
        public void Disconnect()
        {
            var cmd = $"rasdial \"{ConnectName}\" /disconnect";
            InvokeCmd(cmd);
        }
        /// <summary>
        /// 重连
        /// </summary>
        public void Reconnect()
        {
            Disconnect();
            Thread.Sleep(Interval);
            Connect();
        }
        /// <summary>
        /// 执行cmd命令
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        private string InvokeCmd(string cmd)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = "cmd.exe";
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardInput = true;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.CreateNoWindow = true;
            proc.Start();
            proc.StandardInput.WriteLine(cmd);
            proc.StandardInput.WriteLine("exit");
            return proc.StandardOutput.ReadToEnd();
        }
    }

}
