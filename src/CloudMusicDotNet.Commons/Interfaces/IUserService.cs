using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CloudMusicDotNet.Commons.Interfaces
{
    /// <summary>
    /// 用户相关服务
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// 用户详情
        /// </summary>
        /// <param name="data"></param>
        /// <param name="uid">用户id</param>
        /// <returns></returns>
        Task<string> Detail(string data,string uid);

        /// <summary>
        /// 用户电台节目
        /// </summary>
        /// <param name="data"></param>
        /// <param name="uid">用户id</param>
        /// <returns></returns>
        Task<string> Dj(string data,string uid);

        /// <summary>
        /// 用户动态
        /// </summary>
        /// <param name="data"></param>
        /// <param name="uid">用户id</param>
        /// <returns></returns>
        Task<string> Event(string data,string uid);

        /// <summary>
        /// 关注TA的人(粉丝)
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> Followeds(string data);

        /// <summary>
        /// TA关注的人(关注)
        /// </summary>
        /// <param name="data"></param>
        /// <param name="uid">用户id</param>
        /// <returns></returns>
        Task<string> Follows(string data, string uid);

        /// <summary>
        /// 用户歌单
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> Playlist(string data);

        /// <summary>
        /// 听歌排行
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> Record(string data, string uid);

        /// <summary>
        /// 收藏计数
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> SubCount(string data);

        /// <summary>
        /// 编辑用户信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> Update(string data);
    }
}
