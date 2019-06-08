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
        /// <param name="uid">用户id</param>
        /// <returns></returns>
        Task<string> Detail(string uid);

        /// <summary>
        /// 用户电台节目
        /// </summary>
        /// <param name="uid">用户id</param>
        /// <param name="limit">数据条数</param>
        /// <param name="offset">偏移量</param>
        /// <returns></returns>
        Task<string> Dj(string uid, int limit, int offset);

        /// <summary>
        /// 用户动态
        /// </summary>
        /// <param name="uid">用户id</param>
        /// <param name="limit">数据条数</param>
        /// <param name="time">返回数据的lasttime,默认-1,传入上一次返回结果的 lasttime,将会返回下一页的数据</param>
        /// <returns></returns>
        Task<string> Event(string uid, int limit, long time);

        /// <summary>
        /// 关注TA的人(粉丝)
        /// </summary>
        /// <param name="uid">用户id</param>
        /// <param name="limit">数据条数</param>
        /// <param name="offset">偏移量</param>
        /// <returns></returns>
        Task<string> Followers(string uid, int limit, int offset);

        /// <summary>
        /// TA关注的人(关注)
        /// </summary>
        /// <param name="uid">用户id</param>
        /// <param name="limit">数据条数</param>
        /// <param name="offset">偏移量</param>
        /// <returns></returns>
        Task<string> Followeds(string uid, int limit, int offset);

        /// <summary>
        /// 关注/取消关注用户
        /// </summary>
        /// <param name="uid">用户 id</param>
        /// <param name="t">1为关注,其他为取消关注</param>
        /// <returns></returns>
        Task<string> Follow(string uid, int t);

        /// <summary>
        /// 用户歌单
        /// </summary>
        /// <param name="uid">用户id</param>
        /// <param name="limit">数据条数</param>
        /// <param name="offset">偏移量</param>
        /// <returns></returns>
        Task<string> Playlist(string uid, int limit, int offset);

        /// <summary>
        /// 听歌排行
        /// </summary>
        /// <param name="uid">用户id</param>
        /// <param name="type">1: 最近一周, 0: 所有时间</param>
        /// <returns></returns>
        Task<string> Record(string uid, int type);

        /// <summary>
        /// 收藏计数
        /// </summary>
        /// <returns></returns>
        Task<string> SubCount();

        /// <summary>
        /// 编辑用户信息
        /// </summary>
        /// <param name="nickname">用户昵称</param>
        /// <param name="gender">性别 0:保密 1:男性 2:女性</param>
        /// <param name="birthday">出生日期,时间戳 unix timestamp</param>
        /// <param name="province">省份id</param>
        /// <param name="city">城市id</param>
        /// <param name="signature">用户签名</param>
        /// <param name="avatarImgId">头像id</param>
        /// <returns></returns>
        Task<string> Update(string nickname, int gender, long birthday, int province, int city, string signature, string avatarImgId);
    }
}
