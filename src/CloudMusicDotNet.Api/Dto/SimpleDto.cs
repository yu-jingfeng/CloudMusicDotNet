using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudMusicDotNet.Api.Dto
{
    public class SimpleDto
    {
        /// <summary>
        /// 数据条数
        /// </summary>
        public int Limit { get; set; }

        /// <summary>
        /// 偏移数量
        /// </summary>
        public int Offset { get; set; }

        /// <summary>
        /// 总条数
        /// </summary>
        public bool Total { get; set; }
    }
}
