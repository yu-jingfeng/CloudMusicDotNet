using CloudMusicDotNet.Api.Dto;
using CloudMusicDotNet.Api.Infrastructure;
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
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumService _albumService;
        private readonly IDtoParseService _dtoParseService;

        public AlbumController(
            IAlbumService albumService,
            IDtoParseService dtoParseService)
        {
            _albumService = albumService;
            _dtoParseService = dtoParseService;
        }

        /// <summary>
        /// 全部新碟（最新专辑）
        /// </summary>
        /// <returns></returns>
        [HttpGet("New")]
        public async Task<IActionResult> New([FromQuery]NewAlbumDto newAlbumDto)
        {
            var data = _dtoParseService.Parse(newAlbumDto);
            var result = await _albumService.NewAlubm(data);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 已收藏专辑列表
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpGet("Sublist")]
        public async Task<IActionResult> Sublist([FromQuery]SimpleDto dto)
        {
            var data = _dtoParseService.Parse(dto);
            var result = await _albumService.Sublist(data);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 专辑内容
        /// </summary>
        /// <param name="id">专辑id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Content(string id)
        {
            var data = _dtoParseService.Parse(null);
            var result = await _albumService.Content(data, id);

            return Content(result, "application/json");
        }

    }
}
