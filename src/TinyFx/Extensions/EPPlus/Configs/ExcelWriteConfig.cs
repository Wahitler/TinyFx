using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Text;

namespace TinyFx.Extensions.EPPlus
{
    /// <summary>
    /// Excel写入配置
    /// </summary>
    public class ExcelWriteConfig : ExcelConfig
    {
        public bool WriteHeader { get; set; } = true;
        public void InitConfig(ExcelWorksheet sheet)
        {
            // init
            if (StartRowIndex < 1)
                StartRowIndex = (sheet.Dimension == null) ? 1 : sheet.Dimension.Start.Row;
            if (StartColumnIndex < 1)
                StartColumnIndex = (sheet.Dimension == null) ? 1 : sheet.Dimension.Start.Column;
            if (HeaderRowIndex.HasValue && HeaderRowIndex.Value < 1)
                HeaderRowIndex = 1;

            // SheetHeaders
            if (HeaderRowIndex.HasValue)
            {
                if (HeaderRowIndex.Value == StartRowIndex)
                    StartRowIndex++;
                SheetHeaders.Clear();
                for (var columnIndex = StartColumnIndex; columnIndex < int.MaxValue; columnIndex++)
                {
                    var title = sheet.Cells[HeaderRowIndex.Value, columnIndex].GetValue<string>();
                    if (string.IsNullOrEmpty(title)) break;
                    SheetHeaders.Add(columnIndex, title);
                }
            }
            if (WriteHeader && !HeaderRowIndex.HasValue)
            {
                HeaderRowIndex = StartRowIndex;
                StartRowIndex++;
            }
        }
        public void DoWriteHeader(ExcelWorksheet sheet)
        {
            if (WriteHeader)
            {
                foreach (var header in Headers)
                {
                    sheet.Cells[HeaderRowIndex.Value, header.ColumnIndex].Value = header.Title;
                }
            }
        }
    }
}
