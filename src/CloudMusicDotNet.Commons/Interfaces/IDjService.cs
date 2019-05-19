using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CloudMusicDotNet.Commons.Interfaces
{
    /// <summary>
    /// 电台服务
    /// </summary>
    public interface IDjService
    {
        /// <summary>
        /// 电台轮播图
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> Banner(string data);

        /// <summary>
        /// 非热门类别
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> ExcludeHotCategory(string data);

        /// <summary>
        /// 电台推荐类型
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> RecommendCategory(string data);

        /// <summary>
        /// 电台分类列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> Category(string data);

        /// <summary>
        /// 电台详情
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> Detail(string data);

        /// <summary>
        /// 热门电台
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> Hot(string data);

        /// <summary>
        /// 付费电台
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> Paygift(string data);

        /// <summary>
        /// 电台节目列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> Program(string data);

        /// <summary>
        /// 电台节目详情
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> ProgramDetail(string data);

        /// <summary>
        /// 推荐电台
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> Recommend(string data);

        /// <summary>
        /// 电台分类推荐(按分类获得推荐电台)
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> TypeRecommend(string data);

        /// <summary>
        /// 订阅与取消电台
        /// </summary>
        /// <param name="data"></param>
        /// <param name="t">操作 1 订阅, 0 取消订阅</param>
        /// <returns></returns>
        Task<string> Sub(string data, int t);

        /// <summary>
        /// 订阅电台列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> Sublist(string data);

        /// <summary>
        /// 今日优选
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> TodayPerfered(string data);
    }
}
