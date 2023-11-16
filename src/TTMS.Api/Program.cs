var builder = WebApplication.CreateBuilder(args);


// 获取配置
var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.Dev.json")
    .Build();


// 注册服务
builder.Services.AddControllers(options =>{options.Filters.Add(typeof(ValidateModelAttribute));}).AddDataAnnotationsLocalization(); // 注册自定义全局过滤器

builder.Services.AddScoped<ValidateModelAttribute>();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(SwaggerProvider.ConfigureSwaggerGen); // Swagger配置

builder.Services.AddAutoMapper(typeof(TTMS.DTO.Mapper.UserMapper).Assembly); // 注册映射规则

builder.Services.AddSingleton(r => FreeSqlProvider.CreateFreeSqlInstance(config)); // FreeSql实例

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IGroupRepository, GroupRepository>();
builder.Services.AddScoped<IVersionInfoRepository, VersionInfoRepository>();
builder.Services.AddScoped<IDemandRepository, DemandRepository>();

builder.Services.AddScoped<IDemandService, DemandService>();

var app = builder.Build();

/*if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}*/
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
