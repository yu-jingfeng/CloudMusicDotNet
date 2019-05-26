using CloudMusicDotNet.Commons.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CloudMusicDotNet.Commons.MusicServices
{
    public class EventService : IEventService
    {
        private readonly IRequestService _requestService;

        public EventService(IRequestService requestService)
        {
            _requestService = requestService;
        }

        /// <summary>
        /// 删除用户动态
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<string> Delete(string data)
        {
            return _requestService.Request("EventDel", data);
        }

        /// <summary>
        /// 转发用户动态
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<string> Forward(string data)
        {
            return _requestService.Request("EventForward", data);
        }
    }
}
