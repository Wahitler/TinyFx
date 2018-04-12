using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.VersionControl.Client;

namespace TinyFx.Windows.EnvDTE
{
    public class TfsSourceControl
    {
        //public Uri ServerUri { get; private set; }
        //public TfsConfigurationServer ConfigurationServer;
        //public Dictionary<string, TfsTeamProjectCollection> ProjectCollections = new Dictionary<string, TfsTeamProjectCollection>();

        public string ProjectCollectionUrl;
        public TfsTeamProjectCollection ProjectCollection;
        public VersionControlServer VersionControl;
        public List<Workspace> Workspaces = new List<Workspace>();
        public List<TeamProject> TeamProjects = new List<TeamProject>();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="projectCollectionUrl">TFS 项目集合地址：http://172.28.9.211:8080/tfs/OSCCollection </param>
        public TfsSourceControl(string projectCollectionUrl)
        {
            ProjectCollectionUrl = projectCollectionUrl;
            ProjectCollection = new TfsTeamProjectCollection(new Uri(ProjectCollectionUrl));
            VersionControl = ProjectCollection.GetService<VersionControlServer>();
            Workspaces.AddRange(VersionControl.QueryWorkspaces(null, Environment.UserName, Environment.MachineName));
            TeamProjects.AddRange(VersionControl.GetAllTeamProjects(false));

            /*
            ServerUri = new Uri(uri);
            ConfigurationServer = TfsConfigurationServerFactory.GetConfigurationServer(ServerUri);
            var collectionNodes = ConfigurationServer.CatalogNode.QueryChildren(new[] { CatalogResourceTypes.ProjectCollection }, false, CatalogQueryOptions.None);
            foreach (var collectionNode in collectionNodes)
            {
                var collectionId = new Guid(collectionNode.Resource.Properties["InstanceId"]);
                var teamProjectCollection = ConfigurationServer.GetTeamProjectCollection(collectionId);
                ProjectCollections.Add(teamProjectCollection.Name, teamProjectCollection);
            }
            */
        }
        /// <summary>
        /// 签出文件
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public int CheckOut(string file)
            => GetWorkspace(file).PendEdit(file);
        
        /// <summary>
        /// 签出目录
        /// </summary>
        /// <param name="dir"></param>
        public void CheckOutDir(string dir)
        {
            var ws = GetWorkspace(dir);
            foreach (var file in Directory.GetFiles(dir, "*", SearchOption.AllDirectories))
                ws.PendEdit(file);
        }
        /// <summary>
        /// 签入目录
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public int CheckIn(string path)
        {
            var ws = GetWorkspace(path);
            var pendings = ws.GetPendingChanges().SkipWhile((pending) => {
                return !pending.LocalItem.StartsWith(path);
            }).ToArray();
            return ws.CheckIn(pendings, "TinyFx.TfsControl程序提交。");
        }
        /// <summary>
        /// 添加文件
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public int PendAdd(string file)
        {
            return GetWorkspace(file).PendAdd(file);
        }

        /// <summary>
        /// 获取路径所在workspace
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private Workspace GetWorkspace(string path)
        {
            Workspace ret = null;
            foreach (var ws in Workspaces)
            {
                foreach (var folder in ws.Folders)
                {
                    if (path.StartsWith(folder.LocalItem))
                    {
                        ret = ws;
                        break;
                    }
                }
                if (ret != null && ret.HasUsePermission)
                    break;
            }
            if (ret == null)
                throw new Exception($"未找到对应的workspaces。path:{path}");
            return ret;
        }
    }

}
