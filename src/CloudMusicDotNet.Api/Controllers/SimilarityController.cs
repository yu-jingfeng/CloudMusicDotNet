using CloudMusicDotNet.Api.Infrastructure;
using CloudMusicDotNet.Commons.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudMusicDotNet.Api.Controllers
{
    [Route("api/simi")]
    [ApiController]
    public class SimilarityController : ControllerBase
    {
        private readonly ISimilarityService _similarityService;
        private readonly IDtoParseService _dtoParseService;

        public SimilarityController(
            ISimilarityService similarityService,
            IDtoParseService dtoParseService)
        {
            _similarityService = similarityService;
            _dtoParseService = dtoParseService;
        }

        /// <summary>
        /// 相似歌手
        /// </summary>
        /// <param name="artistid">歌手id</param>
        /// <returns></returns>
        [HttpGet("Artist/{artistid}")]
        public async Task<IActionResult> Artist(string artistid)
        {
            var param = new { artistid };
            var data = _dtoParseService.Parse(param);
            var result = await _similarityService.Artist(data);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 相似MV
        /// </summary>
        /// <param name="mvid">MV id</param>
        /// <returns></returns>
        [HttpGet("Mv/{mvid}")]
        public async Task<IActionResult> Mv(string mvid)
        {
            var param = new { mvid };
            var data = _dtoParseService.Parse(param);
            var result = await _similarityService.Mv(data);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 相似歌单
        /// </summary>
        /// <param name="songid">歌曲 id</param>
        /// <param name="limit">数据条数</param>
        /// <param name="offset">偏移量</param>
        /// <returns></returns>
        [HttpGet("Playlist/{songid}")]
        public async Task<IActionResult> Playlist(string songid, int limit = 50, int offset = 0)
        {
            var param = new { songid, limit, offset };
            var data = _dtoParseService.Parse(param);
            var result = await _similarityService.Playlist(data);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 相似歌曲
        /// </summary>
        /// <param name="songid">歌曲 id</param>
        /// <param name="limit">数据条数</param>
        /// <param name="offset">偏移量</param>
        /// <returns></returns>
        [HttpGet("Song/{songid}")]
        public async Task<IActionResult> Song(string songid, int limit = 50, int offset = 0)
        {
            var param = new { songid, limit, offset };
            var data = _dtoParseService.Parse(param);
            var result = await _similarityService.Song(data);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 最近 5 个听了这首歌的用户
        /// </summary>
        /// <param name="songid">歌曲 id</param>
        /// <returns></returns>
        [HttpGet("User/{songid}")]
        public async Task<IActionResult> Users(string songid)
        {
            var param = new { songid };
            var data = _dtoParseService.Parse(param);
            var result = await _similarityService.User(data);

            return Content(result, "application/json");
        }
    }
}
