using CloudMusicDotNet.Commons.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CloudMusicDotNet.Commons.MusicServices
{
    public class PlaylistService : IPlaylistService
    {
        private readonly IRequestService _requestService;

        public PlaylistService(IRequestService requestService)
        {
            _requestService = requestService;
        }

        /// <summary>
        /// 全部歌单分类
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<string> Categories(string data)
        {
            return _requestService.Request("PlaylistCategories", data);
        }

        /// <summary>
        /// 创建歌单
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<string> Create(string data)
        {
            return _requestService.Request("PlaylistCreate", data);
        }

        /// <summary>
        /// 歌单详情
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<string> Detail(string data)
        {
            return _requestService.Request("PlaylistDetail", data);
        }

        /// <summary>
        /// 热门歌单分类
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<string> HotTags(string data)
        {
            return _requestService.Request("PlaylistHotTags", data);
        }

        /// <summary>
        /// 收藏与取消收藏歌单
        /// </summary>
        /// <param name="data"></param>
        /// <param name="t">操作 1 收藏, 0 取消收藏</param>
        /// <returns></returns>
        public Task<string> Subscribe(string data, int t)
        {
            return _requestService.Request("PlaylistSubscribe", data, (t == 1 ? "subscribe" : "unsubscribe"));
        }

        /// <summary>
        /// 歌单的所有收藏者
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<string> Subscribers(string data)
        {
            return _requestService.Request("PlaylistSubscribers", data);
        }

        /// <summary>
        /// 收藏单曲到歌单 从歌单删除歌曲
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<string> Tracks(string data)
        {
            return _requestService.Request("PlaylistTracks", data);
        }

        /// <summary>
        /// 更新歌单
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<string> Update(string data)
        {
            return _requestService.Request("PlaylistUpdate", data);
        }
    }
}
