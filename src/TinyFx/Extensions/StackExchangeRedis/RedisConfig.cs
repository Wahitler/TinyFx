using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using TinyFx;

namespace TinyFx.Configuration
{
    /// <summary>
    /// Redis模块配置节信息
    /// </summary>
    public class RedisConfig : TinyFxConfiguration
    {
        /// <summary>
        /// 配置节名称
        /// </summary>
        /// <returns></returns>
        public override string GetConfigName()
            => "redis";

        /// <summary>
        /// 默认数据库
        /// </summary>
        public string DefaultConnectionString { get; set; }

        /// <summary>
        /// 连接字符串集合
        /// </summary>
        public Dictionary<string, RedisConnectionStringElement> ConnectionStrings = new Dictionary<string, RedisConnectionStringElement>();

        /// <summary>
        /// 解析
        /// </summary>
        /// <param name="element"></param>
        public override void Parse(XmlElement element)
        {
            if (element == null) return;
            DefaultConnectionString = GetAttributeValue(element, "defaultConnectionString");
            var nodes = element.SelectNodes("/tinyFx/redis/connectionStrings/*");
            if (nodes != null)
            {
                foreach (XmlElement node in nodes)
                {
                    var item = new RedisConnectionStringElement()
                    {
                        Name = GetAttributeValue(node, "name"),
                        ConnectionString = GetAttributeValue(node, "connectionString"),
                        Database = GetAttributeValue(node, "database").ToInt32(0),
                        KeyPrefix = GetAttributeValue(node, "keyPrefix"),
                        Serializer = GetAttributeValue(node, "serializer")
                    };
                    ConnectionStrings.Add(item.Name, item);
                }
            }
        }
    }

    public class RedisConnectionStringElement
    {
        /// <summary>
        /// RedisConnectionString标识
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Redis连接信息
        /// </summary>
        public string ConnectionString { get; set; }
        /// <summary>
        /// DatabaseNumber
        /// </summary>
        public int Database { get; set; }
        /// <summary>
        /// 保存时Key添加的前缀
        /// </summary>
        public string KeyPrefix { get; set; }
        /// <summary>
        /// 保存时使用的序列化器
        /// </summary>
        public string Serializer { get; set; }
    }
}
