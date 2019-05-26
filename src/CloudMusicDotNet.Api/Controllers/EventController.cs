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
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;
        private readonly IDtoParseService _dtoParseService;

        public EventController(
            IEventService eventService,
            IDtoParseService dtoParseService)
        {
            _eventService = eventService;
            _dtoParseService = dtoParseService;
        }

        /// <summary>
        /// 删除用户动态
        /// </summary>
        /// <param name="id">动态id</param>
        /// <returns></returns>
        [HttpGet("Del/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var param = new { id };
            var data = _dtoParseService.Parse(param);
            var result = await _eventService.Delete(data);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 转发用户动态
        /// </summary>
        /// <param name="evId">动态id</param>
        /// <param name="uid">用户id</param>
        /// <param name="forwards">转发的评论</param>
        /// <returns></returns>
        [HttpGet("Forward")]
        public async Task<IActionResult> Forward(string evId, string uid, string forwards)
        {
            var param = new { id = evId, forwards, eventUserId = uid };
            var data = _dtoParseService.Parse(param);
            var result = await _eventService.Forward(data);

            return Content(result, "application/json");
        }
    }
}
