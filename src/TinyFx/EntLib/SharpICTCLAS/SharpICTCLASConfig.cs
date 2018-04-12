using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace TinyFx.Configuration
{
    public class SharpICTCLASConfig: TinyFxConfiguration
    {
        public override string GetConfigName() => "sharpICTCLAS";
        public string ResourcePath { get; set; }

        public override void Parse(XmlElement element)
        {
            if (element == null) return;
            ResourcePath = GetAttributeValue(element, "resourcePath");
        }
    }
}
