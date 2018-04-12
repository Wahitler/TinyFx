using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace TinyFx.Configuration
{
    /// <summary>
    /// TinyFx配置项基类
    /// </summary>
    public abstract class TinyFxConfiguration
    {
        /// <summary>
        /// 获取配置项名称
        /// </summary>
        /// <returns></returns>
        public abstract string GetConfigName();
        /// <summary>
        /// 解析配置信息获得配置对象
        /// </summary>
        /// <param name="element"></param>
        public abstract void Parse(XmlElement element);
        protected string GetAttributeValue(XmlElement element, string name)
        {
            var attr = element.Attributes[name];
            return attr?.Value;
        }
    }

}
