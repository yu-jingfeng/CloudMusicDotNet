using CloudMusicDotNet.Api.Dto;
using CloudMusicDotNet.Api.Infrastructure;
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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IDtoParseService _dtoParseService;

        public UserController(
            IUserService userService,
            IDtoParseService dtoParseService)
        {
            _userService = userService;
            _dtoParseService = dtoParseService;
        }

        /// <summary>
        /// 用户详情
        /// </summary>
        /// <param name="uid">用户id</param>
        /// <returns></returns>
        [HttpGet("Detail")]
        public async Task<IActionResult> Detail(string uid)
        {
            var result = await _userService.Detail(uid);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 用户电台节目
        /// </summary>
        /// <param name="uid">用户id</param>
        /// <param name="limit">数据条数</param>
        /// <param name="offset">偏移量</param>
        /// <returns></returns>
        [HttpGet("Dj")]
        public async Task<IActionResult> Dj(string uid, int limit = 30, int offset = 0)
        {
            var result = await _userService.Dj(uid, limit, offset);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 用户动态
        /// </summary>
        /// <param name="uid">用户id</param>
        /// <param name="limit">数据条数</param>
        /// <param name="time">返回数据的lasttime,默认-1,传入上一次返回结果的 lasttime,将会返回下一页的数据</param>
        /// <returns></returns>
        [HttpGet("Event")]
        public async Task<IActionResult> Event(string uid, int limit = 30, long time = -1)
        {
            var result = await _userService.Event(uid, limit, time);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 关注TA的人(粉丝)
        /// </summary>
        /// <param name="uid">用户id</param>
        /// <param name="limit">数据条数</param>
        /// <param name="offset">偏移量</param>
        /// <returns></returns>
        [HttpGet("Followers")]
        public async Task<IActionResult> Followers(string uid, int limit = 30, int offset = 0)
        {
            var result = await _userService.Followers(uid, limit, offset);

            return Content(result, "application/json");
        }

        /// <summary>
        /// TA关注的人(关注)
        /// </summary>
        /// <param name="uid">用户id</param>
        /// <param name="limit">数据条数</param>
        /// <param name="offset">偏移量</param>
        /// <returns></returns>
        [HttpGet("Followeds")]
        public async Task<IActionResult> Followeds(string uid, int limit = 30, int offset = 0)
        {
            var result = await _userService.Followeds(uid, limit, offset);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 关注/取消关注用户
        /// </summary>
        /// <param name="uid">用户 id</param>
        /// <param name="t">1为关注,其他为取消关注</param>
        /// <returns></returns>
        [HttpGet("Follow")]
        public async Task<IActionResult> Follow(string uid, int t)
        {
            var result = await _userService.Follow(uid, t);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 用户歌单
        /// </summary>
        /// <param name="uid">用户id</param>
        /// <param name="limit">数据条数</param>
        /// <param name="offset">偏移量</param>
        /// <returns></returns>
        [HttpGet("Playlist")]
        public async Task<IActionResult> Playlist(string uid, int limit = 30, int offset = 0)
        {
            var result = await _userService.Playlist(uid, limit, offset);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 听歌排行
        /// </summary>
        /// <param name="uid">用户id</param>
        /// <param name="type">1: 最近一周, 0: 所有时间</param>
        /// <returns></returns>
        [HttpGet("Record")]
        public async Task<IActionResult> Record(string uid, int type = 1)
        {
            var result = await _userService.Record(uid, type);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 收藏计数
        /// </summary>
        /// <returns></returns>
        [HttpGet("SubCount")]
        public async Task<IActionResult> SubCount()
        {
            var result = await _userService.SubCount();

            return Content(result, "application/json");
        }

        /// <summary>
        /// 编辑用户信息
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        [HttpPost("Update")]
        public async Task<IActionResult> Update(UserInfoDto userInfo)
        {
            var result = await _userService.Update(userInfo.Nickname, userInfo.Gender, userInfo.Birthday, userInfo.Province, 
                                                   userInfo.City, userInfo.Signature, userInfo.AvatarImgId);

            return Content(result, "application/json");
        }
    }
}
