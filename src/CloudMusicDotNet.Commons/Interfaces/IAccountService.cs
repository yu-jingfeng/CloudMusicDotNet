using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CloudMusicDotNet.Commons.Interfaces
{
    public interface IAccountService
    {
        /// <summary>
        /// 邮箱登录
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> Login(string data);

        /// <summary>
        /// 手机登录
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> PhoneLogin(string data);

        /// <summary>
        /// 登录刷新
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> Refresh(string data);

        /// <summary>
        /// 登录状态
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> Status(string data);

        /// <summary>
        /// 发送验证码
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> SentCode(string data);

        /// <summary>
        /// 校验验证码
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> VerifyCode(string data);

        /// <summary>
        /// 注册账号(修改密码)
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> Register(string data);

        /// <summary>
        /// 退出登录
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> Logout(string data);
    }
}
