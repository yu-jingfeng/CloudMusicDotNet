using CloudMusicDotNet.Api.Dto;
using CloudMusicDotNet.Api.Infrastructure;
using CloudMusicDotNet.Commons.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudMusicDotNet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistController : ControllerBase
    {
        private readonly IPlaylistService _playlistService;
        private readonly IDtoParseService _dtoParseService;

        public PlaylistController(
            IPlaylistService playlistService,
            IDtoParseService dtoParseService)
        {
            _playlistService = playlistService;
            _dtoParseService = dtoParseService;
        }

        /// <summary>
        /// 全部歌单分类
        /// </summary>
        /// <returns></returns>
        [HttpGet("Catlist")]
        public async Task<IActionResult> Categories()
        {
            var data = _dtoParseService.Parse(null);
            var result = await _playlistService.Categories(data);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 创建歌单
        /// </summary>
        /// <param name="name">歌单名</param>
        /// <param name="privacy">是否设置为隐私歌单，默认否，传'10'则设置成隐私歌单</param>
        /// <returns></returns>
        [HttpGet("Create")]
        public async Task<IActionResult> Create(string name, int privacy)
        {
            var param = new { name, privacy };
            var data = _dtoParseService.Parse(param);
            var result = await _playlistService.Create(data);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 歌单详情
        /// </summary>
        /// <param name="id">歌单 id</param>
        /// <param name="s">歌单最近的 s 个收藏者(可选)</param>
        /// <returns></returns>
        [HttpGet("Detail/{id}")]
        public async Task<IActionResult> Detail(string id, int s = 8)
        {
            var param = new { id, s, n = 100000 };
            var data = _dtoParseService.Parse(param);
            var result = await _playlistService.Detail(data);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 热门歌单分类
        /// </summary>
        /// <returns></returns>
        [HttpGet("Hot")]
        public async Task<IActionResult> HotTags()
        {
            var data = _dtoParseService.Parse(null);
            var result = await _playlistService.HotTags(data);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 收藏与取消收藏歌单
        /// </summary>
        /// <param name="id">歌单 id</param>
        /// <param name="t">类型,1:收藏,2:取消收藏</param>
        /// <returns></returns>
        [HttpGet("Subscribe")]
        public async Task<IActionResult> Subscribe(string id, int t)
        {
            var data = _dtoParseService.Parse(null);
            var result = await _playlistService.Subscribe(data, t);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 歌单的所有收藏者
        /// </summary>
        /// <param name="id">歌单 id</param>
        /// <param name="limit">数据条数</param>
        /// <param name="offset">偏移量</param>
        /// <returns></returns>
        [HttpGet("Subscribers")]
        public async Task<IActionResult> Subscribers(string id, int limit = 20, int offset = 0)
        {
            var param = new { id, limit, offset };
            var data = _dtoParseService.Parse(param);
            var result = await _playlistService.Subscribers(data);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 收藏单曲到歌单 从歌单删除歌曲
        /// </summary>
        /// <param name="op">操作 从歌单增加单曲为 add, 删除为 del</param>
        /// <param name="pid">歌单 id</param>
        /// <param name="tracks">歌曲 id,可多个,用逗号隔开</param>
        /// <returns></returns>
        [HttpGet("Tracks")]
        public async Task<IActionResult> Tracks(string op, string pid, string tracks)
        {
            var param = new { op, pid, trackIds = $"[{tracks}]" };
            var data = _dtoParseService.Parse(param);
            var result = await _playlistService.Tracks(data);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 更新歌单
        /// </summary>
        /// <param name="id">歌单id</param>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        [HttpPost("Update/{id}")]
        public async Task<IActionResult> Update(string id, PlaylistUpdateDto updateDto)
        {
            var descParam = new JObject
            {
                { "id", id },
                { "desc", updateDto.Desc }
            };

            var tagsParam = new JObject
            {
                { "id", id },
                { "desc", updateDto.Tags }
            };

            var name = new JObject
            {
                { "id", id },
                { "desc", updateDto.Name }
            };
            var param = new JObject();
            param.Add("/api/playlist/desc/update", descParam);
            param.Add("/api/playlist/tags/update", tagsParam);
            param.Add("/api/playlist/update/name", name);

            var data = _dtoParseService.Parse(param);
            var result = await _playlistService.Update(data);

            return Content(param.ToString(), "application/json");
        }
    }
}
