using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TinyFx.Log4net;
using TinyFx.Configuration;
using System.Web.Configuration;
using System.Configuration;

namespace TinyFx.AspNet.WebForm
{
    /// <summary>
    /// 未处理异常类 HttpModule
    /// 用于处理程序中未处理的异常
    /// </summary>
    public class UnhandledExceptionModule //: IHttpModule
    {
        private static object _lock = new object();
        private static bool _initialized = false;
        private static ITinyLog _logger = null;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        public void Init(HttpApplication app)
        {
            if (!_initialized)
            {
                lock (_lock)
                {
                    if (!_initialized)
                    {
                        _logger = LogUtil.GetDefaultLogger();
                        app.Error += new EventHandler(app_Error);
                        //AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(OnUnhandledException);
                        _initialized = true;
                    }
                }
            }
        }

        private void app_Error(object sender, EventArgs e)
        {
            DoException(((HttpApplication)sender).Server.GetLastError());
        }

        private void OnUnhandledException(object o, UnhandledExceptionEventArgs e)
        {
            DoException(e.ExceptionObject as Exception);
        }

        private void DoException(Exception exp)
        {
            if (_logger == null) return;
            exp = ExceptionUtil.GetFirstException(exp);
            _logger.Error("WEB未处理异常。", exp);
        }
        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        { }

        private static bool _isRegistered = false;

        /// <summary>
        /// 修改配置文件注册IHttpModule
        /// </summary>
        public static void RegisterModule()
        {
            if (_isRegistered) return;
            System.Configuration.Configuration config = WebConfigurationManager.OpenWebConfiguration("~/");
            if (config != null)
            {
                HttpModulesSection section = (HttpModulesSection)config.GetSection("system.web/httpModules");
                if (section == null)
                {
                    section = new HttpModulesSection();
                    ConfigurationSectionGroup group = config.GetSectionGroup("system.web");
                    if (group == null)
                    {
                        config.SectionGroups.Add("system.web", new ConfigurationSectionGroup());
                    }
                    group.Sections.Add("httpModules", section);
                }
                foreach (HttpModuleAction action in section.Modules)
                {
                    if (string.Equals(action.Name, "UnhandledException", StringComparison.CurrentCultureIgnoreCase))
                    {
                        _isRegistered = true;
                        return;
                    }
                }
                section.Modules.Add(new HttpModuleAction("UnhandledException", typeof(UnhandledExceptionModule).AssemblyQualifiedName));
                config.Save(ConfigurationSaveMode.Minimal);
            }
            _isRegistered = true;
        }
    }

}
