using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace TinyFx.Configuration.AspNet
{
    public class AspNetConfig : TinyFxConfiguration
    {
        public override string GetConfigName() => "aspNet";
        /// <summary>
        /// PreApplicationStartMethod 执行时是否进行配置
        /// </summary>
        public bool PreStartConfig { get; set; }

        public WebApiConfig WebApiConfig = new WebApiConfig();
        public WebFormConfig WebFormConfig = new WebFormConfig();
        public List<VirtualPathElement> VirtualPaths { get; set; } = new List<VirtualPathElement>();

        public override void Parse(XmlElement element)
        {
            PreStartConfig = GetAttributeValue(element, "preStartConfig").ToBoolean(false);
            var webApiNode = element.SelectSingleNode("webApi") as XmlElement;
            WebApiConfig.Parse(webApiNode);
            var webFormNode = element.SelectSingleNode("webForm") as XmlElement;
            WebFormConfig.Parse(webFormNode);

            var nodes = element.SelectNodes("virtualPaths/*");
            if (nodes != null)
            {
                foreach (XmlElement path in nodes)
                {
                    var item = new VirtualPathElement()
                    {
                        RequestPath = GetAttributeValue(path, "requestPath"),
                        ResourcePath = GetAttributeValue(path, "resourcePath"),
                        Assembly = GetAttributeValue(path, "assembly")
                    };
                    VirtualPaths.Add(item);
                }
            }
        }
    }
}
