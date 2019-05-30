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
    public class SearchController : ControllerBase
    {
        private readonly ISearchService _searchService;
        private readonly IDtoParseService _dtoParseService;

        public SearchController(
            ISearchService searchService,
            IDtoParseService dtoParseService)
        {
            _searchService = searchService;
            _dtoParseService = dtoParseService;
        }

        /// <summary>
        /// 普通搜索
        /// </summary>
        /// <param name="keywords">关键词</param>
        /// <param name="type">搜索类型；默认为 1 即单曲 , 取值意义 : 1: 单曲, 10: 专辑, 
        /// 100: 歌手, 1000: 歌单, 1002: 用户, 1004: MV, 1006: 歌词, 1009: 电台, 1014: 视频
        /// </param>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        [HttpGet("")]
        public async Task<IActionResult> Get(string keywords, int type = 1, int limit = 30, int offset = 0)
        {
            var param = new { s = keywords, type, limit, offset };
            var data = _dtoParseService.Parse(param);
            var result = await _searchService.Get(data);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 热搜
        /// </summary>
        /// <returns></returns>
        [HttpGet("Hot")]
        public async Task<IActionResult> Hot()
        {
            var param = new { type = 1111 };
            var data = _dtoParseService.Parse(param);
            var result = await _searchService.Hot(data);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 搜索多重匹配
        /// </summary>
        /// <param name="keywords">关键词</param>
        /// <returns></returns>
        [HttpGet("Multimatch")]
        public async Task<IActionResult> Multimatch(string keywords)
        {
            var param = new { type = 1, s = keywords };
            var data = _dtoParseService.Parse(param);
            var result = await _searchService.Multimatch(data);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 搜索建议
        /// </summary>
        /// <param name="keywords">关键词</param>
        /// <param name="type">(可选)如果传 'mobile' 则返回移动端数据</param>
        /// <returns></returns>
        [HttpGet("Suggest")]
        public async Task<IActionResult> Suggest(string keywords, string type)
        {
            var param = new { s = keywords };
            var data = _dtoParseService.Parse(param);
            var result = await _searchService.Suggest(data, type);

            return Content(result, "application/json");
        }
    }
}
