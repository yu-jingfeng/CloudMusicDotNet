using CloudMusicDotNet.Commons.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CloudMusicDotNet.Commons.MusicServices
{
    /// <summary>
    /// 每日推荐服务
    /// </summary>
    public class RecommendService : IRecommendService
    {
        private readonly IRequestService _requestService;

        public RecommendService(IRequestService requestService)
        {
            _requestService = requestService;
        }

        /// <summary>
        /// 每日推荐歌曲
        /// </summary>
        /// <returns></returns>
        public Task<string> Songs()
        {
            var json = new JObject
            {
                { "limit", 30 },
                { "offset", 0 },
                { "total", true }
            };
            var data = json.ToString();

            return _requestService.Request("RecommendSongs", data);
        }

        /// <summary>
        /// 每日推荐歌单
        /// </summary>
        /// <returns></returns>
        public Task<string> Resource()
        {
            return _requestService.Request("RecommendResource", DataBody.Empty);
        }
    }
}
