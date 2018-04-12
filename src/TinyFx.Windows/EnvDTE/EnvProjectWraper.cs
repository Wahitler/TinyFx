using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvDTE;
using VSLangProj;
using System.IO;
using System.Text.RegularExpressions;

namespace TinyFx.Windows.EnvDTE
{
    /// <summary>
    /// EnvProject包装类
    /// </summary>
    public class EnvProjectWraper : Project
    {
        /// <summary>
        /// EnvProject对象
        /// </summary>
        public Project EnvProject { get; }
        /// <summary>
        /// 获得VSProject对象
        /// </summary>
        public VSProject EnvVSProject { get { return (VSProject)EnvProject; } }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="project"></param>
        public EnvProjectWraper(Project project)
        {
            EnvProject = project;
        }
        /// <summary>
        /// 设置变量
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void SetVariable(string name, string value)
        {
            EnvDTEWraper.SetVariable(EnvProject.Globals, name, value);
        }
        /// <summary>
        /// 获取变量
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetVariable(string name)
        {
            return EnvDTEWraper.GetVariable(EnvProject.Globals, name);
        }
        /// <summary>
        /// 添加引用
        /// </summary>
        /// <param name="bstrPath"></param>
        public void AddReference(string bstrPath)
        {
            EnvVSProject.References.Add(bstrPath);
        }
        /// <summary>
        /// 添加文件
        /// </summary>
        /// <param name="fileName"></param>
        public void AddFromFile(string fileName)
        {
            //if (EnvProject.DTE.Mode == vsIDEMode.vsIDEModeDebug)
            //    throw new Exception("调试阶段不能添加文件。");
            EnvProject.ProjectItems.AddFromFile(fileName);
            EnvProject.Save();
        }
        /// <summary>
        /// 添加文件
        /// </summary>
        /// <param name="files"></param>
        public void AddFromFiles(IEnumerable<string> files)
        {
            foreach (var file in files)
                AddFromFile(file);
            EnvProject.Save();
        }
        /// <summary>
        /// 添加目录
        /// </summary>
        /// <param name="dir"></param>
        public void AddFromDirectory(string dir)
        {
            EnvProject.ProjectItems.AddFromDirectory(dir);
        }
        /// <summary>
        /// 是否是Web项目
        /// </summary>
        public bool IsWebProject {
            get {
                bool ret = false;
                foreach (Property prop in Properties)
                {
                    if ((prop.Name == "WebApplication.AspNetDebugging" && GetPropertyValue(prop) == "True")
                        || (prop.Name == "WebApplication.IISUrl" && !string.IsNullOrEmpty(GetPropertyValue(prop)))
                        || (prop.Name == "WebApplication.BrowseURL" && !string.IsNullOrEmpty(GetPropertyValue(prop))))
                    {
                        ret = true;
                        break;
                    }
                }
                return ret;
            }
        }
        private string GetPropertyValue(Property prop)
        {
            string ret = null;
            try
            {
                ret = Convert.ToString(prop.Value);
            }
            catch { }
            return ret;
        }

        /// <summary>
        /// 源代码管理提供程序
        /// </summary>
        public SccProvider SccProvider
        {
           get
           {
                SccProvider ret = SccProvider.None;
                string file = Path.Combine(Path.GetDirectoryName(DTE.Solution.FullName), UniqueName);
                string content = File.OpenText(file).ReadToEnd();
                var regex = Regex.Match(content, "<SccProvider>(.*?)</SccProvider>");
                switch (regex.Groups[1].Value)
                {
                    case "SAK":
                        ret = SccProvider.TFS;
                        break;
                    case "Svn":
                        ret = SccProvider.SVN;
                        break;
                }
                return ret;
           }
        }

        public List<ProjectItem> ProjectItems
        {
            get {
                return Descendants(EnvProject.ProjectItems.Cast<ProjectItem>(), pi => pi.ProjectItems.Cast<ProjectItem>()).ToList();
            }
        }
        private static IEnumerable<T> Descendants<T>(IEnumerable<T> source, Func<T, IEnumerable<T>> descendBy)
        {
            foreach (T value in source)
            {
                yield return value;
                foreach (T child in Descendants(descendBy(value), descendBy))
                {
                    yield return child;
                }
            }
        }

        #region Project 实现
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get { return EnvProject.Name; } }
        /// <summary>
        /// 文件名
        /// </summary>
        public string FileName { get { return EnvProject.FileName; } }
        /// <summary>
        /// 是否目录
        /// </summary>
        public bool IsDirty { get { return EnvProject.IsDirty; } }
        /// <summary>
        /// 项目集合
        /// </summary>
        public Projects Collection { get { return EnvProject.Collection; } }
        /// <summary>
        /// DTE
        /// </summary>
        public DTE DTE { get { return EnvProject.DTE; } }
        /// <summary>
        /// KIND
        /// </summary>
        public string Kind { get { return EnvProject.Kind; } }
        /// <summary>
        /// 属性集合
        /// </summary>
        public Properties Properties { get { return EnvProject.Properties; } }
        /// <summary>
        /// 唯一名称
        /// </summary>
        public string UniqueName { get { return EnvProject.UniqueName; } }
        /// <summary>
        /// 对象
        /// </summary>
        public dynamic Object { get { return EnvProject.Object; } }
        /// <summary>
        /// 
        /// </summary>
        public dynamic ExtenderNames { get { return EnvProject.ExtenderNames; } }
        /// <summary>
        /// 
        /// </summary>
        public string ExtenderCATID { get { return EnvProject.ExtenderCATID; } }
        /// <summary>
        /// 全文件名
        /// </summary>
        public string FullName { get { return EnvProject.FullName; } }
        /// <summary>
        /// 是否保存
        /// </summary>
        public bool Saved { get { return EnvProject.Saved; } }
        /// <summary>
        /// 配置管理
        /// </summary>
        public ConfigurationManager ConfigurationManager { get { return EnvProject.ConfigurationManager; } }
        /// <summary>
        /// 全局
        /// </summary>
        public Globals Globals { get { return EnvProject.Globals; } }
        /// <summary>
        /// 父项目对象
        /// </summary>
        public ProjectItem ParentProjectItem { get { return EnvProject.ParentProjectItem; } }
        /// <summary>
        /// CodeModel
        /// </summary>
        public CodeModel CodeModel { get { return EnvProject.CodeModel; } }

        /// <summary>
        /// 保存为
        /// </summary>
        /// <param name="NewFileName"></param>
        public void SaveAs(string NewFileName)
        {
            EnvProject.SaveAs(NewFileName);
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="FileName"></param>
        public void Save(string FileName = "")
        {
            EnvProject.Save(FileName);
        }
        /// <summary>
        /// 删除
        /// </summary>
        public void Delete()
        {
            EnvProject.Delete();
        }

        /// <summary>
        /// 获取项文件名
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static string GetFullPath(ProjectItem item)
            => (string)item.Properties.Item("FullPath").Value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ExtenderName"></param>
        /// <returns></returns>
        public dynamic get_Extender(string ExtenderName)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 项目名
        /// </summary>
        string Project.Name
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }
        /// <summary>
        /// 是否目录
        /// </summary>
        bool Project.IsDirty
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }
        /// <summary>
        /// 是否以保存
        /// </summary>
        bool Project.Saved
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        ProjectItems Project.ProjectItems => throw new NotImplementedException();

        #endregion
    }
}
