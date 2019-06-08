using CloudMusicDotNet.Commons.Interfaces;
using Newtonsoft.Json.Linq;
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

        /// <summary>
        /// 推荐节目
        /// </summary>
        /// <param name="cateId">类别id</param>
        /// <param name="limit">数据条数</param>
        /// <param name="offset">偏移量</param>
        /// <returns></returns>
        public Task<string> Program(string cateId, int limit = 10, int offset = 0)
        {
            var json = new JObject
            {
                { "cateId", cateId },
                { "limit", limit },
                { "offset", offset }
            };
            var data = json.ToString();

            return _requestService.Request("PersonalizedProgram", data);
        }
    }
}
