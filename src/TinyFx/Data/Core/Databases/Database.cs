using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using TinyFx.Data.Instrumentation;
using System.ComponentModel;
using System.Data.SqlClient;
using TinyFx.Security;
using System.Collections.Concurrent;
using System.Text.RegularExpressions;

namespace TinyFx.Data
{
    /// <summary>
    /// 数据库访问类，提供数据库操作方法，通过DbFactory类进行创建。线程安全
    /// ExecuteScalar ==> T
    /// ExecuteNonQuery
    /// ExecuteReader ==> Table/T (Mutil|List|Single|First)
    /// </summary>
    public abstract partial class Database
    {
        #region Fields & Abstract

        /// <summary>
        /// DbProviderFactory对象
        /// </summary>
        public abstract DbProviderFactory Factory { get; }

        /// <summary> 
        /// 数据提供程序类型
        /// </summary>
        public abstract DbDataProvider Provider { get; }

        #region ConnectionStringConfig
        protected ConnectionStringConfig _connectionStringConfig { get; private set; }

        /// <summary>
        /// 配置中数据库连接字符串名
        /// </summary>
        public string ConnectionStringName => _connectionStringConfig.ConnectionStringName;

        /// <summary>
        /// 连接字符串
        /// </summary>
        public string ConnectionString => _connectionStringConfig.ConnectionString;

        /// <summary>
        /// 只读数据库连接字符串
        /// </summary>
        public string ReadConnectionString => _connectionStringConfig.ReadConnectionString;
        /// <summary>
        /// 是否使用只读数据库连接
        /// 解决问题：当需要读取刚操作的数据，并且他们不在一个事务时，需要设置此属性为false访问主库
        /// </summary>
        public bool UseOnlyRead { get; set; } = true;

        /// <summary>
        /// 获取或设置在终止执行命令的尝试并生成错误之前的等待时间，单位秒。默认30秒，0表示不限制时间
        /// </summary>
        public int CommandTimeout { get; set; }

        /// <summary>
        /// 性能监视提供程序
        /// </summary>
        public IDataInstProvider InstProvider => _connectionStringConfig.InstProvider ?? DefaultDataInstProvider.Instance;
        #endregion // ConnectionStringConfig

        #region ConnectionStringInfo
        private ConnectionStringInfo _connectionStringInfo;
        /// <summary>
        /// 获取连接字符串信息
        /// </summary>
        /// <returns></returns>
        protected abstract ConnectionStringInfo GetConnectionStringInfo();
        
        /// <summary>
        /// 数据库连接字符串信息
        /// </summary>
        public  ConnectionStringInfo ConnectionStringInfo
        {
            get {
                if (_connectionStringInfo == null)
                    _connectionStringInfo = GetConnectionStringInfo();
                if (_connectionStringInfo == null)
                    throw new Exception("获取ConnectionStringInfo失败，请检查解析代码是否有误。");
                return _connectionStringInfo;
            }
        }
        
        /// <summary>
        ///  数据库名称
        /// </summary>
        public string DatabaseName => ConnectionStringInfo.Database;
        #endregion 

        /// <summary>
        /// 不同的数据库可能需要重写
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public virtual IDataParameter CloneParameter(IDataParameter parameter)
            => (IDataParameter)((ICloneable)parameter).Clone();

        /// <summary>
        /// 解析并获得SQL中定义的参数名称列表，转成大写
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public virtual List<string> ParseSqlParameterNames(string sql)
        {
            List<string> ret = new List<string>();
            Regex regx = new Regex(@"[^@@](?<p>@\w+)");
            MatchCollection matches = regx.Matches(string.Concat(sql, " "));
            foreach (Match match in matches)
            {
                var name = GetParameterName(match.Groups["p"].Value.ToUpper());
                ret.Add(name);
            }
            return ret;
        }

        /// <summary>
        /// 是否支持异步操作
        /// </summary>
        public virtual bool SupportsAsync { get { return false; } }

        #endregion // Fields 

        #region Constructors
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="config"></param>
        public Database(ConnectionStringConfig config)
            => Init(config);

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="connectionStringName">配置文件中的 connectionStringName</param>
        public Database(string connectionStringName = null)
        {
            if (!DbConfigManager.TryGetConnectionStringConfig(connectionStringName, Provider, out ConnectionStringConfig config))
                throw new Exception($"ConnectionStringName在配置中不存在。ConnectionStringName: {connectionStringName}");
            Init(config);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="commandTimeout">超时时间，单位秒</param>
        /// <param name="inst">数据操作执行事件监测对象</param>
        public Database(string connectionString, int commandTimeout, IDataInstProvider inst = null)
            => Init(DbConfigManager.GetConnectionStringConfig(Provider, connectionString, null, commandTimeout, inst));

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="readConnectionString">只读数据库连接字符串</param>
        /// <param name="commandTimeout">超时时间，单位秒</param>
        /// <param name="inst">数据操作执行事件监测对象</param>
        public Database(string connectionString, string readConnectionString, int commandTimeout, IDataInstProvider inst = null)
            => Init(DbConfigManager.GetConnectionStringConfig(Provider, connectionString, readConnectionString, commandTimeout, inst));

        private void Init(ConnectionStringConfig config)
        {
            if (string.IsNullOrEmpty(config.ConnectionString))
                throw new ArgumentException("创建Database时数据库连接字符串不能为空。", "config");
            if (config.Provider != Provider)
                throw new Exception($"配置文件中数据提供程序与当期Database不匹配。Database:{Provider} - Config:{config.Provider}");
            _connectionStringConfig = config;
            CommandTimeout = config.CommandTimeout;
        }
        #endregion // Constructors

        #region Connection 
        /*************************** 【创建Connection】 ****************/
        // 创建数据库连接
        protected internal DbConnection CreateConnection(string connectionString = null)
        {
            DbConnection ret = Factory.CreateConnection();
            ret.ConnectionString = connectionString ?? ConnectionString; ;
            return ret;
        }
        // 打开数据库连接
        protected internal void OpenConnection(DbConnection conn)
        {
            try
            {
                conn.Open();
                InstProvider.FireConnectionOpenedEvent(ConnectionString);
            }
            catch(Exception ex)
            {
                ex.AddUserData("错误信息", "打开数据库连接失败。");
                ex.AddUserData("方法名", "OpenConnection()");
                ex.AddUserData("ConnectionString", ConnectionString);
                InstProvider.FireConnectionFailedEvent(ConnectionString, ex);
                throw;
            }
        }
        /// <summary>
        /// 检查当前数据库是否可以连接
        /// </summary>
        /// <returns></returns>
        public bool CheckConnection()
        {
            var ret = false;
            var conn = CreateConnection(ConnectionString);
            try
            {
                conn.Open();
                ret = conn.State == ConnectionState.Open;
            }
            catch { }
            finally {
                conn.Close();
            }
            return ret;
        }
        #endregion // Connection

        #region Command
        /*************************** 【创建Command】 ********************/
        /// <summary>
        /// 创建完整的Command，包含Connection和Parameters
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="commandType"></param>
        /// <param name="paras"></param>
        /// <param name="tm"></param>
        /// <param name="repairConnection">是否配置Connection属性.DAO对象在执行时才创建</param>
        /// <returns></returns>
        protected internal CommandWrapper CreateCommand(string commandText, CommandType commandType, IEnumerable<DbParameter> paras, TransactionManager tm, bool repairConnection = true)
        {
            DbCommand command = Factory.CreateCommand();
            command.CommandText = commandText;
            command.CommandType = commandType;
            command.CommandTimeout = CommandTimeout;
            if (paras != null)
            {
                foreach (DbParameter para in paras)
                {
                    if (para.Value == null)
                        para.Value = DBNull.Value;
                    command.Parameters.Add(para);
                }
            }
            // 配置Connection，处理事务连接和只读连接
            if (repairConnection)
                RepairCommandConnection(command, tm);
            return new CommandWrapper(command);
        }
        /// <summary>
        /// 创建Command，解析Parameters并设置Values
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="commandType"></param>
        /// <param name="tm"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        protected internal CommandWrapper CreateCommand(string commandText, CommandType commandType, TransactionManager tm, params object[] values)
        {
            CommandWrapper command = CreateCommand(commandText, commandType, null, tm);
            if (values != null && values.Length > 0)
            {
                AutoDeriveParameters(command);
                SetParametersValue(command, values);
            }
            return command;
        }

        // 根据SQL语句判断是否只读，尝试分配只读 ReadConnectionString
        private static ConcurrentDictionary<string, bool> _useReadConnection = new ConcurrentDictionary<string, bool>();
        internal void RepairCommandConnection(DbCommand command, TransactionManager tm)
        {
            if (tm != null)
            {
                DbTransaction tran = tm.GetTransaction(this);
                command.Connection = tran.Connection;
                command.Transaction = tran;
            }
            else
            {
                var isOnlyRead = false;
                if (tm == null && UseOnlyRead && !string.IsNullOrEmpty(ReadConnectionString) && command.CommandType == CommandType.Text)
                {
                    isOnlyRead = _useReadConnection.GetOrAdd(command.CommandText, (sql) => {
                        return (sql.TrimStart().Substring(0, 7).ToLower() == "select ");
                    });
                }
                command.Connection = isOnlyRead ? CreateConnection(ReadConnectionString) : CreateConnection();
            }
        }
        #endregion // Command

        #region Execute
        /*************************** 【执行Command】 ********************/
        //执行Command
        protected T ExecuteCommand<T>(CommandWrapper command, Func<CommandWrapper, T> action, bool closeConnection = true)
        {
            T ret = default(T);
            try
            {
                if (command.Connection.State == ConnectionState.Closed)
                    OpenConnection(command.Connection);
                DateTime startTime = DateTime.Now;
                try
                {
                    ret = action(command);
                    InstProvider.FireCommandExecutedEvent(command, startTime, DateTime.Now);
                }
                catch(Exception ex)
                {
                    RepairCommandException(command, ex);
                    InstProvider.FireCommandFailedEvent(command, ex);
                    throw;
                }
            }
            finally 
            {
                if (closeConnection) // 返回DataReader时不能关闭Connection
                    command.Dispose(); // 如存在事务Command对象内有处理
            }
            return ret;
        }
        
        // **** 执行ExecuteScalar
        internal object ExecScalar(CommandWrapper command)
            => ExecuteCommand(command, cmd => { return cmd.ExecuteScalar(); });

        // *** 执行ExecuteNonQuery
        internal int ExecNonQuery(CommandWrapper command)
            => ExecuteCommand(command, cmd => { return cmd.ExecuteNonQuery(); });

        // *** 执行ExecReader 返回封装的DbDataReader
        internal DataReaderWrapper ExecReader(CommandWrapper command)
        {
            Func<CommandWrapper, DataReaderWrapper> action = (cmd) =>
            {
                // 如果没有事务，则当遍历完成时,关闭Reader的同时关闭Connection
                return cmd.HasTransaction ? cmd.ExecuteReader() : cmd.ExecuteReader(CommandBehavior.CloseConnection);
            };
            return ExecuteCommand(command, action, false);
        }
        private static void RepairCommandException(CommandWrapper command, Exception ex)
        {
            string commandType = null;
            switch (command.CommandType)
            {
                case CommandType.Text:
                    commandType = "SQL语句";
                    break;
                case CommandType.StoredProcedure:
                    commandType = "存储过程";
                    break;
                case CommandType.TableDirect:
                    commandType = "表名称";
                    break;
            }
            ex.AddUserData("错误信息", string.Format("执行{0}出现异常。", commandType));
            if (command.Transaction != null)
                ex.AddUserData("Transaction", "在事务中");
            ex.AddUserData("ConnectionString", command.ConnectionString);
            ex.AddUserData("CommandText", command.CommandText);
            foreach (DbParameter param in command.Parameters)
            {
                ex.AddUserData(string.Format("Parameter {0} : {1}", param.ParameterName, param.Value));
            }
        }

        // 检查SQL注入
        private static void CheckSqlInjection(object[] values)
        {
            if (values != null)
            {
                foreach (var value in values)
                {
                    if (DbUtil.CheckSqlInjection(Convert.ToString(value)))
                        throw new Exception($"执行ExecSqlFormat时values存在SQL注入风险，请改用其他方法。value: {value}");
                }
            }
        }
        #endregion // Execute

        #region Get DbObjects
        /// <summary>
        /// 获得SqlDao
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public abstract IDao GetSqlDao(string sql);

        /// <summary>
        /// 获得ProcDao
        /// </summary>
        /// <param name="proc"></param>
        /// <returns></returns>
        public abstract IDao GetProcDao(string proc);

        /// <summary>
        /// 创建分页辅助对象
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="userData">关键键（主键或唯一键）</param>
        /// <returns></returns>
        public abstract IDataPager GetPager(string sql, int pageSize, string userData = null);

        public DataTable GetTable(string tableName)
        {
            var ret = ExecSqlTable($"select * from {tableName}");
            ret.TableName = tableName;
            return ret;
        }
        /// <summary>
        /// 获取指定表名的空的 DataTable
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public DataTable GetEmptyTable(string tableName)
        {
            DataTable ret = this.ExecSqlTable($"select * from {tableName} where 1=0");
            ret.TableName = tableName;
            return ret;
        }

        /// <summary>
        /// 获取指定表名的描述列元数据的 DataTable
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public DataTable GetSchemaTable(string tableName)
        {
            DataTable ret = null;
            using (IDataReader reader = this.ExecSqlReader($"select * from {tableName} where 1=0"))
            {
                ret = reader.GetSchemaTable();
            }
            return ret;
        }
        #endregion
    }
}
