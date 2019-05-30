using CloudMusicDotNet.Commons.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CloudMusicDotNet.Commons.MusicServices
{
    public class SearchService : ISearchService
    {
        private readonly IRequestService _requestService;

        public SearchService(IRequestService requestService)
        {
            _requestService = requestService;
        }

        /// <summary>
        /// 普通搜索
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<string> Get(string data)
        {
            return _requestService.Request("Search", data);
        }

        /// <summary>
        /// 热门搜索
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<string> Hot(string data)
        {
            return _requestService.Request("SearchHot", data);
        }

        /// <summary>
        /// 多类型搜索
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<string> Multimatch(string data)
        {
            return _requestService.Request("SearchMultimatch", data);
        }

        /// <summary>
        /// 搜索建议
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type">如果传 'mobile' 则返回移动端数据</param>
        /// <returns></returns>
        public Task<string> Suggest(string data, string type)
        {
            return _requestService.Request("SearchSuggest", data, (type == "mobile" ? "keyword" : "web"));
        }
    }
}
