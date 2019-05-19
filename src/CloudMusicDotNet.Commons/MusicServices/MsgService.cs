using CloudMusicDotNet.Commons.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CloudMusicDotNet.Commons.MusicServices
{
    /// <summary>
    /// 消息通知服务
    /// </summary>
    public class MsgService : IMsgService
    {
        private readonly IRequestService _requestService;

        public MsgService(IRequestService requestService)
        {
            _requestService = requestService;
        }

        /// <summary>
        /// 评论消息
        /// </summary>
        /// <param name="data"></param>
        /// <param name="userId">用户id</param>
        /// <returns></returns>
        public Task<string> Comments(string data, string userId)
        {
            return _requestService.Request("CommentsMsg", data, userId);
        }

        /// <summary>
        /// @我
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<string> Forwards(string data)
        {
            return _requestService.Request("ForwardsMsg", data);
        }

        /// <summary>
        /// 通知消息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<string> Notices(string data)
        {
            return _requestService.Request("NoticesMsg", data);
        }

        /// <summary>
        /// 私信消息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<string> Private(string data)
        {
            return _requestService.Request("PrivateMsg", data);
        }
    }
}
