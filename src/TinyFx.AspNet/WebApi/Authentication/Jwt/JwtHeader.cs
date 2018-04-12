using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TinyFx.AspNet.WebApi.Authentication
{
    /// <summary>
    /// Jwt的Header，目前只支持HS256
    /// </summary>
    public class JwtHeader
    {
        /// <summary>
        /// 
        /// </summary>
        public string typ { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string alg { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public JwtHeader()
        {
            typ = "JWT";
            alg = "HS256";
        }
    }
}