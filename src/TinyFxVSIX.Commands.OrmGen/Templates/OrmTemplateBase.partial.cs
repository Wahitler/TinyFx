using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TinyFx;
using TinyFx.Data.Schema;
using TinyFx.Reflection;

namespace TinyFxVSIX.Commands.OrmGen.Templates
{
    public partial class OrmTemplateBase
    {
        #region 注释处理
        // 类注释
        public string ClassComment(TableViewSchemaBase table, int tabNum = 0)
        {
            return ParseComment(table.Comment, tabNum);
        }
        public string ClassComment(ProcSchema proc, int tabNum = 0)
        {
            return ParseComment(proc.Comment, tabNum);
        }
        // 属性注释
        public string PropertyComment(ColumnSchema column, int tabNum = 1)
        {
            return ParseComment(column.Comment, tabNum);
        }
        // 参数注释
        public string ParamComment(ColumnSchema column, bool onlyFirstLine = true)
        {
            return string.Format("/// <param name = \"{0}\">{1}</param>", column.OrmParamName, ParseComment(column.Comment, 1, onlyFirstLine));
        }
        public string ParamComment(DbParameterSchema param)
        {
            return string.Format("/// <param name = \"{0}\">输入参数 {0} {1}</param>", param.OrmParamName, param.EngineTypeStringFull);
        }
        // 解析描述
        public string ParseComment(string comment, int tabNum = 0, bool onlyFirstLine = false)
        {
            if (string.IsNullOrEmpty(comment)) return string.Empty;
            string ret = string.Empty;
            string[] lines = StringUtil.SplitNewLine(comment);
            for (int i = 0; i < lines.Length; i++)
            {
                if (i > 0) ret += Environment.NewLine + StringUtil.Tab(tabNum) + "/// ";
                ret += lines[i];
                if (onlyFirstLine) break;
            }
            return ret;
        }
        #endregion

        #region 字段集合转换成 Link 形式的代码
        /// <summary>
        /// 获取SQL语句中字段集合：UserID, UserName ....
        /// </summary>
        /// <param name="columns"></param>
        /// <returns></returns>
        public string GetOrmSqlFieldsLink(IEnumerable<ColumnSchema> columns)
        {
            var names = columns.Select(item => { return item.SqlColumnName; });
            return string.Join(", ", names);
        }
        public string GetOrmSqlFieldsLink(TableSchema table, ColumnSelectMode mode = ColumnSelectMode.All)
        {
            return GetOrmSqlFieldsLink(table.ColumnsFilter(mode));
        }
        /// <summary>
        /// 获取SQL语句中字段参数集合: @UserID, @UserName
        /// </summary>
        /// <param name="columns"></param>
        /// <returns></returns>
        public string GetOrmSqlParamsLink(IEnumerable<ColumnSchema> columns)
        {
            var names = columns.Select(item => { return item.SqlParamName; });
            return string.Join(", ", names);
        }
        public string GetOrmSqlParamsLink(TableSchema table, ColumnSelectMode mode = ColumnSelectMode.All)
        {
            return GetOrmSqlParamsLink(table.ColumnsFilter(mode));
        }
        /// <summary>
        /// 获取 Where 条件列表：'userID' = @UserID AND 'userName' = @UserName
        /// </summary>
        /// <param name="columns"></param>
        /// <param name="hasOriginal"></param>
        /// <returns></returns>
        public string GetOrmSqlWhereLink(IEnumerable<ColumnSchema> columns, bool hasOriginal = false)
        {
            var names = columns.Select(item => {
                return hasOriginal ? string.Format("{0} = {1}_Original", item.SqlColumnName, item.SqlParamName)
                    : string.Format("{0} = {1}", item.SqlColumnName, item.SqlParamName);
            });
            return string.Join(" AND ", names);
        }
        public string GetOrmSqlWhereLink(TableSchema table, ColumnSelectMode mode = ColumnSelectMode.All)
        {
            return GetOrmSqlWhereLink(table.ColumnsFilter(mode));
        }
        public string GetOrmSqlWhereLink(ColumnSchema column)
        {
            return string.Format("{0} = {1}", column.SqlColumnName, column.SqlParamName);
        }
        // 条件Sql Where, 处理IS NULL 条件
        public string GetOrmSqlWhereContent(ColumnSchema column, bool hasWhere = false)
        {
            string ret = null;
            if (!column.AllowDBNull)
            {
                ret = string.Format("{0}{1}\"", hasWhere ? "\"" : "", GetOrmSqlWhereLink(column));
            }
            else
            {
                if (hasWhere)
                {
                    if (column.DotNetTypeString == "string" || column.DotNetTypeString == "byte[]")
                        ret = string.Format("{0} != null ? \"{1}\" : \"{2} IS NULL\"", column.OrmParamName, GetOrmSqlWhereLink(column), column.SqlColumnName);
                    else
                        ret = string.Format("{0}.HasValue ? \"{1}\" : \"{2} IS NULL\"", column.OrmParamName, GetOrmSqlWhereLink(column), column.SqlColumnName);
                }
                else
                {
                    if (column.DotNetTypeString == "string" || column.DotNetTypeString == "byte[]")
                        ret = string.Format("\" + ({0} != null ? \"{1}\" : \"{2} IS NULL\")", column.OrmParamName, GetOrmSqlWhereLink(column), column.SqlColumnName);
                    else
                        ret = string.Format("\" + ({0}.HasValue ? \"{1}\" : \"{2} IS NULL\")", column.OrmParamName, GetOrmSqlWhereLink(column), column.SqlColumnName);
                }
            }
            return ret;
        }
        public string GetOrmSqlWhereIF(ColumnSchema column)
        {
            string ret = string.Empty;
            if (column.AllowDBNull)
            {
                if (column.DotNetTypeString == "string" || column.DotNetTypeString == "byte[]")
                    ret = string.Format("if ({0} != null)", column.OrmParamName);
                else
                    ret = string.Format("if ({0}.HasValue)", column.OrmParamName);
                ret += Environment.NewLine + StringUtil.Tab(3);
            }
            return ret;
        }
        /// <summary>
        /// SQL语句Update Set语句：UserID = @UserID, UserName = @UserName
        /// </summary>
        /// <param name="columns"></param>
        /// <returns></returns>
        public string GetOrmSqlSetLink(IEnumerable<ColumnSchema> columns)
        {
            var names = columns.Select(item => {
                return string.Format("{0} = {1}", item.SqlColumnName, item.SqlParamName);
            });
            return string.Join(", ", names);
        }
        public string GetOrmSqlSetLink(TableSchema table, ColumnSelectMode mode = ColumnSelectMode.All)
        {
            return GetOrmSqlSetLink(table.ColumnsFilter(mode));
        }
        public string GetOrmSqlSetLink(ColumnSchema column)
        {
            return string.Format("{0} = {1}", column.SqlColumnName, column.SqlParamName);
        }
        /// <summary>
        /// 获取Item对象属性列表：item.UserID, item.UserName
        /// </summary>
        /// <param name="columns"></param>
        /// <returns></returns>
        public string GetOrmItemValueLink(IEnumerable<ColumnSchema> columns)
        {
            var names = columns.Select(item => {
                return string.Format("item.{0}", item.OrmPropertyName);
            });
            return string.Join(", ", names);
        }
        public string GetOrmItemValueLink(TableSchema table, ColumnSelectMode mode = ColumnSelectMode.All)
        {
            return GetOrmItemValueLink(table.ColumnsFilter(mode));
        }
        /// <summary>
        /// 获取方法参数列表：int userID, string userName
        /// </summary>
        /// <param name="columns"></param>
        /// <returns></returns>
        public string GetOrmMethodParamsLink(IEnumerable<ColumnSchema> columns)
        {
            var names = columns.Select(item => {
                return string.Format("{0} {1}", item.DotNetTypeString, item.OrmParamName);
            });
            return string.Join(", ", names);
        }
        public string GetOrmMethodParamsLink(TableSchema table, ColumnSelectMode mode = ColumnSelectMode.All)
        {
            return GetOrmMethodParamsLink(table.ColumnsFilter(mode));
        }
        public string GetOrmMethodParamsLink(ColumnSchema column)
        {
            return string.Format("{0} {1}", column.DotNetTypeString, column.OrmParamName);
        }
        public string GetOrmMethodParamsLink(IEnumerable<DbParameterSchema> paras)
        {
            var names = paras.Select(item => {
                return string.Format("{0} {1}", item.DotNetTypeString, item.OrmParamName);
            });
            string ret = string.Join(", ", names);
            if (!string.IsNullOrEmpty(ret)) ret += ", ";
            return ret;
        }
        // userID, userName....
        public string GetOrmMethodParamsValueLink(IEnumerable<DbParameterSchema> paras, bool andDot)
        {
            var names = paras.Select(item => {
                return string.Format("{0}", item.OrmParamName);
            });
            string ret = string.Join(", ", names);
            if (!string.IsNullOrEmpty(ret) && andDot) ret += ", ";
            return ret;
        }
        public string GetOrmMethodParamsValueLink(IEnumerable<ColumnSchema> columns)
        {
            var names = columns.Select(item => { return item.OrmParamName; });
            return string.Join(", ", names);
        }
        /// <summary>
        /// 获取对象属性名And连接: UserIDAndUserName
        /// </summary>
        /// <param name="columns"></param>
        /// <returns></returns>
        public string GetOrmPropertyAndLink(IEnumerable<ColumnSchema> columns)
        {
            var names = columns.Select(item => {
                return string.Format("{0}", item.OrmPropertyName);
            });
            return string.Join("And", names);
        }
        /// <summary>
        /// MO Set方法中的判断：item.UserID == default(int) || item.UserName == default(string)
        /// </summary>
        /// <param name="columns"></param>
        /// <returns></returns>

        public string GetMOSetCheckList(IEnumerable<ColumnSchema> columns)
        {
            string ret = string.Empty;
            var names = columns.Select(column => {
                return string.Format("item.{0} == default({1})", column.OrmPropertyName, column.DotNetTypeString.TrimEnd('?'));
            });
            return string.Join(" || ", names);
        }
        #endregion

        #region 文件结构
        public static string GetCopyright()
        {
            StringBuilder sb = new StringBuilder();
            var assem = Assembly.GetExecutingAssembly();
            string publishDate = "2016-06-20";
            var objs = assem.GetCustomAttributes(typeof(AssemblyPublishDateAttribute), false);
            if (objs != null && objs.Length > 0) publishDate = ((AssemblyPublishDateAttribute)objs[0]).PublishDate;
            sb.AppendLine("/******************************************************");
            sb.AppendLine(" * 此代码由代码生成器工具自动生成，请不要修改");
            sb.AppendFormat(" * TinyFx代码生成器核心库版本号：{0}.{1} by JiangHui {2}"
                , assem.GetName().Version.Major.ToString()
                , assem.GetName().Version.Minor.ToString()
                , publishDate);
            sb.AppendLine();
            sb.AppendFormat(" * 文档生成时间：{0}", DateTime.Now.ToString("yyyy-MM-dd HH: mm:ss"));
            sb.AppendLine();
            sb.AppendLine(" ******************************************************/");
            return sb.ToString();
        }
        public static string GetUsings(List<string> namespaces = null)
        {
            HashSet<string> items = new HashSet<string>();
            items.Add("System");
            items.Add("System.Data");
            items.Add("System.Data.Common");
            items.Add("System.Collections.Generic");
            items.Add("System.Runtime.Serialization");
            items.Add("System.Linq");
            items.Add("System.Xml");
            items.Add("System.Xml.Serialization");
            items.Add("TinyFx");
            items.Add("TinyFx.Data");
            StringBuilder sb = new StringBuilder();
            if (namespaces != null)
            {
                foreach (var name in namespaces)
                {
                    if (!items.Contains(name))
                        items.Add(name);
                }
            }
            foreach (var name in items)
                sb.AppendFormat("using {0};" + Environment.NewLine, name);
            return sb.ToString();
        }
        public static string AddNamespace(string content, string namespaceName)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("namespace {0}", namespaceName + Environment.NewLine);
            sb.AppendLine("{");
            using (var reader = new StringReader(content))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    sb.AppendLine(StringUtil.Tab(1) + line);
                    line = reader.ReadLine();
                }
            }
            sb.AppendLine("}");
            return sb.ToString();
        }

        public static string AddRegion(string content, string regionName)
        {
            return string.Format("#region {0}{1}#endregion // {0}", regionName + Environment.NewLine, content + Environment.NewLine);
        }
        #endregion
    }
}
