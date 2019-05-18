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
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        private readonly IDtoParseService _dtoParseService;

        public CommentController(
            ICommentService commentService,
            IDtoParseService dtoParseService)
        {
            _commentService = commentService;
            _dtoParseService = dtoParseService;
        }

        /// <summary>
        /// 歌曲评论
        /// </summary>
        /// <param name="id">歌曲id</param>
        /// <param name="limit">数据条数</param>
        /// <param name="offset">偏移数量</param>
        /// <returns></returns>
        [HttpGet("Music/{id}")]
        public async Task<IActionResult> Music(string id, int limit = 20, int offset = 0)
        {
            var param = new { rid = id, limit = limit, offset = offset };
            var data = _dtoParseService.Parse(param);
            var result = await _commentService.Music(data, id);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 专辑评论
        /// </summary>
        /// <param name="id">专辑id</param>
        /// <param name="limit">数据条数</param>
        /// <param name="offset">偏移数量</param>
        /// <returns></returns>
        [HttpGet("Album/{id}")]
        public async Task<IActionResult> Album(string id, int limit = 20, int offset = 0)
        {
            var param = new { rid = id, limit = limit, offset = offset };
            var data = _dtoParseService.Parse(param);
            var result = await _commentService.Album(data, id);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 歌单评论
        /// </summary>
        /// <param name="id">歌单id</param>
        /// <param name="limit">数据条数</param>
        /// <param name="offset">偏移数量</param>
        /// <returns></returns>
        [HttpGet("Playlist/{id}")]
        public async Task<IActionResult> Playlist(string id, int limit = 20, int offset = 0)
        {
            var param = new { rid = id, limit = limit, offset = offset };
            var data = _dtoParseService.Parse(param);
            var result = await _commentService.Playlist(data, id);

            return Content(result, "application/json");
        }

        /// <summary>
        /// MV评论
        /// </summary>
        /// <param name="id">MV id</param>
        /// <param name="limit">数据条数</param>
        /// <param name="offset">偏移数量</param>
        /// <returns></returns>
        [HttpGet("Mv/{id}")]
        public async Task<IActionResult> Mv(string id, int limit = 20, int offset = 0)
        {
            var param = new { rid = id, limit = limit, offset = offset };
            var data = _dtoParseService.Parse(param);
            var result = await _commentService.Mv(data, id);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 电台评论
        /// </summary>
        /// <param name="id">电台id</param>
        /// <param name="limit">数据条数</param>
        /// <param name="offset">偏移数量</param>
        /// <returns></returns>
        [HttpGet("Dj/{id}")]
        public async Task<IActionResult> Dj(string id, int limit = 20, int offset = 0)
        {
            var param = new { rid = id, limit = limit, offset = offset };
            var data = _dtoParseService.Parse(param);
            var result = await _commentService.Dj(data, id);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 视频评论
        /// </summary>
        /// <param name="id">视频id</param>
        /// <param name="limit">数据条数</param>
        /// <param name="offset">偏移数量</param>
        /// <returns></returns>
        [HttpGet("Video/{id}")]
        public async Task<IActionResult> Video(string id, int limit = 20, int offset = 0)
        {
            var param = new { rid = id, limit = limit, offset = offset };
            var data = _dtoParseService.Parse(param);
            var result = await _commentService.Video(data, id);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 热门评论
        /// </summary>
        /// <param name="id">资源id</param>
        /// <param name="type">类别(0:歌曲; 1:mv; 2:歌单; 3:专辑; 4:电台; 5:视频)</param>
        /// <param name="limit">数据条数</param>
        /// <param name="offset">偏移数量</param>
        /// <returns></returns>
        [HttpGet("Hot")]
        public async Task<IActionResult> Hot(string id, int type, int limit = 20, int offset = 0)
        {
            if (type < 0 || type > 5)
                return BadRequest("type参数错误");

            var param = new { rid = id, limit = limit, offset = offset };
            var data = _dtoParseService.Parse(param);
            var result = await _commentService.Hot(data, type, id);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 点赞与取消点赞评论
        /// </summary>
        /// <param name="id">资源id</param>
        /// <param name="cid">评论id</param>
        /// <param name="t">是否点赞 1 为点赞 ,0 为取消点赞</param>
        /// <param name="type">资源类型(0:歌曲; 1:mv; 2:歌单; 3:专辑; 4:电台; 5:视频; 6:动态)</param>
        /// <returns></returns>
        [HttpGet("Like")]
        public async Task<IActionResult> Like(string id, string cid, int t, int type)
        {
            if (type < 0 || type > 6)
                return BadRequest("type参数错误");

            var types = new string[] { "R_SO_4_", "R_MV_5_", "A_PL_0_", "R_AL_3_", "A_DJ_1_", "R_VI_62_", "A_EV_2_" };
            string typeString = types[type];

            var threadId = (type == 6 ? id : typeString + id);

            var param = new { commentId = cid, threadId = threadId };

            var data = _dtoParseService.Parse(param);
            var result = await _commentService.Like(data, t);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 获取动态评论(登陆后调用此接口 , 可以获取动态下评论)
        /// </summary>
        /// <param name="id">动态id</param>
        /// <param name="limit">数据条数</param>
        /// <param name="offset">偏移数量</param>
        /// <returns></returns>
        [HttpGet("Event/{id}")]
        public async Task<IActionResult> Event(string id, int limit = 20, int offset = 0)
        {
            var param = new { limit = limit, offset = offset };
            var data = _dtoParseService.Parse(param);
            var result = await _commentService.Video(data, id);

            return Content(result, "application/json");
        }

        /// <summary>
        /// 发送与删除评论
        /// </summary>
        /// <param name="id">资源id</param>
        /// <param name="t">操作 1 发送 0 删除</param>
        /// <param name="cid">评论id t=0 时传递</param>
        /// <param name="type">资源类型(0:歌曲; 1:mv; 2:歌单; 3:专辑; 4:电台; 5:视频; 6:动态)</param>
        /// <param name="content">评论内容 t=1 时传递</param>
        /// <returns></returns>
        [HttpGet("Post")]
        public async Task<IActionResult> Post(string id, int t, string cid, int type, string content)
        {
            if (type < 0 || type > 6)
                return BadRequest("type参数错误");

            var types = new string[] { "R_SO_4_", "R_MV_5_", "A_PL_0_", "R_AL_3_", "A_DJ_1_", "R_VI_62_", "A_EV_2_" };
            string typeString = types[type];

            var threadId = (type == 6 ? id : typeString + id);

            var param = new
            {
                threadId = threadId,
                content = content,
                commentId = cid
            };

            var data = _dtoParseService.Parse(param);
            var result = await _commentService.Post(data, t);

            return Content(result, "application/json");
        }
    }
}
