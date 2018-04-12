using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using TinyFx.Data.DataMapping;
using System.Collections.Concurrent;

namespace TinyFx.Data.ORM
{
    /// <summary>
    /// 数据库MO基类
    ///     DbMOBase => DbObjectMO => DbTableMO/DbViewMO => XXTableMO/XXViewMO
    ///              => DbProcMO => XXProcMO
    /// </summary>
    public abstract class DbMOBase<TDatabase, TParameter, TDbType>
        where TDatabase : Database<TParameter, TDbType>
        where TParameter : DbParameter
        where TDbType : struct
    {
        // key: connectionStringName_provider_typeNamespace
        private static ConcurrentDictionary<string, Database> DatabaseCache = new ConcurrentDictionary<string, Database>();

        /// <summary>
        /// 当前对象初始化
        /// </summary>
        /// <param name="connectionStringName"></param>
        /// <param name="builder"></param>
        public void Init(string connectionStringName, Func<ConnectionStringConfig, TDatabase> builder)
        {
            var ns = this.GetType().Namespace;
            var key = $"{connectionStringName}_{Provider}_{ns}";
            if (DatabaseCache.TryGetValue(key, out Database database))
            {
                Database = (TDatabase)database;
                return;
            }
            ConnectionStringConfig config = null;
            if (connectionStringName == null) // namespace判断优先
            {
                config = DbConfigManager.GetOrmConnectionStringConfig(ns);
                if (config != null)
                {
                    Database = builder(config);
                    DatabaseCache.TryAdd(key, Database);
                    return;
                }
            }
            if (!DbConfigManager.TryGetConnectionStringConfig(connectionStringName, Provider, out config))
                throw new Exception($"ConnectionStringName在配置中不存在。ConnectionStringName: {connectionStringName}");
            Database = builder(config);
            DatabaseCache.TryAdd(key, Database);
        }

        /// <summary>
        /// 数据库对象
        /// </summary>
        public TDatabase Database { get; set; }
        /// <summary> 
        /// 数据提供程序类型
        /// </summary>
        public abstract DbDataProvider Provider { get; }

        /// <summary>
        /// 特定数据库的ORM提供
        /// </summary>
        protected abstract IDbOrmProvider<TDatabase, TParameter, TDbType> OrmProvider { get; }

        /// <summary>
        /// 数据对象类型
        /// </summary>
        public abstract DbObjectType SourceType { get; }

        /// <summary>
        /// 数据对象名称
        /// </summary>
        public abstract string SourceName { get; }

        /// <summary>
        /// 执行SQL时Timeout时间
        /// </summary>
        public int CommandTimeout
        {
            get { return Database.CommandTimeout; }
            set { Database.CommandTimeout = value; }
        }
    }
}
