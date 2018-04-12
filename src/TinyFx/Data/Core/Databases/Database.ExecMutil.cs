using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using TinyFx.Data.DataMapping;

namespace TinyFx.Data
{
    public abstract partial class Database
    {
        #region ExecSqlMutil
        /// <summary>
        /// 执行SQL语句返回枚举集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">SQL</param>
        /// <returns></returns>
        public IEnumerable<T> ExecSqlMutil<T>(string sql)
            => ExecSqlReader(sql).MapToMutil<T>();

        /// <summary>
        /// 执行SQL语句返回枚举集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">SQL</param>
        /// <param name="rowMapper">映射方法</param>
        /// <returns></returns>
        public IEnumerable<T> ExecSqlMutil<T>(string sql, Func<IDataReader, T> rowMapper)
            => ExecSqlReader(sql).MapToMutil<T>(rowMapper);

        /// <summary>
        /// 执行SQL语句返回枚举集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">SQL</param>
        /// <param name="mode">映射模式</param>
        /// <returns></returns>
        public IEnumerable<T> ExecSqlMutil<T>(string sql, DataMappingMode mode)
            => ExecSqlReader(sql).MapToMutil<T>(mode);

        /// <summary>
        /// 执行SQL语句返回枚举集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">SQL</param>
        /// <param name="paras">参数集合</param>
        /// <param name="tm">事务对象</param>
        /// <returns></returns>
        public IEnumerable<T> ExecSqlMutil<T>(string sql, IEnumerable<DbParameter> paras, TransactionManager tm)
            => ExecSqlReader(sql, paras, tm).MapToMutil<T>();

        /// <summary>
        /// 执行SQL语句返回枚举集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">SQL</param>
        /// <param name="paras">参数集合</param>
        /// <param name="tm">事务对象</param>
        /// <param name="rowMapper">映射方法</param>
        /// <returns></returns>
        public IEnumerable<T> ExecSqlMutil<T>(string sql, IEnumerable<DbParameter> paras, TransactionManager tm, Func<IDataReader, T> rowMapper)
            => ExecSqlReader(sql, paras, tm).MapToMutil<T>(rowMapper);

        /// <summary>
        /// 执行SQL语句返回枚举集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">SQL</param>
        /// <param name="paras">参数集合</param>
        /// <param name="tm">事务对象</param>
        /// <param name="mode">映射模式</param>
        /// <returns></returns>
        public IEnumerable<T> ExecSqlMutil<T>(string sql, IEnumerable<DbParameter> paras, TransactionManager tm, DataMappingMode mode)
            => ExecSqlReader(sql, paras, tm).MapToMutil<T>(mode);

        /// <summary>
        /// 执行SQL语句返回枚举集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">SQL</param>
        /// <param name="tm">事务对象</param>
        /// <returns></returns>
        public IEnumerable<T> ExecSqlMutil<T>(string sql, TransactionManager tm)
            => ExecSqlReader(sql, tm).MapToMutil<T>();

        /// <summary>
        /// 执行SQL语句返回枚举集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">SQL</param>
        /// <param name="tm">事务对象</param>
        /// <param name="rowMapper">映射方法</param>
        /// <returns></returns>
        public IEnumerable<T> ExecSqlMutil<T>(string sql, TransactionManager tm, Func<IDataReader, T> rowMapper)
            => ExecSqlReader(sql, tm).MapToMutil<T>(rowMapper);

        /// <summary>
        /// 执行SQL语句返回枚举集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">SQL</param>
        /// <param name="tm">事务对象</param>
        /// <param name="mode">映射模式</param>
        /// <returns></returns>
        public IEnumerable<T> ExecSqlMutil<T>(string sql, TransactionManager tm, DataMappingMode mode)
            => ExecSqlReader(sql, tm).MapToMutil<T>(mode);

        /// <summary>
        /// 执行SQL语句返回枚举集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">SQL</param>
        /// <param name="paras">参数集合</param>
        /// <returns></returns>
        public IEnumerable<T> ExecSqlMutil<T>(string sql, IEnumerable<DbParameter> paras)
            => ExecSqlReader(sql, paras).MapToMutil<T>();

        /// <summary>
        /// 执行SQL语句返回枚举集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">SQL</param>
        /// <param name="paras">参数集合</param>
        /// <param name="rowMapper">映射方法</param>
        /// <returns></returns>
        public IEnumerable<T> ExecSqlMutil<T>(string sql, IEnumerable<DbParameter> paras, Func<IDataReader, T> rowMapper)
            => ExecSqlReader(sql, paras).MapToMutil<T>(rowMapper);

        /// <summary>
        /// 执行SQL语句返回枚举集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">SQL</param>
        /// <param name="paras">参数集合</param>
        /// <param name="mode">映射模式</param>
        /// <returns></returns>
        public IEnumerable<T> ExecSqlMutil<T>(string sql, IEnumerable<DbParameter> paras, DataMappingMode mode)
            => ExecSqlReader(sql, paras).MapToMutil<T>(mode);

        /// <summary>
        /// 执行SQL语句返回枚举集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">SQL</param>
        /// <param name="tm">事务对象</param>
        /// <param name="values">参数值集合</param>
        /// <returns></returns>
        public IEnumerable<T> ExecSqlMutil<T>(string sql, TransactionManager tm, params object[] values)
            => ExecSqlReader(sql, tm, values).MapToMutil<T>();

        /// <summary>
        /// 执行SQL语句返回枚举集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">SQL</param>
        /// <param name="tm">事务对象</param>
        /// <param name="rowMapper">映射方法</param>
        /// <param name="values">参数值集合</param>
        /// <returns></returns>
        public IEnumerable<T> ExecSqlMutil<T>(string sql, TransactionManager tm, Func<IDataReader, T> rowMapper, params object[] values)
            => ExecSqlReader(sql, tm, values).MapToMutil<T>(rowMapper);

        /// <summary>
        /// 执行SQL语句返回枚举集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">SQL</param>
        /// <param name="tm">事务对象</param>
        /// <param name="mode">映射模式</param>
        /// <param name="values">参数值集合</param>
        /// <returns></returns>
        public IEnumerable<T> ExecSqlMutil<T>(string sql, TransactionManager tm, DataMappingMode mode, params object[] values)
            => ExecSqlReader(sql, tm, values).MapToMutil<T>(mode);

        /// <summary>
        /// 执行SQL语句返回枚举集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">SQL</param>
        /// <param name="values">参数值集合</param>
        /// <returns></returns>
        public IEnumerable<T> ExecSqlMutil<T>(string sql, params object[] values)
            => ExecSqlReader(sql, values).MapToMutil<T>();

        /// <summary>
        /// 执行SQL语句返回枚举集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">SQL</param>
        /// <param name="rowMapper">映射方法</param>
        /// <param name="values">参数值集合</param>
        /// <returns></returns>
        public IEnumerable<T> ExecSqlMutil<T>(string sql, Func<IDataReader, T> rowMapper, params object[] values)
            => ExecSqlReader(sql, values).MapToMutil<T>(rowMapper);

        /// <summary>
        /// 执行SQL语句返回枚举集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">SQL</param>
        /// <param name="mode">映射模式</param>
        /// <param name="values">参数值集合</param>
        /// <returns></returns>
        public IEnumerable<T> ExecSqlMutil<T>(string sql, DataMappingMode mode, params object[] values)
            => ExecSqlReader(sql, values).MapToMutil<T>(mode);
        #endregion

        #region ExecProcMutil
        /// <summary>
        /// 执行存储过程返回枚举集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="proc">存储过程</param>
        /// <returns></returns>
        public IEnumerable<T> ExecProcMutil<T>(string proc)
            => ExecProcReader(proc).MapToMutil<T>();

        /// <summary>
        /// 执行存储过程返回枚举集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="proc">存储过程</param>
        /// <param name="rowMapper">映射方法</param>
        /// <returns></returns>
        public IEnumerable<T> ExecProcMutil<T>(string proc, Func<IDataReader, T> rowMapper)
            => ExecProcReader(proc).MapToMutil<T>(rowMapper);

        /// <summary>
        /// 执行存储过程返回枚举集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="proc">存储过程</param>
        /// <param name="mode">映射模式</param>
        /// <returns></returns>
        public IEnumerable<T> ExecProcMutil<T>(string proc, DataMappingMode mode)
            => ExecProcReader(proc).MapToMutil<T>(mode);

        /// <summary>
        /// 执行存储过程返回枚举集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="proc">存储过程</param>
        /// <param name="paras">参数集合</param>
        /// <param name="tm">事务对象</param>
        /// <returns></returns>
        public IEnumerable<T> ExecProcMutil<T>(string proc, IEnumerable<DbParameter> paras, TransactionManager tm)
            => ExecProcReader(proc, paras).MapToMutil<T>();

        /// <summary>
        /// 执行存储过程句返回枚举集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="proc">存储过程</param>
        /// <param name="paras">参数集合</param>
        /// <param name="tm">事务对象</param>
        /// <param name="rowMapper">映射方法</param>
        /// <returns></returns>
        public IEnumerable<T> ExecProcMutil<T>(string proc, IEnumerable<DbParameter> paras, TransactionManager tm, Func<IDataReader, T> rowMapper)
            => ExecProcReader(proc, paras, tm).MapToMutil<T>(rowMapper);

        /// <summary>
        /// 执行存储过程返回枚举集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="proc">存储过程</param>
        /// <param name="paras">参数集合</param>
        /// <param name="tm">事务对象</param>
        /// <param name="mode">映射模式</param>
        /// <returns></returns>
        public IEnumerable<T> ExecProcMutil<T>(string proc, IEnumerable<DbParameter> paras, TransactionManager tm, DataMappingMode mode)
            => ExecProcReader(proc, paras, tm).MapToMutil<T>(mode);

        /// <summary>
        /// 执行存储过程返回枚举集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="proc">存储过程</param>
        /// <param name="tm">事务对象</param>
        /// <returns></returns>
        public IEnumerable<T> ExecProcMutil<T>(string proc, TransactionManager tm)
            => ExecProcReader(proc,tm).MapToMutil<T>();

        /// <summary>
        /// 执行存储过程返回枚举集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="proc">存储过程</param>
        /// <param name="tm">事务对象</param>
        /// <param name="rowMapper">映射方法</param>
        /// <returns></returns>
        public IEnumerable<T> ExecProcMutil<T>(string proc, TransactionManager tm, Func<IDataReader, T> rowMapper)
            => ExecProcReader(proc, tm).MapToMutil<T>(rowMapper);

        /// <summary>
        /// 执行存储过程返回枚举集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="proc">存储过程</param>
        /// <param name="tm">事务对象</param>
        /// <param name="mode">映射模式</param>
        /// <returns></returns>
        public IEnumerable<T> ExecProcMutil<T>(string proc, TransactionManager tm, DataMappingMode mode)
            => ExecProcReader(proc, tm).MapToMutil<T>(mode);

        /// <summary>
        /// 执行存储过程返回枚举集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="proc">存储过程</param>
        /// <param name="paras">参数集合</param>
        /// <returns></returns>
        public IEnumerable<T> ExecProcMutil<T>(string proc, IEnumerable<DbParameter> paras)
            => ExecProcReader(proc,paras).MapToMutil<T>();

        /// <summary>
        /// 执行存储过程返回枚举集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="proc">存储过程</param>
        /// <param name="paras">参数集合</param>
        /// <param name="rowMapper">映射方法</param>
        /// <returns></returns>
        public IEnumerable<T> ExecProcMutil<T>(string proc, IEnumerable<DbParameter> paras, Func<IDataReader, T> rowMapper)
            => ExecProcReader(proc, paras).MapToMutil<T>(rowMapper);

        /// <summary>
        /// 执行存储过程返回枚举集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="proc">存储过程</param>
        /// <param name="paras">参数集合</param>
        /// <param name="mode">映射模式</param>
        /// <returns></returns>
        public IEnumerable<T> ExecProcMutil<T>(string proc, IEnumerable<DbParameter> paras, DataMappingMode mode)
            => ExecProcReader(proc, paras).MapToMutil<T>(mode);

        /// <summary>
        /// 执行存储过程返回枚举集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="proc">存储过程</param>
        /// <param name="tm">事务对象</param>
        /// <param name="values">参数值集合</param>
        /// <returns></returns>
        public IEnumerable<T> ExecProcMutil<T>(string proc, TransactionManager tm, params object[] values)
            => ExecProcReader(proc, tm, values).MapToMutil<T>();

        /// <summary>
        /// 执行存储过程返回枚举集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="proc">存储过程</param>
        /// <param name="tm">事务对象</param>
        /// <param name="rowMapper">映射方法</param>
        /// <param name="values">参数值集合</param>
        /// <returns></returns>
        public IEnumerable<T> ExecProcMutil<T>(string proc, TransactionManager tm, Func<IDataReader, T> rowMapper, params object[] values)
            => ExecProcReader(proc, tm, values).MapToMutil<T>(rowMapper);

        /// <summary>
        /// 执行存储过程返回枚举集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="proc">存储过程</param>
        /// <param name="tm">事务对象</param>
        /// <param name="mode">映射模式</param>
        /// <param name="values">参数值集合</param>
        /// <returns></returns>
        public IEnumerable<T> ExecProcMutil<T>(string proc, TransactionManager tm, DataMappingMode mode, params object[] values)
            => ExecProcReader(proc, tm, values).MapToMutil<T>(mode);

        /// <summary>
        /// 执行存储过程返回枚举集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="proc">存储过程</param>
        /// <param name="values">参数值集合</param>
        /// <returns></returns>
        public IEnumerable<T> ExecProcMutil<T>(string proc, params object[] values)
            => ExecProcReader(proc, values).MapToMutil<T>();

        /// <summary>
        /// 执行存储过程返回枚举集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="proc">存储过程</param>
        /// <param name="rowMapper">映射方法</param>
        /// <param name="values">参数值集合</param>
        /// <returns></returns>
        public IEnumerable<T> ExecProcMutil<T>(string proc, Func<IDataReader, T> rowMapper, params object[] values)
            => ExecProcReader(proc, values).MapToMutil<T>(rowMapper);

        /// <summary>
        /// 执行存储过程返回枚举集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="proc">存储过程</param>
        /// <param name="mode">映射模式</param>
        /// <param name="values">参数值集合</param>
        /// <returns></returns>
        public IEnumerable<T> ExecProcMutil<T>(string proc, DataMappingMode mode, params object[] values)
            => ExecProcReader(proc, values).MapToMutil<T>(mode);
        #endregion
    }
}
