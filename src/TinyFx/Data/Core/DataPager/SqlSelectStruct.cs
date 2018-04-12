using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TinyFx.Data
{
    /// <summary>
    /// SQL语句解析后的结构
    /// </summary>
    public class SqlSelectStruct
    {
        public string Select { get; set; }
        public string From { get; set; }
        public string Where { get; set; }
        public string GroupBy { get; set; }
        public string Having { get; set; }
        public string OrderBy { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT ");
            if (!string.IsNullOrEmpty(Select))
                sb.Append(Select);
            else
                sb.Append("*");
            if (!string.IsNullOrEmpty(From))
            {
                sb.Append(" FROM ");
                sb.Append(From);
            }
            if (!string.IsNullOrEmpty(Where))
            {
                sb.Append(" WHERE ");
                sb.Append(Where);
            }
            if (!string.IsNullOrEmpty(GroupBy))
            {
                sb.Append(" GROUP BY ");
                sb.Append(GroupBy);
            }
            if (!string.IsNullOrEmpty(Having))
            {
                sb.Append(" HAVING ");
                sb.Append(Having);
            }
            if (!string.IsNullOrEmpty(OrderBy))
            {
                sb.Append(" ORDER BY ");
                sb.Append(OrderBy);
            }
            return sb.ToString();
        }
    }
}
