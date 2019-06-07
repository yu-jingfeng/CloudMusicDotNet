using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CloudMusicDotNet.Api.Dto
{
    public class PhoneLoginDto
    {
        /// <summary>
        /// 手机号
        /// </summary>
        [Required]
        public string Phone { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// 国家码，用于国外手机号登陆，例如美国传入：1
        /// </summary>
        public string Countrycode { get; set; }
    }
}
