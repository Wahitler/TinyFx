using System;
using System.Collections.Generic;
using System.Text;
using TinyFx.Data.MySqlClient;
using MySql.Data.MySqlClient;
using TinyFx.Data.ORM;
using TinyFx.Data.Schema;
using System.Linq;

namespace TinyFx.Data.MySqlClient
{
    public class MySqlOrmProvider : IDbOrmProvider<MySqlDatabase, MySqlParameter, MySqlDbType>
    {
        public string BuildSelectSQL(string sourceName, string where, int top, string sort)
        {
            var topStr = (top > 0) ? " LIMIT " + top : string.Empty;
            var whereStr = !string.IsNullOrEmpty(where) ? " WHERE " + where : string.Empty;
            var sortStr = !string.IsNullOrEmpty(sort) ? " ORDER BY " + sort : string.Empty;
            return $"SELECT * FROM {sourceName}{whereStr}{sortStr}{topStr}";
        }
        /// <summary>
        /// 获取表或试图列参数名对应的MySqlDbType集合
        /// </summary>
        /// <param name="database"></param>
        /// <param name="sourceName"></param>
        /// <param name="objectType"></param>
        /// <returns></returns>
        public Dictionary<string, MySqlDbType> GetDbTypeMappings(MySqlDatabase database, string sourceName, DbObjectType objectType)
        {
            sourceName = sourceName.Trim('`');
            var provider = new MySqlSchemaProvider(database);
            Schema.SchemaCollection<Schema.ColumnSchema> columns = null;
            switch (objectType)
            {
                case DbObjectType.Table:
                    columns = provider.GetTableColumns(sourceName, null);
                    break;
                case DbObjectType.View:
                    columns = provider.GetViewColumns(sourceName, null);
                    break;
            }
            Dictionary<string, MySqlDbType> dic = new Dictionary<string, MySqlDbType>();
            foreach (MySqlColumnSchema column in columns)
                dic.Add(column.SqlParamName.ToUpper(), column.DbType);
            return dic;
        }

        public MySqlSqlDao BuildInsertDao(MySqlDatabase db, string tableName, List<object> values = null)
        {
            var provider = new MySqlSchemaProvider(db);
            var tableSchema = provider.GetTable(tableName);
            var columnSchemas = tableSchema.ColumnsFilter(ColumnSelectMode.NoAutoIncrement).ToList();
            if (values != null && values.Count != columnSchemas.Count)
                throw new Exception($"传入的参数值values和所需参数数量不匹配。columnSchemas.Count={columnSchemas.Count}. values.Count={values.Count}");
            var sql = BuildInsertSql(tableSchema, columnSchemas);
            var ret = new MySqlSqlDao(sql, db);
            for (int i = 0; i < columnSchemas.Count; i++)
            {
                object value = (values == null) ? null : values[i];
                var column = columnSchemas[i] as MySqlColumnSchema;
                ret.AddInParameter(column.SqlParamName, value, column.DbType);
            }
            return ret;
        }
        private static string BuildInsertSql(TableSchema table, IEnumerable<ColumnSchema> columns)
        {
            var ret = new StringBuilder($"INSERT INTO {table.SqlTableName} ");
            var columnNames = columns.Select(item => { return item.SqlColumnName; });
            ret.Append($"({string.Join(", ", columnNames)}) ");
            var paramNames = columns.Select(item => { return item.SqlParamName; });
            ret.Append($"VALUE ({string.Join(", ", paramNames)})");
            return ret.ToString();
        }
    }
}
