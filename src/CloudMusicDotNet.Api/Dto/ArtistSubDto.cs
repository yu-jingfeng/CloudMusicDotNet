using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudMusicDotNet.Api.Dto
{
    public class ArtistSubDto
    {
        /// <summary>
        /// 歌手 id
        /// </summary>
        public string ArtistId { get; set; }

        /// <summary>
        /// 操作, sub/unsub
        /// </summary>
        public string T { get; set; }
    }
}
