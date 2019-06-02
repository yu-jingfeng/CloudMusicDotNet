using CloudMusicDotNet.Commons.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CloudMusicDotNet.Commons.MusicServices
{
    public class VideoService : IVideoService
    {
        private readonly IRequestService _requestService;

        public VideoService(IRequestService requestService)
        {
            _requestService = requestService;
        }

        /// <summary>
        /// 视频详情
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<string> Detail(string data)
        {
            return _requestService.Request("VideoDetail", data);
        }

        /// <summary>
        /// 获取视频标签下的视频
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<string> Group(string data)
        {
            return _requestService.Request("VideoGroup", data);
        }

        /// <summary>
        /// 收藏与取消收藏视频
        /// </summary>
        /// <param name="data"></param>
        /// <param name="t">操作: 1 收藏 ,0 取消收藏</param>
        /// <returns></returns>
        public Task<string> Sub(string data, int t)
        {
            return _requestService.Request("VideoSub", data, (t == 1 ? "sub" : "unsub"));
        }

        /// <summary>
        /// 视频链接
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<string> Url(string data)
        {
            return _requestService.Request("VideoUrl", data);
        }
    }
}
