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

        /// <summary>
        /// 排行榜
        /// </summary>
        /// <param name="index">类型索引</param>
        /// <returns></returns>
        [HttpGet("Top/{id}")]
        public async Task<IActionResult> Top(int index)
        {
            var topList = new[]
            {
                "3779629", //云音乐新歌榜
                "3778678", //云音乐热歌榜
                "2884035", //云音乐原创榜
                "19723756", //云音乐飙升榜
                "10520166", //云音乐电音榜
                "180106", //UK排行榜周榜
                "60198", //美国Billboard周榜
                "21845217", //KTV嗨榜
                "11641012", //iTunes榜
                "120001", //Hit FM Top榜
                "60131", //日本Oricon周榜
                "3733003", //韩国Melon排行榜周榜
                "60255", //韩国Mnet排行榜周榜
                "46772709", //韩国Melon原声周榜
                "112504", //中国TOP排行榜(港台榜)
                "64016", //中国TOP排行榜(内地榜)
                "10169002", //香港电台中文歌曲龙虎榜
                "4395559", //华语金曲榜
                "1899724", //中国嘻哈榜
                "27135204", //法国 NRJ EuroHot 30周榜
                "112463", //台湾Hito排行榜
                "3812895", //Beatport全球电子舞曲榜
                "71385702", //云音乐ACG音乐榜
                "991319590" //云音乐嘻哈榜
            };
            var param = new { id = topList[index], n = 10000 };
            var data = _dtoParseService.Parse(param);
            var result = await _playlistService.Top(data);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 精品歌单
        /// </summary>
        /// <param name="cat">tag, 比如 "华语"、"古风" 、"欧美"、"流行", 默认为 "全部"</param>
        /// <param name="limit">数据条数</param>
        /// <param name="lasttime">分页参数,取上一页最后一个歌单的 updateTime 获取下一页数据</param>
        /// <returns></returns>
        [HttpGet("HighQuality/{id}")]
        public async Task<IActionResult> HighQuality(string cat = "全部", int limit = 50, string lasttime = "0")
        {
            var param = new { cat, limit, lasttime };
            var data = _dtoParseService.Parse(param);
            var result = await _playlistService.HighQuality(data);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 歌单列表
        /// </summary>
        /// <param name="cat">全部,华语,欧美,日语,韩语,粤语,小语种,流行...</param>
        /// <param name="order">hot,new 最热,最新</param>
        /// <param name="limit">数据条数</param>
        /// <param name="offset">偏移量</param>
        /// <returns></returns>
        [HttpGet("List")]
        public async Task<IActionResult> List(string cat = "全部", string order = "hot", int limit = 50, int offset = 0)
        {
            var param = new { cat, order, limit, offset, total = true };
            var data = _dtoParseService.Parse(param);
            var result = await _playlistService.List(data);

            return Content(result, "application/json");
        }
    }
}
