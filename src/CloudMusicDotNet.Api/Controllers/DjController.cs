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
    public class DjController : ControllerBase
    {
        private readonly IDjService _djService;
        private readonly IDtoParseService _dtoParseService;

        public DjController(
            IDjService djService,
            IDtoParseService dtoParseService)
        {
            _djService = djService;
            _dtoParseService = dtoParseService;
        }

        /// <summary>
        /// 电台轮播图
        /// </summary>
        /// <returns></returns>
        [HttpGet("Banner")]
        public async Task<IActionResult> Banner()
        {
            var data = _dtoParseService.Parse(null);
            var result = await _djService.Banner(data);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 非热门类别
        /// </summary>
        /// <returns></returns>
        [HttpGet("Category/ExcludeHot")]
        public async Task<IActionResult> ExcludeHotCategory()
        {
            var data = _dtoParseService.Parse(null);
            var result = await _djService.ExcludeHotCategory(data);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 电台推荐类型
        /// </summary>
        /// <returns></returns>
        [HttpGet("Category/Recommend")]
        public async Task<IActionResult> RecommendCategory()
        {
            var data = _dtoParseService.Parse(null);
            var result = await _djService.RecommendCategory(data);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 电台分类列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("Category")]
        public async Task<IActionResult> Category()
        {
            var data = _dtoParseService.Parse(null);
            var result = await _djService.Category(data);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 电台详情
        /// </summary>
        /// <param name="id">电台id</param>
        /// <returns></returns>
        [HttpGet("Detail/{id}")]
        public async Task<IActionResult> Detail(string id)
        {
            var param = new { id };
            var data = _dtoParseService.Parse(param);
            var result = await _djService.Detail(data);

            return Content(result, "application/json");
        }


        [HttpGet("Hot")]
        public async Task<IActionResult> Hot()
        {
            var data = _dtoParseService.Parse(null);
            var result = await _djService.Hot(data);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 付费电台
        /// </summary>
        /// <param name="limit">数据条数</param>
        /// <param name="offset">偏移数量</param>
        /// <returns></returns>
        [HttpGet("Paygift")]
        public async Task<IActionResult> Paygift(int limit = 20, int offset = 0)
        {
            var param = new { limit, offset };
            var data = _dtoParseService.Parse(param);
            var result = await _djService.Paygift(data);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 电台节目列表
        /// </summary>
        /// <param name="rid">电台id</param>
        /// <param name="limit">数据条数</param>
        /// <param name="offset">偏移数量</param>
        /// <param name="asc">排序方式,默认为 false (新 => 老 ) 设置 true 可改为 老 => 新</param>
        /// <returns></returns>
        [HttpGet("Program/{rid}")]
        public async Task<IActionResult> Program(string rid, int limit = 20, int offset = 0, bool asc = false)
        {
            var param = new { radioId = rid, limit, offset, asc };
            var data = _dtoParseService.Parse(param);
            var result = await _djService.Program(data);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 电台节目详情
        /// </summary>
        /// <param name="id">节目id</param>
        /// <returns></returns>
        [HttpGet("Program/Detail")]
        public async Task<IActionResult> ProgramDetail(string id)
        {
            var param = new { id };
            var data = _dtoParseService.Parse(param);
            var result = await _djService.ProgramDetail(data);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 推荐电台
        /// </summary>
        /// <returns></returns>
        [HttpGet("Recommend")]
        public async Task<IActionResult> Recommend()
        {
            var data = _dtoParseService.Parse(null);
            var result = await _djService.Recommend(data);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 电台分类推荐(按分类获得推荐电台)
        /// </summary>
        /// <param name="cateId">分类id</param>
        /// <returns></returns>
        [HttpGet("Recommend/Type/{cateId}")]
        public async Task<IActionResult> TypeRecommend(string cateId)
        {
            var param = new { cateId };
            var data = _dtoParseService.Parse(param);
            var result = await _djService.TypeRecommend(data);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 订阅与取消电台
        /// </summary>
        /// <param name="id">电台id</param>
        /// <param name="t">操作 1 订阅, 0 取消订阅</param>
        /// <returns></returns>
        [HttpGet("Sub")]
        public async Task<IActionResult> Sub(string id, int t)
        {
            var param = new { id };
            var data = _dtoParseService.Parse(param);
            var result = await _djService.Sub(data, t);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 订阅电台列表
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpGet("Sublist")]
        public async Task<IActionResult> Sublist([FromQuery]SimpleDto dto)
        {
            var data = _dtoParseService.Parse(dto);
            var result = await _djService.Sublist(data);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 今日优选(登陆后调用此接口, 可获得电台今日优选)
        /// </summary>
        /// <returns></returns>
        [HttpGet("Today/Perfered")]
        public async Task<IActionResult> TodayPerfered()
        {
            var param = new { page = 0 };
            var data = _dtoParseService.Parse(param);
            var result = await _djService.TodayPerfered(data);

            return Content(result, "application/json");
        }
    }
}
