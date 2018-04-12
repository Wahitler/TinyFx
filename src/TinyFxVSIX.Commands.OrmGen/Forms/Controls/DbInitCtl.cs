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
using MySql.Data.MySqlClient;
using System.IO;
using OfficeOpenXml;
using TinyFx.Extensions.EPPlus;
using TinyFx;

namespace TinyFxVSIX.Commands.OrmGen.Forms.Controls
{
    public partial class DbInitCtl : UserControl
    {
        #region Init
        public DbInitCtl()
        {
            InitializeComponent();
        }
        private DBONodeInfo _nodeInfo;
        public void ReflashData(DBONodeInfo nodeInfo, SchemaCollection<TableSchema> tables)
        {
            _nodeInfo = nodeInfo;
            //txtCreateSql.Text = nodeInfo.DbInitSettings.CreateSqlFile;
            //txtDataFile.Text = nodeInfo.DbInitSettings.InitDataFile;
            txtCreateSql.Text = $"{_nodeInfo.ConnStrInfo.Database}.sql";
            txtDataFile.Text = $"{_nodeInfo.ConnStrInfo.Database}.xlsx";
            lvTables.BindData(tables);
            string file = GetFullName(txtDataFile.Text);
            if (File.Exists(file))
            {
                HashSet<string> tableNames = new HashSet<string>();
                using (var pkg = new ExcelPackage(new FileInfo(file)))
                {
                    foreach (var item in pkg.Workbook.Worksheets)
                        tableNames.Add(item.Name);
                }
                foreach (ListViewItem item in lvTables.Items)
                {
                    item.Checked = tableNames.Contains(item.Text);
                }
                cbxExportMode.SelectedIndex = 1;
            }
            else
            {
                cbxExportMode.SelectedIndex = 0;
            }
        }
        #endregion

        #region Util
        private MySqlDatabase GetDatabase()
            => new MySqlDatabase(_nodeInfo.ConnStrInfo.ConnectionString, _nodeInfo.ConnStrInfo.ConnectTimeout);
        private string GetFullName(string fileName)
            => Path.Combine(Path.GetDirectoryName(MainForm.CurrentDTE.ActiveProject.FullName), fileName);
        #endregion

        #region CreateSql
        private void btnSqlBrowser_Click(object sender, EventArgs e)
        {
            if (ofdBrowser.ShowDialog() == DialogResult.OK)
            {
                var srcFile = new FileInfo(ofdBrowser.FileName);
                string destFileName = GetFullName(txtCreateSql.Text);
                srcFile.CopyTo(destFileName);
                MainForm.CurrentDTE.ActiveProject.AddFromFile(destFileName);
                MessageBox.Show("文件已复制到当前项目中。", "提示");
            }
        }
        private void btnSqlOpen_Click(object sender, EventArgs e)
        {
            string file = GetFullName(txtCreateSql.Text);
            if (!File.Exists(file))
            {
                MessageBox.Show("数据文件不存在。", "错误");
                return;
            }
            System.Diagnostics.Process.Start(file);
        }
        private void btnSqlExec_Click(object sender, EventArgs e)
        {
            string file = GetFullName(txtCreateSql.Text);
            if (!File.Exists(file))
            {
                MessageBox.Show("初始化SQL文件不存在。","错误");
                return;
            }
            var db = GetDatabase();
            try
            {
                db.ExecSqlNonQuery(File.ReadAllText(file, Encoding.GetEncoding("gb2312")));
                MessageBox.Show("创建数据对象成功。", "提示");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region InitData
        private void btnDataBrowser_Click(object sender, EventArgs e)
        {
            if (ofdBrowser.ShowDialog() == DialogResult.OK)
            {
                var srcFile = new FileInfo(ofdBrowser.FileName);
                string destFileName = GetFullName(txtDataFile.Text);
                srcFile.CopyTo(destFileName);
                MainForm.CurrentDTE.ActiveProject.AddFromFile(destFileName);
                MessageBox.Show("文件已复制到当前项目中。", "提示");
            }
        }
        private void btnDataOpen_Click(object sender, EventArgs e)
        {
            string file = GetFullName(txtDataFile.Text);
            if (!File.Exists(file))
            {
                MessageBox.Show("数据文件不存在。", "错误");
                return;
            }
            System.Diagnostics.Process.Start(file);
        }
        private void btnDataExport_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认导出数据到文件？注意文件可能被覆盖。", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            string file = GetFullName(txtDataFile.Text);
            // 0-创建新文件 1-更新或新增 2-仅更新 3-仅新增
            var mode = cbxExportMode.SelectedIndex;
            if (File.Exists(file) && mode == 0)
            {
                MessageBox.Show("数据文件已存在，无法创建新文件，请选择更新。", "错误");
                return;
            }
            var tableNames = GetSelectedTables();
            if (tableNames.Count == 0)
            {
                MessageBox.Show("请选择需要导出的表。", "错误");
                return;
            }
            var db = GetDatabase();
            try
            {
                using (var pkg = GetExcelPackage(file, mode))
                {
                    foreach (var tableName in tableNames)
                    {
                        var dt = db.GetTable(tableName);
                        WriteTable(dt, pkg, mode);
                    }
                    File.WriteAllBytes(file, pkg.GetAsByteArray());
                }
                MainForm.CurrentDTE.ActiveProject.AddFromFile(file);
                MessageBox.Show("导出数据成功。", "提示");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }
        }
        private ExcelPackage GetExcelPackage(string file, int mode)
        {
            return mode == 0 ? new ExcelPackage() : new ExcelPackage(new FileInfo(file), true);
        }
        private void WriteTable(DataTable dt, ExcelPackage pkg, int mode)
        {
            ExcelWorksheet sheet = null;
            var config = new ExcelWriteConfig();
            #region Mode
            switch (mode)
            {
                case 0: // 创建新文件
                    sheet = pkg.Workbook.Worksheets.Add(dt.TableName);
                    config.WriteHeader = true;
                    break;
                case 1: // 更新或新增
                    sheet = pkg.Workbook.Worksheets[dt.TableName];
                    if (sheet == null)
                    {
                        sheet = pkg.Workbook.Worksheets.Add(dt.TableName);
                        config.WriteHeader = true;
                    }
                    else
                    {
                        config.WriteHeader = false;
                        config.StartRowIndex = 2;
                    }
                    break;
                case 2: // 仅更新
                    sheet = pkg.Workbook.Worksheets[dt.TableName];
                    config.WriteHeader = false;
                    config.StartRowIndex = 2;
                    break;
                case 3: // 仅新增
                    sheet = pkg.Workbook.Worksheets[dt.TableName];
                    if (sheet != null)
                        sheet = null;
                    else
                        sheet = pkg.Workbook.Worksheets.Add(dt.TableName);
                    config.WriteHeader = true;
                    break;
            }
            if (sheet == null) return;
            #endregion
            EPPlusUtil.Write(sheet, dt, config);
        }
        private List<string> GetSelectedTables()
        {
            var ret = new List<string>();
            foreach (ListViewItem item in lvTables.Items)
            {
                if (item.Checked)
                    ret.Add(item.Text);
            }
            return ret;
        }
        private void btnDataImport_Click(object sender, EventArgs e)
        {
            string file = GetFullName(txtDataFile.Text);
            if (!File.Exists(file))
            {
                MessageBox.Show("数据文件不存在。", "错误");
                return;
            }
            if (MessageBox.Show("确认导入文件数据到数据库？注意：导入后将不能回复！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            TransactionManager tm = new TransactionManager();
            try
            {
                var db = GetDatabase();
                var provider = new MySqlOrmProvider();
                var typeMpper = new MySqlTypeMapper();
                using (var pkg = GetExcelPackage(file, 1))
                {
                    foreach (var sheet in pkg.GetWorksheets())
                    {
                        string sql = $"delete from {sheet.Name}";
                        db.ExecSqlNonQuery(sql, tm);
                        var insertDao = provider.BuildInsertDao(db, sheet.Name);
                        var config = new ExcelReadConfig();
                        var srcTable = EPPlusUtil.ReadToTable(sheet, config);
                        foreach (DataRow row in srcTable.Rows)
                        {
                            for (int i = 0; i < srcTable.Columns.Count; i++)
                            {
                                var parameter = insertDao.Command.Parameters[i] as MySqlParameter;
                                var destType = typeMpper.MapDotNetType(parameter.MySqlDbType);
                                var value = Convert.ToString(row[i]);
                                parameter.Value = string.IsNullOrEmpty(value) ? null : TinyFxUtil.ConvertTo(row[i], destType);
                            }
                            insertDao.ExecNonQuery(tm);
                        }
                    }
                }
                tm.Commit();
                MessageBox.Show("导入数据成功。", "提示");
            }
            catch (Exception ex)
            {
                tm.Rollback();
                MessageBox.Show(ex.Message, "错误");
            }
        }

        #endregion

        #region Tables
        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvTables.Items)
                item.Checked = true;
        }

        private void btnSelectInvert_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvTables.Items)
                item.Checked = !item.Checked;
        }

        private void btnSelectNone_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvTables.Items)
                item.Checked = false;
        }
        #endregion

    }

    [Serializable]
    public class DbInitSettings
    {
        public string CreateSqlFile { get; set; }
        public string InitDataFile { get; set; }
    }
}
