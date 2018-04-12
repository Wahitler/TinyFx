using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using TinyFx.Configuration.AspNet.WebApi;

namespace TinyFx.Configuration.AspNet
{
    public class WebApiConfig
    {
        public DebugElement DebugElement { get; set; }
        public ResultFilterElement ResultFilterElement { get; set; }
        public UnhandledExceptionElement UnhandledExceptionElement { get; set; }
        public JwtAuthElement JwtAuthElement { get; set; }
        public CorsElement CorsElement { get; set; }
        public VersionElement VersionElement { get; set; }
        public JsonSerializerElement JsonSerializerElement { get; set; }
        public void Parse(XmlElement element)
        {
            if (element == null) return;
            var currElement = element.SelectSingleNode("debug") as XmlElement;
            if (currElement != null)
            {
                DebugElement = new DebugElement()
                {
                    LogRequest = GetAttributeValue(currElement, "logRequest").ToBoolean(false),
                    LogResponse = GetAttributeValue(currElement, "logResponse").ToBoolean(false),
                    //ResponseException = GetAttributeValue(currElement, "responseException").ToBoolean(false),
                    Logger = GetAttributeValue(currElement, "logger"),
                };
            }
            currElement = element.SelectSingleNode("resultFilter") as XmlElement;
            if (currElement != null)
            {
                ResultFilterElement = new ResultFilterElement()
                {
                    Enabled = GetAttributeValue(currElement, "enabled").ToBoolean(false)
                };
            }
            currElement = element.SelectSingleNode("unhandledException") as XmlElement;
            if (currElement != null)
            {
                UnhandledExceptionElement = new UnhandledExceptionElement()
                {
                    Enabled = GetAttributeValue(currElement, "enabled").ToBoolean(true),
                    ResponseOKStatusCode = GetAttributeValue(currElement, "responseOKStatusCode").ToBoolean(false),
                    ResponseExceptionDetail = GetAttributeValue(currElement, "responseExceptionDetail").ToBoolean(false),
                    Logger = GetAttributeValue(currElement, "logger"),
                };
            }
            currElement = element.SelectSingleNode("jwtAuth") as XmlElement;
            if (currElement != null)
            {
                JwtAuthElement = new JwtAuthElement()
                {
                    Enabled = GetAttributeValue(currElement, "enabled").ToBoolean(true),
                    ResponseOKStatusCode = GetAttributeValue(currElement, "responseOKStatusCode").ToBoolean(false),
                    SecretKey = GetAttributeValue(currElement, "secretKey"),
                    TokenExpiry = GetAttributeValue(currElement, "tokenExpiry")
                };
            }
            currElement = element.SelectSingleNode("cors") as XmlElement;
            if (currElement != null)
            {
                CorsElement = new CorsElement()
                {
                    Enabled = GetAttributeValue(currElement, "enabled").ToBoolean(true),
                    Origins = GetAttributeValue(currElement, "origins"),
                    Headers = GetAttributeValue(currElement, "headers"),
                    Methods = GetAttributeValue(currElement, "methods")
                };
            }
            currElement = element.SelectSingleNode("version") as XmlElement;
            if (currElement != null)
            {
                VersionElement = new VersionElement()
                {
                    Mode = GetAttributeValue(currElement, "mode")
                };
            }
            currElement = element.SelectSingleNode("jsonSerializer") as XmlElement;
            if (currElement != null)
            {
                var dfh = GetAttributeValue(currElement, "dateFormatHandling");
                JsonSerializerElement = new JsonSerializerElement()
                {
                    Enabled = GetAttributeValue(currElement, "enabled").ToBoolean(true),
                    DefaultValueHandling = GetAttributeValue(currElement, "defaultValueHandling").ToEnum(DefaultValueHandling.Include),
                    NullValueHandling = GetAttributeValue(currElement, "nullValueHandling").ToEnum(NullValueHandling.Include),
                    DateFormatHandling = (dfh != null && dfh.ToLower().Contains("iso")) ? DateFormatHandling.IsoDateFormat : DateFormatHandling.MicrosoftDateFormat,
                    DateFormatString = GetAttributeValue(currElement, "dateFormatString").DefaultIfNullOrEmpty("yyyy-MM-dd HH:mm:ss"),
                    CamelCasePropertyNames = GetAttributeValue(currElement, "camelCasePropertyNames").ToBoolean(true)
                };
            }
        }
        protected string GetAttributeValue(XmlElement element, string name)
        {
            var attr = element.Attributes[name];
            return attr?.Value;
        }
    }
}
