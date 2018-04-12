using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx;
using TinyFx.Data.Schema;

namespace TinyFxVSIX.Commands.OrmGen.Templates.MySqlClient
{
    public class MySqlTemplateBase : OrmTemplateBase
    {
        public string GetEOName(TableViewSchemaBase table)
        {
            return StringUtil.PascalCase(string.Format("{0}EO", table.SourceName));
        }
        public string GetMOName(TableViewSchemaBase table)
        {
            return StringUtil.PascalCase(string.Format("{0}MO", table.SourceName));
        }
        public string GetMOName(ProcSchema proc)
        {
            return StringUtil.PascalCase(string.Format("{0}MO", proc.ProcName));
        }
    }
}
