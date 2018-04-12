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
    /// OracleSqlDao
    /// </summary>
    public class OracleSqlDao : DaoBase<OracleParameter, OracleDbType>
    {
        #region Constructs
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="database">数据库访问对象</param>
        public OracleSqlDao(string sql, Database database)
            : base(sql, CommandType.Text, database) { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="sql">SQL语句</param>
        public OracleSqlDao(string sql)
            : base(sql, CommandType.Text, new OracleDatabase()) { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="connectionStringName">数据库连接字符串名称</param>
        public OracleSqlDao(string sql, string connectionStringName)
            : base(sql, CommandType.Text, new OracleDatabase(connectionStringName)) { }


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="commandTimeout">Timeout时间</param>
        public OracleSqlDao(string sql, string connectionString, int commandTimeout)
            : base(sql, CommandType.Text, new OracleDatabase(connectionString, commandTimeout)) { }
        #endregion

        /// <summary>
        /// SetParameterDbType
        /// </summary>
        /// <param name="para"></param>
        /// <param name="dbType"></param>
        protected override void SetParameterDbType(OracleParameter para, OracleDbType dbType)
        {
            para.OracleDbType = dbType;
        }
    }
    /// <summary>
    /// OracleProcDao
    /// </summary>
    public class OracleProcDao : DaoBase<OracleParameter, OracleDbType>
    {
        #region Constructs
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="proc">存储过程名称</param>
        /// <param name="database">数据库访问对象</param>
        public OracleProcDao(string proc, Database database)
            : base(proc, CommandType.StoredProcedure, database) { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="proc">存储过程名称</param>
        public OracleProcDao(string proc)
            : base(proc, CommandType.StoredProcedure, new OracleDatabase()) { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="proc">存储过程名称</param>
        /// <param name="connectionStringName">数据库连接字符串名称</param>
        public OracleProcDao(string proc, string connectionStringName)
            : base(proc, CommandType.StoredProcedure, new OracleDatabase(connectionStringName)) { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="proc">存储过程名称</param>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="commandTimeout">commandTimeout</param>
        public OracleProcDao(string proc, string connectionString, int commandTimeout)
            : base(proc, CommandType.StoredProcedure, new OracleDatabase(connectionString, commandTimeout)) { }
        #endregion

        /// <summary>
        /// SetParameterDbType
        /// </summary>
        /// <param name="para"></param>
        /// <param name="dbType"></param>
        protected override void SetParameterDbType(OracleParameter para, OracleDbType dbType)
        {
            para.OracleDbType = dbType;
        }
    }
}
