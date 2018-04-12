using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace TinyFx.Windows
{
    /// <summary>
    /// ODBC操作辅助类
    /// </summary>
    public static class ODBCUtil
    {
        private const string ODBC_INI_PATH = @"SOFTWARE\ODBC\ODBC.INI\";
        private const string ODBCINST_INI_PATH = @"SOFTWARE\ODBC\ODBCINST.INI\";

        private const string ODBC_DRIVERS = @"Software\ODBC\ODBCINST.INI\ODBC Drivers";
        private const string ODBC_DATA_SOURCES = @"SOFTWARE\ODBC\ODBC.INI\ODBC Data Sources";

        #region Utils
        private static RegistryKey Try64BitRoot(RegistryHive hKey)
        {
            return RegistryKey.OpenBaseKey(hKey, RegistryView.Registry64);
        }
        private static RegistryKey Get32BitRoot(RegistryHive hKey)
        {
            return RegistryKey.OpenBaseKey(hKey, RegistryView.Registry32);
        }
        private static RegistryKey Get32BitKey(RegistryHive hKey, string name, bool writable = false)
        {
            return Get32BitRoot(hKey).OpenSubKey(name, writable);
        }
        private static RegistryKey Try64BitKey(RegistryHive hKey, string name, bool writable = false)
        {
            return Try64BitRoot(hKey).OpenSubKey(name, writable);
        }
        private static RegistryKey Get32BitSystemKey(string name, bool writable = false)
        {
            return Get32BitKey(RegistryHive.LocalMachine, name, writable);
        }
        private static RegistryKey Try64BitSystemKey(string name, bool writable = false)
        {
            return Try64BitKey(RegistryHive.LocalMachine, name, writable);
        }
        private static RegistryKey Get32BitUserKey(string name, bool writable = false)
        {
            return Get32BitKey(RegistryHive.CurrentUser, name, writable);
        }
        private static RegistryKey Try64BitUserKey(string name, bool writable = false)
        {
            return Try64BitKey(RegistryHive.CurrentUser, name, writable);
        }
        #endregion

        #region Drivers
        /// <summary>
        /// 获取已安装的驱动名称
        /// </summary>
        /// <returns></returns>
        public static string[] GetDriverNames()
        {
            return Try64BitSystemKey(ODBC_DRIVERS).GetValueNames();
        }

        /// <summary>
        /// 获取驱动程序
        /// </summary>
        /// <param name="driverName"></param>
        /// <returns></returns>
        public static string GetDriver(string driverName)
        {
            var key = Try64BitSystemKey(ODBCINST_INI_PATH + driverName);
            if (key == null)
                throw new Exception(string.Format("在注册表中ODBC驱动‘{0}’不存在。", driverName));
            return key.GetValue("Driver").ToString();
        }
        #endregion

        #region GetDSNs
        /// <summary>
        /// 获取用户DSN列表
        /// </summary>
        /// <returns></returns>
        public static string[] GetUserDSNs()
        {
            return Try64BitUserKey(ODBC_DATA_SOURCES).GetValueNames();
        }

        /// <summary>
        /// 获取系统DSN列表
        /// </summary>
        /// <returns></returns>
        public static string[] GetSystemDSNs()
        {
            return Try64BitSystemKey(ODBC_DATA_SOURCES).GetValueNames();
        }
        #endregion

        #region ExistsDSN
        /// <summary>
        /// 检查用户DSN是否存在
        /// </summary>
        /// <param name="dsnName">DSN名称</param>
        /// <returns></returns>
        public static bool ExistsUserDSN(string dsnName)
        {
            return GetUserDSNs().Contains(dsnName);
        }
        /// <summary>
        /// 检查系统DSN是否存在
        /// </summary>
        /// <param name="dsnName">DSN名称</param>
        /// <returns></returns>
        public static bool ExistsSystemDSN(string dsnName)
        {
            return GetSystemDSNs().Contains(dsnName);
        }
        #endregion

        #region RemoveDSN
        /// <summary>
        /// 移除用户DSN
        /// </summary>
        /// <param name="dsnName">DSN名称</param>
        public static bool RemoveUserDSN(string dsnName)
        {
            return RemoveDSN(dsnName, false);
        }
        /// <summary>
        /// 移除系统DSN
        /// </summary>
        /// <param name="dsnName">DSN名称</param>
        public static bool RemoveSystemDSN(string dsnName)
        {
            return RemoveDSN(dsnName, true);
        }
        private static bool RemoveDSN(string dsnName, bool isSystem)
        {
            bool ret = true;
            try
            {
                var root = isSystem ? Try64BitRoot(RegistryHive.LocalMachine) : Try64BitRoot(RegistryHive.CurrentUser);
                // Remove DSN key
                root.DeleteSubKeyTree(ODBC_INI_PATH + dsnName, true);
                //Remove ODBC Data Sources Value
                root.OpenSubKey(ODBC_DATA_SOURCES, true).DeleteValue(dsnName, true);
            }
            catch
            {
                ret = false;
            }
            return ret;
        }
        #endregion

        #region CreateDSN
        /// <summary>
        /// 创建用户DSN
        /// </summary>
        /// <param name="dsnName">DSN名称</param>
        /// <param name="driverName">使用的驱动名称</param>
        /// <param name="server">服务器地址</param>
        /// <param name="database">数据库名</param>
        /// <param name="trustedConnection">是否使用集成验证</param>
        public static void CreateUserDSN(string dsnName, string driverName, string server, string database, bool trustedConnection = false)
        {
            CreateDSN(dsnName, driverName, server, database, trustedConnection, false);
        }

        /// <summary>
        /// 创建系统DSN
        /// </summary>
        /// <param name="dsnName">DSN名称</param>
        /// <param name="driverName">使用的驱动名称</param>
        /// <param name="server">服务器地址</param>
        /// <param name="database">数据库名</param>
        /// <param name="trustedConnection">是否使用集成验证</param>
        public static void CreateSystemDSN(string dsnName, string driverName, string server, string database, bool trustedConnection = false)
        {
            CreateDSN(dsnName, driverName, server, database, trustedConnection, true);
        }

        private static void CreateDSN(string dsnName, string driverName, string server, string database, bool trustedConnection, bool isSystem)
        {
            var root = isSystem ? Try64BitRoot(RegistryHive.LocalMachine) : Try64BitRoot(RegistryHive.CurrentUser);
            // Get Driver
            string driver = GetDriver(driverName);
            // Add value to odbc data sources
            root.OpenSubKey(ODBC_DATA_SOURCES, true).SetValue(dsnName, driverName);
            // Create new key in odbc.ini with dsn name and add values
            var key = root.CreateSubKey(ODBC_INI_PATH + dsnName);
            key.SetValue("Driver", driver);
            key.SetValue("Server", server);
            key.SetValue("Database", database);
            key.SetValue("Trusted_Connection", trustedConnection ? "Yes" : "No");
            key.SetValue("LastUser", Environment.UserName);
            //key.SetValue("Description", "");
        }

        /// <summary>
        /// 创建用户SQL Server DSN
        /// </summary>
        /// <param name="dsnName">DSN名称</param>
        /// <param name="server">服务器地址</param>
        /// <param name="database">数据库名</param>
        /// <param name="trustedConnection">是否使用集成验证</param>
        public static void CreateUserSqlServerDSN(string dsnName, string server, string database, bool trustedConnection = false)
        {
            CreateDSN(dsnName, "SQL Server", server, database, trustedConnection, false);
        }

        /// <summary>
        /// 创建系统SQL Server DSN
        /// </summary>
        /// <param name="dsnName">DSN名称</param>
        /// <param name="server">服务器地址</param>
        /// <param name="database">数据库名</param>
        /// <param name="trustedConnection">是否使用集成验证</param>
        public static void CreateSystemSqlServerDSN(string dsnName, string server, string database, bool trustedConnection = false)
        {
            CreateDSN(dsnName, "SQL Server", server, database, trustedConnection, true);
        }

        #endregion
    }

}
