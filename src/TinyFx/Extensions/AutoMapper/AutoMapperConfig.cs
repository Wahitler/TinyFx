using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace TinyFx.Configuration
{
    /// <summary>
    /// AutoMapper配置类
    /// </summary>
    public class AutoMapperConfig : TinyFxConfiguration
    {
        /// <summary>
        /// 配置节名
        /// </summary>
        /// <returns></returns>
        public override string GetConfigName()
            => "autoMapper";
        /// <summary>
        /// 是否使用
        /// </summary>
        public bool Enabled { get; set; }
        /// <summary>
        /// 映射的程序集
        /// </summary>
        public List<string> Assemblies = new List<string>();
        /// <summary>
        /// 解析
        /// </summary>
        /// <param name="element"></param>
        public override void Parse(XmlElement element)
        {
            if (element == null) return;
            Enabled = GetAttributeValue(element, "enabled").ToBoolean(false);
            var nodes = element.SelectNodes("/tinyFx/autoMapper/assemblies/*");
            if (nodes == null) return;
            foreach (XmlElement node in nodes)
            {
                var asm = GetAttributeValue(node, "assembly");
                if (string.IsNullOrEmpty(asm))
                    Assemblies.Add(asm);
            }
        }
    }
}
