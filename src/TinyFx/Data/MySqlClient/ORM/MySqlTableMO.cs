using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using TinyFx.Data.DataMapping;
using TinyFx.Data.MySqlClient;
using TinyFx.Data.ORM;

namespace TinyFx.Data.MySqlClient
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class MySqlTableMO<TEntity> : DbTableMO<MySqlDatabase, MySqlParameter, MySqlDbType, TEntity>
         where TEntity : IRowMapper<TEntity>
    {
        protected override IDbOrmProvider<MySqlDatabase, MySqlParameter, MySqlDbType> OrmProvider => new MySqlOrmProvider();
        public override DbDataProvider Provider => DbDataProvider.MySqlClient;

        #region Constructors
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="database"></param>
        public MySqlTableMO(MySqlDatabase database) { Database = database; }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="connectionString">MySql数据库连接字符串，如server=192.168.1.1;database=testdb;uid=root;pwd=root</param>
        /// <param name="commandTimeout">Command的Timeout时间</param>
        public MySqlTableMO(string connectionString, int commandTimeout)
            : this(new MySqlDatabase(connectionString, commandTimeout)) { }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name = "connectionStringName">连接字符串名称</param>
        public MySqlTableMO(string connectionStringName = null)
            => Init(connectionStringName, (config) => new MySqlDatabase(config));

        #endregion
    }
}
