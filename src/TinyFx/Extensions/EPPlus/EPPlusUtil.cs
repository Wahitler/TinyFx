using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using OfficeOpenXml;
using System.Reflection;
using System.Data;
using System.Linq.Expressions;

namespace TinyFx.Extensions.EPPlus
{
    /// <summary>
    /// EPPLus辅助类，XLSX,CSV,List,DataTable
    /// </summary>
    public static class EPPlusUtil
    {
        #region ReadToTable (XLSX => DataTable)
        public static DataTable ReadToTable(string file, ExcelReadConfig config=null, int sheetIndex = 1)
        {
            using (var stream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                return ReadToTable(stream, config, sheetIndex);
            }
        }
        public static DataTable ReadToTable(Stream stream, ExcelReadConfig config=null, int sheetIndex = 1)
        {
            using (var pkg = new ExcelPackage(stream))
            {
                var sheet = pkg.Workbook.Worksheets[sheetIndex];
                return ReadToTable(sheet, config);
            }
        }
        public static DataTable ReadToTable(ExcelWorksheet sheet, ExcelReadConfig config = null)
        {
            config = config ?? new ExcelReadConfig() { HasHeader = false, };
            config.InitConfig(sheet);
            // 不使用Excel的header，则自动使用ABCD作为列名
            if (!config.HasHeader && config.SheetHeaders.Count == 0 && config.ConfigHeaders.Count == 0)
            {
                int startCol = config.StartColumnIndex > 0 ? config.StartColumnIndex : sheet.Dimension.Start.Column;
                int endCol = config.EndColumnIndex.HasValue ? config.EndColumnIndex.Value : sheet.Dimension.End.Column;
                for (int colIndex = config.StartColumnIndex; colIndex <= config.EndColumnIndex.Value; colIndex++)
                {
                    //var value = sheet.Cells[config.StartRowIndex, colIndex].GetValue<string>();
                    //if (string.IsNullOrEmpty(value)) break;
                    config.ConfigHeaders.Add(new HeaderMapConfig() {
                        ColumnIndex = colIndex,
                        Title = ParseColumnIndex(colIndex)
                    });
                }
            }
            config.PrepareHeaders();
            var ret = new DataTable();
            foreach (var header in config.Headers)
            {
                ret.Columns.Add(header.Title);
            }
            foreach (var row in config.GetRowEnumerator(sheet))
            {
                var newRow = ret.NewRow();
                foreach (var header in config.Headers)
                {
                    newRow[header.Title] = row.GetValue(header.ColumnIndex);
                }
                ret.Rows.Add(newRow);
            }
            return ret;
        }

        #endregion

        #region ReadCsvToTable (CSV => DataTable)
        public static DataTable ReadCsvToTable(string file, ExcelTextFormat format, ExcelReadConfig config=null)
        {
            using (var stream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                return ReadCsvToTable(stream, format, config);
            }
        }
        public static DataTable ReadCsvToTable(Stream stream, ExcelTextFormat format, ExcelReadConfig config=null)
        {
            var encoding = config == null ? Encoding.UTF8 : config.Encoding;
            using (StreamReader reader = new StreamReader(stream, encoding))
            {
                var text = reader.ReadToEnd();
                return ReadCsvToTable(text, config, format);
            }
        }
        public static DataTable ReadCsvToTable(string text, ExcelReadConfig config, ExcelTextFormat format)
        {
            using (ExcelPackage pkg = new ExcelPackage())
            {
                var sheet = pkg.Workbook.Worksheets.Add("csv1");
                sheet.Cells["A1"].LoadFromText(text, format);
                return ReadToTable(sheet, config);
            }
        }
        #endregion

        #region ReadToList (XLSX => List<Entity>)
        public static List<T> ReadToList<T>(string file, EntityReadConfig<T> config, int sheetIndex = 1)
            where T : class, new()
        {
            using (var stream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                return ReadToList(stream, config, sheetIndex);
            }
        }
        public static List<T> ReadToList<T>(Stream stream, EntityReadConfig<T> config, int sheetIndex = 1)
            where T : class, new()
        {
            using (var pkg = new ExcelPackage(stream))
            {
                return ReadToList(pkg.Workbook.Worksheets[sheetIndex], config);
            }
        }
        public static List<T> ReadToList<T>(ExcelWorksheet sheet, EntityReadConfig<T> config)
            where T : class, new()
        {
            var ret = new List<T>();
            config.InitConfig(sheet);
            config.PrepareHeaders();
            foreach (var row in config.GetRowEnumerator(sheet))
            {
                var item = config.MapEntity(row);
                ret.Add(item);
            }
            return ret;
        }
        #endregion

        #region ReadCsvToList (CSV => List<TEntity>)
        public static List<T> ReadCsvToList<T>(string file, ExcelTextFormat format, EntityReadConfig<T> config)
            where T : class, new()
        {
            using (var stream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                return ReadCsvToList(stream, format, config);
            }
        }
        public static List<T> ReadCsvToList<T>(Stream stream, ExcelTextFormat format, EntityReadConfig<T> config)
            where T : class, new()
        {
            using (StreamReader reader = new StreamReader(stream, config.Encoding))
            {
                var text = reader.ReadToEnd();
                return ReadCsvToList(text, config, format);
            }
        }
        public static List<T> ReadCsvToList<T>(string text, EntityReadConfig<T> config, ExcelTextFormat format)
            where T : class, new()
        {
            using (ExcelPackage pkg = new ExcelPackage())
            {
                var sheet = pkg.Workbook.Worksheets.Add("csv1");
                sheet.Cells["A1"].LoadFromText(text, format);
                return ReadToList(sheet, config);
            }
        }
        #endregion

        #region Write (DataTable => XLSX)
        public static void Write(ExcelWorksheet sheet, DataTable table, ExcelWriteConfig config)
        {
            config.InitConfig(sheet);
            // 如果没有配置，自动使用 TableColumns
            if (config.ConfigHeaders.Count == 0)
            {
                foreach (DataColumn column in table.Columns)
                {
                    var columnIndex = config.StartColumnIndex + column.Ordinal;
                    config.ConfigHeaders.Add(new HeaderMapConfig() { ColumnIndex = columnIndex, Title = column.ColumnName });
                }
            }
            config.PrepareHeaders();
            config.DoWriteHeader(sheet);
            var rowIndex = config.StartRowIndex;
            foreach (DataRow row in table.Rows)
            {
                foreach (var header in config.Headers)
                {
                    var columnIndex = header.ColumnIndex - config.StartColumnIndex;
                    var cell = sheet.Cells[rowIndex, header.ColumnIndex];
                    header.WriteCellValue(cell, row[columnIndex]);
                }
                rowIndex++;
            }
        }
        #endregion

        #region Write (List<Entity> => XLSX)
        public static void Write<T>(string file, List<T> items, EntityWriteConfig<T> config, int sheetIndex = 1, bool isOverwrite = false)
            where T : class, new()
        {
            if (File.Exists(file) && !isOverwrite)
                throw new Exception($"文件已存在不允许修改。file:{file}");
            using (var pkg = new ExcelPackage(new FileInfo(file)))
            {
                var sheet = pkg.Workbook.Worksheets[sheetIndex];
                Write(sheet, items, config);
                File.WriteAllBytes(file, pkg.GetAsByteArray());
            }
        }
        public static void Write<T>(ExcelWorksheet sheet, List<T> items, EntityWriteConfig<T> config)
            where T : class, new()
        {
            config.InitConfig(sheet);
            config.PrepareHeaders();
            config.DoWriteHeader(sheet);
            foreach (var item in items)
            {
                int rowIndex = config.StartRowIndex;
                foreach (var property in config.PropertyConfigs.Keys)
                {
                    var cfg = config.PropertyConfigs[property];
                    var value = property.GetValue(item);
                    var cell = sheet.Cells[rowIndex, cfg.ColumnIndex];
                    cfg.WriteCellValue(cell, value);
                }
                rowIndex++;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// 是否安装Excel
        /// </summary>
        public static bool HasExcel { get { return Type.GetTypeFromProgID("Excel.Application") != null; } }
        /// <summary>
        /// 使用微软Excel打开
        /// </summary>
        /// <param name="file"></param>
        public static void OpenExcel(string file)
        {
            System.Diagnostics.Process.Start(file);
        }

        public static bool ContainsWorksheet(this ExcelPackage pkg, string name)
            => pkg.Workbook.Worksheets[name] != null;
        public static List<ExcelWorksheet> GetWorksheets(this ExcelPackage pkg)
        {
            var ret = new List<ExcelWorksheet>();
            var emt = pkg.Workbook.Worksheets.GetEnumerator();
            while (emt.MoveNext())
            {
                ret.Add(emt.Current);
            }
            return ret;
        }
        public static List<string> GetWorksheetNames(this ExcelPackage pkg)
        {
            var ret = new List<string>();
            var emt = pkg.Workbook.Worksheets.GetEnumerator();
            while (emt.MoveNext())
            {
                ret.Add(emt.Current.Name);
            }
            return ret;
        }

        public static (int RowIndex, int ColIndex) ParseCellString(string cellString)
        {
            int row = 0;
            string colStr = null;
            for (int i = 0; i < cellString.Length; i++)
            {
                if (Char.IsDigit(cellString[i]))
                {
                    colStr = cellString.Substring(0, i);
                    row = int.Parse(cellString.Substring(i));
                    break;
                }
            }
            if (row == 0 || string.IsNullOrEmpty(colStr))
                throw new Exception($"Excel cell格式错误。cell: {cellString}");
            int col = ParseColumnString(colStr);
            return (row, col);
        }
        public static int ParseColumnString(string columnStr)
        {
            int ret = 0;
            for (int i = 0; i < columnStr.Length - 1; i++)
            {
                var num = columnStr[i] - 64;
                var prefix = (int)Math.Pow(26, columnStr.Length - i - 1);
                ret += num * prefix;
            }
            ret += columnStr[columnStr.Length - 1] - 65;
            return ret + 1;// EPPlus Column索引从1开始
        }
        public static string ParseColumnIndex(int columnIndex)
        {
            StringBuilder ret = new StringBuilder();
            while (columnIndex > 26)
            {
                columnIndex = Math.DivRem(columnIndex, 26, out int result);
                ret.Insert(0, (char)(result + 64));
            }
            ret.Insert(0, (char)(columnIndex + 64));
            return ret.ToString();
        }
        #endregion

    }
}
