using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyFx.Data.MySqlClient
{
    public class MySqlBulk
    {
        public MySqlDatabase Database { get; private set; }
        public string TableName { get; set; }
        public int Timeout { get; set; }
        private HashSet<string> _filterColumns = new HashSet<string>();
        public int CommitCount { get; set; }
        public MySqlBulk(Database database)
        {
            Database = database as MySqlDatabase;
            if (database == null)
                throw new ArgumentException("database参数必须是MySqlDatabase类型且不能为空。", "database");
            Timeout = 30;
            CommitCount = 1000;
        }
        /// <summary>
        /// 获取当前MySQL的
        /// </summary>
        /// <returns></returns>
        public int GetCurrentMaxAllowedPacket()
        {
            return Database.GetVariable<int>(MySqlVariableNames.max_allowed_packet);
        }
        /// <summary>
        /// 获取日志缓存大小
        /// </summary>
        /// <returns></returns>
        public int GetCurrentLogBuffeSize()
        {
            return Database.GetVariable<int>(MySqlVariableNames.innodb_log_buffer_size);
        }
        /// <summary>
        /// 过滤指定的列
        /// </summary>
        /// <param name="columnNames"></param>
        public void FilterColumns(params string[] columnNames)
        {
            foreach (var name in columnNames)
            {
                if (!_filterColumns.Contains(name))
                    _filterColumns.Add(name);
            }
        }

        /// <summary>
        /// 批量插入数据
        /// </summary>
        /// <param name="table"></param>
        /// <param name="tableName"></param>
        public void Load(DataTable table, string tableName)
        {
            /*
            SET UNIQUE_CHECKS=0
            SET AUTOCOMMIT=0
            */
            if (!string.IsNullOrEmpty(tableName))
                TableName = tableName;
            string baseSQL = string.Format("INSERT INTO `{0}` ({1}) VALUES ", TableName, ParseTableFields(table.Columns));
            int rowCount = 0;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                sb.Append(ParseTableRow(table.Columns, table.Rows[i]));
                rowCount++;
                if (rowCount >= CommitCount || i >= table.Rows.Count - 1)
                {
                    ExecuteLoad(baseSQL + sb.ToString());
                    sb.Clear();
                    rowCount = 0;
                    Console.WriteLine(i);
                }
                else
                {
                    sb.Append(",");
                }
            }
        }
        private string ParseTableFields(DataColumnCollection columns)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < columns.Count; i++)
            {
                if (_filterColumns.Contains(columns[i].ColumnName))
                    continue;
                sb.Append("`").Append(columns[i].ColumnName).Append("`").Append(",");
            }
            return sb.Remove(sb.Length-1,1).ToString();
        }
        private string ParseTableRow(DataColumnCollection columns, DataRow row)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("(");
            for (int i = 0; i < columns.Count; i++)
            {
                if (_filterColumns.Contains(columns[i].ColumnName))
                    continue;
                switch (columns[i].DataType.Name)
                {
                    case "String":
                    case "DateTime":
                        var value = row.ToString(i).Replace("'", "\\'");
                        sb.AppendFormat("'{0}'", value);
                        break;
                    default:
                        sb.Append(row.ToString(i));
                        break;
                }
                sb.Append(",");
            }
            sb.Remove(sb.Length-1,1).Append(")");
            return sb.ToString();
        }
        private void ExecuteLoad(string sql)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("START TRANSACTION;").Append(sql).Append(";").Append("COMMIT;");
            Database.ExecSqlNonQuery(sb.ToString());
        }
    }
}
