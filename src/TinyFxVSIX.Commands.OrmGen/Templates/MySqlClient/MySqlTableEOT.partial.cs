using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx.Data.Schema;

namespace TinyFxVSIX.Commands.OrmGen.Templates.MySqlClient
{
    public partial class MySqlTableEOT
    {
        public TableSchema CurrentTable { get; internal set; }
        public MySqlTableEOT(TableSchema table)
        {
            CurrentTable = table;
        }
        public string EOName { get { return GetEOName(CurrentTable); } }
    }
}
