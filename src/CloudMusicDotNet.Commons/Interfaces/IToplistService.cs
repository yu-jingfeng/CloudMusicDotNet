using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CloudMusicDotNet.Commons.Interfaces
{
    /// <summary>
    /// 榜单服务
    /// </summary>
    public interface IToplistService
    {
        /// <summary>
        /// 歌手榜
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> Artist(string data);

        /// <summary>
        /// 所有榜单内容摘要
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> Detail(string data);

        /// <summary>
        /// 所有榜单介绍
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> All(string data);
    }
}
