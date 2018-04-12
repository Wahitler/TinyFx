using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using TinyFx;

namespace TinyFx.Configuration.AspNet
{
    public class WebFormConfig
    {
        public bool UseControls { get; set; }
        public void Parse(XmlElement element)
        {
            if (element == null) return;
            UseControls = GetAttributeValue(element, "useControls").ToBoolean(false);
        }
        protected string GetAttributeValue(XmlElement element, string name)
            => element.Attributes[name]?.Value;
    }
}
