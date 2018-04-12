using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using TinyFx.Data.ORM;

namespace TinyFx.Data.SqlClient
{
    public class SqlOrmProvider : IDbOrmProvider<SqlDatabase, SqlParameter, SqlDbType>
    {
        public string BuildSelectSQL(string sourceName, string where, int top, string sort)
        {
            var topStr = (top > 0) ? " TOP " + top : string.Empty;
            var whereStr = !string.IsNullOrEmpty(where) ? " WHERE " + where : string.Empty;
            var sortStr = !string.IsNullOrEmpty(sort) ? " ORDER BY " + sort : string.Empty;
            return $"SELECT{topStr} * FROM {sourceName}{whereStr}{sortStr}";
        }

        public Dictionary<string, SqlDbType> GetDbTypeMappings(SqlDatabase database, string sourceName, DbObjectType objectType)
        {
            throw new NotImplementedException();
        }
    }
}
