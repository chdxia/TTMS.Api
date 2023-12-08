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
        /// <param name="config"></param>
        public static void RegisterHangfire(IServiceCollection services, IConfiguration config)
        {
            services.AddHangfire(configuration => configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UsePostgreSqlStorage(options =>
                {
                    options.UseNpgsqlConnection(config.GetConnectionString("HangfireDBConnection"));
                }));
        }
    }
}
