using CloudMusicDotNet.Commons.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CloudMusicDotNet.Commons.MusicServices
{
    /// <summary>
    /// 云盘服务
    /// </summary>
    public class CloudService : ICloudService
    {
        private readonly IRequestService _requestService;

        public CloudService(IRequestService requestService)
        {
            _requestService = requestService;
        }

        /// <summary>
        /// 获取云盘数据,获取的数据没有对应url,需要调用/song/url获取url
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<string> List(string data)
        {
            return _requestService.Request("Cloud", data);
        }

        /// <summary>
        /// 云盘数据详情
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<string> Detail(string data)
        {
            return _requestService.Request("CloudDetail", data);
        }

        /// <summary>
        /// 云盘歌曲删除
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<string> Delete(string data)
        {
            return _requestService.Request("CloudDelete", data);
        }
    }
}
