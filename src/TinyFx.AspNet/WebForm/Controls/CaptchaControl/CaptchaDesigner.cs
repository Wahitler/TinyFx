using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.Design;
using System.Security.Permissions;
using System.Configuration;
using System.Web.Configuration;
using System.IO;

namespace TinyFx.AspNet.WebForm.Controls
{
    /// <summary>
    /// 设计时样式
    /// </summary>
    [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode)]
    public class CaptchaDesigner : ControlDesigner
    {
        private void RegisterHandler()
        {
            IWebApplication web = (IWebApplication)this.GetService(typeof(IWebApplication));
            System.Configuration.Configuration config = web.OpenWebConfiguration(false);
            if (config != null)
            {
                HttpHandlersSection section = (HttpHandlersSection)config.GetSection("system.web/httpHandlers");
                if (section == null)
                {
                    section = new HttpHandlersSection();
                    ConfigurationSectionGroup group = config.GetSectionGroup("system.web");
                    if (group == null)
                    {
                        config.SectionGroups.Add("system.web", new ConfigurationSectionGroup());
                    }
                    group.Sections.Add("httpHandlers", section);
                }
                section.Handlers.Add(new HttpHandlerAction("CaptchaImage.aspx", typeof(CaptchaImageHandler).AssemblyQualifiedName, "GET"));
                config.Save(ConfigurationSaveMode.Minimal);
            }
        }

        private bool IsRegistered()
        {
            IWebApplication web = (IWebApplication)this.GetService(typeof(IWebApplication));
            System.Configuration.Configuration config = web.OpenWebConfiguration(true);
            if (config != null)
            {
                HttpHandlersSection section = (HttpHandlersSection)config.GetSection("system.web/httpHandlers");
                if (section != null)
                {
                    foreach (HttpHandlerAction item in section.Handlers)
                    {
                        if (string.Equals(item.Path, "CaptchaImage.aspx", StringComparison.CurrentCultureIgnoreCase))
                            return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// 获取设计时样式
        /// </summary>
        /// <returns></returns>
        public override string GetDesignTimeHtml()
        {
            //if (!IsRegistered() && MessageBox.Show("是否自动在web.config中自动注册控件需要的HttpHandler。", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            //    RegisterHandler();
            return base.GetDesignTimeHtml();
        }
    }
}
