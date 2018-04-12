using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using TinyFx.Data.DataMapping;
using TinyFx.Data.ORM;

namespace TinyFx.Data.SqlClient
{
    public abstract class SqlTableMO<TEntity> : DbViewMO<SqlDatabase, SqlParameter, SqlDbType, TEntity>
         where TEntity : IRowMapper<TEntity>
    {
        protected override IDbOrmProvider<SqlDatabase, SqlParameter, SqlDbType> OrmProvider => new SqlOrmProvider();
        public override DbDataProvider Provider => DbDataProvider.SqlClient;

        #region Constructors
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="database"></param>
        public SqlTableMO(SqlDatabase database) { Database = database; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="connectionString">数据库连接字符串，如server=192.168.1.1;database=testdb;uid=root;pwd=root</param>
        /// <param name="commandTimeout">Command的Timeout时间</param>
        public SqlTableMO(string connectionString, int commandTimeout) 
            : this(new SqlDatabase(connectionString, commandTimeout)) { }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name = "connectionStringName">连接字符串名称</param>
        public SqlTableMO(string connectionStringName = null)
            => Init(connectionStringName, (config) => new SqlDatabase(config));
        #endregion
    }
}
