using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CloudMusicDotNet.Commons.Interfaces
{
    /// <summary>
    /// 歌单服务
    /// </summary>
    public interface IPlaylistService
    {
        /// <summary>
        /// 全部歌单分类
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> Categories(string data);

        /// <summary>
        /// 创建歌单
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> Create(string data);

        /// <summary>
        /// 歌单详情
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> Detail(string data);

        /// <summary>
        /// 热门歌单分类
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> HotTags(string data);

        /// <summary>
        /// 收藏与取消收藏歌单
        /// </summary>
        /// <param name="data"></param>
        /// <param name="t">操作 1 收藏, 0 取消收藏</param>
        /// <returns></returns>
        Task<string> Subscribe(string data, int t);

        /// <summary>
        /// 歌单的所有收藏者
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> Subscribers(string data);

        /// <summary>
        /// 收藏单曲到歌单 从歌单删除歌曲
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> Tracks(string data);

        /// <summary>
        /// 更新歌单
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> Update(string data);

        /// <summary>
        /// 排行榜
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> Top(string data);

        /// <summary>
        /// 精品歌单
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> HighQuality(string data);

        /// <summary>
        /// 歌单列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> List(string data);
    }
}
