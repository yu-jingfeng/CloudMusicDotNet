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
    public class CloudController : ControllerBase
    {
        private readonly ICloudService _cloudService;
        private readonly IDtoParseService _dtoParseService;

        public CloudController(
            ICloudService cloudService,
            IDtoParseService dtoParseService)
        {
            _cloudService = cloudService;
            _dtoParseService = dtoParseService;
        }

        /// <summary>
        /// 获取云盘数据,获取的数据没有对应url,需要调用/song/url获取url
        /// </summary>
        /// <param name="limit">数据条数</param>
        /// <param name="offset">偏移量</param>
        /// <returns></returns>
        [HttpGet("")]
        public async Task<IActionResult> List(int limit = 30, int offset = 0)
        {
            var param = new { limit, offset };
            var data = _dtoParseService.Parse(param);
            var result = await _cloudService.List(data);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 云盘数据详情
        /// </summary>
        /// <param name="id">云盘歌曲id</param>
        /// <returns></returns>
        [HttpGet("Detail/{id}")]
        public async Task<IActionResult> Detail(string id)
        {
            var param = new { songIds = id };
            var data = _dtoParseService.Parse(param);
            var result = await _cloudService.Detail(data);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 云盘歌曲删除
        /// </summary>
        /// <param name="id">云盘歌曲id</param>
        /// <returns></returns>
        [HttpGet("Del/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var param = new { songIds = id };
            var data = _dtoParseService.Parse(param);
            var result = await _cloudService.Delete(data);

            return Content(result, "application/json");
        }
    }
}
