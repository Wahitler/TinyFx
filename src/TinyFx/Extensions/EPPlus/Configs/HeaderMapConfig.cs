using System;
using System.Collections.Generic;
using System.Text;
using OfficeOpenXml;

namespace TinyFx.Extensions.EPPlus
{
    public class HeaderMapConfig
    {
        public int ColumnIndex { get; set; }
        public string Title { get; set; }
        public string Formatter { get; set; }
        public Func<ExcelRangeBase, object> ReadCellValueDelegate { get; set; }
        public Action<ExcelRangeBase, object> WriteCellValueDelegate { get; set; }
        public bool AllowMerge { get; set; }
        public bool IsIgnored { get; set; }

        public object ReadCellValue(ExcelRangeBase cell)
            => ReadCellValueDelegate != null ? ReadCellValueDelegate(cell) : cell.Value;
        public void WriteCellValue(ExcelRangeBase cell, object value)
        {
            if (WriteCellValueDelegate == null)
                cell.Value = value;
            else
                WriteCellValueDelegate(cell, value);
        }

        #region 设置属性
        public HeaderMapConfig SetColumnIndex(int columnIndex)
        {
            ColumnIndex = columnIndex;
            return this;
        }
        public HeaderMapConfig SetTitle(string title)
        {
            Title = title;
            return this;
        }
        public HeaderMapConfig SetFormatter(string formatter)
        {
            Formatter = formatter;
            return this;
        }
        public HeaderMapConfig SetReadCellValueDelegate(Func<ExcelRangeBase, object> func)
        {
            ReadCellValueDelegate = func;
            return this;
        }
        public HeaderMapConfig SetWriteCellValueDelegate(Action<ExcelRangeBase, object> action)
        {
            WriteCellValueDelegate = action;
            return this;
        }
        public HeaderMapConfig SetAllowMerge(bool allowMerge)
        {
            AllowMerge = allowMerge;
            return this;
        }
        #endregion
    }
}
