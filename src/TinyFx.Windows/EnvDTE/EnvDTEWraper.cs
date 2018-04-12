using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using EnvDTE;
using EnvDTE80;
using VSLangProj;

namespace TinyFx.Windows.EnvDTE
{
    /// <summary>
    /// DTE封装
    ///     DTE -> Solution -> Projects -> Project -> ProjectItems -> ProjectItem -> FileCodeModel -> CodeElements
    /// </summary>
    public class EnvDTEWraper
    {
        #region Constructors
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="provider"></param>
        public EnvDTEWraper(IServiceProvider provider)
        {
            DTE = (DTE2)provider.GetService(typeof(DTE));
        }
        /// <summary>
        /// 通过解决方案名称获取DTE，注意同一个解决方案只能打开一个，否则只能获取第一个
        /// </summary>
        /// <param name="solutionName">解决方案文件全路径名称或者解决方案名称</param>
        public EnvDTEWraper(string solutionName)
        {
            var fullPath = solutionName.Contains(".sln");
            foreach (var dte in EnvDTEWraper.GetAllDTE())
            {
                if (fullPath)
                {
                    if (dte.Solution.FileName.ToLower() == solutionName.ToLower())
                    {
                        DTE = dte as DTE2;
                        break;
                    }
                }
                else
                {
                    try
                    {
                        foreach (Property prop in dte.Solution.Properties)
                        {
                            if (prop.Name == "Name")
                            {
                                if (Convert.ToString(prop.Value) == solutionName)
                                    DTE = dte as DTE2;
                                break;
                            }
                        }
                    }
                    catch { }
                    if (DTE != null) break;
                }
            }
            if (DTE == null)
                throw new Exception("未知的solutionName，请指定全路径解决方案名称。");
        }
        /// <summary>
        /// 如果打开多个，无法确定具体打开的那个VS，不建议使用
        /// </summary>
        /// <param name="progID"></param>
        public EnvDTEWraper(VSProgID progID)
        {
            string progId = null;
            switch (progID)
            {
                case VSProgID.VS2010:
                    progId = "VisualStudio.DTE.10.0";
                    break;
                case VSProgID.VS2012:
                    progId = "VisualStudio.DTE.11.0";
                    break;
                case VSProgID.VS2013:
                    progId = "VisualStudio.DTE.12.0";
                    break;
                case VSProgID.VS2015:
                    progId = "VisualStudio.DTE.14.0";
                    break;
                case VSProgID.VS2017:
                    progId = "VisualStudio.DTE.15.0";
                    break;
            }
            if (progId == null)
                throw new Exception("不可识别的 VSProgID。");

            DTE = (EnvDTE80.DTE2)Marshal.GetActiveObject(progId);
            if (DTE == null)
                throw new Exception("未找到当前DET");
        }

        public EnvDTEWraper(DTE dte)
        {
            DTE = (DTE2)dte;
        }

        /// <summary>
        /// 获取所有DTE
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<DTE2> GetAllDTE()
        {
            List<DTE2> ret = new List<DTE2>();
            GetRunningObjectTable(0, out IRunningObjectTable rot);
            rot.EnumRunning(out IEnumMoniker enumMoniker);

            enumMoniker.Reset();
            IntPtr fetched = IntPtr.Zero;
            IMoniker[] moniker = new IMoniker[1];
            while (enumMoniker.Next(1, moniker, fetched) == 0)
            {
                CreateBindCtx(0, out IBindCtx bindCtx);
                moniker[0].GetDisplayName(bindCtx, null, out string displayName);
                if (displayName.StartsWith("!VisualStudio.DTE."))
                {
                    rot.GetObject(moniker[0], out object comObject);
                    ret.Add((EnvDTE80.DTE2)comObject);
                }
            }
            return ret;
        }
        public static EnvDTEWraper GetCurrent()
        {
            var dte = Marshal.GetActiveObject("VisualStudio.DTE.15.0");
            return new EnvDTEWraper((DTE)dte);
        }
        [DllImport("ole32.dll")]
        private static extern void CreateBindCtx(int reserved, out IBindCtx ppbc);

        [DllImport("ole32.dll")]
        private static extern int GetRunningObjectTable(int reserved, out IRunningObjectTable prot);
        #endregion // Constructors

        #region Properties
        /// <summary>
        /// 当前DTE对象
        /// </summary>
        public DTE2 DTE { get; }
        /// <summary>
        /// 当前Solution
        /// </summary>
        public Solution Solution { get { return DTE.Solution; } }
        public string SolutionFile => Solution.FileName;
        public string SolutionFileName => System.IO.Path.GetFileName(Solution.FileName);
        public string SolutionName => Solution.Properties.Item("Name").Value.ToString();
        /// <summary>
        /// 获取指定名称的Project
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public EnvProjectWraper this[string name]
        {
            get
            {
                Project ret = null;
                foreach (Project item in DTE.Solution.Projects)
                {
                    if (item.Name.Contains(name))
                    {
                        ret = item;
                        break;
                    }
                }
                return new EnvProjectWraper(ret);
            }
        }
        #endregion

        /// <summary>
        /// 当前选择的项目，如果解决方案中选择了多项则返回NULL
        /// </summary>
        public EnvProjectWraper ActiveProject
        {
            get
            {
                Project ret = null;
                dynamic projs = DTE.ActiveSolutionProjects;
                if (projs.Length == 1)
                    ret = projs.GetValue(0) as Project;
                return ret != null ? new EnvProjectWraper(ret) : null;
            }
        }

        /// <summary>
        /// 解决方案中所有项目
        /// </summary>
        public List<EnvProjectWraper> Projects
        {
            get
            {
                var ret = new List<EnvProjectWraper>();
                foreach (Project item in Solution.Projects)
                {
                    if (item == null) continue;
                    var temp = new EnvProjectWraper(item).Name;
                    if (item.Kind == VsProjectType.SolutionFolder)
                        ret.AddRange(GetSolutionFolderProjects(item));
                    else
                        ret.Add(new EnvProjectWraper(item));
                }
                return ret;
            }
        }
        public IEnumerable<EnvProjectWraper> GetSolutionFolderProjects(Project solutionFolder)
        {
            List<EnvProjectWraper> list = new List<EnvProjectWraper>();

            for (var i = 1; i <= solutionFolder.ProjectItems.Count; i++)
            {
                var subProject = solutionFolder.ProjectItems.Item(i).SubProject;
                if (subProject == null)
                {
                    continue;
                }

                // If this is another solution folder, do a recursive call, otherwise add
                if (subProject.Kind == VsProjectType.SolutionFolder)
                {
                    list.AddRange(GetSolutionFolderProjects(subProject));
                }
                else
                {
                    list.Add(new EnvProjectWraper(subProject));
                }
            }

            return list;
        }

        public EnvProjectWraper GetProject(string projectName)
            => Projects.First(p => p.Name == projectName);

        #region Variables
        /// <summary>
        /// 设置变量
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void SetVariable(string name, string value)
        {
            SetVariable(Solution.Globals, name, value);
        }
        /// <summary>
        /// 获取变量
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetVariable(string name)
        {
            return GetVariable(Solution.Globals, name);
        }

        internal static void SetVariable(Globals globals, string name, string value)
        {
            if (globals.VariableExists[name])
            {
                globals[name] = value;
            }
            else
            {
                globals[name] = value;
                globals.VariablePersists[name] = true;
            }
        }
        internal static string GetVariable(Globals globals, string name)
        {
            return globals.VariableExists[name] ? Convert.ToString(globals[name]) : null;
        }

        #endregion
    }
    public static class VsProjectType
    {
        public const string SolutionFolder = "{66A26720-8FB5-11D2-AA7E-00C04F688DDE}";
        public const string VisualBasic = "{F184B08F-C81C-45F6-A57F-5ABD9991F28F}";
        public const string VisualCSharp = "{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}";
        public const string VisualCPlusPlus = "{8BC9CEB8-8B4A-11D0-8D11-00A0C91BC942}";
        public const string VisualJSharp = "{E6FDF86B-F3D1-11D4-8576-0002A516ECE8}";
        public const string WebProject = "{E24C65DC-7377-472b-9ABA-BC803B73C61A}";
    }
}
