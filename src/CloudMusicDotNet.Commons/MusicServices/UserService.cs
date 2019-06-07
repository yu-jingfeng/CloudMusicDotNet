using CloudMusicDotNet.Commons.Interfaces;
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
        public Task<string> Detail(string data, string uid)
        {
            return _requestService.Request("UserDetail", data, uid);
        }

        /// <summary>
        /// 用户电台节目
        /// </summary>
        /// <param name="data"></param>
        /// <param name="uid">用户id</param>
        /// <returns></returns>
        public Task<string> Dj(string data, string uid)
        {
            return _requestService.Request("UserDj", data, uid);
        }

        /// <summary>
        /// 用户动态
        /// </summary>
        /// <param name="data"></param>
        /// <param name="uid">用户id</param>
        /// <returns></returns>
        public Task<string> Event(string data, string uid)
        {
            return _requestService.Request("UserEvent", data, uid);
        }

        /// <summary>
        /// 关注TA的人(粉丝)
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<string> Followeds(string data)
        {
            return _requestService.Request("UserFolloweds", data);
        }

        /// <summary>
        /// TA关注的人(关注)
        /// </summary>
        /// <param name="data"></param>
        /// <param name="uid">用户id</param>
        /// <returns></returns>
        public Task<string> Follows(string data, string uid)
        {
            return _requestService.Request("UserFollows", data, uid);
        }

        /// <summary>
        /// 用户歌单
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<string> Playlist(string data)
        {
            return _requestService.Request("UserPlaylist", data);
        }

        /// <summary>
        /// 听歌排行
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<string> Record(string data, string uid)
        {
            return _requestService.Request("UserRecord", data, uid);
        }

        /// <summary>
        /// 收藏计数
        /// </summary>
        /// <param name="data"></param>
        /// <param name="uid">用户id</param>
        /// <returns></returns>
        public Task<string> SubCount(string data)
        {
            return _requestService.Request("UserSubCount", data);
        }

        /// <summary>
        /// 编辑用户信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<string> Update(string data)
        {
            return _requestService.Request("UserUpdate", data);
        }
    }
}
