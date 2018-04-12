using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TinyFx.Data;
using TinyFx.Windows.EnvDTE;
using System.Xml;
using TinyFx.Configuration.Data;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using TinyFxVSIX.Commands.OrmGen;
using TinyFx;

namespace TinyFxVSIX.Commands.OrmGen.Forms
{
    public partial class ConnFromConfigForm : Form
    {
        public ConnFromConfigForm()
        {
            InitializeComponent();
        }
        public EnvDTEWraper CurrentDTE { get { return MainForm.CurrentDTE; } }
        private string SolutionDir { get { return Path.GetDirectoryName(CurrentDTE.Solution.FullName); } }
        private string SolutionName { get { return Path.GetFileNameWithoutExtension(CurrentDTE.Solution.FullName); } }
        private string ProjectDir { get { return Path.GetDirectoryName(CurrentDTE.ActiveProject.FullName); } }
        public string ConfigFileName { get; set; }

        private Dictionary<string, ConnectionStringElement> _list;
        private void ConnFromConfigForm_Load(object sender, EventArgs e)
        {
            dlgConfigBrowser.InitialDirectory = ProjectDir;
            this.txtConfigPath.Text = string.Format(@"解决方案[{0}]所在路径\", SolutionName);
            InitCbxDBProvider();
            SetByConfigFile();
        }
        private void InitCbxDBProvider()
        {
            cbxDBProvider.Items.Clear();
            foreach (var item in Enum.GetNames(typeof(DbDataProvider)))
            {
                cbxDBProvider.Items.Add(item);
            }
            cbxDBProvider.SelectedIndex = 0;
        }
        private void SetByConfigFile()
        {
            cbxDBProvider.SelectedIndex = 0;
            txtConnStr.Clear();

            if (string.IsNullOrEmpty(ConfigFileName)) return;
            this.txtConfigPath.Text = string.Format(@"解决方案[{0}]所在路径{1}", SolutionName
                , StringUtil.TrimStart(ConfigFileName, SolutionDir));
            _list = new Dictionary<string, ConnectionStringElement>();
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(File.ReadAllText(ConfigFileName));
            // <tinyFx>
            XmlNode node = xml.SelectSingleNode("//tinyFx/data/connectionStrings");
            if (node != null && node.ChildNodes != null)
            {
                foreach (XmlNode item in node.ChildNodes)
                {
                    if (item.NodeType != XmlNodeType.Element) continue;
                    var element = new ConnectionStringElement();
                    element.Name = item.Attributes["name"].Value;
                    element.ProviderName = item.Attributes["providerName"].Value;
                    element.ConnectionString = item.Attributes["connectionString"].Value;
                    element.Encrypt = item.Attributes["encrypt"].Value;
                    _list.Add(element.Name, element);
                }
            }
            // <connectionStrings>
            node = xml.SelectSingleNode("configuration/connectionStrings");
            if (node!= null && node.ChildNodes!=null)
            {
                foreach (XmlNode item in node.ChildNodes)
                {
                    if (item.NodeType != XmlNodeType.Element) continue;
                    if (item.Attributes.GetNamedItem("name") == null) continue;
                    var element = new ConnectionStringElement();
                    element.Name = item.Attributes["name"].Value;
                    element.ProviderName = item.Attributes["providerName"].Value;
                    element.ConnectionString = item.Attributes["connectionString"].Value;
                    element.Encrypt = "none";
                    _list.Add(element.Name, element);
                }
            }
            if (_list.Keys.Count >0)
            { 
                cbxConnStrName.DataSource = _list.Keys.ToList();
                cbxConnStrName.SelectedIndex = 0;
            }

        }

        private void btnConfigBrowser_Click(object sender, EventArgs e)
        {
            if (dlgConfigBrowser.ShowDialog() == DialogResult.OK)
            {
                ConfigFileName = dlgConfigBrowser.FileName;
                SetByConfigFile();
            }
        }

        public ConnectionStringInfo ConnStrElement { get; protected set; }
        private void cbxConnStrName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = ((ComboBox)sender).SelectedItem.ToString();
            var item = _list[name];
            var provider = DbDataProviderUtil.GetProvider(item.ProviderName);
            cbxDBProvider.SelectedItem = provider.ToString();
            txtConnStr.Text = item.ConnectionString;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (cbxConnStrName.SelectedIndex == -1)
            {
                MessageBox.Show("请选择数据库连接名。");
                return;
            }
            string name = cbxConnStrName.SelectedItem.ToString();
            var element = _list[name];
            var database = DbFactory.Create(DbDataProviderUtil.GetProvider(element.ProviderName), element.ConnectionString);
            ConnStrElement = database.ConnectionStringInfo;
            if (!database.CheckConnection())
                MessageBox.Show("提供的数据库连接字符串无法连接数据库。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                this.DialogResult = DialogResult.OK;
        }

        private void cbxDBProvider_SelectedIndexChanged(object sender, EventArgs e)
        {
            var provider = (DbDataProvider)cbxDBProvider.SelectedIndex;
            btnConnect.Enabled = provider == DbDataProvider.MySqlClient;
        }
    }
}
