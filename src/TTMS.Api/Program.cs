using Hangfire;

namespace TTMS.Api
{
    /// <summary>
    /// 应用程序入口
    /// </summary>
    public class Program
    {
        /// <summary>
        /// 应用程序入口
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // 获取配置
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Dev.json")
                .Build();


            // 注册服务
            builder.Services.AddControllers(options => options.Filters.Add(typeof(ValidateModelAttribute)))
                .AddDataAnnotationsLocalization(); // 注册控制器以及自定义全局过滤器

            builder.Services.AddScoped<ValidateModelAttribute>(); // 自定义全局过滤器

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(SwaggerProvider.ConfigureSwaggerGen); // Swagger配置

            builder.Services.AddAutoMapper(typeof(DTO.Mapper.UserMapper).Assembly); // 注册映射规则

            //builder.Services.AddSingleton<IConfiguration>(config); // 注册配置

            builder.Services.AddSingleton(FreeSqlProvider.CreateFreeSqlInstance(config)); // 注册FreeSql实例

            HangfireRegisterHelper.RegisterHangfire(builder.Services, config); // 注册hangfire

            RepositoryRegisterHelper.RegisterRepositories(builder.Services); // 批量注册Repository层接口

            ServiceRegisterHelper.RegisterServices(builder.Services); // 批量注册Service层接口

            builder.Services.AddHangfireServer();


            var app = builder.Build();

            //if (app.Environment.IsDevelopment())
            //{
            //    app.UseSwagger();
            //    app.UseSwaggerUI();
            //}
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHangfireDashboard("/hangfire", new DashboardOptions
            {
                Authorization = new[] { new HangfireDashboardAuthorizationFilter() }
            });

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
