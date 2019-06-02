using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.OpenSsl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace CloudMusicDotNet.Commons
{
    /// <summary>
    /// 密码工具
    /// </summary>
    public static class CryptoUtil
    {
        /// <summary>
        /// AES加密
        /// </summary>
        /// <param name="plainData">明文数据</param>
        /// <param name="key">密钥</param>
        /// <param name="iv">初始化向量(initialization vector)</param>
        /// <returns></returns>
        public static byte[] AesEncrypt(string plainData, string key, string iv, CipherMode cipherMode)
        {
            byte[] toEncryptArray = Encoding.UTF8.GetBytes(plainData);
            var rm = new RijndaelManaged();
            rm.Key = Encoding.UTF8.GetBytes(key);
            rm.Mode = cipherMode;
            rm.Padding = PaddingMode.PKCS7;

            if (!string.IsNullOrEmpty(iv))
                rm.IV = Encoding.UTF8.GetBytes(iv);

            ICryptoTransform cTransform = rm.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            return resultArray;
        }


        /// <summary>
        /// RSA加密(NoPadding)
        /// </summary>
        /// <param name="plainData">明文数据</param>
        /// <param name="publicKey">公钥</param>
        /// <returns></returns>
        public static byte[] RsaEncrypt(string plainData, string publicKey)
        {
            //  analogue of Java:
            //  Cipher rsa = Cipher.getInstance("RSA/ECB/nopadding");
            var bytesToEncrypt = Encoding.UTF8.GetBytes(plainData);
            var buffer = new byte[128 - bytesToEncrypt.Length];
            bytesToEncrypt = buffer.Concat(bytesToEncrypt).ToArray();

            var encryptEngine = new RsaEngine(); // new Pkcs1Encoding (new RsaEngine());

            using (var txtreader = new StringReader("-----BEGIN PUBLIC KEY-----\n" + publicKey + "\n-----END PUBLIC KEY-----"))
            {
                var keyParameter = (AsymmetricKeyParameter)new PemReader(txtreader).ReadObject();

                encryptEngine.Init(true, keyParameter);
            }

            var encrypted = encryptEngine.ProcessBlock(bytesToEncrypt, 0, bytesToEncrypt.Length);
            return encrypted;
        }
    }
}
