using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TinyFx.Configuration
{
    public class IPLocatorConfig : TinyFxConfiguration
    {
        public override string GetConfigName() => "ipLocator";
        public string ResourcePath { get; set; }

        public override void Parse(XmlElement element)
        {
            if (element == null) return;
            ResourcePath = GetAttributeValue(element, "resourcePath");
        }
    }
}
