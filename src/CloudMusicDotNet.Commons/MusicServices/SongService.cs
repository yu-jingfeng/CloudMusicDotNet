using CloudMusicDotNet.Commons.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CloudMusicDotNet.Commons.MusicServices
{
    /// <summary>
    /// 歌曲相关服务
    /// </summary>
    public class SongService : ISongService
    {
        private readonly IRequestService _requestService;

        public SongService(IRequestService requestService)
        {
            _requestService = requestService;
        }

        /// <summary>
        /// 歌曲详情
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<string> Detail(string data)
        {
            return _requestService.Request("SongDetail", data);
        }

        /// <summary>
        /// 歌曲链接
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<string> Url(string data)
        {
            return _requestService.Request("SongUrl", data);
        }

        /// <summary>
        /// 歌曲可用性
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<string> Check(string data)
        {
            var result = await _requestService.Request("SongCheck", data);

            if (result.Contains("\"code\":404"))
                result = "{success:false,message:\"亲爱的,暂无版权\"}"; 
            else
                result = "{success:true,message:'ok'}";

            return result;
        }

        /// <summary>
        /// 歌词
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<string> Lyric(string data)
        {
            return _requestService.Request("SongLyric", data);
        }

        /// <summary>
        /// 喜欢的歌曲列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<string> LikeList(string data)
        {
            return _requestService.Request("SongLikeList", data);
        }

        /// <summary>
        /// 新歌速递
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<string> New(string data)
        {
            return _requestService.Request("SongLikeList", data);
        }
    }
}
