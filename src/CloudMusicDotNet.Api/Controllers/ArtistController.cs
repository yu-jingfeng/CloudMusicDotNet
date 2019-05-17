using CloudMusicDotNet.Api.Dto;
using CloudMusicDotNet.Api.Infrastructure;
using CloudMusicDotNet.Commons.Interfaces;
using CloudMusicDotNet.Commons.MusicServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudMusicDotNet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistService _artistService;
        private readonly IDtoParseService _dtoParseService;

        public ArtistController(
            IArtistService artistService,
            IDtoParseService dtoParseService)
        {
            _artistService = artistService;
            _dtoParseService = dtoParseService;
        }

        /// <summary>
        /// 歌手专辑列表
        /// </summary>
        /// <param name="id">歌手id</param>
        /// <returns></returns>
        [HttpGet("Albums/{id}")]
        public async Task<IActionResult> Albums(string id, [FromQuery]SimpleDto dto)
        {
            var data = _dtoParseService.Parse(dto);
            var result = await _artistService.Albums(data, id);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 歌手介绍描述
        /// </summary>
        /// <param name="id">歌手id</param>
        /// <returns></returns>
        [HttpGet("Desc/{id}")]
        public async Task<IActionResult> Desc(string id)
        {
            var param = new { Id = id };
            var data = _dtoParseService.Parse(param);
            var result = await _artistService.Desc(data);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 所有歌手(歌手分类)
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpGet("List")]
        public async Task<IActionResult> List([FromQuery]ArtistListDto dto)
        {
            var data = _dtoParseService.Parse(dto);
            var result = await _artistService.List(data);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 歌手相关MV
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpGet("Mvs")]
        public async Task<IActionResult> Mvs([FromQuery]ArtistMvsDto dto)
        {
            var data = _dtoParseService.Parse(dto);
            var result = await _artistService.Mvs(data);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 收藏与取消收藏歌手
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpGet("Sub")]
        public async Task<IActionResult> Sub([FromQuery]ArtistSubDto dto)
        {
            var param = new { ArtistId = dto.ArtistId, ArtistIds = $"[{dto.ArtistId}]" };
            var data = _dtoParseService.Parse(param);
            var result = await _artistService.Sub(data, dto.T);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 关注歌手列表
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpGet("SubList")]
        public async Task<IActionResult> SubList([FromQuery]SimpleDto dto)
        {
            var data = _dtoParseService.Parse(dto);
            var result = await _artistService.SubList(data);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 歌手单曲(可获得歌手部分信息和热门歌曲)
        /// </summary>
        /// <param name="id">歌手id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Song(string id)
        {
            var data = _dtoParseService.Parse(null);
            var result = await _artistService.Song(data, id);

            return Content(result, "application/json");
        }
    }
}
