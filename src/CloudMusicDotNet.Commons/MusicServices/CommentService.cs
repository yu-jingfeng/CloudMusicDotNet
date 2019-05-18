using CloudMusicDotNet.Commons.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CloudMusicDotNet.Commons.MusicServices
{
    public class CommentService : ICommentService
    {
        private readonly IRequestService _requestService;

        public CommentService(IRequestService requestService)
        {
            _requestService = requestService;
        }

        /// <summary>
        /// 歌曲评论
        /// </summary>
        /// <param name="data"></param>
        /// <param name="id">歌曲id</param>
        /// <returns></returns>
        public Task<string> Music(string data, string id)
        {
            return _requestService.Request("MusicComment", data, id);
        }

        /// <summary>
        /// 专辑评论
        /// </summary>
        /// <param name="data"></param>
        /// <param name="id">专辑id</param>
        /// <returns></returns>
        public Task<string> Album(string data, string id)
        {
            return _requestService.Request("AlbumComment", data, id);
        }

        /// <summary>
        /// 歌单评论
        /// </summary>
        /// <param name="data"></param>
        /// <param name="id">歌单id</param>
        /// <returns></returns>
        public Task<string> Playlist(string data, string id)
        {
            return _requestService.Request("PlaylistComment", data, id);
        }

        /// <summary>
        /// MV评论
        /// </summary>
        /// <param name="data"></param>
        /// <param name="id">MV id</param>
        /// <returns></returns>
        public Task<string> Mv(string data, string id)
        {
            return _requestService.Request("MvComment", data, id);
        }

        /// <summary>
        /// 电台评论
        /// </summary>
        /// <param name="data"></param>
        /// <param name="id">电台id</param>
        /// <returns></returns>
        public Task<string> Dj(string data, string id)
        {
            return _requestService.Request("DjComment", data, id);
        }

        /// <summary>
        /// 视频评论
        /// </summary>
        /// <param name="data"></param>
        /// <param name="id">视频id</param>
        /// <returns></returns>
        public Task<string> Video(string data, string id)
        {
            return _requestService.Request("VideoComment", data, id);
        }

        /// <summary>
        /// 热门评论
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type">类别(0:歌曲; 1:mv; 2:歌单; 3:专辑; 4:电台; 5:视频)</param>
        /// <param name="id">资源id</param>
        /// <returns></returns>
        public Task<string> Hot(string data, int type, string id)
        {
            var types = new string[] { "R_SO_4_", "R_MV_5_", "A_PL_0_", "R_AL_3_", "A_DJ_1_", "R_VI_62_" };
            string queryString = types[type];

            queryString += id;
            return _requestService.Request("HotComment", data, queryString);
        }

        /// <summary>
        /// 点赞与取消点赞评论
        /// </summary>
        /// <param name="data"></param>
        /// <param name="t">是否点赞 1 为点赞 ,0 为取消点赞</param>
        /// <returns></returns>
        public Task<string> Like(string data, int t)
        {
            return _requestService.Request("LikeComment", data, (t == 1 ? "like" : "unlike"));
        }

        /// <summary>
        /// 获取动态评论(登陆后调用此接口 , 可以获取动态下评论)
        /// </summary>
        /// <param name="data"></param>
        /// <param name="id">动态id</param>
        /// <returns></returns>
        public Task<string> Event(string data, string id)
        {
            return _requestService.Request("EventComment", data, id);
        }

        /// <summary>
        /// 发送与删除评论
        /// </summary>
        /// <param name="data"></param>
        /// <param name="t">操作 1 发送 ,0 删除</param>
        /// <returns></returns>
        public Task<string> Post(string data, int t)
        {
            return _requestService.Request("Comment", data, (t == 1 ? "add" : "delete"));
        }

    }
}
