using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudMusicDotNet.Api.Dto
{
    public class NewAlbumDto : SimpleDto
    {
        /// <summary>
        /// 地区 ALL(所有),ZH(华语),EA(欧美),KR(韩国),JP(日本)
        /// </summary>
        public string Area { get; set; }
    }
}
