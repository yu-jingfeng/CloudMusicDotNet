using CloudMusicDotNet.Commons.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CloudMusicDotNet.Commons.MusicServices
{
    public class ToplistService : IToplistService
    {
        private readonly IRequestService _requestService;

        public ToplistService(IRequestService requestService)
        {
            _requestService = requestService;
        }

        /// <summary>
        /// 歌手榜
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<string> Artist(string data)
        {
            return _requestService.Request("ToplistArtist", data);
        }

        /// <summary>
        /// 所有榜单内容摘要
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<string> Detail(string data)
        {
            return _requestService.Request("ToplistDetail", data);
        }

        public Task<string> All(string data)
        {
            return _requestService.Request("Toplist", data);
        }
    }
}
