using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TinyFx.Extensions.EPPlus
{
    /// <summary>
    /// Excel 读取配置
    /// </summary>
    public class ExcelReadConfig : ExcelConfig
    {
        #region Properties
        /// <summary>
        /// 是否有 Header
        /// </summary>
        public bool HasHeader { get; set; } = true;

        /// <summary>
        /// 末列索引，从1开始。如未设置则自动判断
        /// </summary>
        public int? EndColumnIndex { get; set; }
        /// <summary>
        /// 末行数据索引,从1开始。如未设置则根据自动判断
        /// </summary>
        public int? EndRowIndex { get; set; }
        /// <summary>
        /// 起始行检测器
        /// </summary>
        public Func<ExcelRowEx, int?> StartRowChecker { get; set; }
        /// <summary>
        /// 结束行检测器
        /// </summary>
        public Func<ExcelRowEx, int?> EndRowChecker { get; set; }
        #endregion

        #region Method
        /// <summary>
        /// 设置结束Cell
        /// </summary>
        /// <param name="cellString"></param>
        public void SetEndCell(string cellString)
        {
            var cell = EPPlusUtil.ParseCellString(cellString);
            EndRowIndex = cell.RowIndex;
            EndColumnIndex = cell.ColIndex;
        }
        /// <summary>
        /// 设置最后一列。如：E
        /// </summary>
        /// <param name="columnString"></param>
        public void SetLastColumn(string columnString)
        {
            EndColumnIndex = EPPlusUtil.ParseColumnString(columnString);
        }

        public void AddStartRowChecker(int columnIndex, string content, RowCheckerMode mode = RowCheckerMode.Equals)
            => StartRowChecker = GetRowChecker(columnIndex, content, mode);
        public void AddEndRowChecker(int columnIndex, string content, RowCheckerMode mode = RowCheckerMode.Equals)
            => EndRowChecker = GetRowChecker(columnIndex, content, mode);
        private static Func<ExcelRowEx, int?> GetRowChecker(int columnIndex, string content, RowCheckerMode mode = RowCheckerMode.Equals)
        {
            return (row) => {
                var value = Convert.ToString(row.GetValue(columnIndex));
                bool hasIndex = false;
                switch (mode)
                {
                    case RowCheckerMode.Equals:
                        hasIndex = value == content;
                        break;
                    case RowCheckerMode.Contains:
                        hasIndex = value.Contains(content);
                        break;
                    case RowCheckerMode.StartsWith:
                        hasIndex = value.StartsWith(content);
                        break;
                }
                return hasIndex ? row.RowIndex : (int?)null;
            };
        }
        #endregion

        public void InitConfig(ExcelWorksheet sheet)
        {
            if (StartRowIndex < 1)
                StartRowIndex = sheet.Dimension.Start.Row;
            if (StartColumnIndex < 1)
                StartColumnIndex = sheet.Dimension.Start.Column;
            if (HeaderRowIndex.HasValue && HeaderRowIndex.Value < 1)
                HeaderRowIndex = 1;

            int endCol = EndColumnIndex.HasValue ? EndColumnIndex.Value : sheet.Dimension.End.Column;
            if (HasHeader)
            {
                if (!HeaderRowIndex.HasValue)
                {
                    HeaderRowIndex = StartRowIndex;
                    StartRowIndex++;
                }
                else
                {
                    if (HeaderRowIndex.Value == StartRowIndex)
                        StartRowIndex++;
                }
                SheetHeaders.Clear();
                for (int colIndex = StartColumnIndex; colIndex <= endCol; colIndex++)
                {
                    var value = sheet.Cells[HeaderRowIndex.Value, colIndex].GetValue<string>();
                    if (string.IsNullOrEmpty(value)) break;
                    SheetHeaders.Add(colIndex, value);
                }
            }
            if (!EndColumnIndex.HasValue)
            {
                EndColumnIndex = (SheetHeaders.Count > 0)
                    ? StartColumnIndex + SheetHeaders.Count
                    : sheet.Dimension.End.Column;
            }
            if (!EndRowIndex.HasValue)
                EndRowIndex = sheet.Dimension.End.Row;
        }

        /// <summary>
        /// 根据当前配置获取Rows
        /// </summary>
        /// <param name="sheet"></param>
        /// <returns></returns>
        public IEnumerable<ExcelRowEx> GetRowEnumerator(ExcelWorksheet sheet)
        {
            var checkedStart = false;
            var checkedEnd = false;
            for (int rowIndex = StartRowIndex; rowIndex <= EndRowIndex.Value; rowIndex++)
            {
                var rowRange = sheet.Cells[rowIndex, StartColumnIndex, rowIndex, EndColumnIndex.Value];
                var row = new ExcelRowEx(rowRange.AsEnumerable(), Headers);
                #region CheckRow
                // 如果存在起始行检测函数，则设置起始行索引值并跳过再次检测
                if (!checkedStart && StartRowChecker != null)
                {
                    try
                    {
                        var idx = StartRowChecker(row);
                        if (idx.HasValue)
                        {
                            rowIndex = idx.Value;
                            checkedStart = true;
                            continue;
                        }
                    }
                    catch { }
                }
                // 检测结束行
                if (!checkedEnd && EndRowChecker != null)
                {
                    try
                    {
                        var idx = EndRowChecker(row);
                        if (idx.HasValue)
                        {
                            EndRowIndex = idx.Value;
                            checkedEnd = true;
                            if (rowIndex <= EndRowIndex.Value)
                                break;
                        }
                    }
                    catch { }
                }
                #endregion
                yield return row;
            }
        }
    }
}
