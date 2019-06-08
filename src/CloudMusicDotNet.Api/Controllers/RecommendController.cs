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
    public class RecommendController : ControllerBase
    {
        private readonly IRecommendService _recommendService;

        public RecommendController(
            IRecommendService recommendService)
        {
            _recommendService = recommendService;
        }

        /// <summary>
        /// 每日推荐歌曲
        /// </summary>
        /// <returns></returns>
        [HttpGet("Songs")]
        public async Task<IActionResult> Songs()
        {
            var result = await _recommendService.Songs();

            return Content(result, "application/json");
        }

        /// <summary>
        /// 每日推荐歌单
        /// </summary>
        /// <returns></returns>
        [HttpGet("Resource")]
        public async Task<IActionResult> Resource()
        {
            var result = await _recommendService.Resource();

            return Content(result, "application/json");
        }
    }
}
