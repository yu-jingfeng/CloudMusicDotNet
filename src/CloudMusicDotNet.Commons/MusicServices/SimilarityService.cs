using CloudMusicDotNet.Commons.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CloudMusicDotNet.Commons.MusicServices
{
    /// <summary>
    /// 发现相似内容服务
    /// </summary>
    public class SimilarityService : ISimilarityService
    {
        private readonly IRequestService _requestService;

        public SimilarityService(IRequestService requestService)
        {
            _requestService = requestService;
        }

        /// <summary>
        /// 相似歌手
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<string> Artist(string data)
        {
             return _requestService.Request("SimiArtist", data);
        }

        /// <summary>
        /// 相似MV
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<string> Mv(string data)
        {
             return _requestService.Request("SimiMv", data);
        }

        /// <summary>
        /// 相似歌单
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<string> Playlist(string data)
        {
             return _requestService.Request("SimiPlaylist", data);
        }

        /// <summary>
        /// 相似歌曲
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<string> Song(string data)
        {
             return _requestService.Request("SimiSong", data);
        }

        /// <summary>
        /// 相似用户
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<string> User(string data)
        {
             return _requestService.Request("SimiUser", data);
        }
    }
}
