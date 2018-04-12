using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyFx.Extensions.EPPlus
{
    /// <summary>
    /// EPPlus 行数据
    /// </summary>
    public class ExcelRowEx
    {
        #region Properties
        /// <summary>
        /// Headers
        /// key: title value: columnIndex
        /// </summary>
        public HeaderMapConfigCollection Headers { get; private set; }
        /// <summary>
        /// 当前行的Cells。 key: columnIndex
        /// </summary>
        public Dictionary<int, ExcelRangeBase> Cells { get; } = new Dictionary<int, ExcelRangeBase>();
        /// <summary>
        /// 当前行起始 ColumnIndex
        /// </summary>
        public int StartColumnIndex { get; private set; }
        /// <summary>
        /// 当前行终止 ColumnIndex
        /// </summary>
        public int EndColumnIndex { get; private set; }
        /// <summary>
        /// 当前行索引
        /// </summary>
        public int RowIndex => Cells[StartColumnIndex].Start.Row;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="cells"></param>
        /// <param name="headers"></param>
        public ExcelRowEx(IEnumerable<ExcelRangeBase> cells, HeaderMapConfigCollection headers = null)
        {
            Headers = headers;
            StartColumnIndex = int.MaxValue;
            EndColumnIndex = int.MinValue;
            foreach (var cell in cells)
            {
                var celCol = cell.Start.Column;
                if (StartColumnIndex > celCol)
                    StartColumnIndex = celCol;
                if (EndColumnIndex < celCol)
                    EndColumnIndex = celCol;
                Cells.Add(celCol, cell);
            }
        }
        #endregion

        public ExcelRangeBase this[int columnIndex] => Cells[columnIndex];

        public ExcelRangeBase this[string title] => Cells[Headers.GetIndex(title)];

        #region GetValue
        public T GetValue<T>(int columnIndex)
        {
            var value = GetValue(columnIndex);
            return TinyFxUtil.ConvertTo<T>(value);
        }
        public T GetValue<T>(string title)
        {
            var columnIndex = Headers.GetIndex(title);
            return GetValue<T>(columnIndex);
        }

        /// <summary>
        /// 获取指定Cell值
        /// </summary>
        /// <param name="columnIndex"></param>
        /// <returns></returns>
        public object GetValue(int columnIndex)
        {
            var cell = Cells[columnIndex];
            object ret = null;
            if (Headers != null && Headers.ContainsIndex(columnIndex))
            {
                var config = Headers[columnIndex];
                ret = config.ReadCellValue(cell);
            }
            return ret;
        }
        /// <summary>
        /// 获取指定Cell值
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public object GetValue(string title)
        {
            var columnIndex = Headers.GetIndex(title);
            return GetValue(columnIndex);
        }
        #endregion
    }
}
