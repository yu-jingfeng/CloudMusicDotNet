using CloudMusicDotNet.Api.Infrastructure;
using CloudMusicDotNet.Commons;
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
    public class SongController : ControllerBase
    {
        private readonly ISongService _songService;
        private readonly IDtoParseService _dtoParseService;

        public SongController(
            ISongService songService,
            IDtoParseService dtoParseService)
        {
            _songService = songService;
            _dtoParseService = dtoParseService;
        }

        /// <summary>
        /// 歌曲详情
        /// </summary>
        /// <param name="ids">音乐 id</param>
        /// <returns></returns>
        [HttpGet("Detail")]
        public async Task<IActionResult> Detail(string ids)
        {
            string c = string.Join(',', ids.Split(',').Select(id => "{\"id\":" + id + "}"));
            var param = new { ids = $"[{ids}]", c = $"[{c}]" };
            var data = _dtoParseService.Parse(param);
            var result = await _songService.Detail(data);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 歌曲链接
        /// </summary>
        /// <param name="ids">音乐id</param>
        /// <param name="br">码率,默认999000 即最大码率,如果要 320k 则可设置为 320000</param>
        /// <returns></returns>
        [HttpGet("Url/{ids}")]
        public async Task<IActionResult> PlayUrl(string ids, int br = 999000)
        {
            var param = new { ids = $"[{ids}]", br };
            var data = _dtoParseService.Parse(param);
            var result = await _songService.Url(data);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 歌词
        /// </summary>
        /// <param name="id">音乐id</param>
        /// <returns></returns>
        [HttpGet("Lyric/{id}")]
        public async Task<IActionResult> Lyric(string id)
        {
            var param = new { id };
            var data = _dtoParseService.Parse(param);
            var result = await _songService.Lyric(data);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 喜欢的歌曲列表
        /// </summary>
        /// <param name="uid">用户id</param>
        /// <returns></returns>
        [HttpGet("LikeList")]
        public async Task<IActionResult> LikeList(string uid)
        {
            var param = new { uid };
            var data = _dtoParseService.Parse(param);
            var result = await _songService.LikeList(data);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 歌曲可用性
        /// </summary>
        /// <param name="ids">音乐id</param>
        /// <param name="br">码率,默认999000 即最大码率,如果要 320k 则可设置为 320000</param>
        /// <returns></returns>
        [HttpGet("Check")]
        public async Task<IActionResult> Check(string ids, int br = 999000)
        {
            var param = new { ids = $"[{ids}]", br };
            var data = _dtoParseService.Parse(param);
            var result = await _songService.Check(data);

            return Content(result, "application/json");
        }

    }
}
