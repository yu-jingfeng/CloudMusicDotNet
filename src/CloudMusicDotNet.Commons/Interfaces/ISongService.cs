using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CloudMusicDotNet.Commons.Interfaces
{
    /// <summary>
    /// 歌曲相关服务
    /// </summary>
    public interface ISongService
    {
        /// <summary>
        /// 歌曲详情
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> Detail(string data);

        /// <summary>
        /// 歌曲链接
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> Url(string data);

        /// <summary>
        /// 歌曲可用性
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> Check(string data);

        /// <summary>
        /// 歌词
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> Lyric(string data);

        /// <summary>
        /// 喜欢的歌曲
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> LikeList(string data);
    }
}
