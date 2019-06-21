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
        /// <param name="area">区域 ALL,ZH,EA,KR,JP</param>
        /// <param name="limit">数据条数</param>
        /// <param name="offset">偏移量</param>
        /// <param name="total">是否获取总条数</param>
        /// <returns></returns>
        Task<string> New(string area, int limit, int offset, bool total);

        /// <summary>
        /// 热门新碟（新碟上架）
        /// </summary>
        /// <returns></returns>
        Task<string> Hot();

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