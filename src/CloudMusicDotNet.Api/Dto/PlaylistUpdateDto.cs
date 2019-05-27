using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudMusicDotNet.Api.Dto
{
    /// <summary>
    /// 更新歌单dto
    /// </summary>
    public class PlaylistUpdateDto
    {
        /// <summary>
        /// 歌单名字
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 歌单描述
        /// </summary>
        public string Desc { get; set; }

        /// <summary>
        /// 歌单tag
        /// </summary>
        public string Tags { get; set; }

    }
}
