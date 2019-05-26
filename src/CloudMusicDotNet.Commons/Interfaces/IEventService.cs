using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CloudMusicDotNet.Commons.Interfaces
{
    /// <summary>
    /// 动态服务
    /// </summary>
    public interface IEventService
    {
        /// <summary>
        /// 删除用户动态
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> Delete(string data);

        /// <summary>
        /// 转发用户动态
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> Forward(string data);
    }
}
