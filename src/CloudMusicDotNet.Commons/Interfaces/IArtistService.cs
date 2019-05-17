using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CloudMusicDotNet.Commons.Interfaces
{
    /// <summary>
    /// 歌手服务
    /// </summary>
    public interface IArtistService
    {
        /// <summary>
        /// 歌手专辑列表
        /// </summary>
        /// <param name="data"></param>
        /// <param name="id">歌手id</param>
        /// <returns></returns>
        Task<string> Albums(string data, string id);

        /// <summary>
        /// 歌手介绍
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> Desc(string data);

        /// <summary>
        /// 所有歌手(歌手分类)
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> List(string data);

        /// <summary>
        /// 歌手相关MV
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> Mvs(string data);

        /// <summary>
        /// 收藏与取消收藏歌手
        /// </summary>
        /// <param name="data"></param>
        /// <param name="queryString">操作: sub/unsub</param>
        /// <returns></returns>
        Task<string> Sub(string data, string queryString);

        /// <summary>
        /// 关注歌手列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> SubList(string data);

        /// <summary>
        /// 歌手单曲(可获得歌手部分信息和热门歌曲)
        /// </summary>
        /// <param name="data"></param>
        /// <param name="id">歌手id</param>
        /// <returns></returns>
        Task<string> Song(string data, string id);
    }
}
