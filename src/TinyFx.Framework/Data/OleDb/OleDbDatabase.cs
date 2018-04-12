using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using TinyFx.Data.Instrumentation;
using System.Data.Common;
using System.Text.RegularExpressions;
using System.Data;

namespace TinyFx.Data.OleDb
{
    /// <summary>
    /// 表示一个OLE DB数据库操作对象，参数以?占位，必须按照顺序传入
    /// </summary>
    public class OleDbDatabase : Database<OleDbParameter, OleDbType>
    {
        #region Constructors
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="config">配置信息</param>
        public OleDbDatabase(ConnectionStringConfig config) 
            : base(config) { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="connectionStringName">配置文件中的 connectionStringName， 如果长度超过50则默认理解为connectionString</param>
        public OleDbDatabase(string connectionStringName = null)
            : base(connectionStringName) { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="commandTimeout">超时时间，单位秒</param>
        /// <param name="inst">数据操作执行事件监测对象</param>
        public OleDbDatabase(string connectionString, int commandTimeout, IDataInstProvider inst = null) 
            : base(connectionString, commandTimeout, inst) { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="readConnectionString">只读数据库连接字符串</param>
        /// <param name="commandTimeout">超时时间，单位秒</param>
        /// <param name="inst">数据操作执行事件监测对象</param>
        public OleDbDatabase(string connectionString, string readConnectionString, int commandTimeout, IDataInstProvider inst = null) 
            : base(connectionString, readConnectionString, commandTimeout, inst) { }
        #endregion

        #region Overrides
        /// <summary>
        /// 获得符合数据库提供者的参数名称
        /// </summary>
        /// <param name="parameterName">参数名称</param>
        /// <returns></returns>
        public override string GetParameterName(string parameterName) => ParameterToken.ToString();
        
        /// <summary>
        /// ParameterToken
        /// </summary>
        protected override char ParameterToken => '?';
        
        /// <summary>
        /// Factory
        /// </summary>
        public override DbProviderFactory Factory => OleDbFactory.Instance;
        public override DbDataProvider Provider => DbDataProvider.OleDb;

        protected override ConnectionStringInfo GetConnectionStringInfo()
            => GetConnectionStringInfo(ConnectionString);

        /// <summary>
        /// 获取连接字符串信息
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static ConnectionStringInfo GetConnectionStringInfo(string connectionString)
        {
            var csb = new OleDbConnectionStringBuilder(connectionString);
            ConnectionStringInfo ret = new ConnectionStringInfo
            {
                Provider = DbDataProvider.OleDb,
                ConnectionString = connectionString,
                DataSource = csb.DataSource,
                FileName = csb.FileName,
                UserID = (csb.ContainsKey("User ID")) ? Convert.ToString(csb["User ID"]) : string.Empty,
                Password = (csb.ContainsKey("Password")) ? Convert.ToString(csb["Password"]) : string.Empty
            };
            return ret;
        }

        /// <summary>
        /// 设置参数类型方法
        /// </summary>
        /// <param name="para"></param>
        /// <param name="dbType"></param>
        protected override void SetParameterDbType(OleDbParameter para, OleDbType dbType)
            => para.OleDbType = dbType;
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
                    string sql = command.CommandText;
                    Regex regx = new Regex(@"(?<p>\?\w*)");
                    MatchCollection matches = regx.Matches(String.Concat(sql, " "));
                    foreach(Match match in matches)
                    {
                        OleDbParameter para = (OleDbParameter)CreateParameter(match.Groups["p"].Value);
                        command.Parameters.Add(para);
                    }
                    break;
                case CommandType.StoredProcedure:
                    using (CommandWrapper cmd = CreateCommand(command.CommandText, command.CommandType, null))
                    {
                        OpenConnection(cmd.Connection);
                        OleDbCommandBuilder.DeriveParameters((OleDbCommand)cmd.Command);
                        foreach (var param in cmd.Command.Parameters)
                            command.Parameters.Add(param);
                    }
                    break;
            }
        }
        #endregion

        #region Database Objects
        /// <summary>
        /// GetPager
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="pageSize"></param>
        /// <param name="keyField"></param>
        /// <returns></returns>
        public override IDataPager GetPager(string sql, int pageSize, string keyField = null)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// GetSqlDao
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public override IDao GetSqlDao(string sql)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// GetProcDao
        /// </summary>
        /// <param name="proc"></param>
        /// <returns></returns>
        public override IDao GetProcDao(string proc)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region 特定数据库方法
        #endregion
    }
}
