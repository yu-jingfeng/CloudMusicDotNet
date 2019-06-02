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
    public class ToplistController : ControllerBase
    {
        private readonly IToplistService _toplistService;
        private readonly IDtoParseService _dtoParseService;

        public ToplistController(
            IToplistService toplistService,
            IDtoParseService dtoParseService)
        {
            _toplistService = toplistService;
            _dtoParseService = dtoParseService;
        }

        /// <summary>
        /// 歌手榜
        /// </summary>
        /// <returns></returns>
        [HttpGet("Artist")]
        public async Task<IActionResult> Artist()
        {
            var param = new { type = 1, limit = 100, offset = 0, total = true };
            var data = _dtoParseService.Parse(param);
            var result = await _toplistService.Artist(data);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 所有榜单内容摘要
        /// </summary>
        /// <returns></returns>
        [HttpGet("Detail")]
        public async Task<IActionResult> Detail()
        {
            var data = _dtoParseService.Parse(null);
            var result = await _toplistService.Detail(data);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 所有榜单内容摘要
        /// </summary>
        /// <returns></returns>
        [HttpGet("")]
        public async Task<IActionResult> All()
        {
            var data = _dtoParseService.Parse(null);
            var result = await _toplistService.All(data);

            return Content(result, "application/json");
        }
    }
}
