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
using System.Reflection;
using System.Diagnostics;

namespace TinyFxActiveXTool
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            Assembly asm = Assembly.LoadFrom("TinyFxActiveX.dll");
            var ver = asm.GetName().Version;
            this.txtVersion.Text = $"{ver.Major}.{ver.Minor}";
        }

        private void btnBuild_Click(object sender, EventArgs e)
        {
            string[] content =File.ReadAllText("installer.inf").Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            content[content.Length-1] = $"AdvancedInf={this.txtVersion.Text}";
            File.WriteAllText("installer.inf", string.Join("\r\n", content));
            this.txtInfo.Text = RunCommand("makecabsigned.bat");
            MessageBox.Show($"生成{this.txtOutput.Text}完成，请将此文件拷贝到WEB工程相关目录。");
        }
        public static string RunCommand(string commandText)
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;

            string strOutput = null;
            p.Start();
            p.StandardInput.WriteLine(commandText);
            p.StandardInput.WriteLine("exit");
            strOutput = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            p.Close();

            return strOutput;
        }
    }
}
