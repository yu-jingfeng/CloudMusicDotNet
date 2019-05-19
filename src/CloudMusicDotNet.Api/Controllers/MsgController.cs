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
    public class MsgController : ControllerBase
    {
        private readonly IMsgService _msgService;
        private readonly IDtoParseService _dtoParseService;

        public MsgController(
            IMsgService msgService,
            IDtoParseService dtoParseService)
        {
            _msgService = msgService;
            _dtoParseService = dtoParseService;
        }

        /// <summary>
        /// 评论消息
        /// </summary>
        /// <param name="uid">用户id</param>
        /// <param name="limit">数据条数</param>
        /// <param name="beforeTime">分页参数,取上一页最后一个歌单的 updateTime 获取下一页数据</param>
        /// <returns></returns>
        [HttpGet("Comments")]
        public async Task<IActionResult> Comments(string uid, int limit = 30, string beforeTime = "-1")
        {
            var param = new { uid, limit, beforeTime };
            var data = _dtoParseService.Parse(param);
            var result = await _msgService.Comments(data, uid);

            return Content(result, "application/json");
        }

        /// <summary>
        /// @我
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpGet("Forwards")]
        public async Task<IActionResult> Forwards([FromQuery]SimpleDto dto)
        {
            var data = _dtoParseService.Parse(dto);
            var result = await _msgService.Forwards(data);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 通知消息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpGet("Notices")]
        public async Task<IActionResult> Notices([FromQuery]SimpleDto dto)
        {
            var data = _dtoParseService.Parse(dto);
            var result = await _msgService.Notices(data);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 私信消息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpGet("Private")]
        public async Task<IActionResult> Private([FromQuery]SimpleDto dto)
        {
            var data = _dtoParseService.Parse(dto);
            var result = await _msgService.Private(data);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 私信内容(登陆后调用此接口 , 可获取私信内容)
        /// </summary>
        /// <param name="uid">用户id</param>
        /// <param name="limit">数据条数</param>
        /// <param name="offset">偏移数量</param>
        /// <returns></returns>
        [HttpGet("Private/History")]
        public async Task<IActionResult> PrivateHistory(string uid, int limit = 20, int offset = 0)
        {
            var param = new { userId = uid, limit, offset, total = "true" };
            var data = _dtoParseService.Parse(param);
            var result = await _msgService.PrivateHistory(data);

            return Content(result, "application/json");
        }
    }
}
