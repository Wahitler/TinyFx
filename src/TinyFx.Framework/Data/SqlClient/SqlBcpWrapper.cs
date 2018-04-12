using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx.Windows;

namespace TinyFx.Data.SqlClient
{
    /// <summary>
    /// SQL Server bcp工具功能封装，只支持SQL Server 2008 R2的BCP v10以上的版本
    /// </summary>
    public class SqlBcpWrapper
    {
        /// <summary>
        /// 服务器ip
        /// </summary>
        public string Server { get; set; }
        /// <summary>
        /// 数据库名称
        /// </summary>
        public string Database { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool UseChar { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool UseNative { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int BatchSize { get; set; }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="server"></param>
        /// <param name="uid"></param>
        /// <param name="pwd"></param>
        /// <param name="database"></param>
        public SqlBcpWrapper(string server, string uid = null, string pwd = null, string database = null)
        {
            Server = server;
            Database = database;
            UserId = uid;
            Password = pwd;
            UseChar = true;
        }
        /// <summary>
        /// 导出查询数据到文件
        /// </summary>
        /// <param name="query"></param>
        /// <param name="outFile"></param>
        /// <returns></returns>
        public bool ExportQuery(string query, string outFile)
        {
            string cmd = string.Format("bcp \"{0}\" queryout {1} {2}", query, outFile, GetCommandStr());
            string output = WindowsUtil.RunCommand(cmd);
            Console.WriteLine(output);
            return output.Contains("已复制 ");
        }
        /// <summary>
        /// 导出表
        /// </summary>
        /// <param name="table"></param>
        /// <param name="outFile"></param>
        /// <returns></returns>
        public bool ExportTable(string table, string outFile)
        {
            string cmd = string.Format("bcp {0} out {1} {2}", table, outFile, GetCommandStr());
            string output = WindowsUtil.RunCommand(cmd);
            Console.WriteLine(output);
            return output.Contains("已复制 ");
        }
        /// <summary>
        /// 导入表
        /// </summary>
        /// <param name="table"></param>
        /// <param name="inFile"></param>
        public void ImportTable(string table, string inFile)
        {
            string cmd = string.Format("bcp {0} in {1} {2}", table, inFile, GetCommandStr());
            string output = WindowsUtil.RunCommand(cmd);
            Console.WriteLine(output);
            //return output.Contains("已复制 ");
        }

        private string GetCommandStr()
        {
            string ret = null;
            if (!string.IsNullOrEmpty(Server))
                ret += " -S" + Server;
            if (!string.IsNullOrEmpty(Database))
                ret += " -d" + Database;
            if (!string.IsNullOrEmpty(UserId))
                ret += " -U" + UserId + " -P" + Password ?? string.Empty;
            else
                ret += " -T";
            if (UseChar)
                ret += " -c";
            if (UseNative)
                ret += " -n";
            if (BatchSize > 0)
                ret += " -b" + BatchSize;
            return ret;
        }
    }

}
