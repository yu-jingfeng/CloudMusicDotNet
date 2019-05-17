using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace CloudMusicDotNet.Commons
{
    public class CryptoService : ICryptoService
    {
        string presetKey = "0CoJUm6Qyw8W8jud";
        string linuxapiKey = "rFgB&h#%2?^eDg:Q";
        string iv = "0102030405060708";
        string publicKey = "MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQDgtQn2JZ34ZC28NWYpAUd98iZ37BUrX/aKzmFbt7clFSs6sXqHauqKWqdtLkF2KexO40H1YTX8z2lSgBBOAxLsvaklV8k4cBFK9snQXE9/DDaFt6Rr7iVZMldczhC0JNgTz+SHXT6CBHuX3e9SdB1Ua44oncaTWz7OBGLbCiK45wIDAQAB";


        public string GetWeapiCrypto(string data)
        {
            string secretKey = GetRandomString(16);
            string temp = Convert.ToBase64String(CryptoUtil.AesEncrypt(data, presetKey, iv, CipherMode.CBC));
            string @params = Convert.ToBase64String(CryptoUtil.AesEncrypt(temp, secretKey, iv, CipherMode.CBC));

            string encSecKey = BitConverter.ToString(CryptoUtil.RsaEncrypt(new string(secretKey.Reverse().ToArray()), publicKey)).Replace("-", "");

            return $"params={HttpUtility.UrlEncode(@params)}&encSecKey={encSecKey}";
        }

        public string GetLinuxapiCrypto(string data)
        {
            var bytes = CryptoUtil.AesEncrypt(data, linuxapiKey, "", CipherMode.ECB);

            string eparams = BitConverter.ToString(bytes).ToUpper();

            return $"eparams={eparams}";
        }

        /// <summary>
        /// 生成随机字符串
        /// </summary>
        /// <param name="length">字符串长度</param>
        /// <returns></returns>
        private string GetRandomString(int length)
        {
            string originalStr = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            StringBuilder randomStr = new StringBuilder();

            Random rnd = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < length; i++)
            {
                randomStr.Append(originalStr[rnd.Next(0, originalStr.Length)].ToString());
            }

            return randomStr.ToString();
        }
    }
}
