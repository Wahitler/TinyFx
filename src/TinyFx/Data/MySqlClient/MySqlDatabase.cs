using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyFx.Data.Instrumentation;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data.Common;
using System.Data;
using System.Text.RegularExpressions;
using TinyFx.Data.ORM;
using TinyFx.Data.Schema;

namespace TinyFx.Data.MySqlClient
{
    /// <summary>
    /// 表示一个MySQL数据库操作对象，需要数据提供程序MySQL Connector Net（mysql.data.dll），参数以@开头
    /// </summary>
    public class MySqlDatabase : Database<MySqlParameter, MySqlDbType>
    {
        #region Constructors
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="config">配置信息</param>
        public MySqlDatabase(ConnectionStringConfig config)
            : base(config) { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="connectionStringName">配置文件中的 connectionStringName， 如果长度超过50则默认理解为connectionString</param>
        public MySqlDatabase(string connectionStringName = null)
            : base(connectionStringName) { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="commandTimeout">超时时间，单位秒</param>
        /// <param name="inst">数据操作执行事件监测对象</param>
        public MySqlDatabase(string connectionString, int commandTimeout, IDataInstProvider inst = null)
            : base(connectionString, commandTimeout, inst) { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="readConnectionString">只读数据库连接字符串</param>
        /// <param name="commandTimeout">超时时间，单位秒</param>
        /// <param name="inst">数据操作执行事件监测对象</param>
        public MySqlDatabase(string connectionString, string readConnectionString, int commandTimeout, IDataInstProvider inst = null)
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

        protected override char ParameterToken => '@';
        public override bool SupportsAsync => false;
        public override DbProviderFactory Factory => MySqlClientFactory.Instance;

        public override DbDataProvider Provider => DbDataProvider.MySqlClient;
        protected override void SetParameterDbType(MySqlParameter para, MySqlDbType dbType)
            => para.MySqlDbType = dbType;

        protected override ConnectionStringInfo GetConnectionStringInfo()
            => GetConnectionStringInfo(ConnectionString);

        /// <summary>
        /// 获取连接字符串信息
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static ConnectionStringInfo GetConnectionStringInfo(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentNullException("connectionString", "connectionString参数不能为空。");
            var csb = new MySqlConnectionStringBuilder(connectionString);
            ConnectionStringInfo ret = new ConnectionStringInfo
            {
                Provider = DbDataProvider.MySqlClient,
                ConnectionString = connectionString,
                DataSource = csb.Server,
                Database = csb.Database,
                UserID = csb.UserID,
                Password = csb.Password,
                ConnectTimeout = (int)csb.ConnectionTimeout
            };
            return ret;
        }

        public override IDataParameter CloneParameter(IDataParameter parameter)
        {
            var input = parameter as MySqlParameter;
            var ret = new MySqlParameter()
            {
                ParameterName = input.ParameterName,
                MySqlDbType = input.MySqlDbType,
                Direction = input.Direction,
                DbType = input.DbType,
                IsNullable = input.IsNullable,
                Size = input.Size,
                Precision = input.Precision,
                Scale = input.Scale,
                SourceColumn = input.SourceColumn,
                Value = input.Value,
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
                    // 创建一个新的连接获取Parameters，不能使用原来的Command对象。
                    using (CommandWrapper cmd = CreateCommand(command.CommandText, command.CommandType, null))
                    {
                        OpenConnection(cmd.Connection);
                        MySqlCommandBuilder.DeriveParameters((MySqlCommand)cmd.Command);
                        foreach (var param in cmd.Command.Parameters)
                            command.Parameters.Add(param);
                    }
#if CORE_2
                    /*
                    // 创建一个新的连接获取Parameters，不能使用原来的Command对象。
                    string sql = $"SELECT * FROM information_schema.PARAMETERS WHERE ROUTINE_TYPE='PROCEDURE' AND SPECIFIC_SCHEMA ='{DatabaseName}' AND SPECIFIC_NAME='{command.CommandText}' ORDER BY ORDINAL_POSITION";
                    using (var reader = ExecSqlReader(sql))
                    {
                        while (reader.Read())
                        {
                            var param = new MySqlParameter();
                            param.ParameterName = reader.ToString("PARAMETER_NAME");
                            var engineType = reader.ToString("DATA_TYPE");
                            var engineTypeString = reader.ToString("DTD_IDENTIFIER");
                            param.MySqlDbType = new MySqlTypeMapper().MapDbType(engineType, engineTypeString);
                            switch (reader.ToString("PARAMETER_MODE"))
                            {
                                case "IN":
                                    param.Direction = ParameterDirection.Input;
                                    break;
                                case "OUT":
                                    param.Direction = ParameterDirection.Output;
                                    break;
                                case "INOUT":
                                    param.Direction = ParameterDirection.InputOutput;
                                    break;
                            }
                            command.Parameters.Add(param);
                        }
                    }
                    */
#endif
                    break;
            }
        }
        #endregion

        #region Database Objects
        /// <summary>
        /// 获得Dao
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public override IDao GetSqlDao(string sql)
            => new MySqlSqlDao(sql, this);
        /// <summary>
        /// 获得Dao
        /// </summary>
        /// <param name="proc"></param>
        /// <returns></returns>
        public override IDao GetProcDao(string proc)
            => new MySqlProcDao(proc, this);
        /// <summary>
        /// 获得IDataPager分页对象
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="pageSize"></param>
        /// <param name="keyField"></param>
        /// <returns></returns>
        public override IDataPager GetPager(string sql, int pageSize, string keyField = null)
            => new MySqlDataPager(sql, pageSize, this);

        #endregion

        #region 特定数据库方法
        /// <summary>
        /// 获得MySQL环境变量
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="variableName">环境变量名称</param>
        /// <returns></returns>
        public T GetVariable<T>(MySqlVariableNames variableName)
        {
            return this.ExecSqlScalarFormat<T>("SHOW VARIABLES where Variable_name = '{0}'"
                , variableName.ToString().ToLower());
        }
        /// <summary>
        /// 获得MySQL环境变量
        /// </summary>
        /// <returns></returns>
        public DataTable GetVariables()
            => this.ExecSqlTable("SHOW VARIABLES");

        /// <summary>
        /// 获取数据库死锁信息
        /// </summary>
        /// <returns></returns>
        public DeadLockInfo GetDeadLockInfo()
        {
            string status = this.ExecSqlSingle("show engine innodb status")["status"].ToString();
            if (string.IsNullOrEmpty(status)) return null;
            var ret = new DeadLockInfo();
            ret.Status = status;
            string sign = "LATEST DETECTED DEADLOCK\n------------------------\n";
            var index = status.IndexOf(sign) + sign.Length;
            status = status.Substring(index);
            ret.DeadLockDate = status.Substring(0, 19).ToDateTime();

            var lines = status.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            ret.TransactionA = lines[7];
            ret.AWaitingFor = lines[9];

            sign = "*** (2) TRANSACTION:\n";
            index = status.IndexOf(sign) + sign.Length;
            status = status.Substring(index);
            lines = status.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            ret.TransactionB = lines[4];
            ret.BHoldsLock = lines[6];

            sign = "*** (2) WAITING FOR THIS LOCK TO BE GRANTED:\n";
            index = status.IndexOf(sign) + sign.Length;
            status = status.Substring(index);
            lines = status.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            ret.BWaitingFor = lines[0];
            return ret;
        }

        #endregion
    }
}
