using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CloudMusicDotNet.Commons.Interfaces
{
    /// <summary>
    /// 每日推荐服务
    /// </summary>
    public interface IRecommendService
    {
        /// <summary>
        /// 每日推荐歌曲
        /// </summary>
        /// <returns></returns>
        Task<string> Songs();

        /// <summary>
        /// 每日推荐歌单
        /// </summary>
        /// <returns></returns>
        Task<string> Resource();
    }
}
