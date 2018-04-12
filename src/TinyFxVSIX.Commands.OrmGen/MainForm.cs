using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TinyFx.Data;
using TinyFx.Windows.EnvDTE;
using TinyFxVSIX.Commands.OrmGen.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace TinyFxVSIX.Commands.OrmGen
{
    public partial class MainForm : Form
    {
        private bool _showSplash = true;
        private SplashScreen _splashScreen;
        private Timer _timer;
        public MainForm()
        {
            //SetSplashScreen();
            InitializeComponent();
        }
        public MainForm(EnvDTEWraper dte):this()
        {
            CurrentDTE = dte;
        }
        private void SetSplashScreen()
        {
            _showSplash = true;
            _splashScreen = new SplashScreen();
            _splashScreen.Visible = true;
            _timer = new Timer();
            _timer.Tick += (sender, e) => {
                if (_showSplash) return;
                _splashScreen.Visible = false;
                _timer.Enabled = false;
            };
            _timer.Interval = 1000;
            _timer.Enabled = true;
        }
        public static EnvDTEWraper CurrentDTE { get; set; }

        private DBOListWindow frmDBOList;
        private DBOInfoWindow frmDBOInfo;
        
        private void OrmGenForm_Load(object sender, EventArgs e)
        {
            //this.tsMain.Visible = false;
            //this.Size = new Size(1340, 900);
            this.dockPanel1.Dock = DockStyle.Fill;
            frmDBOList = new DBOListWindow();
            frmDBOInfo = new DBOInfoWindow();
            frmDBOList.DBOChange += frmDBOInfo.OnDBOChange;
            frmDBOList.Show(this.dockPanel1, DockState.DockLeft);
            frmDBOInfo.Show(this.dockPanel1);
            _showSplash = false;
            this.Width = 1200;
            this.Height = 800;
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm form = new AboutForm();
            form.ShowDialog();
        }

        private void 对象资源管理器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.frmDBOList.VisibleState = frmDBOList.VisibleState == DockState.DockLeft ? DockState.DockLeftAutoHide : DockState.DockLeft;
        }

        private void 对象资源管理器详细信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.frmDBOInfo.VisibleState = frmDBOInfo.VisibleState == DockState.Unknown ? DockState.Document : DockState.Unknown;
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 自定义数据库连接ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.frmDBOList.自定义数据库连接ToolStripMenuItem.PerformClick();
        }

        private void 从TinyFx配置文件获取连接ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.frmDBOList.从TinyFx配置文件获取连接ToolStripMenuItem.PerformClick();
        }

        private void 刷新连接ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.frmDBOList.tsbRefresh.PerformClick();
        }

        private void 断开连接ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.frmDBOList.tsbDisconnect.PerformClick();
        }

        private void 全部保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.frmDBOList.tsbSave.PerformClick();
        }

        private void 选项ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 文件FToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            this.断开连接ToolStripMenuItem.Enabled = this.frmDBOList.tsbDisconnect.Enabled;
            this.刷新连接ToolStripMenuItem.Enabled = this.frmDBOList.tsbDisconnect.Enabled;
            this.全部保存ToolStripMenuItem.Enabled = this.frmDBOList.tsbSave.Enabled;
        }
    }
}
