using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TinyFx.Configuration.Data;
using WeifenLuo.WinFormsUI.Docking;
using TinyFx.Data.Schema;
using TinyFx.Data.MySqlClient;
using TinyFx.Data;
using System.Data.Common;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.IO;
using TinyFxVSIX.Commands.OrmGen;
using TinyFx;

namespace TinyFxVSIX.Commands.OrmGen.Forms
{
    public partial class DBOListWindow : DockContent
    {
        public DBOListWindow()
        {
            InitializeComponent();
        }
        private const string _configFile = "TinyFx.OrmGen.xml";
        private string GetConfigFileName()
        {
            return Path.Combine(Path.GetDirectoryName(MainForm.CurrentDTE.ActiveProject.FullName), _configFile);
        }
        private void DBOListWindow_Load(object sender, EventArgs e)
        {
            tvMain.Nodes.Clear();
            OnTreeViewAfterSelect(null);
            var configFile = GetConfigFileName();
            if (File.Exists(configFile))
            {
                List<DBONodeInfo> items = SerializerUtil.DeserializeXml<List<DBONodeInfo>>(File.ReadAllText(configFile));
                foreach (var item in items)
                {
                    AddDatabase(item);
                }
                if (tvMain.Nodes.Count > 0)
                { 
                    tvMain.SelectedNode = tvMain.Nodes[0];
                    tvMain.SelectedNode.Expand();
                }

            }

            //ConnectionStringElement element = new ConnectionStringElement();
            //element.Name = "MYSQL";
            //element.ProviderName = "mysql";
            //element.ConnectionString = "server=172.28.9.211;user id=root;pwd=root;database=test";
            //AddDatabase(element);
        }

        private void 从TinyFx配置文件获取连接ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ConnFromConfigForm();
            form.ShowInTaskbar = false;
            if (form.ShowDialog() == DialogResult.OK)
            {
                 var node = AddDatabase(new DBONodeInfo(form.ConnStrElement));
                tvMain.SelectedNode = node;
            }
        }

        private void 自定义数据库连接ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConnCustomForm form = new ConnCustomForm();
            form.ShowInTaskbar = false;
            if (form.ShowDialog() == DialogResult.OK)
            {
                var node = AddDatabase(new DBONodeInfo(form.ConnStrElement));
                tvMain.SelectedNode = node;
            }
        }
        private bool CheckNewElement(DBONodeInfo info)
        {
            bool ret = true;
            if (tvMain.Nodes == null || tvMain.Nodes.Count == 0) return true;
            foreach (DBOTreeNode node in tvMain.Nodes)
            {
                if (node.DBOListType != DBOListType.Database) continue;
                var schema = node.Data as DatabaseSchema;
                if (schema.DatabaseName.Equals(info.ConnStrInfo.Database, StringComparison.CurrentCultureIgnoreCase)
                    && schema.DataSource.Equals(info.ConnStrInfo.DataSource, StringComparison.CurrentCultureIgnoreCase))
                {
                    tvMain.SelectedNode = node;
                    return false;
                }
            }
            return ret;
        }
        private DBOTreeNode AddDatabase(DBONodeInfo info)
        {
            if (!CheckNewElement(info)) return null;
            var db = DbFactory.Create<MySqlDatabase>(info.ConnStrInfo.ConnectionString);
            DatabaseSchema dbSchema = null;
            try
            {
                dbSchema = new MySqlSchemaProvider(db).GetDatabase();
            }
            catch(Exception ex) {
                MessageBox.Show($"数据库无法连接。数据库: {info.ConnStrInfo.Database}{Environment.NewLine}连接字符串: {info.ConnStrInfo.ConnectionString}","错误");
                return null;
            }
            var nodeDB = new DBOTreeNode(string.Format("{0}({1}-{2})", dbSchema.DatabaseName, dbSchema.DataSource, info.ConnStrInfo.Provider), 0, 0);
            nodeDB.DBOListType = DBOListType.Database;
            nodeDB.Data = dbSchema;
            tvMain.Nodes.Add(nodeDB);
            var nodeTable = new DBOTreeNode("表", 1, 1);
            nodeTable.DBOListType = DBOListType.Tables;
            nodeTable.Data = dbSchema.Tables;
            nodeDB.Nodes.Add(nodeTable);
            foreach (var table in dbSchema.Tables)
            {
                var nodeNew = new DBOTreeNode(table.TableName, 2,2);
                nodeNew.DBOListType = DBOListType.Table;
                nodeNew.Data = table;
                nodeTable.Nodes.Add(nodeNew);
            }
            var nodeView = new DBOTreeNode("视图",1,1);
            nodeView.DBOListType = DBOListType.Views;
            nodeView.Data = dbSchema.Views;
            nodeDB.Nodes.Add(nodeView);
            foreach (var view in dbSchema.Views)
            {
                var nodeNew = new DBOTreeNode(view.ViewName, 3, 3);
                nodeNew.DBOListType = DBOListType.View;
                nodeNew.Data = view;
                nodeView.Nodes.Add(nodeNew);
            }
            var nodeSp = new DBOTreeNode("存储过程", 1,1);
            nodeSp.DBOListType = DBOListType.Procs; 
            nodeSp.Data = dbSchema.Procs;
            nodeDB.Nodes.Add(nodeSp);
            foreach (var sp in dbSchema.Procs)
            {
                var nodeNew = new DBOTreeNode(sp.ProcName, 4, 4);
                nodeNew.DBOListType = DBOListType.Proc;
                nodeNew.Data = sp;
                nodeSp.Nodes.Add(nodeNew);
            }
            //
            nodeDB.DBNodeInfo = info;
            return nodeDB;
        }

        public EventHandler<DBOChangeEventArgs> DBOChange;
        private void OnTreeViewAfterSelect(TreeViewEventArgs e)
        {
            tvMain_AfterSelect(this.tvMain, e);
        }
        private void tvMain_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e == null || e.Node == null)
            {
                tsbDisconnect.Enabled = false;
                tsbRefresh.Enabled = false;
                tsbSave.Enabled = false;
                OnDBOChange(sender, null);
            }
            else
            {
                var node = (DBOTreeNode)e.Node;
                tsbDisconnect.Enabled = true;
                tsbRefresh.Enabled = true;
                tsbSave.Enabled = true;
                DBOChangeEventArgs args = new DBOChangeEventArgs(node);
                OnDBOChange(sender, args);
            }
        }
        private void OnDBOChange(object sender, DBOChangeEventArgs args)
        {
            if (DBOChange == null) return;
            DBOChange(tvMain, args);
        }

        private void tsbDisconnect_Click(object sender, EventArgs e)
        {
            if (tvMain.SelectedNode == null) return;
            if (MessageBox.Show("是否删除当前数据库连接？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            { 
                tvMain.Nodes.Remove(GetRootNode(tvMain.SelectedNode));
                if (tvMain.Nodes.Count > 0)
                    tvMain.SelectedNode = tvMain.Nodes[0];
                else
                    OnTreeViewAfterSelect(null);

            }
        }
        private TreeNode GetRootNode(TreeNode node)
        {
            TreeNode ret = node;
            while (ret.Parent != null)
            {
                ret = ret.Parent;
            }
            return ret;
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("刷新将从新加载数据库列表，确定刷新？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            var infos = new List<DBONodeInfo>();
            foreach (DBOTreeNode node in tvMain.Nodes)
            {
                infos.Add(node.DBNodeInfo);
            }
            tvMain.Nodes.Clear();
            foreach (var info in infos)
            {
                AddDatabase(info);
            }
            OnTreeViewAfterSelect(null);
        }
        private void tsbSave_Click(object sender, EventArgs e)
        {
            if (tvMain.Nodes == null || tvMain.Nodes.Count == 0) return;
            List<DBONodeInfo> items = new List<DBONodeInfo>();
            foreach (DBOTreeNode node in tvMain.Nodes)
            {
                if (node.DBOListType != DBOListType.Database) continue;
                var schema = node.Data as DatabaseSchema;
                DBONodeInfo item = new DBONodeInfo(schema.ConnectionStringInfo);
                item.OrmSettings = node.OrmSettings;
                item.DbInitSettings = node.DBNodeInfo.DbInitSettings;
                items.Add(item);
            }
            var content = SerializerUtil.SerializeXml(items);
            var file = GetConfigFileName();
            File.WriteAllText(file, content);
            MainForm.CurrentDTE.ActiveProject.AddFromFile(file);
            MessageBox.Show("数据库连接信息保存成功！", "提示");
        }
    }

}
