using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudMusicDotNet.Api.Dto
{
    public class ArtistMvsDto : SimpleDto
    {
        /// <summary>
        /// 歌手id
        /// </summary>
        public string ArtistId { get; set; }
    }
}
