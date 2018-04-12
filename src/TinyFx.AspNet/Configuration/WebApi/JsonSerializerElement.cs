using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TinyFx.Configuration.AspNet.WebApi
{
    /// <summary>
    /// 自定义Json序列化
    /// </summary>
    public class JsonSerializerElement
    {
        /// <summary>
        /// 是否使用自定义的Json序列化
        /// </summary>
        public bool Enabled { get; set; }
        public DefaultValueHandling DefaultValueHandling { get; set; }
        public NullValueHandling NullValueHandling { get; set; }
        public DateFormatHandling DateFormatHandling { get; set; }
        public string DateFormatString { get; set; }
        public bool CamelCasePropertyNames { get; set; }
    }
}
