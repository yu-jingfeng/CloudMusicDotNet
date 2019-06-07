using CloudMusicDotNet.Commons.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CloudMusicDotNet.Commons.MusicServices
{
    /// <summary>
    /// 账户相关服务
    /// </summary>
    public class AccountService : IAccountService
    {
        private readonly IRequestService _requestService;

        public AccountService(IRequestService requestService)
        {
            _requestService = requestService;
        }

        /// <summary>
        /// 邮箱登录
        /// </summary>
        /// <param name="email">163 网易邮箱</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public Task<string> Login(string email, string password)
        {
            var json = new JObject
            {
                { "email", email },
                { "password", EncryptWithMD5(password) },
                { "rememberLogin", "true" }
            };

            return _requestService.Request("Login", json.ToString());
        }

        /// <summary>
        /// 手机登录
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <param name="password">密码</param>
        /// <param name="countrycode">国家码，用于国外手机号登陆，例如美国传入：1</param>
        /// <returns></returns>
        public Task<string> PhoneLogin(string phone, string password, string countrycode)
        {
            var json = new JObject
            {
                { "phone", phone },
                { "password", EncryptWithMD5(password) },
                { "countrycode", countrycode }
            };

            return _requestService.Request("PhoneLogin", json.ToString());
        }

        /// <summary>
        /// 注册账号(修改密码)
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <param name="captcha">验证码</param>
        /// <param name="password">密码</param>
        /// <param name="nickname">昵称</param>
        /// <returns></returns>
        public Task<string> Register(string phone, string captcha, string password, string nickname)
        {
            var json = new JObject
            {
                { "phone", phone },
                { "captcha", captcha },
                { "password", EncryptWithMD5(password) },
                { "nickname", nickname }
            };

            return _requestService.Request("Register", json.ToString());
        }

        /// <summary>
        /// 发送验证码
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <param name="ctcode">国家区号,默认86即中国</param>
        /// <returns></returns>
        public Task<string> SentCaptcha(string phone, string ctcode = "86")
        {
            var json = new JObject
            {
                { "phone", phone },
                { "ctcode", ctcode }
            };

            return _requestService.Request("SentCaptcha", json.ToString());
        }

        /// <summary>
        /// 校验验证码
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <param name="captcha">验证码</param>
        /// <param name="ctcode">国家区号,默认86即中国</param>
        /// <returns></returns>
        public Task<string> VerifyCaptcha(string phone, string captcha, string ctcode = "86")
        {
            var json = new JObject
            {
                { "phone", phone },
                { "captcha", captcha },
                { "ctcode", ctcode }
            };

            return _requestService.Request("VerifyCaptcha", json.ToString());
        }

        /// <summary>
        /// 登录状态
        /// </summary>
        /// <returns></returns>
        public Task<string> Status()
        {
            return _requestService.Request("Status", "{}");
        }

        /// <summary>
        /// 登录刷新
        /// </summary>
        /// <returns></returns>
        public Task<string> Refresh()
        {
            return _requestService.Request("Refresh", "{}");
        }

        /// <summary>
        /// 退出登录
        /// </summary>
        /// <returns></returns>
        public Task<string> Logout()
        {
            return _requestService.Request("Logout", "{}");
        }

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        private string EncryptWithMD5(string source)
        {
            byte[] sor = Encoding.UTF8.GetBytes(source);
            var md5 = MD5.Create();
            byte[] result = md5.ComputeHash(sor);
            StringBuilder strbul = new StringBuilder(40);
            for (int i = 0; i < result.Length; i++)
            {
                strbul.Append(result[i].ToString("x2"));//加密结果"x2"结果为32位,"x3"结果为48位,"x4"结果为64位
            }
            return strbul.ToString();
        }
    }
}
