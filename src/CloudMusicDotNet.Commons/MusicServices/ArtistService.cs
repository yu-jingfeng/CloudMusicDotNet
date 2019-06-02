using CloudMusicDotNet.Commons.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CloudMusicDotNet.Commons.MusicServices
{
    /// <summary>
    /// 歌手服务
    /// </summary>
    public class ArtistService : IArtistService
    {
        private readonly IRequestService _requestService;

        public ArtistService(IRequestService requestService)
        {
            _requestService = requestService;
        }

        /// <summary>
        /// 歌手专辑列表
        /// </summary>
        /// <param name="data"></param>
        /// <param name="id">歌手id</param>
        /// <returns></returns>
        public Task<string> Albums(string data, string id)
        {
            return _requestService.Request("ArtistAlbums", data, id);
        }

        /// <summary>
        /// 歌手介绍
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<string> Desc(string data)
        {
            return _requestService.Request("ArtistDesc", data);
        }

        /// <summary>
        /// 所有歌手(歌手分类)
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<string> List(string data)
        {
            return _requestService.Request("ArtistList", data);
        }

        /// <summary>
        /// 歌手相关MV
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<string> Mvs(string data)
        {
            return _requestService.Request("ArtistMvs", data);
        }

        /// <summary>
        /// 收藏与取消收藏歌手
        /// </summary>
        /// <param name="data"></param>
        /// <param name="t">操作: 1 收藏 ,0 取消收藏</param>
        /// <returns></returns>
        public Task<string> Sub(string data, int t)
        {
            return _requestService.Request("ArtistSub", data, (t == 1 ? "sub" : "unsub"));
        }

        /// <summary>
        /// 关注歌手列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<string> SubList(string data)
        {
            return _requestService.Request("ArtistSubList", data);
        }

        /// <summary>
        /// 歌手单曲(可获得歌手部分信息和热门歌曲)
        /// </summary>
        /// <param name="data"></param>
        /// <param name="id">歌手id</param>
        /// <returns></returns>
        public Task<string> Song(string data, string id)
        {
            return _requestService.Request("ArtistSong", data, id);
        }

        /// <summary>
        /// 热门歌手
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<string> Top(string data)
        {
            return _requestService.Request("ArtistTop", data);
        }
    }
}
