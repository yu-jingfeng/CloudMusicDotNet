using CloudMusicDotNet.Api.Infrastructure;
using CloudMusicDotNet.Commons.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudMusicDotNet.Api.Controllers
{
    /// <summary>
    /// 个性化推荐服务
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalizedController : ControllerBase
    {
        private readonly IPersonalizedService _personalizedService;
        private readonly IDtoParseService _dtoParseService;

        public PersonalizedController(
            IPersonalizedService personalizedService,
            IDtoParseService dtoParseService)
        {
            _personalizedService = personalizedService;
            _dtoParseService = dtoParseService;
        }

        /// <summary>
        /// 推荐电台
        /// </summary>
        /// <returns></returns>
        [HttpGet("DjProgram")]
        public async Task<IActionResult> DjProgram()
        {
            var data = _dtoParseService.Parse(null);
            var result = await _personalizedService.DjProgram(data);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 推荐MV
        /// </summary>
        /// <returns></returns>
        [HttpGet("Mv")]
        public async Task<IActionResult> Mv()
        {
            var data = _dtoParseService.Parse(null);
            var result = await _personalizedService.Mv(data);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 推荐新歌
        /// </summary>
        /// <returns></returns>
        [HttpGet("NewSong")]
        public async Task<IActionResult> NewSong()
        {
            var param = new { type = "recommend" };
            var data = _dtoParseService.Parse(param);
            var result = await _personalizedService.NewSong(data);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 独家放送
        /// </summary>
        /// <returns></returns>
        [HttpGet("PrivateContent")]
        public async Task<IActionResult> PrivateContent()
        {
            var data = _dtoParseService.Parse(null);
            var result = await _personalizedService.PrivateContent(data);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 推荐歌单
        /// </summary>
        /// <param name="limit">数据条数</param>
        /// <param name="offset">偏移数量</param>
        /// <returns></returns>
        [HttpGet("PlayList")]
        public async Task<IActionResult> PlayList(int limit = 30, int offset = 0)
        {
            var param = new
            {
                limit,
                offset,
                total = true,
                n = 1000
            };
            var data = _dtoParseService.Parse(param);
            var result = await _personalizedService.PlayList(data);

            return Content(result, "application/json");
        }
    }
}
