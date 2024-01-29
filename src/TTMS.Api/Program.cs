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

            // 自定义配置文件
            builder.Configuration.AddJsonFile("appsettings.Dev.json");


            // 注册服务
            builder.Services.AddCustomAuthentication(builder.Configuration); // 注册身份验证

            builder.Services.AddControllers(options => options.Filters.Add(typeof(ValidateModelAttribute))) // 注册控制器以及自定义全局过滤器
                .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new DateTimeConverter())) // 时间序列化
                .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null) // 禁用默认的属性命名策略，JSON字符串中的属性名将保持原样
                .AddDataAnnotationsLocalization(); 

            builder.Services.AddScoped<ValidateModelAttribute>(); // 自定义全局过滤器

            builder.Services.AddHttpContextAccessor();

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(SwaggerProvider.ConfigureSwaggerGen); // Swagger配置

            builder.Services.AddAutoMapper(typeof(DTO.Mapper.UserMapper).Assembly); // 注册映射规则

            builder.Services.AddSingleton(FreeSqlProvider.CreateFreeSqlInstance(builder.Configuration)); // 注册FreeSql实例

            builder.Services.RegisterHangfire(builder.Configuration); // 注册hangfire

            builder.Services.RegisterRepositories(); // 批量注册Repository层接口

            builder.Services.RegisterServices(); // 批量注册Service层接口

            builder.Services.AddHangfireServer(); // hangfire服务


            var app = builder.Build();

            //if (app.Environment.IsDevelopment())
            //{
            //    app.UseSwagger();
            //    app.UseSwaggerUI();
            //}
            app.UseSwagger();
            app.UseSwaggerUI( options => { options.OAuthUseBasicAuthenticationWithAccessCodeGrant(); } ); // swagger支持jwt认证

            app.UseHangfireDashboard("/hangfire", new DashboardOptions {Authorization = new[] { new HangfireDashboardAuthorizationFilter() }}); // hangfire面板

            app.UseHttpsRedirection();

            app.UseMiddleware<ExceptionHandlerMiddleware>(); // 异常处理中间件

            app.UseAuthentication(); // 身份验证

            app.UseAuthorization(); // 权限验证

            app.MapControllers();

            app.Run();
        }
    }
}
