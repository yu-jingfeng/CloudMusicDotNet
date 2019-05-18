using System.Threading.Tasks;

namespace CloudMusicDotNet.Commons.Interfaces
{
    /// <summary>
    /// 专辑服务
    /// </summary>
    public interface IAlbumService
    {
        /// <summary>
        /// 全部新碟（最新专辑）
        /// </summary>
        /// <param name="data">JSON格式的参数</param>
        /// <returns></returns>
        Task<string> NewAlubm(string data);

        /// <summary>
        /// 已收藏专辑列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> Sublist(string data);

        /// <summary>
        /// 专辑内容
        /// </summary>
        /// <param name="data"></param>
        /// <param name="id">专辑Id</param>
        /// <returns></returns>
        Task<string> Content(string data, string id);
    }
}