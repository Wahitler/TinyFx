using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyFx.Data.MySqlClient
{
    /// <summary>
    /// MySqlBulkLoader扩展
    /// </summary>
    public class MySqlBulkCopy : MySqlBulkLoader
    {
        public MySqlBulkCopy(string connectionString)
            : base(new MySqlConnection(connectionString))
        {
            FieldTerminator = ",";
            LineTerminator = "\r\n";
            NumberOfLinesToSkip = 1;
        }

        public int Load(string filename, string tableName)
        {
            TableName = tableName;
            FileName = filename;
            return Load();
        }
    }
}
