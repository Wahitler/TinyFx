using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx.Configuration;
using Topshelf;
using System.IO;
using TinyFx.Log4net;

namespace TinyFx.Windows.Extensions.Topshelf
{
    public static class TopshelfUtil
    {
        /// <summary>
        /// 运行服务
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serviceName"></param>
        /// <returns></returns>
        public static TopshelfExitCode Run<T>(string serviceName = null)
            where T :class, ServiceControl, new()
        {
            return HostFactory.Run(x=> {
                var logConfigFile = TinyFxConfigFile.Log4netConfig;
                if (!string.IsNullOrEmpty(logConfigFile) && File.Exists(logConfigFile))
                    x.UseLog4Net(logConfigFile); // log4net配置文件
                x.Service<T>();
                x.RunAsLocalSystem(); // 安装成本地服务
                x.StartAutomatically(); // 自动启动
                if (string.IsNullOrEmpty(serviceName))
                    x.UseAssemblyInfoForServiceInfo(); // 设置服务名等从AssemblyInfo中获取
                else
                {
                    x.SetServiceName(serviceName); // 服务名
                    x.SetDisplayName(serviceName);// 服务显示名
                    x.SetDescription($"通过Topshelf安装的服务: {serviceName}"); // 服务描述
                }
                // 恢复机制
                x.EnableServiceRecovery(r => {
                    r.RestartService(3);
                    //r.RestartComputer();
                    r.OnCrashOnly();
                    r.SetResetPeriod(2);
                });
                // 异常处理
                x.OnException(ex => {
                    LogUtil.Error("Topshelf的服务出现异常。", ex);
                });
            });
        }
    }
}
