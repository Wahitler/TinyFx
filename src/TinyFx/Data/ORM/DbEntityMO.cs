using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using TinyFx.Data.DataMapping;
using TinyFx.Data.ORM;
using System.Data.Common;
using TinyFx.Data.Schema;
using TinyFx.Data;
using TinyFx.Collections;

namespace TinyFx.Data.ORM
{
    /// <summary>
    /// Table and View MO基类
    /// </summary>
    /// <typeparam name="TDatabase"></typeparam>
    /// <typeparam name="TParameter"></typeparam>
    /// <typeparam name="TDbType"></typeparam>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class DbEntityMO<TDatabase, TParameter, TDbType, TEntity> : DbMOBase<TDatabase, TParameter, TDbType>
        where TDatabase : Database<TParameter, TDbType>
        where TParameter : DbParameter
        where TDbType : struct
        where TEntity : IRowMapper<TEntity>
    {
        #region GetWhere

        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <param name="tm">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<TEntity> GetAll(TransactionManager tm = null)
            => GetTopSort(string.Empty, null, -1, string.Empty, tm);

        #region Get
        /// <summary>
        /// 按自定义条件查询
        /// </summary>
        /// <param name = "where">自定义条件,where子句</param>
        /// <return>实体对象集合</return>
        public List<TEntity> Get(string where)
            => GetTopSort(where, null, -1, string.Empty, null);

        /// <summary>
        /// 按自定义条件查询
        /// </summary>
        /// <param name = "where">自定义条件,where子句</param>
        /// <param name = "values">where子句中定义的参数值集合</param>
        /// <return>实体对象集合</return>
        public List<TEntity> Get(string where, params object[] values)
            => GetTopSort(where, -1, string.Empty, null, values);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public List<TEntity> Get(string where, params (TDbType dbType, object value)[] parameters)
            => GetTopSort(where, -1, string.Empty, null, parameters);

        /// <summary>
        /// 按自定义条件查询
        /// </summary>
        /// <param name = "where">自定义条件,where子句</param>
        /// <param name = "paras">where子句中定义的参数集合</param>
        /// <return>实体对象集合</return>
        public List<TEntity> Get(string where, IEnumerable<TParameter> paras)
            => GetTopSort(where, paras, -1, string.Empty, null);

        /// <summary>
        /// 按自定义条件查询
        /// </summary>
        /// <param name = "where">自定义条件,where子句</param>
        /// <param name="tm">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<TEntity> Get(string where, TransactionManager tm)
            => GetTopSort(where, null, -1, string.Empty, tm);

        /// <summary>
        /// 按自定义条件查询
        /// </summary>
        /// <param name = "where">自定义条件,where子句</param>
        /// <param name="tm">事务管理对象</param>
        /// <param name = "values">where子句中定义的参数值集合</param>
        /// <return>实体对象集合</return>
        public List<TEntity> Get(string where, TransactionManager tm, params object[] values)
            => GetTopSort(where, -1, string.Empty, tm, values);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <param name="tm"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public List<TEntity> Get(string where, TransactionManager tm, params (TDbType dbType, object value)[] parameters)
            => GetTopSort(where, -1, string.Empty, tm, parameters);

        /// <summary>
        /// 按自定义条件查询
        /// </summary>
        /// <param name = "where">自定义条件,where子句</param>
        /// <param name = "paras">where子句中定义的参数集合</param>
        /// <param name="tm">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<TEntity> Get(string where, IEnumerable<TParameter> paras, TransactionManager tm)
            => GetTopSort(where, paras, -1, string.Empty, tm);
        #endregion // Get

        #region GetTop
        /// <summary>
        /// 按自定义条件查询
        /// </summary>
        /// <param name = "where">自定义条件,where子句</param>
        /// <param name = "top">获取行数</param>
        /// <return>实体对象集合</return>
        public List<TEntity> GetTop(string where, int top)
            => GetTopSort(where, null, top, string.Empty, null);

        /// <summary>
        /// 按自定义条件查询
        /// </summary>
        /// <param name = "where">自定义条件,where子句</param>
        /// <param name = "top">获取行数</param>
        /// <param name = "values">where子句中定义的参数值集合</param>
        /// <return>实体对象集合</return>
        public List<TEntity> GetTop(string where, int top, params object[] values)
            => GetTopSort(where, top, string.Empty, null, values);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <param name="top"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public List<TEntity> GetTop(string where, int top, params (TDbType dbType, object value)[] parameters)
            => GetTopSort(where, top, string.Empty, null, parameters);

        /// <summary>
        /// 按自定义条件查询
        /// </summary>
        /// <param name = "where">自定义条件,where子句</param>
        /// <param name = "paras">where子句中定义的参数集合</param>
        /// <param name = "top">获取行数</param>
        /// <return>实体对象集合</return>
        public List<TEntity> GetTop(string where, IEnumerable<TParameter> paras, int top)
            => GetTopSort(where, paras, top, string.Empty, null);

        /// <summary>
        /// 按自定义条件查询
        /// </summary>
        /// <param name = "where">自定义条件,where子句</param>
        /// <param name = "top">获取行数</param>
        /// <param name="tm">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<TEntity> GetTop(string where, int top, TransactionManager tm)
            => GetTopSort(where, null, top, string.Empty, tm);

        /// <summary>
        /// 按自定义条件查询
        /// </summary>
        /// <param name = "where">自定义条件,where子句</param>
        /// <param name = "top">获取行数</param>
        /// <param name="tm">事务管理对象</param>
        /// <param name = "values">where子句中定义的参数值集合</param>
        /// <return>实体对象集合</return>
        public List<TEntity> GetTop(string where, int top, TransactionManager tm, params object[] values)
            => GetTopSort(where, top, string.Empty, tm, values);

        /// <summary>
        /// 按自定义条件查询
        /// </summary>
        /// <param name="where"></param>
        /// <param name="top"></param>
        /// <param name="tm"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public List<TEntity> GetTop(string where, int top, TransactionManager tm, params (TDbType dbType, object value)[] parameters)
            => GetTopSort(where, top, string.Empty, tm, parameters);

        /// <summary>
        /// 按自定义条件查询
        /// </summary>
        /// <param name = "where">自定义条件,where子句</param>
        /// <param name = "paras">where子句中定义的参数集合</param>
        /// <param name = "top">获取行数</param>
        /// <param name="tm">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<TEntity> GetTop(string where, IEnumerable<TParameter> paras, int top, TransactionManager tm)
            => GetTopSort(where, paras, top, string.Empty, tm);
        #endregion // GetTop

        #region GetSort
        /// <summary>
        /// 按自定义条件查询
        /// </summary>
        /// <param name = "where">自定义条件,where子句</param>
        /// <param name = "sort">排序表达式</param>
        /// <return>实体对象集合</return>
        public List<TEntity> GetSort(string where, string sort)
            => GetTopSort(where, null, -1, sort, null);

        /// <summary>
        /// 按自定义条件查询
        /// </summary>
        /// <param name = "where">自定义条件,where子句</param>
        /// <param name = "sort">排序表达式</param>
        /// <param name = "values">where子句中定义的参数值集合</param>
        /// <return>实体对象集合</return>
        public List<TEntity> GetSort(string where, string sort, params object[] values)
            => GetTopSort(where, -1, sort, null, values);

        /// <summary>
        /// 按自定义条件查询
        /// </summary>
        /// <param name="where"></param>
        /// <param name="sort"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public List<TEntity> GetSort(string where, string sort, params (TDbType dbType, object value)[] parameters)
            => GetTopSort(where, -1, sort, null, parameters);

        /// <summary>
        /// 按自定义条件查询
        /// </summary>
        /// <param name = "where">自定义条件,where子句</param>
        /// <param name = "paras">where子句中定义的参数集合</param>
        /// <param name = "sort">排序表达式</param>
        /// <return>实体对象集合</return>
        public List<TEntity> GetSort(string where, IEnumerable<TParameter> paras, string sort)
            => GetTopSort(where, paras, -1, sort, null);

        /// <summary>
        /// 按自定义条件查询
        /// </summary>
        /// <param name = "where">自定义条件,where子句</param>
        /// <param name = "sort">排序表达式</param>
        /// <param name="tm">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<TEntity> GetSort(string where, string sort, TransactionManager tm)
            => GetTopSort(where, null, -1, sort, tm);

        /// <summary>
        /// 按自定义条件查询
        /// </summary>
        /// <param name = "where">自定义条件,where子句</param>
        /// <param name = "sort">排序表达式</param>
        /// <param name="tm">事务管理对象</param>
        /// <param name = "values">where子句中定义的参数值集合</param>
        /// <return>实体对象集合</return>
        public List<TEntity> GetSort(string where, string sort, TransactionManager tm, params object[] values)
            => GetTopSort(where, -1, sort, tm, values);

        /// <summary>
        /// 按自定义条件查询
        /// </summary>
        /// <param name="where"></param>
        /// <param name="sort"></param>
        /// <param name="tm"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public List<TEntity> GetSort(string where, string sort, TransactionManager tm, params (TDbType dbType, object value)[] parameters)
            => GetTopSort(where, -1, sort, tm, parameters);

        /// <summary>
        /// 按自定义条件查询
        /// </summary>
        /// <param name = "where">自定义条件,where子句</param>
        /// <param name = "paras">where子句中定义的参数集合</param>
        /// <param name = "sort">排序表达式</param>
        /// <param name="tm">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<TEntity> GetSort(string where, IEnumerable<TParameter> paras, string sort, TransactionManager tm)
            => GetTopSort(where, paras, -1, sort, tm);
        #endregion // GetSort

        #region GetTopSort
        /// <summary>
        /// 按自定义条件查询
        /// </summary>
        /// <param name = "where">自定义条件,where子句</param>
        /// <param name = "top">获取行数</param>
        /// <param name = "sort">排序表达式</param>
        /// <return>实体对象集合</return>
        public List<TEntity> GetTopSort(string where, int top, string sort)
            => GetTopSort(where, null, top, sort, null);

        /// <summary>
        /// 按自定义条件查询
        /// </summary>
        /// <param name = "where">自定义条件,where子句</param>
        /// <param name = "top">获取行数</param>
        /// <param name = "sort">排序表达式</param>
        /// <param name = "values">where子句中定义的参数值集合</param>
        /// <return>实体对象集合</return>
        public List<TEntity> GetTopSort(string where, int top, string sort, params object[] values)
            => GetTopSort(where, top, sort, null, values);

        /// <summary>
        /// 按自定义条件查询
        /// </summary>
        /// <param name="where"></param>
        /// <param name="top"></param>
        /// <param name="sort"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public List<TEntity> GetTopSort(string where, int top, string sort, params (TDbType dbType, object value)[] parameters)
            => GetTopSort(where, top, sort, null, parameters);

        /// <summary>
        /// 按自定义条件查询
        /// </summary>
        /// <param name = "where">自定义条件,where子句</param>
        /// <param name = "paras">where子句中定义的参数集合</param>
        /// <param name = "top">获取行数</param>
        /// <param name = "sort">排序表达式</param>
        /// <return>实体对象集合</return>
        public List<TEntity> GetTopSort(string where, IEnumerable<TParameter> paras, int top, string sort)
            => GetTopSort(where, paras, top, sort, null);

        /// <summary>
        /// 按自定义条件查询
        /// </summary>
        /// <param name = "where">自定义条件,where子句</param>
        /// <param name = "top">获取行数</param>
        /// <param name = "sort">排序表达式</param>
        /// <param name="tm">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<TEntity> GetTopSort(string where, int top, string sort, TransactionManager tm)
            => GetTopSort(where, null, top, sort, tm);

        /// <summary>
        /// 按自定义条件查询
        /// </summary>
        /// <param name = "where">自定义条件,where子句</param>
        /// <param name = "top">获取行数</param>
        /// <param name = "sort">排序表达式</param>
        /// <param name="tm">事务管理对象</param>
        /// <param name = "values">where子句中定义的参数值集合</param>
        /// <return>实体对象集合</return>
        public List<TEntity> GetTopSort(string where, int top, string sort, TransactionManager tm, params object[] values)
        {
            var sql = BuildSelectSQL(where, top, sort);
            var paras = GetParametersByDerive(sql, values);
            return Database.ExecSqlList<TEntity>(sql, paras, tm, DataMappingMode.Interface);
        }

        /// <summary>
        /// 按自定义条件查询
        /// </summary>
        /// <param name = "where">自定义条件,where子句</param>
        /// <param name = "paras">where子句中定义的参数集合</param>
        /// <param name = "top">获取行数</param>
        /// <param name = "sort">排序表达式</param>
        /// <param name="tm">事务管理对象</param>
        /// <return>实体对象集合</return>
        public List<TEntity> GetTopSort(string where, IEnumerable<TParameter> paras, int top, string sort, TransactionManager tm)
        {
            var sql = BuildSelectSQL(where, top, sort);
            return Database.ExecSqlList<TEntity>(sql, paras, tm, DataMappingMode.Interface);
        }
        /// <summary>
        /// 按自定义条件查询
        /// </summary>
        /// <param name="where"></param>
        /// <param name="top"></param>
        /// <param name="sort"></param>
        /// <param name="tm"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public List<TEntity> GetTopSort(string where, int top, string sort, TransactionManager tm, params (TDbType dbType, object value)[] parameters)
        {
            var sql = BuildSelectSQL(where, top, sort);
            return Database.ExecSqlList<TEntity>(sql, tm, DataMappingMode.Interface, parameters);
        }
        #endregion // GetTopSort

        #endregion // GetWhere

        #region GetSingle
        /// <summary>
        /// 按自定义条件查询，返回唯一一条记录
        /// </summary>
        /// <return>实体对象</return>
        public TEntity GetSingle()
            => GetSingle(string.Empty, null, (TransactionManager)null);
        /// <summary>
        /// 按自定义条件查询，返回唯一一条记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public TEntity GetSingle(string where)
            => GetSingle(where, null, (TransactionManager)null);
        /// <summary>
        /// 按自定义条件查询，返回唯一一条记录
        /// </summary>
        /// <param name = "where">自定义条件,where子句</param>
        /// <param name="tm">事务管理对象</param>
        /// <return>实体对象</return>
        public TEntity GetSingle(string where, TransactionManager tm)
            => GetSingle(where, null, tm);

        /// <summary>
        /// 按自定义条件查询，返回唯一一条记录
        /// </summary>
        /// <param name = "where">自定义条件,where子句</param>
        /// <param name = "values">where子句中定义的参数值集合</param>
        /// <return>实体对象</return>
        public TEntity GetSingle(string where, params object[] values)
            => GetSingle(where, null, values);

        /// <summary>
        /// 按自定义条件查询，返回唯一一条记录
        /// </summary>
        /// <param name="where">自定义条件,where子句</param>
        /// <param name="parameters">where子句中定义的参数集合</param>
        /// <returns></returns>
        public TEntity GetSingle(string where, params (TDbType dbType, object value)[] parameters)
            => GetSingle(where, null, parameters);

        /// <summary>
        /// 按自定义条件查询，返回唯一一条记录
        /// </summary>
        /// <param name = "where">自定义条件,where子句</param>
        /// <param name = "paras">where子句中定义的参数集合</param>
        /// <return>实体对象</return>
        public TEntity GetSingle(string where, IEnumerable<TParameter> paras)
            => GetSingle(where, paras, (TransactionManager)null);

        /// <summary>
        /// 按自定义条件查询，返回唯一一条记录
        /// </summary>
        /// <param name = "where">自定义条件,where子句</param>
        /// <param name="tm">事务管理对象</param>
        /// <param name = "values">where子句中定义的参数值集合</param>
        /// <return>实体对象</return>
        public TEntity GetSingle(string where, TransactionManager tm, params object[] values)
        {
            var sql = BuildSelectSQL(where, 1, string.Empty);
            var paras = GetParametersByDerive(sql, values);
            return Database.ExecSqlSingle<TEntity>(sql, paras, tm, DataMappingMode.Interface);
        }

        /// <summary>
        /// 按自定义条件查询，返回唯一一条记录
        /// </summary>
        /// <param name = "where">自定义条件,where子句</param>
        /// <param name = "paras">where子句中定义的参数集合</param>
        /// <param name="tm">事务管理对象</param>
        /// <return>实体对象</return>
        public TEntity GetSingle(string where, IEnumerable<TParameter> paras, TransactionManager tm)
        {
            var sql = BuildSelectSQL(where, 1, string.Empty);
            return Database.ExecSqlSingle<TEntity>(sql, paras, tm, DataMappingMode.Interface);
        }

        /// <summary>
        /// 按自定义条件查询，返回唯一一条记录
        /// </summary>
        /// <param name="where">自定义条件,where子句</param>
        /// <param name="tm">事务管理对象</param>
        /// <param name="parameters">where子句中定义的参数集合</param>
        /// <returns></returns>
        public TEntity GetSingle(string where, TransactionManager tm, params (TDbType dbType, object value)[] parameters)
        {
            var sql = BuildSelectSQL(where, 1, string.Empty);
            return Database.ExecSqlSingle<TEntity>(sql, tm, DataMappingMode.Interface, parameters);
        }
        #endregion //GetSingle

        #region  GetCount
        /// <summary>
        /// 获取记录数
        /// </summary>
        /// <param name="tm">事务管理对象</param>
        /// <return>数据个数</return>
        public long GetCount(TransactionManager tm = null)
            => GetCount(string.Empty, null, tm);

        /// <summary>
        /// 获取记录数
        /// </summary>
        /// <param name = "where">自定义条件,where子句</param>
        /// <return>数据个数</return>
        public long GetCount(string where)
            => GetCount(where, null, (TransactionManager)null);

        /// <summary>
        /// 获取记录数
        /// </summary>
        /// <param name = "where">自定义条件,where子句</param>
        /// <param name = "values">where子句中定义的参数值集合</param>
        /// <return>数据个数</return>
        public long GetCount(string where, params object[] values)
            => GetCount(where, null, values);

        /// <summary>
        /// 获取记录数
        /// </summary>
        /// <param name="where"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public long GetCount(string where, params (TDbType dbType, object value)[] parameters)
            => GetCount(where, null, parameters);

        /// <summary>
        /// 获取记录数
        /// </summary>
        /// <param name = "where">自定义条件,where子句</param>
        /// <param name = "paras">where子句中定义的参数集合</param>
        /// <return>数据个数</return>
        public long GetCount(string where, IEnumerable<TParameter> paras)
            => GetCount(where, paras, null);

        /// <summary>
        /// 获取记录数
        /// </summary>
        /// <param name = "where">自定义条件,where子句</param>
        /// <param name="tm">事务管理对象</param>
        /// <return>数据个数</return>
        public long GetCount(string where, TransactionManager tm)
            => GetCount(where, null, tm);

        /// <summary>
        /// 获取记录数
        /// </summary>
        /// <param name = "where">自定义条件,where子句</param>
        /// <param name="tm">事务管理对象</param>
        /// <param name = "values">where子句中定义的参数值集合</param>
        /// <return>数据个数</return>
        public long GetCount(string where, TransactionManager tm, params object[] values)
        {
            string sql = BuildCountSQL(where);
            var paras = GetParametersByDerive(sql, values);
            return Database.ExecSqlScalar<long>(sql, paras, tm);
        }
        /// <summary>
        /// 获取记录数
        /// </summary>
        /// <param name="where"></param>
        /// <param name="tm"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public long GetCount(string where, TransactionManager tm, params (TDbType dbType, object value)[] parameters)
        {
            string sql = BuildCountSQL(where);
            return Database.ExecSqlScalar<long>(sql, tm, parameters);
        }

        /// <summary>
        /// 获取记录数
        /// </summary>
        /// <param name = "where">自定义条件,where子句</param>
        /// <param name = "paras">where子句中定义的参数集合</param>
        /// <param name="tm">事务管理对象</param>
        /// <return>数据个数</return>
        public long GetCount(string where, IEnumerable<TParameter> paras, TransactionManager tm)
        {
            string sql = BuildCountSQL(where);
            return Database.ExecSqlScalar<long>(sql, paras, tm);
        }
        #endregion //GetCount

        #region  分页

        /// <summary>
        /// 获取分页操作对象
        /// </summary>
        /// <param name = "pageSize">页大小</param>
        /// <param name = "where">自定义条件,where子句</param>
        /// <param name = "sort">排序表达式</param>
        /// <return>分页操作对象</return>
        public IDataPager GetPager(int pageSize, string where = null, string sort = null)
        {
            string sql = BuildSelectSQL(where, 0, sort);
            return Database.GetPager(sql, pageSize);
        }
        #endregion

        #region Utils
        protected string BuildCountSQL(string where)
        {
            var ret = $"SELECT COUNT(*) FROM {SourceName}";
            if (!string.IsNullOrEmpty(where))
                ret += " WHERE " + where;
            return ret;
        }

        /// <summary>
        /// 获取SelectSQL
        /// </summary>
        /// <param name="where"></param>
        /// <param name="top"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        protected string BuildSelectSQL(string where, int top, string sort)
            => OrmProvider.BuildSelectSQL(SourceName, where, top, sort);

        protected string BuildUpdateSQL(string set, string where)
        {
            if (string.IsNullOrEmpty(set))
                throw new ArgumentException("生成update语句是set参数不能为空。");
            var ret = $"UPDATE {SourceName} SET {set}";
            if (!string.IsNullOrEmpty(where))
                ret += " WHERE " + where;
            return ret;
        }
        #endregion

        #region GetParametersByDerive
        protected object[] ConcatValues(object[] values, params object[] newValues)
        {
            return values.AddRange(newValues);
        }
        protected IEnumerable<TParameter> ConcatParameters(IEnumerable<TParameter> paras, IEnumerable<TParameter> newParas)
        {
            return paras.Concat(newParas);
        }
        // key: connectionString|SQL value: parameterName MyDbType
        protected static ConcurrentDictionary<string, (string parameterName, TDbType dbType)[]> _sqlParametersCache = new ConcurrentDictionary<string, (string parameterName, TDbType dbType)[]>();
        // key : SourceName, value: 所有字段类型
        protected static ConcurrentDictionary<string, Dictionary<string, TDbType>> _objParametersCache = new ConcurrentDictionary<string, Dictionary<string, TDbType>>();
        protected IEnumerable<TParameter> GetParametersByDerive(string sql, object[] values)
        {
            var key = $"{Database.ConnectionString}|{sql}";
            var paras = _sqlParametersCache.GetOrAdd(key, (key1) => {
                return GetSqlCacheItem(sql);
            });
            if (paras.Length != values.Length)
                throw new Exception($"解析SQL语句获得的参数数量与赋值的数量不一致。paras: {paras.Length} values: {values.Length}");
            var ret = new List<TParameter>();
            for (int i = 0; i < paras.Length; i++)
                ret.Add(Database.CreateInParameter(paras[i].parameterName, values[i], paras[i].dbType));
            return ret;
        }
        protected (string parameterName, TDbType dbType)[] GetSqlCacheItem(string sql)
        {
            var key = $"{SourceType}|{SourceName}";
            Dictionary<string, TDbType> paras = _objParametersCache.GetOrAdd(key, (key1) => {
                return OrmProvider.GetDbTypeMappings(Database, SourceName, SourceType);
            });
            var parameterNames = Database.ParseSqlParameterNames(sql);
            var ret = new(string parameterName, TDbType dbType)[parameterNames.Count];
            for (int i = 0; i < parameterNames.Count; i++)
            {
                var parameterName = parameterNames[i];
                if (paras.ContainsKey(parameterName.ToUpper()))
                    ret[i] = (parameterName, paras[parameterName.ToUpper()]);
                else
                    ret[i] = (parameterName, default(TDbType));
            }
            return ret;
        }
        #endregion
    }
}
