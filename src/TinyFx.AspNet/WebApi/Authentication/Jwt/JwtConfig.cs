using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using TinyFx.Web;
using TinyFx.Configuration;
using TinyFx.Configuration.AspNet.WebApi;
using TinyFx.Configuration.AspNet;

namespace TinyFx.AspNet.WebApi.Authentication
{
    /// <summary>
    /// Jwt配置类
    /// </summary>
    public static class JwtConfig
    {
        /// <summary>
        /// Jwt key
        /// </summary>
        public static string SecretKey
        {
            get
            {
                string key = null;
                var config = GetConfig();
                key = config != null ? config.SecretKey : ConfigurationManager.AppSettings.Get("Auth:JwtSecretKey");
                if (string.IsNullOrEmpty(key))
                    throw new Exception("缺少JwtSecretKey，请在config中添加配置。");
                return key;
            }
        }
        /// <summary>
        /// Jwt token 过期时间
        /// </summary>
        public static TimeSpan TokenExpiry
        {
            get
            {
                string expiry = null;
                var config = GetConfig();
                expiry = config != null ? config.TokenExpiry : ConfigurationManager.AppSettings.Get("Auth:JwtTokenExpiry");
                if (string.IsNullOrEmpty(expiry))
                    return TimeSpan.Zero;
                return TimeSpan.Parse(expiry);
            }
        }
        private static JwtAuthElement GetConfig()
        {
            JwtAuthElement ret = null;
            var section = TinyFxConfigManager.GetConfig<AspNetConfig>();
            if (section != null && section.WebApiConfig != null && section.WebApiConfig.JwtAuthElement != null)
                ret = section.WebApiConfig.JwtAuthElement;
            return ret;
        }
    }
}