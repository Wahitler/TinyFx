using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx.Data;
using TinyFx.Data.Schema;
using TinyFxVSIX.Commands.OrmGen.Templates.MySqlClient;

namespace TinyFxVSIX.Commands.OrmGen.Templates
{
    public class OrmGenProvider
    {
        private OrmTemplateBase GetTemplate(TableSchema table, int type = 0)
        {
            OrmTemplateBase ret = null;
            switch (table.DbDataProvider)
            {
                case DbDataProvider.Unknown:
                    break;
                case DbDataProvider.SqlClient:
                    break;
                case DbDataProvider.OracleClient:
                    break;
                case DbDataProvider.OleDb:
                    break;
                case DbDataProvider.Odbc:
                    break;
                case DbDataProvider.SqlServerCe:
                    break;
                case DbDataProvider.Odac:
                    break;
                case DbDataProvider.MySqlClient:
                    if (type == 0) ret = new MySqlTableEOT(table); else ret = new MySqlTableMOT(table);
                    break;
                default:
                    break;
            }
            return ret;

        }
        public string GetTableCode(TableSchema table, string namespaceName)
        {
            StringBuilder ret = new StringBuilder();
            // 1. 注释
            ret.Append(OrmTemplateBase.GetCopyright());
            // 2. 添加自定义命名空间
            List<string> names = new List<string>
            {
                "TinyFx.Data.MySqlClient",
                "MySql.Data.MySqlClient"
            };
            ret.AppendLine(OrmTemplateBase.GetUsings(names));
            // 3. 获取EO并添加Region
            string eo = GetTemplate(table, 0).TransformText();
            eo = OrmTemplateBase.AddRegion(eo, "EO");
            // 4. 获取MO并添加Region
            string mo = GetTemplate(table, 1).TransformText();
            mo = OrmTemplateBase.AddRegion(mo, "MO");
            // 5. 添加命名空间
            string content = OrmTemplateBase.AddNamespace(eo + Environment.NewLine + mo, namespaceName);
            ret.Append(content);
            return ret.ToString();
        }
        private OrmTemplateBase GetTemplate(ViewSchema view, int type = 0)
        {
            OrmTemplateBase ret = null;
            switch (view.DbDataProvider)
            {
                case DbDataProvider.Unknown:
                    break;
                case DbDataProvider.SqlClient:
                    break;
                case DbDataProvider.OracleClient:
                    break;
                case DbDataProvider.OleDb:
                    break;
                case DbDataProvider.Odbc:
                    break;
                case DbDataProvider.SqlServerCe:
                    break;
                case DbDataProvider.Odac:
                    break;
                case DbDataProvider.MySqlClient:
                    if (type == 0) ret = new MySqlViewEOT(view); else ret = new MySqlViewMOT(view);
                    break;
                default:
                    break;
            }
            return ret;

        }
        public string GetViewCode(ViewSchema view, string namespaceName)
        {
            StringBuilder ret = new StringBuilder();
            ret.Append(OrmTemplateBase.GetCopyright());
            List<string> names = new List<string>
            {
                "TinyFx.Data.MySqlClient",
                "MySql.Data.MySqlClient"
            };
            ret.AppendLine(OrmTemplateBase.GetUsings(names));
            string eo = GetTemplate(view, 0).TransformText();
            eo = OrmTemplateBase.AddRegion(eo, "EO");
            string mo = GetTemplate(view, 1).TransformText();
            mo = OrmTemplateBase.AddRegion(mo, "MO");
            string content = OrmTemplateBase.AddNamespace(eo + Environment.NewLine + mo, namespaceName);
            ret.Append(content);
            return ret.ToString();
        }
        private OrmTemplateBase GetTemplate(ProcSchema proc)
        {
            OrmTemplateBase ret = null;
            switch (proc.DbDataProvider)
            {
                case DbDataProvider.Unknown:
                    break;
                case DbDataProvider.SqlClient:
                    break;
                case DbDataProvider.OracleClient:
                    break;
                case DbDataProvider.OleDb:
                    break;
                case DbDataProvider.Odbc:
                    break;
                case DbDataProvider.SqlServerCe:
                    break;
                case DbDataProvider.Odac:
                    break;
                case DbDataProvider.MySqlClient:
                    ret = new MySqlProcMOT(proc);
                    break;
                default:
                    break;
            }
            return ret;

        }
        public string GetProcCode(ProcSchema proc, string namespaceName)
        {
            StringBuilder ret = new StringBuilder();
            ret.Append(OrmTemplateBase.GetCopyright());
            List<string> names = new List<string>
            {
                "TinyFx.Data.MySqlClient",
                "MySql.Data.MySqlClient"
            };
            ret.AppendLine(OrmTemplateBase.GetUsings(names));

            string mo = GetTemplate(proc).TransformText();
            string content = OrmTemplateBase.AddNamespace(mo, namespaceName);
            ret.Append(content);
            return ret.ToString();
        }
    }
}
