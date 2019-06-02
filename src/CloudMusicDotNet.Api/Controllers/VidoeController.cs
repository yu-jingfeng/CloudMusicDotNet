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
    public class VidoeController : ControllerBase
    {
        private readonly IVideoService _videoService;
        private readonly IDtoParseService _dtoParseService;

        public VidoeController(
            IVideoService videoService,
            IDtoParseService dtoParseService)
        {
            _videoService = videoService;
            _dtoParseService = dtoParseService;
        }

        /// <summary>
        /// 视频详情
        /// </summary>
        /// <param name="id">视频id</param>
        /// <returns></returns>
        [HttpGet("Detail/{id}")]
        public async Task<IActionResult> Detail(string id)
        {
            var param = new { id };
            var data = _dtoParseService.Parse(param);
            var result = await _videoService.Detail(data);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 获取视频标签下的视频
        /// </summary>
        /// <param name="groupId">videoGroup的id</param>
        /// <param name="offset">偏移</param>
        /// <param name="res">分辨率</param>
        /// <returns></returns>
        [HttpGet("Group/{groupId}")]
        public async Task<IActionResult> Group(string groupId, int offset = 0, int res = 1080)
        {
            var param = new { groupId, offset, resolution = res, needUrl = true };
            var data = _dtoParseService.Parse(param);
            var result = await _videoService.Group(data);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 收藏与取消收藏视频
        /// </summary>
        /// <param name="id">视频id</param>
        /// <param name="t">操作: 1 收藏 ,0 取消收藏</param>
        /// <returns></returns>
        [HttpGet("Sub")]
        public async Task<IActionResult> Sub(string id, int t)
        {
            var param = new { id };
            var data = _dtoParseService.Parse(param);
            var result = await _videoService.Sub(data, t);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 视频链接
        /// </summary>
        /// <param name="id">视频id</param>
        /// <param name="res">分辨率</param>
        /// <returns></returns>
        [HttpGet("Url")]
        public async Task<IActionResult> Link(string id, int res = 1080)
        {
            var param = new { ids = $"[\"{id}\"]", resolution = res };
            var data = _dtoParseService.Parse(param);
            var result = await _videoService.Url(data);

            return Content(result, "application/json");
        }
    }
}
