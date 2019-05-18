using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CloudMusicDotNet.Commons.Interfaces
{
    /// <summary>
    /// 评论服务
    /// </summary>
    public interface ICommentService
    {
        /// <summary>
        /// 歌曲评论
        /// </summary>
        /// <param name="data"></param>
        /// <param name="id">歌曲id</param>
        /// <returns></returns>
        Task<string> Music(string data, string id);

        /// <summary>
        /// 专辑评论
        /// </summary>
        /// <param name="data"></param>
        /// <param name="id">专辑id</param>
        /// <returns></returns>
        Task<string> Album(string data, string id);

        /// <summary>
        /// 歌单评论
        /// </summary>
        /// <param name="data"></param>
        /// <param name="id">歌单id</param>
        /// <returns></returns>
        Task<string> Playlist(string data, string id);

        /// <summary>
        /// MV评论
        /// </summary>
        /// <param name="data"></param>
        /// <param name="id">MV id</param>
        /// <returns></returns>
        Task<string> Mv(string data, string id);

        /// <summary>
        /// 电台评论
        /// </summary>
        /// <param name="data"></param>
        /// <param name="id">电台id</param>
        /// <returns></returns>
        Task<string> Dj(string data, string id);

        /// <summary>
        /// 视频评论
        /// </summary>
        /// <param name="data"></param>
        /// <param name="id">视频id</param>
        /// <returns></returns>
        Task<string> Video(string data, string id);

        /// <summary>
        /// 热门评论
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type">类别(0:歌曲; 1:mv; 2:歌单; 3:专辑; 4:电台; 5:视频)</param>
        /// <param name="id">id</param>
        /// <returns></returns>
        Task<string> Hot(string data, int type, string id);

        /// <summary>
        /// 点赞与取消点赞评论
        /// </summary>
        /// <param name="data"></param>
        /// <param name="t">是否点赞 1 为点赞 ,0 为取消点赞</param>
        /// <returns></returns>
        Task<string> Like(string data, int t);

        /// <summary>
        /// 获取动态评论(登陆后调用此接口 , 可以获取动态下评论)
        /// </summary>
        /// <param name="data"></param>
        /// <param name="id">动态id</param>
        /// <returns></returns>
        Task<string> Event(string data, string id);

        /// <summary>
        /// 发送与删除评论
        /// </summary>
        /// <param name="data"></param>
        /// <param name="t">操作 1 为发送 ,0 为删除</param>
        /// <returns></returns>
        Task<string> Post(string data, int t);
    }
}
