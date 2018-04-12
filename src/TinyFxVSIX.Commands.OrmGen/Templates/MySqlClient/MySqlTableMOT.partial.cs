using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx.Data.Schema;

namespace TinyFxVSIX.Commands.OrmGen.Templates.MySqlClient
{
    public partial class MySqlTableMOT
    {
        public TableSchema CurrentTable { get; internal set; }
        public MySqlTableMOT(TableSchema table)
        {
            CurrentTable = table;
        }
        public string MOName { get { return GetMOName(CurrentTable); } }
        public string EOName { get { return GetEOName(CurrentTable); } }

        /// <summary>
        /// 获取唯一索引并且多字段和外键并且多字段的集合
        /// </summary>
        /// <returns></returns>
        public List<SchemaCollection<ColumnSchema>> GetMutilFieldsInUniqueAndFK()
        {
            var ret = new List<SchemaCollection<ColumnSchema>>();
            foreach (var index in CurrentTable.Indexes)
            {
                if (index.IsPrimaryKey) continue;
                if (!index.IsUnique || index.Columns.Count == 1) continue;
                // 唯一索引并且多字段
                ret.Add(index.Columns);
            }
            foreach (var fk in CurrentTable.ForeignKeys)
            {
                if (fk.Columns.Count == 1) continue;
                // 外键并且多字段
                ret.Add(fk.Columns);
            }
            return ret;
        }
    }
}
