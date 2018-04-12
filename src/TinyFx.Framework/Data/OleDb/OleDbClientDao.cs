using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;

namespace TinyFx.Data.OleDb
{
    /// <summary>
    /// OleDbSqlDao
    /// </summary>
    public class OleDbSqlDao : DaoBase<OleDbParameter, OleDbType>
    {
        #region Constructs
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="database">数据库访问对象</param>
        public OleDbSqlDao(string sql, Database database)
            : base(sql, CommandType.Text, database) { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="sql">SQL语句</param>
        public OleDbSqlDao(string sql)
            : base(sql, CommandType.Text, new OleDbDatabase()) { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="connectionStringName">数据库连接字符串名称</param>
        public OleDbSqlDao(string sql, string connectionStringName)
            : base(sql, CommandType.Text, new OleDbDatabase(connectionStringName)) { }


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="commandTimeout">Timeout时间</param>
        public OleDbSqlDao(string sql, string connectionString, int commandTimeout)
            : base(sql, CommandType.Text, new OleDbDatabase(connectionString, commandTimeout)) { }
        #endregion

        /// <summary>
        /// SetParameterDbType
        /// </summary>
        /// <param name="para"></param>
        /// <param name="dbType"></param>
        protected override void SetParameterDbType(OleDbParameter para, OleDbType dbType)
        {
            para.OleDbType = dbType;
        }
    }
    /// <summary>
    /// OleDbProcDao
    /// </summary>
    public class OleDbProcDao : DaoBase<OleDbParameter, OleDbType>
    {
        #region Constructs
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="proc">存储过程名称</param>
        /// <param name="database">数据库访问对象</param>
        public OleDbProcDao(string proc, Database database)
            : base(proc, CommandType.StoredProcedure, database) { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="proc">存储过程名称</param>
        public OleDbProcDao(string proc)
            : base(proc, CommandType.StoredProcedure, new OleDbDatabase()) { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="proc">存储过程名称</param>
        /// <param name="connectionStringName">数据库连接字符串名称</param>
        public OleDbProcDao(string proc, string connectionStringName)
            : base(proc, CommandType.StoredProcedure, new OleDbDatabase(connectionStringName)) { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="proc">存储过程名称</param>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="commandTimeout">commandTimeout</param>
        public OleDbProcDao(string proc, string connectionString, int commandTimeout)
            : base(proc, CommandType.StoredProcedure, new OleDbDatabase(connectionString, commandTimeout)) { }
        #endregion

        /// <summary>
        /// SetParameterDbType
        /// </summary>
        /// <param name="para"></param>
        /// <param name="dbType"></param>
        protected override void SetParameterDbType(OleDbParameter para, OleDbType dbType)
        {
            para.OleDbType = dbType;
        }
    }
}
