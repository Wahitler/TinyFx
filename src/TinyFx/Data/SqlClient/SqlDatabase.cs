using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using TinyFx.Data.Instrumentation;
using System.Text.RegularExpressions;

namespace TinyFx.Data.SqlClient
{
    /// <summary>
    /// 表示一个SQL Server数据库操作对象,参数以@开头
    /// </summary>
    public partial class SqlDatabase : Database<SqlParameter, SqlDbType>
    {
        #region Constructors
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="config">配置信息</param>
        public SqlDatabase(ConnectionStringConfig config)
            : base(config) { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="connectionStringName">配置文件中的 connectionStringName， 如果长度超过50则默认理解为connectionString</param>
        public SqlDatabase(string connectionStringName = null)
            : base(connectionStringName) { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="commandTimeout">超时时间，单位秒</param>
        /// <param name="inst">数据操作执行事件监测对象</param>
        public SqlDatabase(string connectionString, int commandTimeout, IDataInstProvider inst = null)
            : base(connectionString, commandTimeout, inst) { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="readConnectionString">只读数据库连接字符串</param>
        /// <param name="commandTimeout">超时时间，单位秒</param>
        /// <param name="inst">数据操作执行事件监测对象</param>
        public SqlDatabase(string connectionString, string readConnectionString, int commandTimeout, IDataInstProvider inst = null)
            : base(connectionString, readConnectionString, commandTimeout, inst) { }
        #endregion

        #region Overrides
        /// <summary>
        /// 获得符合数据库提供者的参数名称
        /// </summary>
        /// <param name="parameterName">参数名称</param>
        /// <returns></returns>
        public override string GetParameterName(string parameterName)
            => parameterName[0] != ParameterToken ? ParameterToken + parameterName : parameterName;

        protected override char ParameterToken => '@';

        public override bool SupportsAsync => false;

        public override DbProviderFactory Factory => SqlClientFactory.Instance;
        public override DbDataProvider Provider => DbDataProvider.SqlClient;
        protected override void SetParameterDbType(SqlParameter para, SqlDbType dbType)
            => para.SqlDbType = dbType;
        protected override ConnectionStringInfo GetConnectionStringInfo()
            => GetConnectionStringInfo(ConnectionString);

        /// <summary>
        /// 获取连接字符串信息
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static ConnectionStringInfo GetConnectionStringInfo(string connectionString)
        {
            var csb = new SqlConnectionStringBuilder(connectionString);
            ConnectionStringInfo ret = new ConnectionStringInfo
            {
                Provider = DbDataProvider.SqlClient,
                ConnectionString = connectionString,
                DataSource = csb.DataSource,
                Database = csb.InitialCatalog,
                UserID = csb.UserID,
                Password = csb.Password,
                ConnectTimeout = csb.ConnectTimeout
            };
            return ret;
        }
        protected override void DeriveParameters(CommandWrapper command)
        {
            switch (command.CommandType)
            {
                case CommandType.Text:
                    foreach (var name in ParseSqlParameterNames(command.CommandText))
                    {
                        if (!command.Parameters.Contains(name))
                            command.Parameters.Add(CreateParameter(name));
                    }
                    break;
                case CommandType.StoredProcedure:
#if CORE_2
                    /*
                    // 创建一个新的连接获取Parameters，不能使用原来的Command对象。
                    string sql = $@"select * from (
select t3.name as SchemaName, t2.name as ProcedureName, t3.name + '.' + t2.name as ProcedureFullName
	, t1.name as ParameterName, t4.name as TypeName, t1.parameter_id
	, t1.precision, t1.scale, t1.is_output, t1.is_nullable
from sys.parameters t1

    inner join sys.procedures t2 on t1.object_id = t2.object_id

    inner join sys.schemas t3 on t2.schema_id = t3.schema_id

    inner join sys.types t4 on t1.user_type_id = t4.user_type_id
) TBL where ProcedureFullName = '{command.CommandText}'
order by parameter_id";
                    using (var reader = ExecSqlReader(sql))
                    {
                        while (reader.Read())
                        {
                            var engineType = reader.ToString("TypeName");
                            var param = new SqlParameter
                            {
                                ParameterName = reader.ToString("ParameterName"),
                                SqlDbType = new SqlServerTypeMapper().MapDbType(engineType),
                                Direction = reader.ToInt32("is_output") == 0 ? ParameterDirection.Input : ParameterDirection.Output
                            };
                            command.Parameters.Add(param);
                        }
                    }
                    */
#endif
#if NET_4
                    using (CommandWrapper cmd = CreateCommand(command.CommandText, command.CommandType, null))
                    {
                        OpenConnection(cmd.Connection);
                        SqlCommandBuilder.DeriveParameters((SqlCommand)cmd.Command);
                        foreach (var param in cmd.Command.Parameters)
                            command.Parameters.Add(param);
                    }
#endif
                    break;
            }
        }
        #endregion

        #region Database Objects
        public override IDataPager GetPager(string sql, int pageSize, string keyField = null)
            => new SqlDataPager(sql, pageSize, this, keyField);

        public override IDao GetSqlDao(string sql)
            => new SqlSqlDao(sql, this);

        public override IDao GetProcDao(string proc)
            => new SqlProcDao(proc, this);
        #endregion

        #region 特定数据库方法
        /// <summary>
        /// 创建SqlBulkCopy，实现类似SQL Server数据库的bcp工具的功能。
        /// </summary>
        /// <param name="tm">事务对象</param>
        /// <returns></returns>
        public SqlBulkCopy CreateBcp(TransactionManager tm)
            => CreateBcp(SqlBulkCopyOptions.Default, tm);

        /// <summary>
        /// 创建SqlBulkCopy，实现类似SQL Server数据库的bcp工具的功能。
        /// </summary>
        /// <param name="opts">SqlBulkCopyOptions 枚举中的值的组合</param>
        /// <returns></returns>
        public SqlBulkCopy CreateBcp(SqlBulkCopyOptions opts)
            => CreateBcp(opts, null);

        /// <summary>
        /// 创建SqlBulkCopy，实现类似SQL Server数据库的bcp工具的功能。
        /// </summary>
        /// <param name="opts">SqlBulkCopyOptions 枚举中的值的组合</param>
        /// <param name="tm">事务对象</param>
        /// <returns></returns>
        public SqlBulkCopy CreateBcp(SqlBulkCopyOptions opts, TransactionManager tm)
        {
            SqlBulkCopy ret = null;
            if (Provider != DbDataProvider.SqlClient)
                throw new ArgumentException("批量加载对象只支持SQL Server数据库。");

            if (tm == null)
            {
                ret = new SqlBulkCopy(ConnectionString, opts);
            }
            else
            {
                SqlTransaction tran = (SqlTransaction)tm.GetTransaction(this);
                ret = new SqlBulkCopy(tran.Connection, opts, tran);
            }
            ret.BulkCopyTimeout = CommandTimeout;
            return ret;
        }
        #endregion
    }
}
