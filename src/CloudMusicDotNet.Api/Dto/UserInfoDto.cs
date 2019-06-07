using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudMusicDotNet.Api.Dto
{
    /// <summary>
    /// 用户信息dto
    /// </summary>
    public class UserInfoDto
    {
        /// <summary>
        /// 用户昵称
        /// </summary>
        public string Nickname { get; set; }

        /// <summary>
        /// 性别 0:保密 1:男性 2:女性
        /// </summary>
        public int Gender { get; set; }

        /// <summary>
        /// 出生日期,时间戳 unix timestamp
        /// </summary>
        public long Birthday { get; set; }

        /// <summary>
        /// 省份id
        /// </summary>
        public int Province { get; set; }

        /// <summary>
        /// 城市id
        /// </summary>
        public int City { get; set; }

        /// <summary>
        /// 用户签名
        /// </summary>
        public string Signature { get; set; }

        /// <summary>
        /// 头像id
        /// </summary>
        public string AvatarImgId { get; set; } = "0";
    }
}
