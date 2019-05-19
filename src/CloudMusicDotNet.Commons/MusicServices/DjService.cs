using CloudMusicDotNet.Commons.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CloudMusicDotNet.Commons.MusicServices
{
    /// <summary>
    /// 电台服务
    /// </summary>
    public class DjService : IDjService
    {
        private readonly IRequestService _requestService;

        public DjService(IRequestService requestService)
        {
            _requestService = requestService;
        }

        /// <summary>
        /// 电台轮播图
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<string> Banner(string data)
        {
            return _requestService.Request("DjBanner", data);
        }

        /// <summary>
        /// 非热门类别
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<string> ExcludeHotCategory(string data)
        {
            return _requestService.Request("DjExcludeHot", data);
        }

        /// <summary>
        /// 电台推荐类型
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<string> RecommendCategory(string data)
        {
            return _requestService.Request("DjRecommendCategory", data);
        }

        /// <summary>
        /// 电台分类列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<string> Category(string data)
        {
            return _requestService.Request("DjCategory", data);
        }

        /// <summary>
        /// 电台详情
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<string> Detail(string data)
        {
            return _requestService.Request("DjDetail", data);
        }

        /// <summary>
        /// 热门电台
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<string> Hot(string data)
        {
            return _requestService.Request("DjHot", data);
        }

        /// <summary>
        /// 付费电台
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<string> Paygift(string data)
        {
            return _requestService.Request("DjPaygift", data);
        }

        /// <summary>
        /// 电台节目列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<string> Program(string data)
        {
            return _requestService.Request("DjProgram", data);
        }

        /// <summary>
        /// 电台节目详情
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<string> ProgramDetail(string data)
        {
            return _requestService.Request("DjProgramDetail", data);
        }

        /// <summary>
        /// 推荐电台
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<string> Recommend(string data)
        {
            return _requestService.Request("DjRecommend", data);
        }

        /// <summary>
        /// 电台分类推荐(按分类获得推荐电台)
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<string> TypeRecommend(string data)
        {
            return _requestService.Request("DjTypeRecommend", data);
        }

        /// <summary>
        /// 订阅与取消电台
        /// </summary>
        /// <param name="data"></param>
        /// <param name="t">操作 1 订阅, 0 取消订阅</param>
        /// <returns></returns>
        public Task<string> Sub(string data, int t)
        {
            return _requestService.Request("DjSub", data, t == 1 ? "sub" : "unsub");
        }

        /// <summary>
        /// 订阅电台列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<string> Sublist(string data)
        {
            return _requestService.Request("DjSublist", data);
        }

        /// <summary>
        /// 今日优选
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<string> TodayPerfered(string data)
        {
            return _requestService.Request("DjTodayPerfered", data);
        }
    }
}
