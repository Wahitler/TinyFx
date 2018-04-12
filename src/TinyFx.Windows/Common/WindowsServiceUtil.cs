using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TinyFx.Windows
{
    /// <summary>
    /// Windows 服务操作辅助类
    /// </summary>
    public static class WindowsServiceUtil
    {
        /// <summary>
        /// 判断服务是否存在
        /// </summary>
        /// <param name="serviceName"></param>
        /// <returns></returns>
        public static bool Exist(string serviceName)
        {
            var services = ServiceController.GetServices();
            foreach (var srv in services)
            {
                if (srv.ServiceName == serviceName)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 启动服务
        /// </summary>
        /// <param name="serviceName"></param>
        /// <returns></returns>
        public static bool Start(string serviceName)
        {
            if (!Exist(serviceName)) return false;
            ServiceController service = new ServiceController(serviceName);
            if (service.Status == ServiceControllerStatus.Running) return false;
            if (service.Status == ServiceControllerStatus.StartPending)
            {
                for (int i = 0; i < 30; i++)
                {
                    service.Refresh();
                    Thread.Sleep(1000);
                    if (service.Status == ServiceControllerStatus.Running)
                        return true;
                    if (i == 29)
                        throw new Exception($"Windows服务 {serviceName} 启动超时。");
                }
            }
            service.Start();
            for (int i = 0; i < 30; i++)
            {
                service.Refresh();
                Thread.Sleep(1000);
                if (service.Status == ServiceControllerStatus.Running)
                    return true;
                if (i == 29)
                    throw new Exception($"Windows服务 {serviceName} 启动超时。");
            }
            return false;
        }

        /// <summary>
        /// 停止服务
        /// </summary>
        /// <param name="serviceName"></param>
        /// <returns></returns>
        public static bool Stop(string serviceName)
        {
            if (!Exist(serviceName)) return false;
            ServiceController service = new ServiceController(serviceName);
            if (service.Status != ServiceControllerStatus.Running) return false;
            service.Stop();
            for (int i = 0; i < 30; i++)
            {
                service.Refresh();
                Thread.Sleep(1000);
                if (service.Status == ServiceControllerStatus.Stopped)
                    return true;
                if (i == 29)
                    throw new Exception($"Windows服务 {serviceName} 停止超时。");
            }
            return false;
        }

        /// <summary>
        /// 安装服务
        /// </summary>
        /// <param name="serviceName"></param>
        /// <param name="filePath"></param>
        public static void Install(string serviceName, string filePath)
        {
            IDictionary state = new Hashtable();
            try
            {
                ServiceController service = new ServiceController(serviceName);
                // 服务存在则卸载
                if (Exist(serviceName))
                    UnInstall(serviceName, filePath);
                service.Refresh();
                var installer = new AssemblyInstaller();
                installer.Path = filePath;
                installer.UseNewContext = true;
                installer.Install(state);
                installer.Commit(state);
                installer.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception($"注册Windows服务出现异常:{ex.Message}");
            }
        }

        /// <summary>
        /// 卸载服务
        /// </summary>
        /// <param name="serviceName"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static bool UnInstall(string serviceName, string filePath)
        {
            try
            {
                if (Exist(serviceName)) return false;
                var installer = new AssemblyInstaller();
                installer.UseNewContext = true;
                installer.Path = filePath;
                installer.Uninstall(null);
                installer.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"卸载Windows服务出现异常:{ex.Message}");
            }
        }
    }

}
