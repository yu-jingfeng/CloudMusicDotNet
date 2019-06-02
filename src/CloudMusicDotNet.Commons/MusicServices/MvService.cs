using CloudMusicDotNet.Commons.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CloudMusicDotNet.Commons.MusicServices
{
    /// <summary>
    /// MV服务
    /// </summary>
    public class MvService : IMvService
    {
        private readonly IRequestService _requestService;

        public MvService(IRequestService requestService)
        {
            _requestService = requestService;
        }

        /// <summary>
        /// MV详情
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<string> Detail(string data)
        {
            return _requestService.Request("MvDetail", data);
        }

        /// <summary>
        /// 最新MV
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<string> First(string data)
        {
            return _requestService.Request("MvFirst", data);
        }

        /// <summary>
        /// 收藏与取消收藏MV
        /// </summary>
        /// <param name="data"></param>
        /// <param name="t">操作 1 收藏, 0 取消收藏</param>
        /// <returns></returns>
        public Task<string> Sub(string data, int t)
        {
            return _requestService.Request("MvSub", data, (t == 1 ? "sub" : "unsub"));
        }

        /// <summary>
        /// 已收藏MV列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<string> Sublist(string data)
        {
            return _requestService.Request("MvSublist", data);
        }

        /// <summary>
        /// MV链接
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<string> Url(string data)
        {
            return _requestService.Request("MvUrl", data);
        }

        /// <summary>
        /// MV排行榜
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<string> TopList(string data)
        {
            return _requestService.Request("MvTopList", data);
        }
    }
}
