using CloudMusicDotNet.Commons.Interfaces;
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
        /// <param name="data">JSON格式的参数</param>
        /// <returns></returns>
        public async Task<string> NewAlubm(string data)
        {
            var result = await _requestService.Request("NewAlubm", data);

            return result;
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
    }
}
