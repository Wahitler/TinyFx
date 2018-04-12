using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyFx.Security
{
    /// <summary>
    /// RSA 秘钥格式
    /// </summary>
    public enum RSAKeyMode
    {
        /// <summary>
        /// 微软生成的Xml格式的秘钥
        /// </summary>
        MSXml,
        /// <summary>
        /// OpenSSL格式的秘钥
        /// </summary>
        OpenSSL
    }
}
