using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using TinyFx.Configuration;
using TinyFx.Configuration.Data;
using TinyFx.Data.Instrumentation;

namespace TinyFx.Data
{
    /// <summary>
    /// tinyfx.config中的数据库配置信息
    /// </summary>
    public static class DbConfigManager
    {
        // key: connectionStringName
        private static ConcurrentDictionary<string, ConnectionStringConfig> _connectionStringConfigCache = new ConcurrentDictionary<string, ConnectionStringConfig>();
        // key: namespace value: connectionStringName
        private static ConcurrentDictionary<string, ConnectionStringConfig> _namespaceCache = new ConcurrentDictionary<string, ConnectionStringConfig>();
        // 默认连接字符串名
        private static string _defaultConnectionStringName = null;

        /// <summary>
        /// 静态构造函数
        /// </summary>
        static DbConfigManager()
        {
            ReloadConfig();
        }
        public static void Load() { }
        
        /// <summary>
        /// 重新加载配置数据
        /// </summary>
        public static void ReloadConfig()
        {
            _connectionStringConfigCache.Clear();
            _defaultConnectionStringName = null;
            var section = TinyFxConfigManager.GetConfig<DataConfig>();
            if (section == null) return;
            _defaultConnectionStringName = section.DefaultConnectionString;
            if (section.ConnectionStrings != null)
            {
                foreach (ConnectionStringElement sett in section.ConnectionStrings.Values)
                {
                    if (string.IsNullOrEmpty(sett.Name) || string.IsNullOrEmpty(sett.ConnectionString))
                        continue;
                    string instType = !string.IsNullOrEmpty(sett.InstProvider) ? sett.InstProvider : section.InstProvider;
                    var config = new ConnectionStringConfig
                    {
                        ConnectionStringName = sett.Name,
                        Provider = DbDataProviderUtil.GetProvider(sett.ProviderName),
                        ConnectionString = sett.ConnectionString,
                        ReadConnectionString = sett.ReadConnectionString,
                        CommandTimeout = sett.CommandTimeout,
                        InstProvider = string.IsNullOrEmpty(instType) ? DefaultDataInstProvider.Instance
                            : (IDataInstProvider)Activator.CreateInstance(Type.GetType(instType))
                    };
                    if (!_connectionStringConfigCache.TryAdd(config.ConnectionStringName, config))
                        throw new Exception("tinyfx.config配置文件中数据库连接配置名称connectionStringName重复。Name: " + config.ConnectionStringName);

                    if (!string.IsNullOrEmpty(sett.OrmMap))
                    {
                        foreach (var ns in sett.OrmMap.Split(';'))
                        {
                            if (!_namespaceCache.TryAdd(ns, config))
                                throw new Exception($"tinyfx.config配置文件中数据库连接配置中OrmMap配置重复。name: {sett.Name} ormMap: {ns}");
                        }
                    }
                }
                if (string.IsNullOrEmpty(_defaultConnectionStringName) && _connectionStringConfigCache.Count == 1)
                    _defaultConnectionStringName = _connectionStringConfigCache.ToArray()[0].Value.ConnectionStringName;
            }
        }

        /// <summary>
        /// 判断是否存在指定名称的ConnectionStringName
        /// </summary>
        /// <param name="connectionStringName"></param>
        /// <returns></returns>
        public static bool ExistConnectionStringName(string connectionStringName)
            => _connectionStringConfigCache.ContainsKey(connectionStringName);

        /// <summary>
        /// 根据配置文件中数据库连接字符串名称获得ConnectionStringConfig
        /// </summary>
        /// <param name="connectionStringName">数据库连接字符串名称</param>
        /// <returns></returns>
        public static ConnectionStringConfig GetConnectionStringConfig(string connectionStringName = null)
        {
            connectionStringName = connectionStringName ?? _defaultConnectionStringName;
            if (string.IsNullOrEmpty(connectionStringName))
                throw new ArgumentNullException("connectionStringName");
            if (!_connectionStringConfigCache.TryGetValue(connectionStringName, out ConnectionStringConfig config))
                throw new Exception("ConnectionStringName在配置中不存在。ConnectionStringName: " + connectionStringName);
            return config;
        }

        /// <summary>
        /// 获得ConnectionStringConfig
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="connectionString"></param>
        /// <param name="readConnectionString"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="inst"></param>
        /// <returns></returns>
        public static ConnectionStringConfig GetConnectionStringConfig(DbDataProvider provider, string connectionString, string readConnectionString, int commandTimeout = 30, IDataInstProvider inst = null)
        {
            return new ConnectionStringConfig() {
                Provider = provider,
                ConnectionString = connectionString,
                ReadConnectionString = readConnectionString,
                CommandTimeout = commandTimeout,
                InstProvider = inst ?? DefaultDataInstProvider.Instance
            };
        }

        /// <summary>
        /// 尝试获取连接配置信息
        /// </summary>
        /// <param name="connectionStringName"></param>
        /// <param name="provider"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static bool TryGetConnectionStringConfig(string connectionStringName, DbDataProvider provider, out ConnectionStringConfig config)
        {
            config = null;
            connectionStringName = connectionStringName ?? _defaultConnectionStringName;
            if (string.IsNullOrEmpty(connectionStringName)) // 空并且没有默认值
                return false;
            if (connectionStringName.Length > 30) // 长度大于30当做连接字符串处理
            {
                config = GetConnectionStringConfig(provider, connectionStringName, null, 30, null);
                return true;
            }
            if (!_connectionStringConfigCache.TryGetValue(connectionStringName, out config)) // 配置文件中不存在
                return false;
            return true;
        }

        /// <summary>
        /// 根据命名空间获取配置信息
        /// </summary>
        /// <param name="ns"></param>
        /// <returns></returns>
        public static ConnectionStringConfig GetOrmConnectionStringConfig(string ns)
        {
            _namespaceCache.TryGetValue(ns, out ConnectionStringConfig config);
            return config;
        }
    }
}
