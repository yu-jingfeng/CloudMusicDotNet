using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CloudMusicDotNet.Commons.Interfaces
{
    /// <summary>
    /// MV服务
    /// </summary>
    public interface IMvService
    {
        /// <summary>
        /// MV详情
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> Detail(string data);

        /// <summary>
        /// 最新MV
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> First(string data);

        /// <summary>
        /// 收藏与取消收藏MV
        /// </summary>
        /// <param name="data"></param>
        /// <param name="t">操作 1 收藏, 0 取消收藏</param>
        /// <returns></returns>
        Task<string> Sub(string data, int t);

        /// <summary>
        /// 已收藏MV列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> Sublist(string data);

        /// <summary>
        /// MV链接
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> Url(string data);

        /// <summary>
        /// MV排行榜
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> TopList(string data);
    }
}
