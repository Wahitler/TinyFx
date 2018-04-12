using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace TinyFx.Data.OracleClient
{
    /// <summary>
    /// Oracle分页类
    /// </summary>
    public class OracleDataPager : DataPagerBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="pageSize"></param>
        /// <param name="database"></param>
        /// <param name="keyField"></param>
        public OracleDataPager(string sql, int pageSize, Database database, string keyField = null)
            : base(sql, pageSize, database, keyField) { }

        /// <summary>
        /// 添加分页SQL语句中定义的参数
        /// </summary>
        /// <param name="name">参数名称</param>
        /// <param name="value">参数值</param>
        /// <param name="dbType">参数类型</param>
        /// <param name="size">参数大小</param>
        public OracleParameter AddInParameter(string name, object value = null, OracleDbType dbType = default(OracleDbType), int size = 0)
        {
            var param = (Database as OracleDatabase).CreateParameter(name, dbType, size, ParameterDirection.Input, value);
            _paras.Add(param);
            return param;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override SqlPagerCacheItem GetSqlCacheItem()
        {
            SqlSelectParser parser = new SqlSelectParser(OriginalSql);
            SqlSelectStruct sqlStruct = new SqlSelectStruct()
            {
                Select = (parser.Select == null) ? string.Empty : parser.Select.Value,
                From = (parser.From == null) ? string.Empty : parser.From.Value,
                Where = (parser.Where == null) ? string.Empty : parser.Where.Value,
                GroupBy = (parser.GroupBy == null) ? string.Empty : parser.GroupBy.Value,
                Having = (parser.Having == null) ? string.Empty : parser.Having.Value,
                OrderBy = (parser.OrderBy == null) ? string.Empty : parser.OrderBy.Value,
            };
            return ParseOracle(sqlStruct, UserData, Database);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
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
                sql = string.Format(PagerSql, pageIndex * PageSize);
                dao = Database.GetSqlDao(sql);
                dao.AddInParameter("PageIndex", pageIndex, System.Data.DbType.Int64, 8);
            }
            dao.AddInParameter("PageSize", PageSize, System.Data.DbType.Int64, 8);
            return dao;
        }

        #region 解析Oracle
        //解析Oracle分页
        private SqlPagerCacheItem ParseOracle(SqlSelectStruct sqlStruct, string keyField, Database database)
        {
            SqlPagerCacheItem ret = new SqlPagerCacheItem();
            //string sql = sqlStruct.ToString();

            if (string.IsNullOrEmpty(sqlStruct.Select)) sqlStruct.Select = "*";
            if (!string.IsNullOrEmpty(sqlStruct.Where)) sqlStruct.Where = "WHERE " + sqlStruct.Where;
            if (!string.IsNullOrEmpty(sqlStruct.GroupBy)) sqlStruct.GroupBy = "GROUP BY " + sqlStruct.GroupBy;
            if (!string.IsNullOrEmpty(sqlStruct.Having)) sqlStruct.Having = "HAVING " + sqlStruct.Having;
            if (!string.IsNullOrEmpty(sqlStruct.OrderBy)) sqlStruct.OrderBy = "ORDER BY " + sqlStruct.OrderBy;
            bool hasGroupBy = !string.IsNullOrEmpty(sqlStruct.GroupBy);

            sqlStruct.From = "FROM " + sqlStruct.From;
            // RecordCountSql
            if (hasGroupBy)
                ret.RecordCountSql = string.Format("SELECT Count(*) FROM (SELECT {0} {1} {2} {3} {4}) Temp_Table_A"
                    , sqlStruct.Select, sqlStruct.From, sqlStruct.Where, sqlStruct.GroupBy, sqlStruct.Having);
            else
                ret.RecordCountSql = string.Format("SELECT Count(*) {0} {1}", sqlStruct.From, sqlStruct.Where);

            // FirstPageSql
            //SELECT * FROM (SELECT * FROM TestTable ORDERY BY name ASC) WHERE ROWNUM <= 10
            ret.FirstPageSql = string.Format("SELECT * FROM ({0}) WHERE ROWNUM <=:PageSize", OriginalSql);

            string id1 = "((:PageIndex-1)*:PageSize)";
            string id2 = "(:PageIndex*:PageSize)";
            // PagerSql
            /*
            SELECT *
               FROM (
                      SELECT A.*, rownum rn
                     FROM  (sql) A
                     WHERE rownum <= id2
                    ) B
                WHERE rn > id1
             */
            ret.PagerSql = string.Format("SELECT * FROM (SELECT Temp_Table_A.*, ROWNUM ROWNUMBER FROM ({0}) Temp_Table_A WHERE ROWNUM <= {1}) Temp_Table_B WHERE ROWNUMBER > {2}"
                , OriginalSql, id2, id1);

            return ret;
        }
        #endregion 
    }
}
