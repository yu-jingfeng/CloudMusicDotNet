using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CloudMusicDotNet.Commons.Interfaces
{
    /// <summary>
    /// 发现相似内容服务
    /// </summary>
    public interface ISimilarityService
    {
        /// <summary>
        /// 相似歌手
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> Artist(string data);

        /// <summary>
        /// 相似MV
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> Mv(string data);

        /// <summary>
        /// 相似歌单
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> Playlist(string data);

        /// <summary>
        /// 相似歌曲
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> Song(string data);

        /// <summary>
        /// 相似用户
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> User(string data);
    }
}
