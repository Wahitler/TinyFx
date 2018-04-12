using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TinyFx.Windows
{
    /// <summary>
    /// Windows相关辅助类
    /// </summary>
    public static class WindowsUtil
    {
        /// <summary>
        /// 运行命令行语句并返回程序输出
        /// </summary>
        /// <param name="commandText"></param>
        /// <returns></returns>
        public static string RunCommand(string commandText)
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;

            string strOutput = null;
            p.Start();
            p.StandardInput.WriteLine(commandText);
            p.StandardInput.WriteLine("exit");
            strOutput = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            p.Close();

            return strOutput;
        }

        /// <summary>
        /// GAC注册DLL
        /// </summary>
        /// <param name="dll"></param>
        /// <returns></returns>
        public static bool GacInstall(string dll)
        {
            var assembly = Assembly.LoadFrom(dll);
            var publish = new System.EnterpriseServices.Internal.Publish();
            if (RuntimeEnvironment.FromGlobalAccessCache(assembly))
                publish.GacRemove(dll);
            publish.GacInstall(dll);
            return RuntimeEnvironment.FromGlobalAccessCache(assembly);
        }

        #region IE设置
        /// <summary>
        /// 清除IE缓存
        /// </summary>
        /// <param name="traces"></param>
        public static void ClearIETraces(IEMyTraces traces = IEMyTraces.DeleteAll)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = "RunDll32.exe";
            proc.StartInfo.Arguments = string.Format("InetCpl.cpl,ClearMyTracksByProcess {0}", traces);
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardInput = true;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.CreateNoWindow = false;
            proc.Start();
        }

        /// <summary>
        /// 设置IE代理服务器
        /// </summary>
        /// <param name="ip">代理服务器IP</param>
        /// <param name="port">代理服务器端口</param>
        public static void SetIEProxy(string ip, int port)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Internet Settings", true);
            //设置代理可用
            key.SetValue("ProxyEnable", 1);
            //设置代理IP和端口
            key.SetValue("ProxyServer", string.Format("{0}:{1}", ip, port));
            key.Close();
        }

        /// <summary>
        /// 清除IE代理服务器设置
        /// </summary>
        public static void ClearIEProxy()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Internet Settings", true);
            //设置代理可用
            key.SetValue("ProxyEnable", 0);
            key.Close();
        }
        #endregion
    }
    /// <summary>
    /// IE缓存项
    /// </summary>
    public enum IEMyTraces
    {
        /// <summary>
        /// 临时文件
        /// </summary>
        TemporaryFiles = 8,
        /// <summary>
        /// Cookies
        /// </summary>
        Cookies = 2,
        /// <summary>
        /// 历史
        /// </summary>
        History = 1,
        /// <summary>
        /// 表单
        /// </summary>
        FormData = 16,
        /// <summary>
        /// 密码
        /// </summary>
        Passwords = 32,
        /// <summary>
        /// 删除全部
        /// </summary>
        DeleteAll = 255,
        /// <summary>
        /// 删除全部和插件
        /// </summary>
        DeleteAllAndAddOns = 4351
    }

}
