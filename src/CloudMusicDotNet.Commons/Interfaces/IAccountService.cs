using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CloudMusicDotNet.Commons.Interfaces
{
    /// <summary>
    /// 账户相关服务
    /// </summary>
    public interface IAccountService
    {
        /// <summary>
        /// 邮箱登录
        /// </summary>
        /// <param name="email">163 网易邮箱</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        Task<string> Login(string email, string password);

        /// <summary>
        /// 手机登录
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <param name="password">密码</param>
        /// <param name="countrycode">国家码，用于国外手机号登陆，例如美国传入：1</param>
        /// <returns></returns>
        Task<string> PhoneLogin(string phone, string password, string countrycode);

        /// <summary>
        /// 登录刷新
        /// </summary>
        /// <returns></returns>
        Task<string> Refresh();

        /// <summary>
        /// 登录状态
        /// </summary>
        /// <returns></returns>
        Task<string> Status();

        /// <summary>
        /// 发送验证码
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <param name="ctcode">国家区号,默认86即中国</param>
        /// <returns></returns>
        Task<string> SentCaptcha(string phone, string ctcode = "86");

        /// <summary>
        /// 校验验证码
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <param name="captcha">验证码</param>
        /// <param name="ctcode">国家区号,默认86即中国</param>
        /// <returns></returns>
        Task<string> VerifyCaptcha(string phone, string captcha, string ctcode = "86");

        /// <summary>
        /// 注册账号(修改密码)
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <param name="captcha">验证码</param>
        /// <param name="password">密码</param>
        /// <param name="nickname">昵称</param>
        /// <returns></returns>
        Task<string> Register(string phone, string captcha, string password, string nickname);

        /// <summary>
        /// 退出登录
        /// </summary>
        /// <returns></returns>
        Task<string> Logout();
    }
}
