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
    public class MvController : ControllerBase
    {

        private readonly IMvService _mvService;
        private readonly IDtoParseService _dtoParseService;

        public MvController(
            IMvService mvService,
            IDtoParseService dtoParseService)
        {
            _mvService = mvService;
            _dtoParseService = dtoParseService;
        }

        /// <summary>
        /// MV详情
        /// </summary>
        /// <param name="id">MV Id</param>
        /// <returns></returns>
        [HttpGet("Detail/{id}")]
        public async Task<IActionResult> Detail(string id)
        {
            var param = new { id };
            var data = _dtoParseService.Parse(param);
            var result = await _mvService.Detail(data);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 最新MV
        /// </summary>
        /// <param name="limit">数据条数</param>
        /// <returns></returns>
        [HttpGet("First")]
        public async Task<IActionResult> First(int limit = 30)
        {
            var param = new { limit, total = true };
            var data = _dtoParseService.Parse(param);
            var result = await _mvService.First(data);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 收藏与取消收藏MV
        /// </summary>
        /// <param name="id">MV Id</param>
        /// <param name="t">操作 1 收藏, 0 取消收藏</param>
        /// <returns></returns>
        [HttpGet("Sub")]
        public async Task<IActionResult> Sub(string id, int t)
        {
            var param = new { mvId = id, mvIds = $"[{id}]" };
            var data = _dtoParseService.Parse(param);
            var result = await _mvService.Sub(data, t);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 已收藏MV列表
        /// </summary>
        /// <param name="limit">数据条数</param>
        /// <param name="offset">偏移数量</param>
        /// <returns></returns>
        [HttpGet("Sublist")]
        public async Task<IActionResult> Sublist(int limit = 25, int offset = 0)
        {
            var param = new SimpleDto { Limit = limit, Offset = offset, Total = true };
            var data = _dtoParseService.Parse(param);
            var result = await _mvService.Sublist(data);

            return Content(result, "application/json");
        }

        /// <summary>
        /// MV链接
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Url")]
        public async Task<IActionResult> Link(string id)
        {
            var param = new { id, r = 1080 };
            var data = _dtoParseService.Parse(param);
            var result = await _mvService.Url(data);

            return Content(result, "application/json");
        }

        /// <summary>
        /// MV排行榜
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpGet("Top")]
        public async Task<IActionResult> TopList([FromQuery]SimpleDto dto)
        {
            var data = _dtoParseService.Parse(dto);
            var result = await _mvService.TopList(data);

            return Content(result, "application/json");
        }
    }
}
