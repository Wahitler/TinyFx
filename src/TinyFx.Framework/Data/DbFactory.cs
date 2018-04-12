﻿using System;
using TinyFx.Data.Instrumentation;
using TinyFx.Data.MySqlClient;
using TinyFx.Data.SqlClient;
using TinyFx.Data.OracleClient;
using TinyFx.Data.OleDb;

namespace TinyFx.Data
{
    /// <summary>
    /// 负责创建 Database 的核心类
    /// </summary>
    public static class DbFactory
    {
        private static Database Create(ConnectionStringConfig config)
        {
            Database ret = null;
            switch (config.Provider)
            {
                case DbDataProvider.MySqlClient:
                    ret = new MySqlDatabase(config);
                    break;
                case DbDataProvider.SqlClient:
                    ret = new SqlDatabase(config);
                    break;
                case DbDataProvider.Odac:
                    ret = new OracleDatabase(config);
                    break;
                case DbDataProvider.OleDb:
                    ret = new OleDbDatabase(config);
                    break;
                default: throw new ArgumentException("目前不支持此数据库提供程序：" + config.Provider.ToString(), "config");
            }
            return ret;
        }

        #region Create By Config
        /// <summary>
        /// 根据connectionStringName创建Database
        /// </summary>
        /// <param name="connectionStringName">配置文件中tinyFx.data.connectionStrings定义的名称, 默认值tinyFx.dataConfig.defaultConnectionString</param>
        /// <returns></returns>
        public static Database Create(string connectionStringName = null)
            => Create(DbConfigManager.GetConnectionStringConfig(connectionStringName));


        /// <summary>
        /// 创建指定类型的Database, ，如果connectionStringName长度超过50则认为是ConnectionString处理
        /// </summary>
        /// <typeparam name="TDatabase">具体的数据库对象，如：MySqlDatabase</typeparam>
        /// <param name="connectionStringName">配置文件中tinyFx.data.connectionStrings定义的名称</param>
        /// <returns></returns>
        public static TDatabase Create<TDatabase>(string connectionStringName = null)
            where TDatabase : Database
        {
            TDatabase ret = default(TDatabase);
            if (connectionStringName.Length > 50)
            {
                var provider = DbDataProviderUtil.GetProvider(typeof(TDatabase));
                ret = Create(provider, connectionStringName) as TDatabase;
            }
            else
                ret = Create(connectionStringName) as TDatabase;
            return ret;
        }
        #endregion

        #region Create By Custom
        /// <summary>
        /// 创建自定义的Database
        /// </summary>
        /// <param name="provider">数据提供程序</param>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="readConnectionString">只读数据库连接字符串</param>
        /// <param name="commandTimeout">超时时间，单位秒</param>
        /// <param name="inst">数据操作执行事件监测对象</param>
        /// <returns></returns>
        public static Database Create(DbDataProvider provider, string connectionString, string readConnectionString, int commandTimeout = 30, IDataInstProvider inst = null)
            => Create(DbConfigManager.GetConnectionStringConfig(provider, connectionString, readConnectionString, commandTimeout, inst));

        /// <summary>
        /// 创建自定义的Database
        /// </summary>
        /// <param name="provider">数据提供程序</param>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="commandTimeout">超时时间，单位秒</param>
        /// <param name="inst">数据操作执行事件监测对象</param>
        /// <returns></returns>
        public static Database Create(DbDataProvider provider, string connectionString, int commandTimeout = 30, IDataInstProvider inst = null)
            => Create(DbConfigManager.GetConnectionStringConfig(provider, connectionString, null, commandTimeout, inst));

        /// <summary>
        /// 创建自定义的Database
        /// </summary>
        /// <typeparam name="TDatabase"></typeparam>
        /// <param name="connectionString"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="inst"></param>
        /// <returns></returns>
        public static TDatabase Create<TDatabase>(string connectionString, int commandTimeout, IDataInstProvider inst = null)
           where TDatabase : Database
            => Create(DbDataProviderUtil.GetProvider(typeof(TDatabase)), connectionString, commandTimeout, inst) as TDatabase;

        /// <summary>
        /// 创建自定义的Database
        /// </summary>
        /// <typeparam name="TDatabase"></typeparam>
        /// <param name="connectionString"></param>
        /// <param name="readConnectionString"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="inst"></param>
        /// <returns></returns>
        public static TDatabase Create<TDatabase>(string connectionString, string readConnectionString, int commandTimeout = 30, IDataInstProvider inst = null)
            where TDatabase : Database
            => Create(DbDataProviderUtil.GetProvider(typeof(TDatabase)), connectionString, readConnectionString, commandTimeout, inst) as TDatabase;
        #endregion

        #region DbDataProvider.SqlClient

        /// <summary>
        /// 创建基于 SQL Server 的 .NET Framework 数据提供程序的 Database
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="commandTimeout">超时时间，单位秒</param>
        /// <param name="inst">数据操作执行事件监测对象</param>
        /// <returns></returns>
        public static SqlDatabase CreateSqlServer(string connectionString, int commandTimeout = 30, IDataInstProvider inst = null)
            => Create(DbConfigManager.GetConnectionStringConfig(DbDataProvider.SqlClient, connectionString, null, commandTimeout, inst)) as SqlDatabase;

        /// <summary>
        /// 创建连接SQL Server的Database
        /// </summary>
        /// <param name="server">服务器地址</param>
        /// <param name="database">数据库名称</param>
        /// <param name="userid">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="commandTimeout">超时时间，单位秒</param>
        /// <param name="inst">数据操作执行事件监测对象</param>
        /// <returns></returns>
        public static SqlDatabase CreateSqlServer(string server, string database, string userid = null, string password = null, int commandTimeout = 30, IDataInstProvider inst = null)
        {
            string connStr = ConnectionStringUtil.GetSqlServer(server, database, userid, password);
            return CreateSqlServer(connStr, commandTimeout, inst);
        }
        #endregion

        #region DbDataProvider.MySqlClient
        /// <summary>
        /// 创建连接MySQL的Database
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="commandTimeout">超时时间，单位秒</param>
        /// <param name="inst">数据操作执行事件监测对象</param>
        /// <returns></returns>
        public static MySqlDatabase CreateMySql(string connectionString, int commandTimeout = 30, IDataInstProvider inst = null)
            => Create(DbConfigManager.GetConnectionStringConfig(DbDataProvider.MySqlClient, connectionString, null, commandTimeout, inst)) as MySqlDatabase;

        /// <summary>
        /// 创建连接MySQL的Database
        /// </summary>
        /// <param name="server">数据库服务器地址</param>
        /// <param name="database">数据库名称</param>
        /// <param name="user">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="commandTimeout">超时时间，单位秒</param>
        /// <param name="inst">数据操作执行事件监测对象</param>
        /// <returns></returns>
        public static MySqlDatabase CreateMySql(string server, string database, string user, string password, int commandTimeout = 30, IDataInstProvider inst = null)
        {
            string connStr = ConnectionStringUtil.GetMySql(server, database, user, password);
            return CreateMySql(connStr, commandTimeout, inst);
        }
        #endregion

        #region DbDataProvider.Odac
        /// <summary>
        /// 创建基于 Oracle 的ODAC(ODP.NET)数据提供程序的 Database
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="commandTimeout">超时时间，单位秒</param>
        /// <param name="inst">数据操作执行事件监测对象</param>
        /// <returns></returns>
        public static OracleDatabase CreateOracle(string connectionString, int commandTimeout = 30, IDataInstProvider inst = null)
            => Create(DbConfigManager.GetConnectionStringConfig(DbDataProvider.Odac, connectionString, null, commandTimeout, inst)) as OracleDatabase;
        
        /// <summary>
        /// 创建基于 Oracle 的ODAC(ODP.NET)数据提供程序的 Database
        /// </summary>
        /// <param name="dataSource">数据服务，如：//172.28.8.31/ServiceName</param>
        /// <param name="userid">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="commandTimeout">超时时间，单位秒</param>
        /// <param name="inst">数据操作执行事件监测对象</param>
        /// <returns></returns>
        public static OracleDatabase CreateOracle(string dataSource, string userid, string password, int commandTimeout = 30, IDataInstProvider inst = null)
        {
            string connStr = ConnectionStringUtil.GetOracle(dataSource, userid, password);
            return CreateOracle(connStr, commandTimeout, inst);
        }
        #endregion

        #region DbDataProvider.OleDb

        /// <summary>
        /// 创建基于 OLE DB 的 .NET Framework 数据提供程序的 Database
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="commandTimeout">超时时间，单位秒</param>
        /// <param name="inst">数据操作执行事件监测对象</param>
        /// <returns></returns>
        public static OleDbDatabase CreateOleDb(string connectionString, int commandTimeout = 30, IDataInstProvider inst = null)
            => Create(DbConfigManager.GetConnectionStringConfig(DbDataProvider.OleDb, connectionString, null, commandTimeout, inst)) as OleDbDatabase;

        /// <summary>
        /// 创建连接Access的Database
        /// </summary>
        /// <param name="filename">文件名，如：d:\1.mdb</param>
        /// <param name="userid">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="commandTimeout">超时时间，单位秒</param>
        /// <param name="inst">数据操作执行事件监测对象</param>
        /// <returns></returns>
        public static OleDbDatabase CreateAccess(string filename, string userid = null, string password = null, int commandTimeout = 30, IDataInstProvider inst = null)
        {
            string connStr = ConnectionStringUtil.GetAccess(filename, userid, password);
            return CreateOleDb(connStr, commandTimeout, inst);
        }

        /// <summary>
        /// 创建连接Excel的Database
        /// </summary>
        /// <param name="filename">文件名，如：d:\1.xls</param>
        /// <param name="hdr">第一行是否处理为标题行</param>
        /// <param name="imex">导入导出模式设置</param>
        /// <param name="commandTimeout">超时时间，单位秒</param>
        /// <param name="inst">数据操作执行事件监测对象</param>
        /// <returns></returns>
        public static OleDbDatabase CreateExcel(string filename, bool hdr = true, int imex = 2, int commandTimeout = 30, IDataInstProvider inst = null)
        {
            string connStr = ConnectionStringUtil.GetExcel(filename, hdr, imex);
            return CreateOleDb(connStr, commandTimeout, inst);
        }
        #endregion
    }
}
