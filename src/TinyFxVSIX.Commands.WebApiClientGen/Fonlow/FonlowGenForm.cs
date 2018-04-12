using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TinyFx.AspNet.WebApi.ClientGen;
using TinyFx.Windows.EnvDTE;
using TinyFx;
using System.IO;
using Fonlow.Poco2Client;
using TinyFx.AspNet.WebApi.ClientGen.Fonlow;

namespace TinyFxVSIX.Commands.WebApiClientGen.Fonlow
{
    public partial class FonlowGenForm : Form
    {
        #region Init
        public FonlowGenForm()
        {
            InitializeComponent();
        }
        private EnvDTEWraper CurrentDTE => MainForm.CurrentDTE;
        private string[] Args => MainForm.InputArgs;
        private void FonlowGenForm_Load(object sender, EventArgs e)
        {
            dlgFolder.SelectedPath = Environment.CurrentDirectory;
            if (CurrentDTE != null)
            {
                var project = CurrentDTE.ActiveProject;
                var path = Path.GetDirectoryName(project.FullName);
                txtAssemblyFolder.Text = Path.Combine(path, "bin");
                txtOutput.Text = Path.Combine(path, "output");
            }
            else
            {
                if (Args != null && Args.Length == 2)
                {
                    txtAssemblyFolder.Text = Args[0];
                    txtOutput.Text = Args[1];
                }
                else
                {
                    var path = Environment.CurrentDirectory;
                    txtAssemblyFolder.Text = Path.Combine(path, "WebApiBin");
                    txtOutput.Text = Path.Combine(path, "output");
                }
            }
            Init();
        }
        private void Init(string file = null)
        {
            lstAssemblyFiles.Items.Clear();
            lstControllerName.Items.Clear();
            btnRemoveAssemblyFiles.Enabled = false;
            btnRemoveControllerName.Enabled = false;
            if (string.IsNullOrEmpty(file))
                file = GetSettingsFile();
            if (File.Exists(file))
            {
                var settings = SerializerUtil.DeserializeJson<FonlowGenSettings>(File.ReadAllText(file, Encoding.UTF8));
                cbxCamelCase.SelectedIndex = settings.CamelCase ? 0 : 1;
                cbxCherryPickingMethods.SelectedItem = settings.CherryPickingMethods.ToString();
                cbxClientGenMode.SelectedItem = settings.ClientGenMode.ToString();
                txtContentType.Text = settings.ContentType;
                txtAssemblyFolder.Text = settings.AssemblyFolder;
                foreach (var item in settings.AssemblyNames)
                    lstAssemblyFiles.Items.Add(item);
                foreach (var item in settings.ExcludedControllerNames)
                    lstControllerName.Items.Add(item);
            }
            else
            {
                cbxCamelCase.SelectedIndex = 0;
                cbxCherryPickingMethods.SelectedIndex = 1;
                cbxClientGenMode.SelectedIndex = 2;
            }
        }
        #endregion

        #region 条件

        private void btnAddAssemblyFiles_Click(object sender, EventArgs e)
        {
            var str = Interaction.InputBox("请输入需要添加的应用程序集，包含WebApi服务和Models。"+Environment.NewLine + Environment.NewLine 
                + "例如：DemoWebApi.dll", "添加应用程序集", "", -1, -1);
            if (!string.IsNullOrEmpty(str))
                lstAssemblyFiles.Items.Add(str);
        }

        private void btnAddControllerName_Click(object sender, EventArgs e)
        {
            var str = Interaction.InputBox("请输入需要排除的控制器名称。" + Environment.NewLine + Environment.NewLine 
                + "例如：DemoWebApi.Controllers.Account", "添加排除的控制器", "", -1, -1);
            if (!string.IsNullOrEmpty(str))
                lstControllerName.Items.Add(str);
        }
        private void lstAssemblyFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRemoveAssemblyFiles.Enabled = lstAssemblyFiles.SelectedItem != null;
        }

        private void lstControllerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRemoveControllerName.Enabled = lstControllerName.SelectedItem != null;
        }

        private void btnRemoveAssemblyFiles_Click(object sender, EventArgs e)
        {
            lstAssemblyFiles.Items.RemoveAt(lstAssemblyFiles.SelectedIndex);
        }

        private void btnRemoveControllerName_Click(object sender, EventArgs e)
        {
            lstControllerName.Items.RemoveAt(lstControllerName.SelectedIndex);
        }
        private void btnAssemblyFolder_Click(object sender, EventArgs e)
        {
            if (dlgFolder.ShowDialog() == DialogResult.OK)
            {
                txtAssemblyFolder.Text = dlgFolder.SelectedPath;
            }
        }

        private void btnOutput_Click(object sender, EventArgs e)
        {
            if (dlgFolder.ShowDialog() == DialogResult.OK)
            {
                txtOutput.Text = dlgFolder.SelectedPath;
            }
        }
        #endregion

        private FonlowGenSettings GetSettings()
        {
            var ret = new FonlowGenSettings() {
                ClientGenMode = cbxClientGenMode.SelectedItem.ToString().ToEnum<FonlowGenMode>(),
                AssemblyFolder = Path.GetFullPath(txtAssemblyFolder.Text),
                CherryPickingMethods = cbxCherryPickingMethods.SelectedItem.ToString().ToEnum<CherryPickingMethods>(),
                CamelCase = cbxCamelCase.SelectedIndex == 0,
                ContentType = txtContentType.Text,
                RouteTemplate= "{controller}/{action}"
            };
            foreach (var item in lstAssemblyFiles.Items)
                ret.AssemblyNames.Add(item.ToString());
            foreach (var item in lstControllerName.Items)
                ret.ExcludedControllerNames.Add(item.ToString());
            return ret;
        }
        private string GetSettingsFile()
            => Path.Combine(Path.GetFullPath(txtOutput.Text), "FonlowSettings.json");
        private string GetGenFile()
        {
            var mode = cbxClientGenMode.SelectedItem.ToString().ToEnum<FonlowGenMode>();
            string ext = mode == FonlowGenMode.CSharp ? ".cs" : ".ts";
            return Path.Combine(Path.GetFullPath(txtOutput.Text), $"WebApiClient{ext}");
        }
        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            if (!CheckInput()) return;
            var settings = GetSettings();
            var content = SerializerUtil.SerializeJson(settings);
            string file = GetSettingsFile();
            var dir = Path.GetDirectoryName(file);
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            File.WriteAllText(file, content);
            if (CurrentDTE != null)
                MainForm.CurrentDTE.ActiveProject.AddFromFile(file);
            MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnLoadSettings_Click(object sender, EventArgs e)
        {
            dlgOpenSettings.Filter = "配置文件|*.json";
            if (dlgOpenSettings.ShowDialog() == DialogResult.OK)
            {
                var file = dlgOpenSettings.FileName;
                Init(file);
            }
        }
        private void btnGen_Click(object sender, EventArgs e)
        {
            if (!CheckInput()) return;
            var settings = GetSettings();
            var content = ClientGenUtil.GenFonlowClientCode(settings);
            var file = GetGenFile();
            File.WriteAllText(file, content);
            MessageBox.Show("代码生成成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private bool CheckInput()
        {
            if (string.IsNullOrEmpty(txtAssemblyFolder.Text) || string.IsNullOrEmpty(txtOutput.Text))
            {
                MessageBox.Show("WebApi的bin所在目录和生成路径不能为空。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
