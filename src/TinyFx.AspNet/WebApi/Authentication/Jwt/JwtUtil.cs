using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace TinyFx.AspNet.WebApi.Authentication
{
    /// <summary>
    /// Jwt辅助类
    /// </summary>
    public static class JwtUtil
    {
        /// <summary>
        /// 获得Jwt的Token编码, 返回给客户端
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="role"></param>
        /// <param name="version">版本，用于控制token过期</param>
        /// <returns></returns>
        public static string EncodeToken(string userId, string role = null, string version = null)
        {
            var expiry = GetTokenExpiry(JwtConfig.TokenExpiry);
            var payload = new JwtPayload() {
                name = userId,
                role = role,
                exp = expiry,
                ver = version
            };
            return EncodeToken(payload, JwtConfig.SecretKey);
        }

        /// <summary>
        /// Token编码
        /// </summary>
        public static string EncodeToken<T>(T payload, string key, JwtHeader header = null)
            where T : JwtPayload
        {
            var segments = new List<string>();
            // 1. header
            header = header ?? new JwtHeader();
            segments.Add(Base64Encrypt(JsonToString(header)));
            // 2. payload
            segments.Add(Base64Encrypt(JsonToString(payload)));
            // 3. signature
            segments.Add(HmacSignature(string.Join(".", segments), key));
            return string.Join(".", segments);
        }

        /// <summary>
        /// Token解码
        /// </summary>
        public static T DecodeToken<T>(string token, string key, bool isVerify = true)
            where T : JwtPayload
        {
            var segments = token.Split('.');
            if (segments.Length != 3) throw new ArgumentException("Token格式不正确");

            var headerSeg = segments[0];
            var payloadSeg = segments[1];
            var signatureSeg = segments[2];

            var header = StringToJson<JwtHeader>(Base64Decrypt(headerSeg));
            var payload = StringToJson<T>(Base64Decrypt(payloadSeg));

            if (isVerify)
            {
                if (!HmacSignature(headerSeg + "." + payloadSeg, key).Equals(signatureSeg))
                    throw new Exception("无效Token");
            }
            return payload;
        }
        /// <summary>
        /// 获取Token过期时间
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static long GetTokenExpiry(TimeSpan value)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var expiry = (DateTime.UtcNow.Add(value) - epoch).TotalSeconds;
            return Convert.ToInt64(expiry);
        }

        /// <summary>
        /// 解析Token 过期时间
        /// </summary>
        /// <param name="unixTime"></param>
        /// <returns></returns>
        public static DateTime ParseTokenExpiry(long unixTime)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(unixTime);
        }

        #region Utils

        private static string Base64Encrypt(string str)
            => Convert.ToBase64String(Encoding.UTF8.GetBytes(str));

        private static string Base64Decrypt(string str)
            => Encoding.UTF8.GetString(Convert.FromBase64String(str));

        private static string HmacSignature(string secret, string value)
        {
            string ret;
            var secretBytes = Encoding.UTF8.GetBytes(secret);
            var valueBytes = Encoding.UTF8.GetBytes(value);

            using (var hmac = new HMACSHA256(secretBytes))
            {
                var hash = hmac.ComputeHash(valueBytes);
                ret = Convert.ToBase64String(hash);
            }
            return ret;
        }

        private static string JsonToString<T>(T obj)
            => Newtonsoft.Json.JsonConvert.SerializeObject(obj);

        private static T StringToJson<T>(string value)
        {
            if (string.IsNullOrEmpty(value)) return default(T);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(value);
        }

        #endregion
    }
}