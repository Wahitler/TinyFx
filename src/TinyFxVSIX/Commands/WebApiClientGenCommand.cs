using System;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.Win32;
using TinyFx.Windows.EnvDTE;
using TinyFx;

namespace TinyFxVSIX
{
    /// <summary>
    /// Command handler
    /// </summary>
    internal sealed class WebApiClientGenCommand
    {
        /// <summary>
        /// Command ID.
        /// </summary>
        public const int CommandId = 4129;

        /// <summary>
        /// Command menu group (command set GUID).
        /// </summary>
        public static readonly Guid CommandSet = new Guid("a2160f06-efff-491b-b3a0-e508db5d8846");

        /// <summary>
        /// VS Package that provides this command, not null.
        /// </summary>
        private readonly Package package;

        /// <summary>
        /// Initializes a new instance of the <see cref="WebApiClientGenCommand"/> class.
        /// Adds our command handlers for menu (commands must exist in the command table file)
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        private WebApiClientGenCommand(Package package)
        {
            if (package == null)
            {
                throw new ArgumentNullException("package");
            }

            this.package = package;

            OleMenuCommandService commandService = this.ServiceProvider.GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
            if (commandService != null)
            {
                var menuCommandID = new CommandID(CommandSet, CommandId);
                var menuItem = new MenuCommand(this.MenuItemCallback, menuCommandID);
                commandService.AddCommand(menuItem);
            }
        }

        /// <summary>
        /// Gets the instance of the command.
        /// </summary>
        public static WebApiClientGenCommand Instance
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the service provider from the owner package.
        /// </summary>
        private IServiceProvider ServiceProvider
        {
            get
            {
                return this.package;
            }
        }

        /// <summary>
        /// Initializes the singleton instance of the command.
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        public static void Initialize(Package package)
        {
            Instance = new WebApiClientGenCommand(package);
        }

        /// <summary>
        /// This function is the callback used to execute the command when the menu item is clicked.
        /// See the constructor to see how the menu item is associated with this function using
        /// OleMenuCommandService service and MenuCommand class.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event args.</param>
        private void MenuItemCallback(object sender, EventArgs e)
        {
            var dte = new EnvDTEWraper(ServiceProvider);
            var dir = Path.GetDirectoryName(dte.ActiveProject.FullName);
            var files = Directory.GetFiles(dir, "*.nswag", SearchOption.AllDirectories);
            string file = null;
            if (files != null && files.Length > 0)
                file = files[0];
            var regValue = Registry.GetValue(@"HKEY_CLASSES_ROOT\NSwagFile\shell\open\command", null, null);
            if (regValue == null)
            {
                string message = $"请安装下载NSwagStudio。https://github.com/RSuter/NSwag";
                string title = "WebApi客户端代码生成";
                VsShellUtilities.ShowMessageBox(
                    this.ServiceProvider,
                    message,
                    title,
                    OLEMSGICON.OLEMSGICON_INFO,
                    OLEMSGBUTTON.OLEMSGBUTTON_OK,
                    OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST);
            }
            else
            {
                var path = Convert.ToString(regValue).TrimEnd(" \"%1\"").Trim('"');
                var process = new Process();
                process.StartInfo.FileName = path;
                process.StartInfo.Arguments = file;
                process.StartInfo.UseShellExecute = true;
                process.Start();
            }

            /*
            string args = GetArgs(dte);
            var vsVer = dte.DTE.RegistryRoot.Substring(dte.DTE.RegistryRoot.LastIndexOf("\\") + 1);
            var vsixPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\microsoft\\visualstudio\\{vsVer}\\Extensions\\Company\\TinyFxVSIX\\{GetVsixVer()}";
            var process = new Process();
            process.StartInfo.FileName = $"{vsixPath}\\TinyFxVSIX.Commands.WebApiClientGen.exe";
            process.StartInfo.Arguments = GetArgs(dte);
            process.StartInfo.UseShellExecute = true;
            process.Start();
            */
        }
        private string GetArgs(EnvDTEWraper dte)
        {
            var project = dte.ActiveProject;
            var path = Path.GetDirectoryName(project.FullName);
            string argument1 = "\"" + Path.Combine(path, "bin") + "\"";
            string argument2 = "\"" + Path.Combine(path, "output") + "\"";
            return $"{Path.Combine(path, "bin")} {Path.Combine(path, "output")}";
        }
        private string GetVsixVer()
        {
            var vsixVer = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            return $"{vsixVer.Major}.{vsixVer.Minor}";
        }
    }
}
