using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace TinyFx.Data.SqlClient
{
    /// <summary>
    /// SQL Server 分页类
    /// </summary>
    public class SqlDataPager : DataPagerBase
    {
        public SqlDataPager(string sql, int pageSize, Database database, string userData = null)
            : base(sql, pageSize, database, userData)
        { }
        /// <summary>
        /// 添加分页SQL语句中定义的参数
        /// </summary>
        /// <param name="name">参数名称</param>
        /// <param name="value">参数值</param>
        /// <param name="dbType">参数类型</param>
        /// <param name="size">参数大小</param>
        public SqlParameter AddInParameter(string name, object value = null,  SqlDbType dbType = default(SqlDbType), int size = 0)
        {
            var param = (Database as SqlDatabase).CreateParameter(name, dbType, size, ParameterDirection.Input, value);
            _paras.Add(param);
            return param;
        }
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
            return ParseSql(sqlStruct, UserData, Database);
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
                sql = string.Format(PagerSql, pageIndex * PageSize);
                dao = Database.GetSqlDao(sql);
                dao.AddInParameter("PageIndex", pageIndex, System.Data.DbType.Int64, 8);
            }
            dao.AddInParameter("PageSize", PageSize, System.Data.DbType.Int64, 8);
            return dao;
        }

        #region 解析SQL Server
        //解析SQL Server分页
        private SqlPagerCacheItem ParseSql(SqlSelectStruct sqlStruct, string keyField, Database database)
        {
            SqlPagerCacheItem ret = new SqlPagerCacheItem();
            //string sql = sqlStruct.ToString();

            if (string.IsNullOrEmpty(sqlStruct.Select)) sqlStruct.Select = "*";
            if (!string.IsNullOrEmpty(sqlStruct.Where)) sqlStruct.Where = "WHERE " + sqlStruct.Where;
            if (!string.IsNullOrEmpty(sqlStruct.GroupBy)) sqlStruct.GroupBy = "GROUP BY " + sqlStruct.GroupBy;
            if (!string.IsNullOrEmpty(sqlStruct.Having)) sqlStruct.Having = "HAVING " + sqlStruct.Having;
            if (!string.IsNullOrEmpty(sqlStruct.OrderBy)) sqlStruct.OrderBy = "ORDER BY " + sqlStruct.OrderBy;

            //string fields = AnalyzeFields(sqlStruct.Fields);
            bool hasGroupBy = !string.IsNullOrEmpty(sqlStruct.GroupBy);

            // 获得KeyField
            keyField = (keyField == null) ? string.Empty : keyField.Trim();
            if (string.IsNullOrEmpty(keyField) && !hasGroupBy)
            {
                keyField = GetKeyField(database, sqlStruct.From);
            }
            sqlStruct.From = "FROM " + sqlStruct.From;

            // RecordCountSql
            if (hasGroupBy)
                ret.RecordCountSql = string.Format("SELECT Count(*) FROM (SELECT {0} {1} {2} {3} {4}) Temp_Table_A"
                    , sqlStruct.Select, sqlStruct.From, sqlStruct.Where, sqlStruct.GroupBy, sqlStruct.Having);
            else
                ret.RecordCountSql = string.Format("SELECT Count(*) {0} {1}", sqlStruct.From, sqlStruct.Where);

            // FirstPageSql
            if (hasGroupBy)
                ret.FirstPageSql = string.Format("SELECT TOP (@PageSize) {0} {1} {2} {3} {4} {5}"
                    , sqlStruct.Select, sqlStruct.From, sqlStruct.Where, sqlStruct.GroupBy, sqlStruct.Having, sqlStruct.OrderBy);
            else
                ret.FirstPageSql = string.Format("SELECT TOP (@PageSize) {0} {1} {2} {3}", sqlStruct.Select, sqlStruct.From, sqlStruct.Where, sqlStruct.OrderBy);

            string id1 = "((@PageIndex-1)*@PageSize)";
            string id2 = "(@PageIndex*@PageSize)";
            // PagerSql
            if (string.IsNullOrEmpty(keyField))
            {
                string tmpStr = string.Empty;
                //无关键字，有排序（使用ROW_NUMBER方式分页）
                if (!string.IsNullOrEmpty(sqlStruct.OrderBy))
                {
                    if (hasGroupBy)
                    {
                        tmpStr = string.Format("*, ROW_NUMBER() OVER ({0}) AS RowNumber FROM (SELECT {1} {2} {3} {4} {5}) AS Temp_Table_A "
                            , sqlStruct.OrderBy, sqlStruct.Select, sqlStruct.From, sqlStruct.Where, sqlStruct.GroupBy, sqlStruct.Having);
                    }
                    else
                    {
                        tmpStr = string.Format("{0}, ROW_NUMBER() OVER ({1}) AS RowNumber {2} {3}"
                            , sqlStruct.Select, sqlStruct.OrderBy, sqlStruct.From, sqlStruct.Where);
                    }
                    ret.PagerSql = string.Format("SELECT * FROM (SELECT {0}) AS Temp_Table_B WHERE Temp_Table_B.RowNumber > {1} AND Temp_Table_B.RowNumber <= {2}"
                        , tmpStr, id1, id2);
                }
                else//无关键字，无排序（使用TempTable方式分页）
                {
                    if (hasGroupBy)
                    {
                        tmpStr = string.Format("* FROM (SELECT {0} {1} {2} {3} {4}) AS Temp_Table_A ", sqlStruct.Select, sqlStruct.From, sqlStruct.Where, sqlStruct.GroupBy, sqlStruct.Having);
                    }
                    else
                    {
                        tmpStr = string.Format("{0} {1} {2}", sqlStruct.Select, sqlStruct.From, sqlStruct.Where);
                    }
                    ret.PagerSql = string.Format("SELECT *, RowNumber = IDENTITY(int, 1, 1) INTO #Pager_Temp_Table FROM (SELECT TOP 100 PERCENT {0}) Temp_Table_B SELECT * FROM #Pager_Temp_Table WHERE RowNumber > {1}  AND RowNumber <= {2}"
                        , tmpStr, id1, id2);
                }
            }
            else
            {
                //有关键字（使用TopNotIn方式分页）
                string tmpWhere = string.IsNullOrEmpty(sqlStruct.Where) ? "WHERE " : sqlStruct.Where + " AND";
                ret.PagerSql = string.Format("SELECT TOP (@PageSize) {0} {1} {2} {3} NOT IN(SELECT TOP {4} {3} {1} {5} {6} {7} {8}) {6} {7} {8}"
                    , sqlStruct.Select, sqlStruct.From, tmpWhere, keyField, id1, sqlStruct.Where, sqlStruct.GroupBy, sqlStruct.Having, sqlStruct.OrderBy);

                //if (string.IsNullOrEmpty(sqlStruct.OrderBy)) sqlStruct.OrderBy = "ORDER BY " + keyField;
                //if (hasGroupBy)//有关键字，存在GroupBy子句（使用TopNotIn方式分页）
                //{
                //    ret.PagerSql = string.Format("SELECT TOP {0} {10} FROM (SELECT TOP {2} {1} {3} {4} {5} {6} {7}) AS Temp_Table_A WHERE {8} NOT IN(SELECT TOP {9} {8} {3} {4} {5} {6} {7}) {7}"
                //        , pageSize, sqlStruct.Fields, id2, sqlStruct.From, sqlStruct.Where, sqlStruct.GroupBy, sqlStruct.Having, sqlStruct.OrderBy, keyField, id1, fields);
                //}
                //else
                //{
                //    string tmpWhere = string.IsNullOrEmpty(sqlStruct.Where) ? "WHERE " : sqlStruct.Where + " AND";
                //    //有关键字，不存在GroupBy子句，@sOrder包含关键字（使用MaxMin方式分页）
                //    if (sqlStruct.OrderBy.IndexOf("ORDER BY " + keyField, StringComparison.CurrentCultureIgnoreCase) == 0)
                //    {
                //        string tmp = string.Empty;
                //        if (sqlStruct.OrderBy.IndexOf("ORDER BY " + keyField + " DESC", StringComparison.CurrentCultureIgnoreCase) == 0)
                //            tmp = "<(SELECT MIN(";
                //        else
                //            tmp = ">(SELECT MAX(";
                //        ret.PagerSql = string.Format("SELECT TOP {0} {1} {2} {3} {4} {5} {4}) FROM (SELECT TOP {6} {4} {2} {7} {8}) AS Temp_Table_A) {8}"
                //            , pageSize, sqlStruct.Fields, sqlStruct.From, tmpWhere, keyField, tmp, id1, sqlStruct.Where, sqlStruct.OrderBy);
                //    }
                //    else//有关键字，不存在GroupBy子句，@sOrder不包含关键字（使用TopNotIn方式分页）
                //    {
                //        ret.PagerSql = string.Format("SELECT TOP {0} {1} {2} {3} {4} NOT IN(SELECT TOP {5} {4} {2} {6} {7}) {7}"
                //            , pageSize, sqlStruct.Fields, sqlStruct.From, tmpWhere, keyField, id1, sqlStruct.Where, sqlStruct.OrderBy);
                //    }
                //}
            }
            return ret;
        }

        ////字段别名
        //private Dictionary<string, string> _fieldAlias = new Dictionary<string, string>();
        //// 分析字段（去掉原始列名）
        //private string AnalyzeFields(string fields)
        //{
        //    string ret = string.Empty;
        //    if (fields == "*") return "*";
        //    string[] arr = fields.Trim().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        //    string field = string.Empty;
        //    foreach (string item in arr)
        //    {
        //        field = (field + item).Trim();
        //        if (CheckFieldFull(field))
        //        {
        //            if (field.Contains(' '))
        //            {
        //                int position = field.LastIndexOf(' ');
        //                string left = field.Substring(0, position + 1).ToUpper();
        //                if (left.EndsWith(" AS "))
        //                {
        //                    left = left.Substring(0, left.LastIndexOf(" AS ")).Trim();
        //                }
        //                string right = field.Substring(position).Trim();
        //                if (right.Contains('.'))
        //                {
        //                    right = right.Substring(right.IndexOf('.') + 1);
        //                }
        //                left = left.Replace(" ", "");
        //                if (!_fieldAlias.ContainsKey(left))
        //                    _fieldAlias.Add(left, right);
        //                ret += right + ", ";
        //            }
        //            else
        //            {
        //                if (field.Contains('.'))
        //                {
        //                    field = field.Substring(field.IndexOf('.') + 1);
        //                }
        //                ret += field + ", ";
        //            }
        //            field = string.Empty;
        //        }
        //        else
        //            field += ", ";
        //    }
        //    return ret.TrimEnd(',', ' ');
        //}
        //private static bool CheckFieldFull(string field)
        //{
        //    if (!field.Contains('(') && !field.Contains(')')) return true;
        //    int left = 0;
        //    int right = 0;
        //    foreach (char chr in field)
        //    {
        //        if (chr == '(') left++;
        //        if (chr == ')') right++;
        //    }
        //    return left == right;
        //}
        ////处理OrderBy
        //private string RepairOrderBy(string order)
        //{
        //    string ret = string.Empty;
        //    string[] arr = order.Trim().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        //    string field = string.Empty;
        //    foreach (string item in arr)
        //    {
        //        field = (field + item).Trim();
        //        if (CheckFieldFull(field))
        //        {
        //            string temp = field.ToUpper().Trim();
        //            if (!temp.EndsWith(" DESC") && !temp.EndsWith(" ASC"))
        //                temp += " ASC";
        //            int position = temp.LastIndexOf(' ');
        //            string left = temp.Substring(0, position).Trim().Replace(" ", "");
        //            string right = temp.Substring(position);
        //            if (_fieldAlias.ContainsKey(left))
        //                ret += _fieldAlias[left] + right + ", ";
        //            else
        //            {
        //                if (field.Contains('.'))
        //                {
        //                    field = field.Substring(field.IndexOf('.') + 1);
        //                }
        //                ret += field + ", ";
        //            }
        //            field = string.Empty;
        //        }
        //        else
        //        {
        //            field += ", ";
        //        }
        //    }
        //    return ret.TrimEnd(',', ' ');

        //}

        //获取查询对象的主键
        private static string GetKeyField(Database database, string from)
        {
            string ret = string.Empty;
            try
            {
                var dao = database.GetSqlDao(
                    @"SELECT t1.name FROM sys.columns t1, sys.index_columns t2
			                        , (SELECT b.object_id, b.index_id FROM sys.indexes a, sys.index_columns b
				                        WHERE a.object_id = b.object_id AND a.index_id = b.index_id AND a.is_primary_key = 1 
					                        AND a.object_id = OBJECT_ID(@From)
				                        GROUP BY b.object_id, b.index_id
				                        HAVING count(*) = 1) t3
		                        WHERE t1.object_id = t2.object_id AND t2.object_id = t3.object_id
			                        AND t1.column_id=t2.column_id AND t2.index_id = t3.index_id");
                dao.AddInParameter("@From", from);
                object result = dao.ExecScalar();
                //获取只有一个字段的主键
                ret = (result == null) ? string.Empty : result.ToString().Trim();
            }
            catch { }
            return ret;
        }

        #endregion
    }
}
