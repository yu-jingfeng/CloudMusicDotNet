using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CloudMusicDotNet.Commons.Interfaces
{
    /// <summary>
    /// 视频服务
    /// </summary>
    public interface IVideoService
    {
        /// <summary>
        /// 视频详情
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> Detail(string data);

        /// <summary>
        /// 获取视频标签下的视频
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> Group(string data);

        /// <summary>
        /// 收藏与取消收藏视频
        /// </summary>
        /// <param name="data"></param>
        /// <param name="t">操作: 1 收藏 ,0 取消收藏</param>
        /// <returns></returns>
        Task<string> Sub(string data,int t);

        /// <summary>
        /// 视频链接
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> Url(string data);
    }
}
