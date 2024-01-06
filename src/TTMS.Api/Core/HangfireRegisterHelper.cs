using Hangfire;
using Hangfire.PostgreSql;

namespace TTMS.Api.Core
{
    /// <summary>
    /// 提供hangfire注册
    /// </summary>
    public static class HangfireRegisterHelper
    {
        /// <summary>
        /// 注册hangfire
        /// </summary>
        /// <param name="services"></param>
        /// <param name="Configuration"></param>
        public static void RegisterHangfire(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddHangfire(options => options
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UsePostgreSqlStorage(options =>
                {
                    options.UseNpgsqlConnection(Configuration.GetConnectionString("HangfireDBConnection"));
                }));
        }
    }
}
