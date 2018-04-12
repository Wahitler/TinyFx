using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using System.Data.Common;

namespace TinyFx.Extensions.CsvHelper
{
    /// <summary>
    /// CSV文件辅助类
    /// </summary>
    public static class CsvUtil
    {
        #region CSV ==> IEnumerable<string[],CsvReader,T>

        #region GetArrayRecords
        /// <summary>
        /// 解析TextReader获取记录string[]集合
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static IEnumerable<string[]> GetArrayRecordsByReader(TextReader reader, CsvConfiguration config = null)
        {
            using (var parser = (config == null) ? new CsvParser(reader) : new CsvParser(reader, config))
            {
                string[] row = null;
                while ((row = parser.Read()) != null)
                {
                    yield return row;
                }
            }
        }
        /// <summary>
        /// 解析csv string获取记录string[]集合
        /// </summary>
        /// <param name="content"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static IEnumerable<string[]> GetArrayRecordsByString(string content, CsvConfiguration config = null)
        {
            return GetArrayRecordsByReader(new StringReader(content), config);
        }
        /// <summary>
        /// 解析csv文件获取记录string[]集合
        /// </summary>
        /// <param name="csvFile"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static IEnumerable<string[]> GetArrayRecordsByFile(string csvFile, CsvConfiguration config = null)
        {
            Encoding encoding = config != null ? config.Encoding : Encoding.UTF8;
            using (var reader = new StreamReader(csvFile, encoding))
            {
                return GetArrayRecordsByReader(reader, config);
            }
        }
        #endregion

        #region GetReaderRecords
        /// <summary>
        /// 解析TextReader获取记录CsvReader集合
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static IEnumerable<CsvReader> GetReaderRecordsByReader(TextReader reader, CsvConfiguration config = null)
        {
            using (var csv = (config == null) ? new CsvReader(reader) : new CsvReader(reader, config))
            {
                while (csv.Read())
                {
                    yield return csv;
                }
            }
        }
        /// <summary>
        /// 解析csv文件获取记录CsvReader集合
        /// </summary>
        /// <param name="csvFile"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static IEnumerable<CsvReader> GetReaderRecordsByFile(string csvFile, CsvConfiguration config = null)
        {
            Encoding encoding = config != null ? config.Encoding : Encoding.UTF8;
            using (var reader = new StreamReader(csvFile, encoding))
            {
                return GetReaderRecordsByReader(reader, config);
            }
        }
        /// <summary>
        /// 解析csv string获取记录CsvReader集合
        /// </summary>
        /// <param name="content"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static IEnumerable<CsvReader> GetReaderRecordsByString(string content, CsvConfiguration config = null)
        {
            return GetReaderRecordsByReader(new StringReader(content), config);
        }
        #endregion

        #region GetItemRecords
        /// <summary>
        /// 解析TextReader获取记录T集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reader"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static IEnumerable<T> GetItemRecordsByReader<T>(TextReader reader, CsvConfiguration config = null)
        {
            return new CsvReader(reader, config).GetRecords<T>();
        }
        /// <summary>
        /// 解析csv文件获取记录T集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="csvFile"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static IEnumerable<T> GetItemRecordsByFile<T>(string csvFile, CsvConfiguration config = null)
        {
            using (var reader = new StreamReader(csvFile, config == null ? config.Encoding : Encoding.UTF8))
            {
                return GetItemRecordsByReader<T>(reader, config);
            }
        }
        /// <summary>
        /// 解析csv string获取记录T集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="content"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static IEnumerable<T> GetItemRecordsByString<T>(string content, CsvConfiguration config = null)
        {
            return GetItemRecordsByReader<T>(new StringReader(content), config);
        }
        #endregion

        #endregion

        #region IEnumerable<T> ==> CSV
        /// <summary>
        /// 解析items写入TextWriter
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="writer"></param>
        /// <param name="config"></param>
        public static void WriteItemsToWriter<T>(IEnumerable<T> items, TextWriter writer, CsvConfiguration config = null)
        {
            using (var csv = (config == null) ? new CsvWriter(writer) : new CsvWriter(writer, config))
            {
                csv.WriteRecords(items);
            }
        }
        /// <summary>
        /// 解析items写入文件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="csvFile"></param>
        /// <param name="config"></param>
        public static void WriteItemsToFile<T>(IEnumerable<T> items, string csvFile, CsvConfiguration config = null)
        {
            Encoding encoding = config == null ? Encoding.UTF8 : config.Encoding;
            WriteItemsToWriter(items, new StreamWriter(csvFile, false, encoding), config);
        }
        /// <summary>
        /// 解析items获取csv string
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static string GetItemsToStrig<T>(IEnumerable<T> items, CsvConfiguration config = null)
        {
            StringBuilder sb = new StringBuilder();
            using (StringWriter writer = new StringWriter(sb))
            {
                WriteItemsToWriter<T>(items, writer, config);
            }
            return sb.ToString();
        }
        #endregion

        #region DataReader ==> CSV
        /// <summary>
        /// 解析DataReader写入TextWriter
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="writer"></param>
        /// <param name="config"></param>

        public static void WriteReaderToWriter(IDataReader reader, TextWriter writer, CsvConfiguration config = null)
        {
            using (var csv = (config == null) ? new CsvWriter(writer) : new CsvWriter(writer, config))
            {
                bool hasHeader = (config == null) ? true : config.HasHeaderRecord;
                if (hasHeader)
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                        csv.WriteField(reader.GetName(i));
                    csv.NextRecord();
                }
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                        csv.WriteField(reader[i]);
                    csv.NextRecord();
                }
            }
        }
        /// <summary>
        /// 解析DataReader写入csv文件
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="csvFile"></param>
        /// <param name="config"></param>
        public static void WriteReaderToFile(IDataReader reader, string csvFile, CsvConfiguration config = null)
        {
            Encoding encoding = config == null ? Encoding.UTF8 : config.Encoding;
            WriteReaderToWriter(reader, new StreamWriter(csvFile, false, encoding), config);
        }
        /// <summary>
        /// 解析DataReader获取csv string
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static string GetReaderToString(IDataReader reader, CsvConfiguration config = null)
        {
            StringBuilder sb = new StringBuilder();
            using (StringWriter writer = new StringWriter(sb))
            {
                WriteReaderToWriter(reader, writer, config);
            }
            return sb.ToString();
        }
        #endregion

        #region DataTable ==> CSV
        /// <summary>
        /// 解析DataTable写入TextWriter
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="writer"></param>
        /// <param name="config"></param>
        public static void WriteTableToWriter(DataTable dt, TextWriter writer, CsvConfiguration config = null)
        {
            using (var csv = (config == null) ? new CsvWriter(writer) : new CsvWriter(writer, config))
            {
                bool hasHeader = (config == null) ? true : config.HasHeaderRecord;
                if (hasHeader)
                {
                    foreach (DataColumn column in dt.Columns)
                        csv.WriteField(column.ColumnName);
                    csv.NextRecord();
                }
                foreach (DataRow row in dt.Rows)
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                        csv.WriteField(row[i]);
                    csv.NextRecord();
                }
            }
        }
        /// <summary>
        /// 解析DataTable写入csv文件
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="csvFile"></param>
        /// <param name="config"></param>
        public static void WriteTableToFile(DataTable dt, string csvFile, CsvConfiguration config = null)
        {
            Encoding encoding = config == null ? Encoding.UTF8 : config.Encoding;
            WriteTableToWriter(dt, new StreamWriter(csvFile, false, encoding), config);
        }
        /// <summary>
        /// 解析DataTable获取csv string
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static string GetTableToString(DataTable dt, CsvConfiguration config = null)
        {
            StringBuilder sb = new StringBuilder();
            using (StringWriter writer = new StringWriter(sb))
            {
                WriteTableToWriter(dt, writer, config);
            }
            return sb.ToString();
        }
        #endregion

        #region CSV ==> DataTable
        #region LoadRecords
        /// <summary>
        /// 解析TextReader加载数据到DataTable
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="reader"></param>
        /// <param name="config"></param>
        public static void LoadTableByReader(DataTable dt, TextReader reader, CsvConfiguration config = null)
        {
            foreach (var csv in GetReaderRecordsByReader(reader, config))
            {
                var newRow = dt.NewRow();
                foreach (DataColumn column in dt.Columns)
                {
                    newRow[column.ColumnName] = csv.GetField(column.DataType, column.ColumnName);
                }
                dt.Rows.Add(newRow);
            }
        }
        /// <summary>
        /// 解析csv文件加载数据到DataTable
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="csvFile"></param>
        /// <param name="config"></param>
        public static void LoadTableByFile(DataTable dt, string csvFile, CsvConfiguration config = null)
        {
            Encoding encoding = config == null ? Encoding.UTF8 : config.Encoding;
            LoadTableByReader(dt, new StreamReader(csvFile, encoding), config);
        }
        /// <summary>
        /// 解析csv string加载数据到DataTable
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="content"></param>
        /// <param name="config"></param>
        public static void LoadTableByString(DataTable dt, string content, CsvConfiguration config = null)
        {
            LoadTableByReader(dt, new StringReader(content), config);
        }
        #endregion

        #region GetTable
        /// <summary>
        /// 解析TextReader获取DataTable
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static DataTable GetTableByReader(TextReader reader, CsvConfiguration config = null)
        {
            DataTable ret = new DataTable();
            using (var csv = (config == null) ? new CsvReader(reader) : new CsvReader(reader, config))
            {
                bool addColumns = false;
                //if (csv.FieldHeaders == null || csv.FieldHeaders.Length == 0)
                if (csv.ReadHeader())
                {
                    foreach (var field in csv.FieldHeaders)
                        ret.Columns.Add(field);
                    addColumns = true;
                }
                while (csv.Read())
                {
                    var record = csv.CurrentRecord;
                    if (!addColumns)
                    {
                        for (int i = 0; i < record.Length; i++)
                            ret.Columns.Add("Column" + i);
                        addColumns = true;
                    }
                    var newRow = ret.NewRow();
                    for (int i = 0; i < record.Length; i++)
                        newRow[i] = record[i];
                    ret.Rows.Add(newRow);
                }
            }
            return ret;
        }
        /// <summary>
        /// 解析csv文件获取DataTable
        /// </summary>
        /// <param name="csvFile"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static DataTable GetTableByFile(string csvFile, CsvConfiguration config = null)
        {
            Encoding encoding = config == null ? Encoding.UTF8 : config.Encoding;
            return GetTableByReader(new StreamReader(csvFile, encoding), config);
        }
        /// <summary>
        /// 解析csv string获取DataTable
        /// </summary>
        /// <param name="content"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static DataTable GetTableByString(string content, CsvConfiguration config = null)
        {
            return GetTableByReader(new StringReader(content), config);
        }
        #endregion
        #endregion

    }
}
