using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CloudMusicDotNet.Commons.Interfaces
{
    /// <summary>
    /// 云盘服务
    /// </summary>
    public interface ICloudService
    {
        /// <summary>
        /// 获取云盘数据,获取的数据没有对应url,需要调用/song/url获取url
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> List(string data);

        /// <summary>
        /// 云盘数据详情
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> Detail(string data);

        /// <summary>
        /// 云盘歌曲删除
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> Delete(string data);
    }
}
