using Hangfire.Dashboard;

namespace TTMS.Api.Core
{
    /// <summary>
    /// hangfire授权
    /// </summary>
    public class HangfireDashboardAuthorizationFilter : IDashboardAuthorizationFilter
    {
        /// <summary>
        /// 授权访问hangfire仪表盘
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public bool Authorize(DashboardContext context)
        {
            // 在此处实现自定义的授权逻辑
            // 返回 true 表示授权通过，返回 false 表示拒绝访问
            return true;
        }
    }
}
