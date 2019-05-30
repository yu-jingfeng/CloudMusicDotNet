using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CloudMusicDotNet.Commons.Interfaces
{
    /// <summary>
    /// 搜索服务
    /// </summary>
    public interface ISearchService
    {
        /// <summary>
        /// 热门搜索
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> Hot(string data);

        /// <summary>
        /// 多类型搜索
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> Multimatch(string data);

        /// <summary>
        /// 搜索建议
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        Task<string> Suggest(string data, string type);

        /// <summary>
        /// 普通搜索
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> Get(string data);
    }
}
