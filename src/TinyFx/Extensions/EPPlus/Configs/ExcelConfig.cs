using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace TinyFx.Extensions.EPPlus
{
    public class ExcelConfig
    {
        /// <summary>
        /// Header 所在行
        /// </summary>
        public int? HeaderRowIndex { get; set; }
        /// <summary>
        /// 首行数据索引, 从1开始（可能包含header）
        /// 不设置取sheet.Dimension.Start.Row
        /// </summary>
        public int StartRowIndex { get; set; }

        public int StartColumnIndex { get; set; }
        /// <summary>
        /// 表示Worksheet中Headers的定义。(ColumnIndex,Title)
        /// 根据HeaderRowIndex读取Sheet获得或用户设置。
        /// </summary>
        public SheetHeaderCollection SheetHeaders { get; } = new SheetHeaderCollection();
        /// <summary>
        /// 用户手工设置的写入时的Header映射配置
        /// </summary>
        public List<HeaderMapConfig> ConfigHeaders { get; } = new List<HeaderMapConfig>();
        /// <summary>
        /// 整理后写入时使用的Headers
        /// </summary>
        public HeaderMapConfigCollection Headers { get; } = new HeaderMapConfigCollection();
        /// <summary>
        /// 文档字符集
        /// </summary>
        public Encoding Encoding { get; set; } = Encoding.UTF8;
        /// <summary>
        /// 设置起始Cell，如：A1
        /// 如果包含header，则HasHeader属性必须是true
        /// </summary>
        /// <param name="cellString"></param>
        public void SetStartCell(string cellString)
        {
            var cell = EPPlusUtil.ParseCellString(cellString);
            StartRowIndex = cell.RowIndex;
            StartColumnIndex = cell.ColIndex;
        }
        /// <summary>
        /// 根据SheetHeaders和ConfigHeaders配置Headers
        /// </summary>
        public void PrepareHeaders()
        {
            Headers.Clear();
            // 用户没有配置，使用SheetHeaders
            if (ConfigHeaders.Count == 0)
            {
                if (SheetHeaders.Count == 0)
                    throw new Exception("没有设置header映射。");
                foreach (var header in SheetHeaders)
                {
                    Headers.Add(new HeaderMapConfig()
                    {
                        ColumnIndex = header.Index,
                        Title = header.Title,
                    });
                }
            }
            else // 用户设置，根据SheetHeaders设置其ColumnIndex或Title
            {
                foreach (var config in ConfigHeaders)
                {
                    if (!string.IsNullOrEmpty(config.Title))
                    {
                        if (SheetHeaders.Contains(config.Title))
                            config.ColumnIndex = SheetHeaders[config.Title];
                    }
                    else
                    {
                        if (SheetHeaders.Contains(config.ColumnIndex))
                            config.Title = SheetHeaders[config.ColumnIndex];
                    }
                    Headers.Add(config);
                }
            }
        }

        protected PropertyInfo GetPropertyInfo<TEntity, TProperty>(Expression<Func<TEntity, TProperty>> expr)
        {
            if (expr.NodeType != ExpressionType.Lambda)
                throw new ArgumentException($"{nameof(expr)} 必须是lambda表达式。", nameof(expr));
            var lambda = (LambdaExpression)expr;
            var memberExpr = ExtractMemberExpression(lambda.Body);
            if (memberExpr == null)
                throw new ArgumentException($"{nameof(expr)} 必须是lambda表达式。", nameof(expr));
            if (memberExpr.Member.DeclaringType == null)
                throw new InvalidOperationException("属性没有声明类型。");
            return memberExpr.Member.DeclaringType.GetProperty(memberExpr.Member.Name);
        }
        private static MemberExpression ExtractMemberExpression(Expression expr)
        {
            if (expr.NodeType == ExpressionType.MemberAccess)
                return ((MemberExpression)expr);

            if (expr.NodeType == ExpressionType.Convert)
            {
                var operand = ((UnaryExpression)expr).Operand;
                return ExtractMemberExpression(operand);
            }
            return null;
        }
    }
}
