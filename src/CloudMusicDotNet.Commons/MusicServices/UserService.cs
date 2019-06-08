using CloudMusicDotNet.Commons.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CloudMusicDotNet.Commons.MusicServices
{
    public class UserService : IUserService
    {
        private readonly IRequestService _requestService;

        public UserService(IRequestService requestService)
        {
            _requestService = requestService;
        }

        /// <summary>
        /// 用户详情
        /// </summary>
        /// <param name="data"></param>
        /// <param name="uid">用户id</param>
        /// <returns></returns>
        public Task<string> Detail(string uid)
        {
            return _requestService.Request("UserDetail", DataBody.Empty, uid);
        }

        /// <summary>
        /// 用户电台节目
        /// </summary>
        /// <param name="uid">用户id</param>
        /// <param name="limit">数据条数</param>
        /// <param name="offset">偏移量</param>
        /// <returns></returns>
        public Task<string> Dj(string uid, int limit = 30, int offset = 0)
        {
            var json = new JObject
            {
                { "limit", limit },
                { "offset", offset }
            };
            var data = json.ToString();

            return _requestService.Request("UserDj", data, uid);
        }

        /// <summary>
        /// 用户动态
        /// </summary>
        /// <param name="uid">用户id</param>
        /// <param name="limit">数据条数</param>
        /// <param name="time">返回数据的lasttime,默认-1,传入上一次返回结果的 lasttime,将会返回下一页的数据</param>
        /// <returns></returns>
        public Task<string> Event(string uid, int limit = 30, long time = -1)
        {
            var json = new JObject
            {
                { "limit", limit },
                { "time", time },
                { "total", true },
                { "getcounts", true }
            };
            var data = json.ToString();

            return _requestService.Request("UserEvent", data, uid);
        }

        /// <summary>
        /// 关注TA的人(粉丝)
        /// </summary>
        /// <param name="uid">用户id</param>
        /// <param name="limit">数据条数</param>
        /// <param name="offset">偏移量</param>
        /// <returns></returns>
        public Task<string> Followers(string uid, int limit = 30, int offset = 0)
        {
            var json = new JObject
            {
                { "userId", uid },
                { "limit", limit },
                { "offset", offset }
            };
            var data = json.ToString();

            return _requestService.Request("UserFollowers", data, uid);
        }

        /// <summary>
        /// TA关注的人(关注)
        /// </summary>
        /// <param name="uid">用户id</param>
        /// <param name="limit">数据条数</param>
        /// <param name="offset">偏移量</param>
        /// <returns></returns>
        public Task<string> Followeds(string uid, int limit = 30, int offset = 0)
        {
            var json = new JObject
            {
                { "order", true },
                { "limit", limit },
                { "offset", offset }
            };
            var data = json.ToString();

            return _requestService.Request("UserFolloweds", data, uid);
        }

        /// <summary>
        /// 关注/取消关注用户
        /// </summary>
        /// <param name="uid">用户 id</param>
        /// <param name="t">1为关注,其他为取消关注</param>
        /// <returns></returns>
        public Task<string> Follow(string uid, int t)
        {
            string queryString = $"{(t == 1 ? "follow" : "delfollow")}/{uid}";
            return _requestService.Request("UserFollow", "{}", queryString);
        }

        /// <summary>
        /// 用户歌单
        /// </summary>
        /// <param name="uid">用户id</param>
        /// <param name="limit">数据条数</param>
        /// <param name="offset">偏移量</param>
        /// <returns></returns>
        public Task<string> Playlist(string uid, int limit = 30, int offset = 0)
        {
            var json = new JObject
            {
                { "uid", uid },
                { "limit", limit },
                { "offset", offset }
            };
            var data = json.ToString();

            return _requestService.Request("UserPlaylist", data);
        }

        /// <summary>
        /// 听歌排行
        /// </summary>
        /// <param name="uid">用户id</param>
        /// <param name="type">1: 最近一周, 0: 所有时间</param>
        /// <returns></returns>
        public Task<string> Record(string uid, int type = 1)
        {
            var json = new JObject
            {
                { "uid", uid },
                { "type", type }
            };
            var data = json.ToString();

            return _requestService.Request("UserRecord", data);
        }

        /// <summary>
        /// 收藏计数
        /// </summary>
        /// <returns></returns>
        public Task<string> SubCount()
        {
            return _requestService.Request("UserSubCount", DataBody.Empty);
        }

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
        public Task<string> Update(string nickname, int gender, long birthday, int province, int city, string signature, string avatarImgId = "0")
        {
            var json = new JObject
            {
                { "nickname", nickname },
                { "gender", gender },
                { "birthday", birthday },
                { "province", province },
                { "city", city },
                { "signature", signature },
                { "avatarImgId", avatarImgId }
            };
            var data = json.ToString();

            return _requestService.Request("UserUpdate", data);
        }
    }
}
