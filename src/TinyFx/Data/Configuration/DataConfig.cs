using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using TinyFx.Configuration;

namespace TinyFx.Configuration.Data
{
    /// <summary>
    /// Data模块配置节信息
    /// </summary>
    public class DataConfig : TinyFxConfiguration
    {
        /// <summary>
        /// 配置节名称
        /// </summary>
        /// <returns></returns>
        public override string GetConfigName()
            => "data";
        
        /// <summary>
        /// 默认数据库
        /// </summary>
        public string DefaultConnectionString { get; set; }
        
        /// <summary>
        /// 数据路由提供程序
        /// </summary>
        public string DataRouter { get; set; }
        
        /// <summary>
        /// 跟踪服务提供程序
        /// </summary>
        public string InstProvider { get; set; }
        
        /// <summary>
        /// 连接字符串集合
        /// </summary>
        public Dictionary<string, ConnectionStringElement> ConnectionStrings = new Dictionary<string, ConnectionStringElement>();
        
        //public Dictionary<string, DbProviderFactoryElement> DbProviderFactories = new Dictionary<string, DbProviderFactoryElement>();

        /// <summary>
        /// 解析
        /// </summary>
        /// <param name="element"></param>
        public override void Parse(XmlElement element)
        {
            if (element == null) return;
            DefaultConnectionString = GetAttributeValue(element, "defaultConnectionString");
            DataRouter = GetAttributeValue(element, "dataRouter");
            InstProvider = GetAttributeValue(element, "instProvider");

            var nodes = element.SelectNodes("//data/connectionStrings/add");
            if (nodes != null)
            {
                foreach (XmlElement node in nodes)
                {
                    var item = new ConnectionStringElement()
                    {
                        Name = GetAttributeValue(node, "name"),
                        ProviderName = GetAttributeValue(node, "providerName"),
                        ConnectionString = GetAttributeValue(node, "connectionString"),
                        ReadConnectionString = GetAttributeValue(node, "readConnectionString"),
                        CommandTimeout = GetAttributeValue(node, "commandTimeout").ToInt32(30),
                        Encrypt = GetAttributeValue(node, "encrypt"),
                        InstProvider = GetAttributeValue(node, "instProvider"),
                        OrmMap = GetAttributeValue(node, "ormMap")
                    };
                    ConnectionStrings.Add(item.Name, item);
                }
            }
            /*
            nodes = element.SelectNodes("/tinyFx/data/dbProviderFactories/*");
            if (nodes != null)
            {
                foreach (XmlElement node in nodes)
                {
                    var item = new DbProviderFactoryElement()
                    {
                        Name = GetAttributeValue(node, "name"),
                        Invariant = GetAttributeValue(node, "invariant"),
                        Type = GetAttributeValue(node, "type"),
                        Description = GetAttributeValue(node, "description"),
                    };
                    DbProviderFactories.Add(item.Invariant, item);
                }
            }
            */
        }
        /*
    <dbProviderFactories>
      <add name="Odbc Data Provider" invariant="System.Data.Odbc" type="System.Data.Odbc.OdbcFactory, System.Data" description=".Net Framework Data Provider for Odbc" />
      <add name="OleDb Data Provider" invariant="System.Data.OleDb" type="System.Data.OleDb.OleDbFactory, System.Data" description=".Net Framework Data Provider for OleDb" />
      <add name="SqlClient Data Provider" invariant="System.Data.SqlClient" type="System.Data.SqlClient.SqlClientFactory, System.Data" description=".Net Framework Data Provider for SqlServer" />
      <add name="OracleClient Data Provider" invariant="System.Data.OracleClient" type="System.Data.OracleClient.OracleClientFactory, System.Data.OracleClient" description=".Net Framework Data Provider for Oracle" />
      <add name="ODP.NET, Managed Driver" invariant="Oracle.ManagedDataAccess.Client" type="Oracle.ManagedDataAccess.Client.OracleClientFactory, Oracle.ManagedDataAccess" description="Oracle Data Provider for .NET, Managed Driver" />
      <add name="MySQL Data Provider" invariant="MySql.Data.MySqlClient" type="MySql.Data.MySqlClient.MySqlClientFactory, MySql.Data" description=".Net Framework Data Provider for MySQL" />
    </dbProviderFactories>
         */
    }
}
