using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace TinyFx.Data
{
    public abstract partial class Database
    {
        #region ExecSqlTable
        /// <summary>
        /// 执行SQL语句并返回DataTable
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns></returns>
        public DataTable ExecSqlTable(string sql)
            => ExecSqlReader(sql).ToTable();

        /// <summary>
        /// 执行SQL语句并返回DataTable
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="paras">参数集合</param>
        /// <param name="tm">数据库事务管理对象</param>
        /// <returns></returns>
        public DataTable ExecSqlTable(string sql, IEnumerable<DbParameter> paras, TransactionManager tm)
            => ExecSqlReader(sql, paras, tm).ToTable();

        /// <summary>
        /// 执行SQL语句并返回DataTable
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="tm">数据库事务管理对象</param>
        /// <returns></returns>
        public DataTable ExecSqlTable(string sql, TransactionManager tm)
            => ExecSqlReader(sql, tm).ToTable();

        /// <summary>
        /// 执行SQL语句并返回DataTable
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="paras">参数集合</param>
        /// <returns></returns>
        public DataTable ExecSqlTable(string sql, IEnumerable<DbParameter> paras)
            => ExecSqlReader(sql, paras).ToTable();

        /// <summary>
        /// 执行SQL语句并返回DataTable
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="tm">数据库事务管理对象</param>
        /// <param name="values">按顺序传入需要的参数值集合，程序会自动解析并添加参数集合，并把传入的参数值赋给对应的参数对象</param>
        /// <returns></returns>
        public DataTable ExecSqlTable(string sql, TransactionManager tm, params object[] values)
            => ExecSqlReader(sql, tm, values).ToTable();

        /// <summary>
        /// 执行SQL语句并返回DataTable
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="values">按顺序传入需要的参数值集合，程序会自动解析并添加参数集合，并把传入的参数值赋给对应的参数对象</param>
        /// <returns></returns>
        public DataTable ExecSqlTable(string sql, params object[] values)
            => ExecSqlReader(sql, values).ToTable();
        #endregion

        #region ExecSqlTableFormat
        /// <summary>
        /// 执行SQL语句并返回DataTable（SQL语句通过string.Format格式化项）
        /// </summary>
        /// <param name="sql">SQL语句，如：select * from {0} where id={1}</param>
        /// <param name="tm">数据库事务管理对象</param>
        /// <param name="values">包含零个或多个替换SQL语句中的格式项的对象</param>
        /// <returns></returns>
        public DataTable ExecSqlTableFormat(string sql, TransactionManager tm, params object[] values)
        {
            CheckSqlInjection(values);
            return ExecSqlTable(string.Format(sql, values), tm);
        }

        /// <summary>
        /// 执行SQL语句并返回DataTable（SQL语句通过string.Format格式化项）
        /// </summary>
        /// <param name="sql">SQL语句，如：select * from {0} where id={1}</param>
        /// <param name="values">包含零个或多个替换SQL语句中的格式项的对象</param>
        /// <returns></returns>
        public DataTable ExecSqlTableFormat(string sql, params object[] values)
            => ExecSqlTableFormat(sql, null, values);
        #endregion

        #region ExecProcTable
        /// <summary>
        /// 执行存储过程并返回DataTable
        /// </summary>
        /// <param name="proc">存储过程</param>
        /// <returns></returns>
        public DataTable ExecProcTable(string proc)
            => ExecProcReader(proc).ToTable();

        /// <summary>
        /// 执行存储过程并返回DataTable
        /// </summary>
        /// <param name="proc">存储过程</param>
        /// <param name="paras">参数集合</param>
        /// <param name="tm">数据库事务管理对象</param>
        /// <returns></returns>
        public DataTable ExecProcTable(string proc, IEnumerable<DbParameter> paras, TransactionManager tm)
            => ExecProcReader(proc, paras, tm).ToTable();

        /// <summary>
        /// 执行存储过程并返回DataTable
        /// </summary>
        /// <param name="proc">存储过程</param>
        /// <param name="tm">数据库事务管理对象</param>
        /// <returns></returns>
        public DataTable ExecProcTable(string proc, TransactionManager tm)
            => ExecProcReader(proc, tm).ToTable();

        /// <summary>
        /// 执行存储过程并返回DataTable
        /// </summary>
        /// <param name="proc">存储过程</param>
        /// <param name="paras">参数集合</param>
        /// <returns></returns>
        public DataTable ExecProcTable(string proc, IEnumerable<DbParameter> paras)
            => ExecProcReader(proc, paras).ToTable();

        /// <summary>
        /// 执行存储过程并返回DataTable
        /// </summary>
        /// <param name="proc">存储过程</param>
        /// <param name="tm">数据库事务管理对象</param>
        /// <param name="values">按顺序传入需要的参数值集合，程序会自动解析并添加参数集合，并把传入的参数值赋给对应的参数对象</param>
        /// <returns></returns>
        public DataTable ExecProcTable(string proc, TransactionManager tm, params object[] values)
            => ExecProcReader(proc, tm, values).ToTable();

        /// <summary>
        /// 执行存储过程并返回DataTable
        /// </summary>
        /// <param name="proc">存储过程</param>
        /// <param name="values">按顺序传入需要的参数值集合，程序会自动解析并添加参数集合，并把传入的参数值赋给对应的参数对象</param>
        /// <returns></returns>
        public DataTable ExecProcTable(string proc, params object[] values)
            => ExecProcReader(proc, values).ToTable();
        #endregion
    }
}
