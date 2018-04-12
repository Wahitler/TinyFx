using System.Configuration;
using System.Configuration.Internal;
using System.Xml;

namespace TinyFx.Configuration
{
    /// <summary>
    /// TinyFx配置SectionHandler
    /// </summary>
    public class TinyFxSectionHandler: IConfigurationSectionHandler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="configContext"></param>
        /// <param name="section"></param>
        /// <returns></returns>
        public object Create(object parent, object configContext, XmlNode section)
		{
			return section;
		} 
    }
}
