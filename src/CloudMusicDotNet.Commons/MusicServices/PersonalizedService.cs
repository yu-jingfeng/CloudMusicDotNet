using CloudMusicDotNet.Commons.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CloudMusicDotNet.Commons.MusicServices
{
    /// <summary>
    /// 个性化推荐服务
    /// </summary>
    public class PersonalizedService : IPersonalizedService
    {
        private readonly IRequestService _requestService;

        public PersonalizedService(IRequestService requestService)
        {
            _requestService = requestService;
        }

        /// <summary>
        /// 推荐电台
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<string> DjProgram(string data)
        {
            return _requestService.Request("PersonalizedDj", data);
        }

        /// <summary>
        /// 推荐MV
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<string> Mv(string data)
        {
            return _requestService.Request("PersonalizedMv", data);
        }

        /// <summary>
        /// 推荐新歌
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<string> NewSong(string data)
        {
            return _requestService.Request("PersonalizedNewSong", data);
        }

        /// <summary>
        /// 独家放送
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<string> PrivateContent(string data)
        {
            return _requestService.Request("PrivateContent", data);
        }

        /// <summary>
        /// 推荐歌单
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<string> PlayList(string data)
        {
            return _requestService.Request("PersonalizedPlayList", data);
        }
    }
}
