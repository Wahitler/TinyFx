using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TinyFx.Data.Schema;
using TinyFx.Data.MySqlClient;
using TinyFx.Data;
using TinyFx.Windows.EnvDTE;
using System.IO;
using TinyFxVSIX.Commands.OrmGen;
using TinyFxVSIX.Commands.OrmGen.Templates;
using TinyFx;

namespace TinyFxVSIX.Commands.OrmGen.Forms.Controls
{
    public partial class DBInfoCtl : DBInfoControlBase, IDBInfoRefresh
    {
        public DBInfoCtl()
        {
            InitializeComponent();
        }
        private DbInitCtl _ctlDbInit = new DbInitCtl();
        private void DBInfoCtl_Load(object sender, EventArgs e)
        {
            tabDbInit.Controls.Clear();
            tabDbInit.Controls.Add(_ctlDbInit);
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _args.CurrentNode.OrmSettings.Namespaces = txtNamespace.Text;
            _args.CurrentNode.OrmSettings.OutputPath = txtOutputPath.Text;
            MessageBox.Show("保存成功！","提示");
        }
        private DatabaseSchema _dbSchema;
        public void RefreshData()
        {
            _dbSchema = _args.CurrentNode.Data as DatabaseSchema;
            this.txtDBProvider.Text = _dbSchema.DbDataProvider.ToString();
            this.txtDBName.Text = _dbSchema.DatabaseName;
            this.txtConnStr.Text = _dbSchema.ConnectionString;
            if (string.IsNullOrEmpty(_args.CurrentNode.OrmSettings.Namespaces))
            {
                _args.CurrentNode.OrmSettings.Namespaces = _dte.ActiveProject.Name + "." + this.txtDBName.Text;
                _args.CurrentNode.OrmSettings.OutputPath = this.txtDBName.Text + "\\";
            }
            this.txtNamespace.Text = _args.CurrentNode.OrmSettings.Namespaces;
            this.lblOutputPath.Text = _dte.ActiveProject.Name + "\\";
            this.txtOutputPath.Text = _args.CurrentNode.OrmSettings.OutputPath;
            this.propertyGrid1.SelectedObject = _dbSchema;
            this.lvTables.BindData(_dbSchema.Tables);
            this.lvViews.BindData(_dbSchema.Views);
            this.lvProcs.BindData(_dbSchema.Procs);
            _ctlDbInit.ReflashData(_args.CurrentNode.DBNodeInfo, _dbSchema.Tables);
        }

        #region ListView选择
        private DBOBaseListView GetActiveListView()
        {
            switch (tabDBObjects.SelectedIndex)
            {
                case 0: return lvTables;
                case 1: return lvViews;
                case 2:return lvProcs;
            }
            throw new Exception("此活动TAB页不存在。");
        }
        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in GetActiveListView().Items)
                item.Checked = true;
        }

        private void btnSelectInvert_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in GetActiveListView().Items)
                item.Checked = !item.Checked;
        }

        private void btnSelectNone_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in GetActiveListView().Items)
                item.Checked = false;
        }
        #endregion

        private void btnGenAll_Click(object sender, EventArgs e)
        {
            try
            {
                string path = Path.Combine(Path.GetDirectoryName(_dte.ActiveProject.FullName), _args.CurrentNode.OrmSettings.OutputPath);
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                // TFS 签出
                if (MainForm.CurrentDTE.ActiveProject.SccProvider == SccProvider.TFS)
                {
                    var slnFile = MainForm.CurrentDTE.SolutionFile;
                    var tfsServer = File.ReadAllLines(slnFile).LastOrDefault((line) => line.Contains("SccTeamFoundationServer ="));
                    if (!string.IsNullOrEmpty(tfsServer))
                    {
                        tfsServer = tfsServer.Trim().TrimStart("SccTeamFoundationServer = ");
                        new TfsSourceControl(tfsServer).CheckOutDir(path);
                    }
                }
                else
                {
                    // 设置可写
                    foreach (var file in Directory.EnumerateFiles(path, "*", SearchOption.AllDirectories))
                    {
                        new FileInfo(file).IsReadOnly = false;
                    }
                }

                OrmGenProvider provider = new OrmGenProvider();
                foreach (var table in _dbSchema.Tables)
                {
                    string content = provider.GetTableCode(table, _args.CurrentNode.OrmSettings.Namespaces);
                    string fileName = Path.Combine(path, table.TableName + ".cs");
                    File.WriteAllText(fileName, content);
                    AddProjectFile(fileName);
                }
                foreach (var view in _dbSchema.Views)
                {
                    string content = provider.GetViewCode(view, _args.CurrentNode.OrmSettings.Namespaces);

                    string fileName = Path.Combine(path, view.ViewName + ".cs");
                    File.WriteAllText(fileName, content);
                    AddProjectFile(fileName);
                }
                foreach (var proc in _dbSchema.Procs)
                {
                    string content = provider.GetProcCode(proc, _args.CurrentNode.OrmSettings.Namespaces);

                    string fileName = Path.Combine(path, proc.ProcName + ".cs");
                    File.WriteAllText(fileName, content);
                    AddProjectFile(fileName);
                }

                MessageBox.Show("生成成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"异常");
            }
        }
        private void AddProjectFile(string file)
        {
            try
            {
                MainForm.CurrentDTE.ActiveProject.AddFromFile(file);
            }
            catch { }
        }

        private void btnGenSelect_Click(object sender, EventArgs e)
        {

        }

        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
        }
    }
}
