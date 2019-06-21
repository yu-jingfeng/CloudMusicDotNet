using CloudMusicDotNet.Commons.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CloudMusicDotNet.Commons.MusicServices
{
    /// <summary>
    /// 专辑相关服务
    /// </summary>
    public class AlbumService : IAlbumService
    {
        private readonly IRequestService _requestService;

        public AlbumService(IRequestService requestService)
        {
            _requestService = requestService;
        }

        /// <summary>
        /// 全部新碟（最新专辑）
        /// </summary>
        /// <param name="area">区域 ALL,ZH,EA,KR,JP</param>
        /// <param name="limit">数据条数</param>
        /// <param name="offset">偏移量</param>
        /// <param name="total">是否获取总条数</param>
        /// <returns></returns>
        public Task<string> New(string area, int limit, int offset, bool total)
        {
            var json = new JObject
            {
                { "area", area },
                { "limit", limit },
                { "offset", offset },
                { "total", total }
            };
            var data = json.ToString();

            return _requestService.Request("NewAlubm", data);
        }

        /// <summary>
        /// 已收藏专辑列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<string> Sublist(string data)
        {
            var result = await _requestService.Request("SubAlubm", data);

            return result;
        }

        /// <summary>
        /// 专辑内容
        /// </summary>
        /// <param name="data"></param>
        /// <param name="queryString">专辑Id</param>
        /// <returns></returns>
        public async Task<string> Content(string data, string id)
        {
            var result = await _requestService.Request("AlubmContent", data, id);

            return result;
        }

        /// <summary>
        /// 热门新碟（新碟上架）
        /// </summary>
        /// <returns></returns>
        public Task<string> Hot()
        {
            return _requestService.Request("AlubmHot", DataBody.Empty);
        }
    }
}
