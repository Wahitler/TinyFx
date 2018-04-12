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
        // ExecReader在使用事务时必须Close，才可以继续下面的事务
        #region ExecSqlReader
        /// <summary>
        /// 执行SQL语句并返回结果集
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns></returns>
        public DataReaderWrapper ExecSqlReader(string sql)
        {
            CommandWrapper command = CreateCommand(sql, CommandType.Text, null);
            return ExecReader(command);
        }

        /// <summary>
        /// 执行SQL语句并返回结果集
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="paras">参数集合</param>
        /// <param name="tm">数据库事务管理对象</param>
        /// <returns></returns>
        public DataReaderWrapper ExecSqlReader(string sql, IEnumerable<DbParameter> paras, TransactionManager tm)
        {
            CommandWrapper command = CreateCommand(sql, CommandType.Text, paras, tm);
            return ExecReader(command);
        }

        /// <summary>
        /// 执行SQL语句并返回结果集
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="tm">数据库事务管理对象</param>
        /// <returns></returns>
        public DataReaderWrapper ExecSqlReader(string sql, TransactionManager tm)
        {
            CommandWrapper command = CreateCommand(sql, CommandType.Text, null, tm);
            return ExecReader(command);
        }

        /// <summary>
        /// 执行SQL语句并返回结果集
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="paras">参数集合</param>
        /// <returns></returns>
        public DataReaderWrapper ExecSqlReader(string sql, IEnumerable<DbParameter> paras)
        {
            CommandWrapper command = CreateCommand(sql, CommandType.Text, paras, null);
            return ExecReader(command);
        }

        /// <summary>
        /// 执行SQL语句并返回结果集
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="tm">数据库事务管理对象</param>
        /// <param name="values">按顺序传入需要的参数值集合，程序会自动解析并添加参数集合，并把传入的参数值赋给对应的参数对象</param>
        /// <returns></returns>
        public DataReaderWrapper ExecSqlReader(string sql, TransactionManager tm, params object[] values)
        {
            CommandWrapper command = CreateCommand(sql, CommandType.Text, tm, values);
            return ExecReader(command);
        }

        /// <summary>
        /// 执行SQL语句并返回结果集
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="values">按顺序传入需要的参数值集合，程序会自动解析并添加参数集合，并把传入的参数值赋给对应的参数对象</param>
        /// <returns></returns>
        public DataReaderWrapper ExecSqlReader(string sql, params object[] values)
        {
            return ExecSqlReader(sql, null, values);
        }
        #endregion

        #region ExecSqlReaderFormat
        /// <summary>
        /// 执行SQL语句并返回结果集（SQL语句通过string.Format格式化项）
        /// </summary>
        /// <param name="sql">SQL语句，如：select * from {0} where id={1}</param>
        /// <param name="tm">数据库事务管理对象</param>
        /// <param name="values">包含零个或多个替换SQL语句中的格式项的对象</param>
        /// <returns></returns>
        public DataReaderWrapper ExecSqlReaderFormat(string sql, TransactionManager tm, params object[] values)
        {
            CheckSqlInjection(values);
            return ExecSqlReader(string.Format(sql, values), tm);
        }
        /// <summary>
        /// 执行SQL语句并返回结果集（SQL语句通过string.Format格式化项）
        /// </summary>
        /// <param name="sql">SQL语句，如：select * from {0} where id={1}</param>
        /// <param name="values">包含零个或多个替换SQL语句中的格式项的对象</param>
        /// <returns></returns>
        public DataReaderWrapper ExecSqlReaderFormat(string sql, params object[] values)
            => ExecSqlReaderFormat(sql, null, values);
        #endregion

        #region ExecProcReader
        /// <summary>
        /// 执行存储过程并返回结果集
        /// </summary>
        /// <param name="proc">存储过程</param>
        /// <returns></returns>
        public DataReaderWrapper ExecProcReader(string proc)
        {
            CommandWrapper command = CreateCommand(proc, CommandType.StoredProcedure, null);
            return ExecReader(command);
        }

        /// <summary>
        /// 执行存储过程并返回结果集
        /// </summary>
        /// <param name="proc">存储过程</param>
        /// <param name="paras">参数集合</param>
        /// <param name="tm">数据库事务管理对象</param>
        /// <returns></returns>
        public DataReaderWrapper ExecProcReader(string proc, IEnumerable<DbParameter> paras, TransactionManager tm)
        {
            CommandWrapper command = CreateCommand(proc, CommandType.StoredProcedure, paras, tm);
            return ExecReader(command);
        }

        /// <summary>
        /// 执行存储过程并返回结果集
        /// </summary>
        /// <param name="proc">存储过程</param>
        /// <param name="tm">数据库事务管理对象</param>
        /// <returns></returns>
        public DataReaderWrapper ExecProcReader(string proc, TransactionManager tm)
        {
            CommandWrapper command = CreateCommand(proc, CommandType.StoredProcedure, null, tm);
            return ExecReader(command);
        }

        /// <summary>
        /// 执行存储过程并返回结果集
        /// </summary>
        /// <param name="proc">存储过程</param>
        /// <param name="paras">参数集合</param>
        /// <returns></returns>
        public DataReaderWrapper ExecProcReader(string proc, IEnumerable<DbParameter> paras)
        {
            CommandWrapper command = CreateCommand(proc, CommandType.StoredProcedure, paras, null);
            return ExecReader(command);
        }

        /// <summary>
        /// 执行存储过程并返回结果集
        /// </summary>
        /// <param name="proc">存储过程</param>
        /// <param name="tm">数据库事务管理对象</param>
        /// <param name="values">按顺序传入需要的参数值集合，程序会自动解析并添加参数集合，并把传入的参数值赋给对应的参数对象</param>
        /// <returns></returns>
        public DataReaderWrapper ExecProcReader(string proc, TransactionManager tm, params object[] values)
        {
            CommandWrapper command = CreateCommand(proc, CommandType.StoredProcedure, tm, values);
            return ExecReader(command);
        }

        /// <summary>
        /// 执行存储过程并返回结果集
        /// </summary>
        /// <param name="proc">存储过程</param>
        /// <param name="values">按顺序传入需要的参数值集合，程序会自动解析并添加参数集合，并把传入的参数值赋给对应的参数对象</param>
        /// <returns></returns>
        public DataReaderWrapper ExecProcReader(string proc, params object[] values)
        {
            return ExecProcReader(proc, null, values);
        }
        #endregion
    }
}
