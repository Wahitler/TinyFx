using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TinyFx.Security
{
    /// <summary>
    /// 安全辅助类
    /// </summary>
    public static class SecurityUtil
    {
        private static string CipherEncodeString(byte[] data, CipherEncode cipherEncode)
        {
            string ret = null;
            switch (cipherEncode)
            {
                case CipherEncode.Base64:
                    ret = Convert.ToBase64String(data);
                    break;
                case CipherEncode.Hex:
                    ret = StringUtil.BytesToHex(data);
                    break;
                case CipherEncode.Bit16Lower:
                    ret = BitConverter.ToString(data, 4, 8).Replace("-", "").ToLower();
                    break;
                case CipherEncode.Bit16Upper:
                    ret = BitConverter.ToString(data, 4, 8).Replace("-", "").ToUpper();
                    break;
                case CipherEncode.Bit32Lower:
                    for (int i = 0; i < data.Length; i++)
                        ret += data[i].ToString("x2");
                    break;
                case CipherEncode.Bit32Upper:
                    for (int i = 0; i < data.Length; i++)
                        ret += data[i].ToString("X2");
                    break;
            }
            return ret;
        }
        
        #region Password处理
        
        /// <summary>
        /// 获取用户密码Hash所需要的Salt
        /// </summary>
        /// <returns></returns>
        public static string GetPasswordSalt()
        {
            var data = new byte[0x10];
            using (var provider = new RNGCryptoServiceProvider())
            {
                provider.GetBytes(data);
                return Convert.ToBase64String(data);
            };
        }
        
        /// <summary>
        /// 使用Salt加密密码
        /// </summary>
        /// <param name="password">密码明文</param>
        /// <param name="salt">加密Salt</param>
        /// <returns></returns>
        public static string EncryptPassword(string password, string salt)
        {
            using (var sha256 = SHA256.Create())
            {
                var saltedPassword = string.Format("{0}{1}", salt, password);
                var saltedPasswordAsBytes = Encoding.UTF8.GetBytes(saltedPassword);
                return Convert.ToBase64String(sha256.ComputeHash(saltedPasswordAsBytes));
            }
        }
        
        /// <summary>
        /// 验证传入的密码
        /// </summary>
        /// <param name="password">用户密码，一般有用户传入</param>
        /// <param name="passwordHash">hash后的密码，一般存在数据库</param>
        /// <param name="salt">hash所需的salt，一般存储在数据库</param>
        /// <returns></returns>
        public static bool ValidatePassword(string password, string passwordHash, string salt)
        {
            var hash = EncryptPassword(password, salt);
            return string.Equals(hash, passwordHash);
        }
        #endregion

        #region Base64
        /// <summary>
        /// Base64编码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Base64Encrypt(string str)
            => Convert.ToBase64String(Encoding.UTF8.GetBytes(str));

        /// <summary>
        /// Base64解码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Base64Decrypt(string str)
            => Encoding.UTF8.GetString(Convert.FromBase64String(str));
        #endregion

        #region Hash 哈希值
        
        // 哈希值 -- 将任意长度的二进制值映射到较小的固定长度的二进制值, 同样的数据获得的哈希值也相同
        //判断字节数组是否相等
        private static bool ArrayEquals(byte[] a1, byte[] a2)
        {
            if (a1.Length != a2.Length) return false;
            for (int i = 0; i < a1.Length; i++)
            {
                if (a1[i] != a2[i]) return false;
            }
            return true;
        }
        
        /// <summary>
        /// SHA1 哈希值
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static byte[] SHA1Hash(byte[] src)
            => new SHA1Managed().ComputeHash(src);

        /// <summary>
        /// SHA1 哈希值的Base64字符串
        /// </summary>
        /// <param name="src"></param>
        /// <param name="encoding"></param>
        /// <param name="cipherEncode"></param>
        /// <returns>返回Base64字符串</returns>
        public static string SHA1Hash(string src, Encoding encoding = null, CipherEncode cipherEncode = CipherEncode.Base64)
        {
            var bytes = (encoding ?? Encoding.UTF8).GetBytes(src);
            return CipherEncodeString(new SHA1Managed().ComputeHash(bytes), cipherEncode);
        }
        
        /// <summary>
        /// SHA1 哈希值验证
        /// </summary>
        /// <param name="source">原始数据</param>
        /// <param name="hashValue">之前SHA1 的哈希数据</param>
        /// <returns></returns>
        public static bool SHA1Verify(byte[] source, byte[] hashValue)
        {
            var hashSource = SHA1Hash(source);
            return ArrayEquals(hashSource, hashValue);
        }

        /// <summary>
        /// SHA1 哈希值验证
        /// </summary>
        /// <param name="source">原始数据</param>
        /// <param name="hashValue">之前SHA1 的哈希数据</param>
        /// <param name="ignoreCase">忽略大小写</param>
        /// <param name="encoding">字符集</param>
        /// <param name="cipherEncode"></param>
        /// <returns></returns>
        public static bool SHA1Verify(string source, string hashValue, bool ignoreCase = false, Encoding encoding = null, CipherEncode cipherEncode = CipherEncode.Base64)
        {
            var hashSource = SHA1Hash(source, encoding, cipherEncode);
            var s1 = ignoreCase ? hashSource.ToLower() : hashSource;
            var s2 = ignoreCase ? hashValue.ToLower() : hashValue;
            return string.Equals(s1, s2);
        }
        
        /// <summary>
        /// SHA256 哈希值
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static byte[] SHA256Hash(byte[] src)
            => new SHA256Managed().ComputeHash(src);

        /// <summary>
        /// SHA256 哈希值的Base64字符串
        /// </summary>
        /// <param name="src"></param>
        /// <param name="encoding"></param>
        /// <param name="cipherEncode"></param>
        /// <returns>返回Base64字符串</returns>
        public static string SHA256Hash(string src, Encoding encoding = null, CipherEncode cipherEncode = CipherEncode.Base64)
        {
            var bytes = (encoding ?? Encoding.UTF8).GetBytes(src);
            var data = new SHA256Managed().ComputeHash(bytes);
            return CipherEncodeString(data, cipherEncode);
        }
        /// <summary>
        /// SHA256 哈希值验证
        /// </summary>
        /// <param name="source">原始数据</param>
        /// <param name="hashValue">之前SHA1 的哈希数据</param>
        /// <returns></returns>
        public static bool SHA256Verify(byte[] source, byte[] hashValue)
        {
            var hashSource = SHA256Hash(source);
            return ArrayEquals(hashSource, hashValue);
        }

        /// <summary>
        /// SHA256 哈希值验证
        /// </summary>
        /// <param name="source">原始数据</param>
        /// <param name="hashValue">之前SHA1 的哈希数据</param>
        /// <param name="ignoreCase">忽略大小写</param>
        /// <param name="encoding">字符集</param>
        /// <param name="cipherEncode"></param>
        /// <returns></returns>
        public static bool SHA256Verify(string source, string hashValue, bool ignoreCase = false, Encoding encoding = null, CipherEncode cipherEncode = CipherEncode.Base64)
        {
            var hashSource = SHA256Hash(source, encoding, cipherEncode);
            var s1 = ignoreCase ? hashSource.ToLower() : hashSource;
            var s2 = ignoreCase ? hashValue.ToLower() : hashValue;
            return string.Equals(s1, s2);
        }

        /// <summary>
        /// MD5 哈希值
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static byte[] MD5Hash(byte[] src)
            => new MD5CryptoServiceProvider().ComputeHash(src);

        /// <summary>
        /// MD5 哈希值的Base64字符串
        /// </summary>
        /// <param name="src"></param>
        /// <param name="encoding"></param>
        /// <param name="cipherEncode"></param>
        /// <returns>返回Base64字符串</returns>
        public static string MD5Hash(string src, Encoding encoding = null, CipherEncode cipherEncode = CipherEncode.Base64)
        {
            var bytes = (encoding ?? Encoding.UTF8).GetBytes(src);
            var data = new MD5CryptoServiceProvider().ComputeHash(bytes);
            return CipherEncodeString(data, cipherEncode);
        }

        /// <summary>
        /// MD5 哈希值验证
        /// </summary>
        /// <param name="source">原始数据</param>
        /// <param name="hashValue">之前MD5的哈希数据</param>
        /// <returns></returns>
        public static bool MD5Verify(byte[] source, byte[] hashValue)
        {
            var hashSource = MD5Hash(source);
            return ArrayEquals(hashSource, hashValue);
        }

        /// <summary>
        /// MD5 哈希值验证
        /// </summary>
        /// <param name="source">原始数据</param>
        /// <param name="hashValue">之前MD5的哈希数据</param>
        /// <param name="ignoreCase">忽略大小写</param>
        /// <param name="encoding">字符集</param>
        /// <param name="cipherEncode"></param>
        /// <returns></returns>
        public static bool MD5Verify(string source, string hashValue, bool ignoreCase = false, Encoding encoding = null, CipherEncode cipherEncode = CipherEncode.Base64)
        {
            var hashSource = MD5Hash(source, encoding, cipherEncode);
            var s1 = ignoreCase ? hashSource.ToLower() : hashSource;
            var s2 = ignoreCase ? hashValue.ToLower() : hashValue;
            return string.Equals(s1, s2);
        }
        #endregion

        #region Symmetric 对称
        #region DES
        /// <summary>
        /// 构建DES加密类
        /// </summary>
        /// <param name="key">密钥(8byte)</param>
        /// <param name="iv">IV</param>
        /// <param name="encoding">字符集</param>
        /// <returns></returns>
        public static SymmetricProvider CreateDESProvider(string key, byte[] iv = null, Encoding encoding = null)
            => new SymmetricProvider(SymmetricMode.DES, key, iv, encoding);

        /// <summary>
        /// DES加密字节数组
        /// </summary>
        /// <param name="clearBytes">明文字节数组</param>
        /// <param name="key">密钥(8byte)</param>
        /// <returns></returns>
        public static byte[] DESEncrypt(byte[] clearBytes, string key)
            => new SymmetricProvider(SymmetricMode.DES, key).Encrypt(clearBytes);

        /// <summary>
        /// DES加密字符串
        /// </summary>
        /// <param name="clearText">明文</param>
        /// <param name="key">密钥(8byte)</param>
        /// <param name="encoding">字符集</param>
        /// <returns></returns>
        public static string DESEncrypt(string clearText, string key, Encoding encoding = null)
            => new SymmetricProvider(SymmetricMode.DES, key, null, encoding).Encrypt(clearText);

        /// <summary>
        /// DES解密字节数组
        /// </summary>
        /// <param name="cipherBytes">密文字节数组</param>
        /// <param name="key">密钥(8byte)</param>
        /// <returns></returns>
        public static byte[] DESDecrypt(byte[] cipherBytes, string key)
            => new SymmetricProvider(SymmetricMode.DES, key).Decrypt(cipherBytes);

        /// <summary>
        /// DES解密字符串
        /// </summary>
        /// <param name="cipherText">密文</param>
        /// <param name="key">密钥(8byte)</param>
        /// <param name="encoding">字符集</param>
        /// <returns></returns>
        public static string DESDecrypt(string cipherText, string key, Encoding encoding = null)
            => new SymmetricProvider(SymmetricMode.DES, key, null, encoding).Decrypt(cipherText);

        #endregion

        #region TripleDES
        /// <summary>
        /// 构建TripleDES加密类
        /// </summary>
        /// <param name="key">密钥(16byte或24Byte)</param>
        /// <param name="iv">IV</param>
        /// <param name="encoding">字符集</param>
        /// <returns></returns>
        public static SymmetricProvider CreateTripleDESProvider(string key, byte[] iv = null, Encoding encoding = null)
        {
            return new SymmetricProvider(SymmetricMode.TripleDES, key, iv, encoding);
        }
        /// <summary>
        /// TripleDES加密字节数组
        /// </summary>
        /// <param name="clearBytes">明文字节数组</param>
        /// <param name="key">密钥(16byte或24Byte)</param>
        /// <returns></returns>
        public static byte[] TripleDESEncrypt(byte[] clearBytes, string key)
        {
            return new SymmetricProvider(SymmetricMode.TripleDES, key).Encrypt(clearBytes);
        }

        /// <summary>
        /// TripleDES加密字符串
        /// </summary>
        /// <param name="clearText">明文</param>
        /// <param name="key">密钥(16byte或24Byte)</param>
        /// <param name="encoding">字符集</param>
        /// <returns></returns>
        public static string TripleDESEncrypt(string clearText, string key, Encoding encoding = null)
        {
            return new SymmetricProvider(SymmetricMode.TripleDES, key, null, encoding).Encrypt(clearText);
        }
        /// <summary>
        /// TripleDES解密字节数组
        /// </summary>
        /// <param name="cipherBytes">密文字节数组</param>
        /// <param name="key">密钥(16byte或24Byte)</param>
        /// <returns></returns>
        public static byte[] TripleDESDecrypt(byte[] cipherBytes, string key)
        {
            return new SymmetricProvider(SymmetricMode.TripleDES, key).Decrypt(cipherBytes);
        }

        /// <summary>
        /// TripleDES解密字符串
        /// </summary>
        /// <param name="cipherText">密文</param>
        /// <param name="key">密钥(16byte或24Byte)</param>
        /// <param name="encoding">字符集</param>
        /// <returns></returns>
        public static string TripleDESDecrypt(string cipherText, string key, Encoding encoding = null)
        {
            return new SymmetricProvider(SymmetricMode.TripleDES, key, null, encoding).Decrypt(cipherText);
        }

        #endregion

        #region RC2
        /// <summary>
        /// 构建RC2加密类
        /// </summary>
        /// <param name="key">密钥(5byte-16byte)</param>
        /// <param name="iv">IV</param>
        /// <param name="encoding">字符集</param>
        /// <returns></returns>
        public static SymmetricProvider CreateRC2Provider(string key, byte[] iv = null, Encoding encoding = null)
        {
            return new SymmetricProvider(SymmetricMode.RC2, key, iv, encoding);
        }
        /// <summary>
        /// RC2加密字节数组
        /// </summary>
        /// <param name="clearBytes">明文字节数组</param>
        /// <param name="key">密钥(5byte-16byte)</param>
        /// <returns></returns>
        public static byte[] RC2Encrypt(byte[] clearBytes, string key)
        {
            return new SymmetricProvider(SymmetricMode.RC2, key).Encrypt(clearBytes);
        }

        /// <summary>
        /// RC2加密字符串
        /// </summary>
        /// <param name="clearText">明文</param>
        /// <param name="key">密钥(5byte-16byte)</param>
        /// <param name="encoding">字符集</param>
        /// <returns></returns>
        public static string RC2Encrypt(string clearText, string key, Encoding encoding = null)
        {
            return new SymmetricProvider(SymmetricMode.RC2, key, null, encoding).Encrypt(clearText);
        }
        /// <summary>
        /// RC2解密字节数组
        /// </summary>
        /// <param name="cipherBytes">密文字节数组</param>
        /// <param name="key">密钥(5byte-16byte)</param>
        /// <returns></returns>
        public static byte[] RC2Decrypt(byte[] cipherBytes, string key)
        {
            return new SymmetricProvider(SymmetricMode.RC2, key).Decrypt(cipherBytes);
        }

        /// <summary>
        /// RC2解密字符串
        /// </summary>
        /// <param name="cipherText">密文</param>
        /// <param name="key">密钥(5byte-16byte)</param>
        /// <param name="encoding">字符集</param>
        /// <returns></returns>
        public static string RC2Decrypt(string cipherText, string key, Encoding encoding = null)
        {
            return new SymmetricProvider(SymmetricMode.RC2, key, null, encoding).Decrypt(cipherText);
        }

        #endregion

        #region Rijndael
        /// <summary>
        /// 构建Rijndael加密类
        /// </summary>
        /// <param name="key">密钥(5byte-16byte)</param>
        /// <param name="iv">IV</param>
        /// <param name="encoding">字符集</param>
        /// <returns></returns>
        public static SymmetricProvider CreateRijndaelProvider(string key, byte[] iv = null, Encoding encoding = null)
        {
            return new SymmetricProvider(SymmetricMode.Rijndael, key, iv, encoding);
        }
        /// <summary>
        /// RC2加密字节数组
        /// </summary>
        /// <param name="clearBytes">明文字节数组</param>
        /// <param name="key">密钥(16byte，24byte或者32byte)</param>
        /// <returns></returns>
        public static byte[] RijndaelEncrypt(byte[] clearBytes, string key)
        {
            return new SymmetricProvider(SymmetricMode.Rijndael, key).Encrypt(clearBytes);
        }

        /// <summary>
        /// Rijndael加密字符串
        /// </summary>
        /// <param name="clearText">明文</param>
        /// <param name="key">密钥(16byte，24byte或者32byte)</param>
        /// <param name="encoding">字符集</param>
        /// <returns></returns>
        public static string RijndaelEncrypt(string clearText, string key, Encoding encoding = null)
        {
            return new SymmetricProvider(SymmetricMode.Rijndael, key, null, encoding).Encrypt(clearText);
        }
        /// <summary>
        /// Rijndael解密字节数组
        /// </summary>
        /// <param name="cipherBytes">密文字节数组</param>
        /// <param name="key">密钥(16byte，24byte或者32byte)</param>
        /// <returns></returns>
        public static byte[] RijndaelDecrypt(byte[] cipherBytes, string key)
        {
            return new SymmetricProvider(SymmetricMode.Rijndael, key).Decrypt(cipherBytes);
        }

        /// <summary>
        /// Rijndael解密字符串
        /// </summary>
        /// <param name="cipherText">密文</param>
        /// <param name="key">密钥(16byte，24byte或者32byte)</param>
        /// <param name="encoding">字符集</param>
        /// <returns></returns>
        public static string RijndaelDecrypt(string cipherText, string key, Encoding encoding = null)
        {
            return new SymmetricProvider(SymmetricMode.Rijndael, key, null, encoding).Decrypt(cipherText);
        }

        #endregion

        #region AES
        /// <summary>
        /// 构建AES加密类
        /// </summary>
        /// <param name="key">密钥(128byte，192byte或者256byte)</param>
        /// <param name="iv">IV</param>
        /// <param name="encoding">字符集</param>
        /// <returns></returns>
        public static SymmetricProvider CreateAESProvider(string key, byte[] iv = null, Encoding encoding = null)
        {
            return new SymmetricProvider(SymmetricMode.AES, key, iv, encoding);
        }
        /// <summary>
        /// AES加密字节数组
        /// </summary>
        /// <param name="clearBytes">明文字节数组</param>
        /// <param name="key">密钥(128byte，192byte或者256byte)</param>
        /// <returns></returns>
        public static byte[] AESEncrypt(byte[] clearBytes, string key)
        {
            return new SymmetricProvider(SymmetricMode.AES, key).Encrypt(clearBytes);
        }

        /// <summary>
        /// AES加密字符串
        /// </summary>
        /// <param name="clearText">明文</param>
        /// <param name="key">密钥(128byte，192byte或者256byte)</param>
        /// <param name="encoding">字符集</param>
        /// <returns></returns>
        public static string AESEncrypt(string clearText, string key, Encoding encoding = null)
        {
            return new SymmetricProvider(SymmetricMode.AES, key, null, encoding).Encrypt(clearText);
        }
        /// <summary>
        /// AES解密字节数组
        /// </summary>
        /// <param name="cipherBytes">密文字节数组</param>
        /// <param name="key">密钥(128byte，192byte或者256byte)</param>
        /// <returns></returns>
        public static byte[] AESDecrypt(byte[] cipherBytes, string key)
        {
            return new SymmetricProvider(SymmetricMode.AES, key).Decrypt(cipherBytes);
        }

        /// <summary>
        /// AES解密字符串
        /// </summary>
        /// <param name="cipherText">密文</param>
        /// <param name="key">密钥(128byte，192byte或者256byte)</param>
        /// <param name="encoding">字符集</param>
        /// <returns></returns>
        public static string AESDecrypt(string cipherText, string key, Encoding encoding = null)
        {
            return new SymmetricProvider(SymmetricMode.AES, key, null, encoding).Decrypt(cipherText);
        }

        #endregion
        #endregion

        #region Asymmetric 非对称

        #region RSA 可用于加密和签名，一般用公钥加密，不推荐私钥加密

        /// <summary>
        /// 获取Microsoft生成的XML格式的RSA秘钥对.
        /// </summary>
        /// <param name="dwKeySize"></param>
        /// <returns></returns>
        public static RSAKeyPair GenRSAKeyPair(int dwKeySize = 1024)
        {
            //var rsa = new RSACryptoServiceProvider(dwKeySize);
            var rsa = RSA.Create();
            rsa.KeySize = dwKeySize;
            var parameter = rsa.ExportParameters(true);
            return new RSAKeyPair() {
                PrivateKeyXml = rsa.ToXmlString(true),
                PublicKeyXml = rsa.ToXmlString(false),
                ExponentHex = StringUtil.BytesToHex(parameter.Exponent),
                ModulusHex = StringUtil.BytesToHex(parameter.Modulus)
            };
        }

        #region 公钥加密 私钥解密
        /// <summary>
        /// RSA 公钥加密，使用 PKCS#1 1.5 版填充
        /// </summary>
        /// <param name="clearBytes">明文</param>
        /// <param name="publicKey">公钥</param>
        /// <param name="keyMode">指定提供的RSA公钥格式，默认微软的XML格式的RSA公钥</param>
        /// <returns></returns>
        public static byte[] RSAEncrypt(byte[] clearBytes, string publicKey, RSAKeyMode keyMode = RSAKeyMode.MSXml)
        {
            var rsa = CreateRsaProviderFromPublicKey(publicKey, keyMode);
            //return rsa.Encrypt(clearBytes, false);
            return rsa.Encrypt(clearBytes, RSAEncryptionPadding.Pkcs1);
        }
        /// <summary>
        /// RSA 公钥加密，使用 PKCS#1 1.5 版填充。返回base64格式字符串
        /// js可使用jsencrypt.min.js进行openssl加密
        /// </summary>
        /// <param name="clearText">明文</param>
        /// <param name="publicKey">公钥</param>
        /// <param name="keyMode">指定提供的RSA公钥格式，默认微软的XML格式的RSA公钥</param>
        /// <param name="encoding">字符集，默认UTF8</param>
        /// <param name="cipherEncode">指定返回密文的编码格式：base64格式还是hex格式</param>
        /// <returns></returns>
        public static string RSAEncrypt(string clearText, string publicKey, RSAKeyMode keyMode = RSAKeyMode.MSXml, Encoding encoding = null, CipherEncode cipherEncode = CipherEncode.Base64)
        {
            var bytes = (encoding ?? Encoding.UTF8).GetBytes(clearText);
            var data = RSAEncrypt(bytes, publicKey, keyMode);
            return CipherEncodeString(data, cipherEncode);

        }
        /// <summary>
        /// RSA 私钥解密，使用 PKCS#1 1.5 版填充
        /// </summary>
        /// <param name="cipherBytes">密文</param>
        /// <param name="privateKey">私钥</param>
        /// <param name="keyMode">指定提供的RSA私钥格式，默认微软的XML格式的RSA私钥</param>
        /// <returns></returns>
        public static byte[] RSADecrypt(byte[] cipherBytes, string privateKey, RSAKeyMode keyMode = RSAKeyMode.MSXml)
        {
            var rsa = CreateRsaProviderFromPrivateKey(privateKey, keyMode);
            //return rsa.Decrypt(cipherBytes, false);
            return rsa.Decrypt(cipherBytes, RSAEncryptionPadding.Pkcs1);
        }
        /// <summary>
        /// RSA 私钥解密，使用 PKCS#1 1.5 版填充
        /// </summary>
        /// <param name="cipherText">密文(base64格式)</param>
        /// <param name="privateKey">私钥</param>
        /// <param name="keyMode">指定提供的RSA私钥格式，默认微软的XML格式的RSA私钥</param>
        /// <param name="encoding">字符集</param>
        /// <param name="cipherEncode">指定输入密文的编码格式：base64格式还是hex格式</param>
        /// <returns></returns>
        public static string RSADecrypt(string cipherText, string privateKey, RSAKeyMode keyMode = RSAKeyMode.MSXml, Encoding encoding = null, CipherEncode cipherEncode = CipherEncode.Base64)
        {
            byte[] bytes = null;
            switch (cipherEncode)
            {
                case CipherEncode.Base64:
                    bytes = Convert.FromBase64String(cipherText);
                    break;
                case CipherEncode.Hex:
                    bytes = StringUtil.HexToBytes(cipherText);
                    break;
            }
            var ret = RSADecrypt(bytes, privateKey, keyMode);
            return (encoding ?? Encoding.UTF8).GetString(ret);
        }
        #endregion

        #region 私钥加密 公钥解密（不推荐）
        /// <summary>
        /// RSA 私钥加密，使用 PKCS#1 1.5 版填充（不推荐）
        /// </summary>
        /// <param name="clearText">明文</param>
        /// <param name="privateKey">私钥</param>
        /// <param name="keyMode">指定提供的RSA私钥格式，默认微软的XML格式的RSA私钥</param>
        /// <returns></returns>
        public static string RSAEncryptByPrivateKey(string clearText, string privateKey, RSAKeyMode keyMode = RSAKeyMode.MSXml)
        {
            var rsa = CreateRsaProviderFromPrivateKey(privateKey, keyMode);
            var paras = rsa.ExportParameters(true);
            return RSAPrivateKeyEncryptString(clearText, new BigInteger(paras.D), new BigInteger(paras.Modulus));
        }
        /// <summary>
        /// RSA 公钥解密，使用 PKCS#1 1.5 版填充（不推荐）
        /// </summary>
        /// <param name="cipherText">密文</param>
        /// <param name="publicKey">公钥</param>
        /// <param name="keyMode">指定提供的RSA公钥格式，默认微软的XML格式的RSA公钥</param>
        /// <returns></returns>
        public static string RSADecryptByPublicKey(string cipherText, string publicKey, RSAKeyMode keyMode = RSAKeyMode.MSXml)
        {
            var rsa = CreateRsaProviderFromPublicKey(publicKey, keyMode);
            var paras = rsa.ExportParameters(false);
            return RSAPrivateKeyDecryptString(cipherText, new BigInteger(paras.Exponent), new BigInteger(paras.Modulus));
        }
        #endregion

        #region RSA Utils
        private static RSA CreateRsaProviderFromPrivateKey(string privateKey, RSAKeyMode keyMode)
        {
            //RSACryptoServiceProvider ret = new RSACryptoServiceProvider();
            var ret = RSA.Create();
            switch (keyMode)
            {
                case RSAKeyMode.MSXml:
                    ret.FromXmlString(privateKey);
                    break;
                case RSAKeyMode.OpenSSL:
                    var parameters = ParseOpenSSLPrivateKey(privateKey);
                    ret.ImportParameters(parameters);
                    break;
            }
            return ret;
        }
        private static RSA CreateRsaProviderFromPublicKey(string publicKey, RSAKeyMode keyMode)
        {
            //RSACryptoServiceProvider ret = new RSACryptoServiceProvider();
            var ret = RSA.Create();
            switch (keyMode)
            {
                case RSAKeyMode.MSXml:
                    ret.FromXmlString(publicKey);
                    break;
                case RSAKeyMode.OpenSSL:
                    var parameters = ParseOpenSSLPublicKey(publicKey);
                    ret.ImportParameters(parameters);
                    break;
            }
            return ret;
        }
        private static RSAParameters ParseOpenSSLPrivateKey(string privateKey)
        {
            var ret = new RSAParameters();
            privateKey = privateKey.Replace("-----BEGIN RSA PRIVATE KEY-----", "")
                .Replace("-----END RSA PRIVATE KEY-----", "");
            var privateKeyBits = Convert.FromBase64String(privateKey);
            using (BinaryReader reader = new BinaryReader(new MemoryStream(privateKeyBits)))
            {
                byte bt = 0;
                ushort twobytes = 0;
                twobytes = reader.ReadUInt16();
                if (twobytes == 0x8130)
                    reader.ReadByte();
                else if (twobytes == 0x8230)
                    reader.ReadInt16();
                else
                    throw new Exception("Unexpected value read binr.ReadUInt16()");

                twobytes = reader.ReadUInt16();
                if (twobytes != 0x0102)
                    throw new Exception("Unexpected version");

                bt = reader.ReadByte();
                if (bt != 0x00)
                    throw new Exception("Unexpected value read binr.ReadByte()");

                ret.Modulus = reader.ReadBytes(GetIntegerSize(reader));
                ret.Exponent = reader.ReadBytes(GetIntegerSize(reader));
                ret.D = reader.ReadBytes(GetIntegerSize(reader));
                ret.P = reader.ReadBytes(GetIntegerSize(reader));
                ret.Q = reader.ReadBytes(GetIntegerSize(reader));
                ret.DP = reader.ReadBytes(GetIntegerSize(reader));
                ret.DQ = reader.ReadBytes(GetIntegerSize(reader));
                ret.InverseQ = reader.ReadBytes(GetIntegerSize(reader));
            }
            return ret;
        }
        private static int GetIntegerSize(BinaryReader binr)
        {
            byte bt = 0;
            byte lowbyte = 0x00;
            byte highbyte = 0x00;
            int count = 0;
            bt = binr.ReadByte();
            if (bt != 0x02)
                return 0;
            bt = binr.ReadByte();

            if (bt == 0x81)
                count = binr.ReadByte();
            else
                if (bt == 0x82)
            {
                highbyte = binr.ReadByte();
                lowbyte = binr.ReadByte();
                byte[] modint = { lowbyte, highbyte, 0x00, 0x00 };
                count = BitConverter.ToInt32(modint, 0);
            }
            else
            {
                count = bt;
            }

            while (binr.ReadByte() == 0x00)
            {
                count -= 1;
            }
            binr.BaseStream.Seek(-1, SeekOrigin.Current);
            return count;
        }
        private static RSAParameters ParseOpenSSLPublicKey(string publicKey)
        {
            RSAParameters ret = new RSAParameters();
            publicKey = publicKey.Replace("-----BEGIN PUBLIC KEY-----", "")
                .Replace("-----END PUBLIC KEY-----", "");
            // encoded OID sequence for  PKCS #1 rsaEncryption szOID_RSA_RSA = "1.2.840.113549.1.1.1"
            byte[] SeqOID = { 0x30, 0x0D, 0x06, 0x09, 0x2A, 0x86, 0x48, 0x86, 0xF7, 0x0D, 0x01, 0x01, 0x01, 0x05, 0x00 };
            byte[] x509key;
            byte[] seq = new byte[15];
            int x509size;

            x509key = Convert.FromBase64String(publicKey);
            x509size = x509key.Length;

            // ---------  Set up stream to read the asn.1 encoded SubjectPublicKeyInfo blob  ------
            using (MemoryStream stream = new MemoryStream(x509key))
            {
                using (BinaryReader reader = new BinaryReader(stream))  //wrap Memory Stream with BinaryReader for easy reading
                {
                    byte bt = 0;
                    ushort twobytes = 0;

                    twobytes = reader.ReadUInt16();
                    if (twobytes == 0x8130) //data read as little endian order (actual data order for Sequence is 30 81)
                        reader.ReadByte();    //advance 1 byte
                    else if (twobytes == 0x8230)
                        reader.ReadInt16();   //advance 2 bytes
                    else
                        throw new Exception("解析OpenSSL PublicKey时出错，请检查PublicKey格式是否正确。");

                    seq = reader.ReadBytes(15);       //read the Sequence OID
                    if (!CompareBytearrays(seq, SeqOID))    //make sure Sequence for OID is correct
                        throw new Exception("解析OpenSSL PublicKey时出错，请检查PublicKey格式是否正确。");

                    twobytes = reader.ReadUInt16();
                    if (twobytes == 0x8103) //data read as little endian order (actual data order for Bit String is 03 81)
                        reader.ReadByte();    //advance 1 byte
                    else if (twobytes == 0x8203)
                        reader.ReadInt16();   //advance 2 bytes
                    else
                        throw new Exception("解析OpenSSL PublicKey时出错，请检查PublicKey格式是否正确。");

                    bt = reader.ReadByte();
                    if (bt != 0x00)     //expect null byte next
                        throw new Exception("解析OpenSSL PublicKey时出错，请检查PublicKey格式是否正确。");

                    twobytes = reader.ReadUInt16();
                    if (twobytes == 0x8130) //data read as little endian order (actual data order for Sequence is 30 81)
                        reader.ReadByte();    //advance 1 byte
                    else if (twobytes == 0x8230)
                        reader.ReadInt16();   //advance 2 bytes
                    else
                        throw new Exception("解析OpenSSL PublicKey时出错，请检查PublicKey格式是否正确。");

                    twobytes = reader.ReadUInt16();
                    byte lowbyte = 0x00;
                    byte highbyte = 0x00;

                    if (twobytes == 0x8102) //data read as little endian order (actual data order for Integer is 02 81)
                        lowbyte = reader.ReadByte();  // read next bytes which is bytes in modulus
                    else if (twobytes == 0x8202)
                    {
                        highbyte = reader.ReadByte(); //advance 2 bytes
                        lowbyte = reader.ReadByte();
                    }
                    else
                        throw new Exception("解析OpenSSL PublicKey时出错，请检查PublicKey格式是否正确。");
                    byte[] modint = { lowbyte, highbyte, 0x00, 0x00 };   //reverse byte order since asn.1 key uses big endian order
                    int modsize = BitConverter.ToInt32(modint, 0);

                    int firstbyte = reader.PeekChar();
                    if (firstbyte == 0x00)
                    {   //if first byte (highest order) of modulus is zero, don't include it
                        reader.ReadByte();    //skip this null byte
                        modsize -= 1;   //reduce modulus buffer size by 1
                    }

                    byte[] modulus = reader.ReadBytes(modsize);   //read the modulus bytes

                    if (reader.ReadByte() != 0x02)            //expect an Integer for the exponent data
                        throw new Exception("解析OpenSSL PublicKey时出错，请检查PublicKey格式是否正确。");
                    int expbytes = (int)reader.ReadByte();        // should only need one byte for actual exponent data (for all useful values)
                    byte[] exponent = reader.ReadBytes(expbytes);

                    ret.Modulus = modulus;
                    ret.Exponent = exponent;
                    return ret;
                }
            }
        }
        private static bool CompareBytearrays(byte[] a, byte[] b)
        {
            if (a.Length != b.Length)
                return false;
            int i = 0;
            foreach (byte c in a)
            {
                if (c != b[i])
                    return false;
                i++;
            }
            return true;
        }
        // 私钥加密
        private static string RSAPrivateKeyEncryptString(string source, BigInteger d, BigInteger n)
        {
            int len = source.Length;
            int len1 = 0;
            int blockLen = 0;
            if ((len % 128) == 0)
                len1 = len / 128;
            else
                len1 = len / 128 + 1;
            string block = "";
            string temp = "";
            for (int i = 0; i < len1; i++)
            {
                if (len >= 128)
                    blockLen = 128;
                else
                    blockLen = len;
                block = source.Substring(i * 128, blockLen);
                byte[] oText = System.Text.Encoding.Default.GetBytes(block);
                BigInteger biText = new BigInteger(oText);
                BigInteger biEnText = biText.modPow(d, n);
                string temp1 = biEnText.ToHexString();
                temp += temp1;
                len -= blockLen;
            }
            return temp;
        }
        // 私钥加密
        private static string RSAPrivateKeyDecryptString(string source, BigInteger e, BigInteger n)
        {
            int len = source.Length;
            int len1 = 0;
            int blockLen = 0;
            if ((len % 256) == 0)
                len1 = len / 256;
            else
                len1 = len / 256 + 1;
            string block = "";
            string temp = "";
            for (int i = 0; i < len1; i++)
            {
                if (len >= 256)
                    blockLen = 256;
                else
                    blockLen = len;
                block = source.Substring(i * 256, blockLen);
                BigInteger biText = new BigInteger(block, 16);
                BigInteger biEnText = biText.modPow(e, n);
                string temp1 = System.Text.Encoding.Default.GetString(biEnText.getBytes());
                temp += temp1;
                len -= blockLen;
            }
            return temp;
        }
        #endregion // RSA Utils

        #region SignData
        /// <summary>
        /// RSA 使用指定的哈希算法计算指定字节数组的哈希值，并对计算所得的哈希值签名（Base64格式）。
        /// 默认使用的哈希算法：SHA1 填充方式：PKCS1
        /// </summary>
        /// <param name="source">原文</param>
        /// <param name="privateKey">私钥</param>
        /// <param name="keyMode">指定提供的RSA私钥格式，默认微软的XML格式的RSA私钥</param>
        /// <param name="hashName">用于创建哈希值的哈希算法</param>
        /// <param name="encoding">字符集</param>
        /// <returns></returns>
        public static string RSASignData(string source, string privateKey, RSAKeyMode keyMode = RSAKeyMode.MSXml, HashAlgorithmName hashName = default(HashAlgorithmName), Encoding encoding= null)
        {
            var rsa = CreateRsaProviderFromPrivateKey(privateKey, keyMode);
            encoding = encoding ?? Encoding.UTF8;
            hashName = (hashName == default(HashAlgorithmName)) ? HashAlgorithmName.SHA1 : hashName;
            var sourceBytes = encoding.GetBytes(source);
            return Convert.ToBase64String(rsa.SignData(sourceBytes, hashName, RSASignaturePadding.Pkcs1));
        }
        /// <summary>
        /// RSA 使用公钥确定签名中的哈希值并将其与所提供数据的哈希值进行比较验证数字签名是否有效。
        /// 默认使用的哈希算法：SHA1 填充方式：PKCS1
        /// </summary>
        /// <param name="source">原文</param>
        /// <param name="sign">Base64格式的签名</param>
        /// <param name="publicKey">公钥</param>
        /// <param name="keyMode">指定提供的RSA公钥格式，默认微软的XML格式的RSA公钥</param>
        /// <param name="hashName">用于创建哈希值的哈希算法</param>
        /// <param name="encoding">字符集</param>
        /// <returns></returns>
        public static bool RSAVerifyData(string source, string sign, string publicKey, RSAKeyMode keyMode = RSAKeyMode.MSXml, HashAlgorithmName hashName = default(HashAlgorithmName), Encoding encoding = null)
        {
            var rsa = CreateRsaProviderFromPublicKey(publicKey, keyMode);
            encoding = encoding ?? Encoding.UTF8;
            hashName = (hashName == default(HashAlgorithmName)) ? HashAlgorithmName.SHA1 : hashName;
            var sourceBytes = encoding.GetBytes(source);
            var signBytes = Convert.FromBase64String(sign);
            return rsa.VerifyData(sourceBytes, signBytes, hashName, RSASignaturePadding.Pkcs1);
        }
        #endregion

        #endregion // RSA

        #endregion // Asymmetric
    }

    /// <summary>
    /// RSA秘钥对信息
    /// </summary>
    public class RSAKeyPair
    {
        /// <summary>
        /// RSA 对象的密钥的 XML 字符串
        /// </summary>
        public string PrivateKeyXml { get; set; }
        /// <summary>
        /// 公钥XML格式
        /// </summary>
        public string PublicKeyXml { get; set; }
        /// <summary>
        /// RSA 算法的 Exponent 参数Hex表示
        /// </summary>
        public string ExponentHex { get; set; }
        /// <summary>
        /// RSA 算法的 Modulus 参数Hex表示
        /// </summary>
        public string ModulusHex { get; set; }
        /// <summary>
        /// 公钥Hex表示，ExponentHex + "," + ModulusHex
        /// </summary>
        public string PublicKeyHex { get { return ExponentHex + "," + ModulusHex; } }
    }

    /// <summary>
    /// 密文的编码格式
    /// </summary>
    public enum CipherEncode
    {
        /// <summary>
        /// 密文采用Base64编码
        /// </summary>
        Base64,
        /// <summary>
        /// 密文采用16进制字符串处理
        /// </summary>
        Hex,
        Bit16Upper,
        Bit16Lower,
        Bit32Upper,
        Bit32Lower,
    }
}
