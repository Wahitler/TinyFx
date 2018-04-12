using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace TinyFx.Data.MySqlClient
{
    /// <summary>
    /// MySql分页类
    /// </summary>
    public class MySqlDataPager : DataPagerBase
    {
        public MySqlDataPager(string sql, int pageSize, Database database)
            : base(sql, pageSize, database)
        {
            if (Database.Provider != DbDataProvider.MySqlClient)
                throw new ArgumentException("无法创建MySql分页类，Database必须是MySQL类型。", "database");
        }
        /// <summary>
        /// 添加分页SQL语句中定义的参数
        /// </summary>
        /// <param name="name">参数名称</param>
        /// <param name="value">参数值</param>
        /// <param name="dbType">参数类型</param>
        /// <param name="size">参数大小</param>
        public MySqlParameter AddInParameter(string name, object value = null, MySqlDbType dbType = default(MySqlDbType), int size = 0)
        {
            var param = (Database as MySqlDatabase).CreateParameter(name, dbType, size, ParameterDirection.Input, value);
            _paras.Add(param);
            return param;
        }

        protected override IDao BuildSqlDao(long pageIndex)
        {
            IDao dao = null;
            string sql = string.Empty;
            if (pageIndex == 1 || pageIndex < 1)
            {
                sql = FirstPageSql;
                dao = Database.GetSqlDao(sql);
            }
            else
            {
                sql = string.Format(PagerSql, (pageIndex - 1) * PageSize);
                dao = Database.GetSqlDao(sql);
            }
            return dao;
        }
        // MySQL分页大小不能通过参数传入，因此缓存KEY需要加入PageSize
        protected override string GetCacheKey()
        {
            return $"{Database.ConnectionString}_{OriginalSql}_{PageSize}";
        }
        protected override SqlPagerCacheItem GetSqlCacheItem()
        {
            var ret = new SqlPagerCacheItem();
            ret.RecordCountSql = string.Format("SELECT COUNT(*) FROM ({0}) AS TBL", OriginalSql);
            ret.FirstPageSql = string.Format("SELECT * FROM ({0}) AS TBL LIMIT {1}", OriginalSql, PageSize);
            ret.PagerSql = string.Format("SELECT * FROM ({0}) AS TBL LIMIT {{0}},{1}", OriginalSql, PageSize);
            return ret;
        }
    }
}
