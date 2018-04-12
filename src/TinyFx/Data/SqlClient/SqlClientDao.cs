using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace TinyFx.Data.SqlClient
{
    /// <summary>
    /// SQL Server数据库SQL语句操作类
    /// </summary>
    public class SqlSqlDao : DaoBase<SqlParameter, SqlDbType>
    {
        #region Constructs
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="database">数据库访问对象</param>
        public SqlSqlDao(string sql, Database database)
            : base(sql, CommandType.Text, database) { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="sql">SQL语句</param>
        public SqlSqlDao(string sql)
            : base(sql, CommandType.Text, new SqlDatabase()) { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="connectionStringName">数据库连接字符串名称</param>
        public SqlSqlDao(string sql, string connectionStringName)
            : base(sql, CommandType.Text, new SqlDatabase(connectionStringName)) { }


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="commandTimeout">Timeout时间</param>
        public SqlSqlDao(string sql, string connectionString, int commandTimeout)
            : base(sql, CommandType.Text, new SqlDatabase(connectionString, commandTimeout)) { }

        #endregion

        protected override void SetParameterDbType(SqlParameter para, SqlDbType dbType)
        {
            para.SqlDbType = dbType;
        }
    }

    /// <summary>
    /// SQL Server数据库存储过程操作类
    /// </summary>
    public class SqlProcDao : DaoBase<SqlParameter, SqlDbType>
    {
        #region Constructs
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="proc">存储过程名称</param>
        /// <param name="database">数据库访问对象</param>
        public SqlProcDao(string proc, Database database)
            : base(proc, CommandType.StoredProcedure, database) { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="proc">存储过程名称</param>
        public SqlProcDao(string proc)
            : base(proc, CommandType.StoredProcedure, new SqlDatabase()) { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="proc">存储过程名称</param>
        /// <param name="connectionStringName">数据库连接字符串名称</param>
        public SqlProcDao(string proc, string connectionStringName)
            : base(proc, CommandType.StoredProcedure, new SqlDatabase(connectionStringName)) { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="proc">存储过程名称</param>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="commandTimeout">commandTimeout</param>
        public SqlProcDao(string proc, string connectionString, int commandTimeout)
            : base(proc, CommandType.StoredProcedure, new SqlDatabase(connectionString, commandTimeout)) { }

        #endregion

        protected override void SetParameterDbType(SqlParameter para, SqlDbType dbType)
        {
            para.SqlDbType = dbType;
        }

        /// <summary>
        /// 表示诸如存储过程、内置函数或用户定义函数之类的操作的返回值参数
        /// </summary>
        public SqlProcDao AddReturnParameter()
        {
            var para = AddParameter("@RETURN_VALUE", ParameterDirection.ReturnValue, SqlDbType.Int, 0);
            return this;
        }

        /// <summary>
        /// 获取返回参数的值
        /// </summary>
        /// <returns></returns>
        public int? GetReturnValue()
        {
            int? ret = null;
            string paraName = Database.GetParameterName("@RETURN_VALUE");
            object o = GetParameterValue(paraName);
            if (o != null)
                ret = o.ConvertTo<int>();
            return ret;
        }
    }
}
