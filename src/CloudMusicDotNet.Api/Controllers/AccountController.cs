using CloudMusicDotNet.Api.Dto;
using CloudMusicDotNet.Commons.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudMusicDotNet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(
            IAccountService accountService)
        {
            _accountService = accountService;
        }

        /// <summary>
        /// 邮箱登录
        /// </summary>
        /// <returns></returns>
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var result = await _accountService.Login(loginDto.Email, loginDto.Password);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 手机登录
        /// </summary>
        /// <param name="loginDto"></param>
        /// <returns></returns>
        [HttpPost("PhoneLogin")]
        public async Task<IActionResult> PhoneLogin(PhoneLoginDto loginDto)
        {
            var result = await _accountService.PhoneLogin(loginDto.Phone, loginDto.Password, loginDto.Countrycode);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="registerDto"></param>
        /// <returns></returns>
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var result = await _accountService.Register(registerDto.Phone, registerDto.Captcha, registerDto.Password, registerDto.Nickname);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 发送验证码
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <param name="ctcode">国家区号,默认86即中国</param>
        /// <returns></returns>
        [HttpPost("SentCaptcha")]
        public async Task<IActionResult> SentCaptcha(string phone, string ctcode = "86")
        {
            var result = await _accountService.SentCaptcha(phone, ctcode);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 校验验证码
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <param name="captcha">验证码</param>
        /// <param name="ctcode">国家区号,默认86即中国</param>
        /// <returns></returns>
        [HttpPost("VerifyCaptcha")]
        public async Task<IActionResult> VerifyCaptcha(string phone, string captcha, string ctcode = "86")
        {
            var result = await _accountService.VerifyCaptcha(phone, captcha, ctcode);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 登录状态
        /// </summary>
        /// <returns></returns>
        [HttpPost("Status")]
        public async Task<IActionResult> Status()
        {
            var result = await _accountService.Status();

            return Content(result, "application/json");
        }

        /// <summary>
        /// 登录刷新
        /// </summary>
        /// <returns></returns>
        [HttpPost("Refresh")]
        public async Task<IActionResult> Refresh()
        {
            var result = await _accountService.Refresh();

            return Content(result, "application/json");
        }

        /// <summary>
        /// 退出登录
        /// </summary>
        /// <returns></returns>
        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            var result = await _accountService.Logout();

            return Content(result, "application/json");
        }
    }
}
