using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.ConnectionUI;
using TinyFx.Configuration.Data;
using TinyFx.Data;

namespace TinyFxVSIX.Commands.OrmGen.Forms
{
    public partial class ConnCustomForm : Form
    {
        public ConnCustomForm()
        {
            InitializeComponent();
        }
        public ConnectionStringInfo ConnStrElement { get; set; }

        private void ConnCustomForm_Load(object sender, EventArgs e)
        {
            foreach (var item in Enum.GetNames(typeof(DBDataSource)))
                cbxDbProvider.Items.Add(item);
            cbxDbProvider.SelectedIndex = (int)DBDataSource.MySql;
        }
        private DBDataSource GetProvider()
        {
            return (DBDataSource)cbxDbProvider.SelectedIndex;
        }
        // DBConnectionDataSource -> DataSource
        private static DataSource GetDataSource(DBDataSource source)
        {
            DataSource ret = null;
            switch (source)
            {
                case DBDataSource.Access:
                    ret = DataSource.AccessDataSource;
                    break;
                case DBDataSource.Odbc:
                    ret = DataSource.OdbcDataSource;
                    break;
                case DBDataSource.Oracle:
                    ret = DataSource.OracleDataSource;
                    break;
                case DBDataSource.SqlServer:
                    ret = DataSource.SqlDataSource;
                    break;
                case DBDataSource.SqlFile:
                    ret = DataSource.SqlFileDataSource;
                    break;
            }
            return ret;
        }
        // DataSource -> DBConnectionDataSource
        private static DBDataSource GetProvider(DataSource source)
        {
            DBDataSource ret = DBDataSource.SqlServer;
            if (source == DataSource.AccessDataSource) ret = DBDataSource.Access;
            else if (source == DataSource.OdbcDataSource) ret = DBDataSource.Odbc;
            else if (source == DataSource.OracleDataSource) ret = DBDataSource.Oracle;
            else if (source == DataSource.SqlDataSource) ret = DBDataSource.SqlServer;
            else if (source == DataSource.SqlFileDataSource) ret = DBDataSource.SqlFile;
            return ret;
        }
        // DataSource -> DataProvider
        private static DataProvider GetDataProvider(DataSource source)
        {
            DataProvider ret = source.DefaultProvider;
            if (source == DataSource.OracleDataSource) ret = DataProvider.OracleDataProvider;
            else if (source == DataSource.SqlDataSource) ret = DataProvider.SqlDataProvider;
            return ret;
        }
        private void btnSettings_Click(object sender, EventArgs e)
        {
            DBDataSource provider = GetProvider();
            DataSource ds = GetDataSource(provider);
            DataConnectionDialog dialog = new DataConnectionDialog();
            DataSource.AddStandardDataSources(dialog);
            dialog.SelectedDataSource = ds;
            dialog.SelectedDataProvider = GetDataProvider(ds);
            if (DataConnectionDialog.Show(dialog) == DialogResult.OK)
            {
                cbxDbProvider.SelectedIndex = (int)GetProvider(dialog.SelectedDataSource);
                this.txtConnStr.Text = dialog.ConnectionString;
            }
        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            string providerName = this.cbxDbProvider.SelectedItem.ToString();
            var provider = DbDataProviderUtil.GetProvider(providerName);
            var database = DbFactory.Create(provider, this.txtConnStr.Text);
            ConnStrElement = database.ConnectionStringInfo;
            if (!database.CheckConnection())
                MessageBox.Show("提供的数据库连接字符串无法连接数据库。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                this.DialogResult = DialogResult.OK;
        }

        private void cbxDbProvider_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSettings.Enabled = GetProvider() != DBDataSource.MySql;
            btnConnect.Enabled = !btnSettings.Enabled;
        }

    }
    /// <summary>
    /// DBConnectionDialog所选择的结果
    /// </summary>
    [Serializable]
    public class DBConnectionResult
    {
        /// <summary>
        /// 数据源
        /// </summary>
        public DBDataSource DataSource { get; set; }

        /// <summary>
        /// 数据提供程序
        /// </summary>
        public DbDataProvider DataProvider { get; set; }

        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public string ConnectionString { get; set; }
    }
}
