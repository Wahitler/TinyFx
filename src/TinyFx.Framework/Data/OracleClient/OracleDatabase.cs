using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyFx.Data.Instrumentation;
using System.Data.Common;
using TinyFx.Configuration;
using System.Data;
using System.Text.RegularExpressions;
using System.Reflection;
using Oracle.ManagedDataAccess.Client;

namespace TinyFx.Data.OracleClient
{
    /// <summary>
    /// 表示一个Oracle数据库操作对象，数据提供程序由Oracle的ODAC提供(需要安装ODAC)。参数以：开头
    /// 由.net提供数据提供程序，支持Oracle8.1.7-9iR2版本，已过期不再使用!
    /// </summary>
    public class OracleDatabase : Database<OracleParameter, OracleDbType>
    {
        #region Constructors
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="config">配置信息</param>
        public OracleDatabase(ConnectionStringConfig config) 
            : base(config) { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="connectionStringName">配置文件中的 connectionStringName， 如果长度超过50则默认理解为connectionString</param>
        public OracleDatabase(string connectionStringName = null)
            : base(connectionStringName) { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="commandTimeout">超时时间，单位秒</param>
        /// <param name="inst">数据操作执行事件监测对象</param>
        public OracleDatabase(string connectionString, int commandTimeout, IDataInstProvider inst = null) 
            : base(connectionString, commandTimeout, inst) { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="readConnectionString">只读数据库连接字符串</param>
        /// <param name="commandTimeout">超时时间，单位秒</param>
        /// <param name="inst">数据操作执行事件监测对象</param>
        public OracleDatabase(string connectionString, string readConnectionString, int commandTimeout, IDataInstProvider inst = null) 
            : base(connectionString, readConnectionString, commandTimeout, inst) { }

        #endregion

        #region Overrides
        /// <summary>
        /// 获得符合数据库提供者的参数名称
        /// </summary>
        /// <param name="parameterName">参数名称</param>
        /// <returns></returns>
        public override string GetParameterName(string parameterName)
            => (parameterName[0] != ParameterToken) ? ParameterToken + parameterName : parameterName;

        /// <summary>
        /// ParameterToken
        /// </summary>
        protected override char ParameterToken => ':';
        /// <summary>
        /// 是否支持异步
        /// </summary>
        public override bool SupportsAsync => false;
        /// <summary>
        /// DbProviderFactory
        /// </summary>
        public override DbProviderFactory Factory => OracleClientFactory.Instance;
        public override DbDataProvider Provider => DbDataProvider.Odac;

        protected override ConnectionStringInfo GetConnectionStringInfo()
            => GetConnectionStringInfo(ConnectionString);

        /// <summary>
        /// 获取连接字符串信息
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static ConnectionStringInfo GetConnectionStringInfo(string connectionString)
        {
            var csb = new OracleConnectionStringBuilder(connectionString);
            ConnectionStringInfo ret = new ConnectionStringInfo
            {
                Provider = DbDataProvider.Odac,
                ConnectionString = connectionString,
                DataSource = csb.DataSource,
                UserID = csb.UserID,
                Password = csb.Password,
                ConnectTimeout = csb.ConnectionTimeout,
            };
            return ret;
        }

        /// <summary>
        /// 设置参数类型方法
        /// </summary>
        /// <param name="para"></param>
        /// <param name="dbType"></param>
        protected override void SetParameterDbType(OracleParameter para, OracleDbType dbType)
            => para.OracleDbType = dbType;
        #endregion

        #region DeriveParameters
        /// <summary>
        /// DeriveParameters
        /// </summary>
        /// <param name="command"></param>
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
                    using (CommandWrapper cmd = CreateCommand(command.CommandText, command.CommandType, null))
                    {
                        OpenConnection(cmd.Connection);
                        OracleCommandBuilder.DeriveParameters((OracleCommand)cmd.Command);
                        //Type commandBuilder = Factory.CreateCommandBuilder().GetType();
                        //commandBuilder.InvokeMember("DeriveParameters", BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Static, null, null, new object[] { command.Command });
                        foreach (var param in cmd.Command.Parameters)
                            command.Parameters.Add(param);
                    }
                    break;
            }
        }
        public override List<string> ParseSqlParameterNames(string sql)
        {
            var ret = new List<string>();
            Regex regx = new Regex(@"(?<p>:\w+)");
            MatchCollection matches = regx.Matches(String.Concat(sql, " "));
            foreach (Match match in matches)
            {
                string name = GetParameterName(match.Groups["p"].Value.ToUpper());
                ret.Add(name);
            }
            return ret;
        }
        #endregion

        #region Database Objects
        /// <summary>
        /// 获得IDataPager
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="pageSize"></param>
        /// <param name="keyField"></param>
        /// <returns></returns>
        public override IDataPager GetPager(string sql, int pageSize, string keyField = null)
            => new OracleDataPager(sql, pageSize, this, keyField);

        /// <summary>
        /// 创建SqlDao
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public override IDao GetSqlDao(string sql)
            => new OracleSqlDao(sql, this);

        /// <summary>
        /// 创建ProcDao
        /// </summary>
        /// <param name="proc"></param>
        /// <returns></returns>
        public override IDao GetProcDao(string proc)
            => new OracleProcDao(proc, this);
        #endregion

        #region 特定数据库方法
        #endregion
    }
}
