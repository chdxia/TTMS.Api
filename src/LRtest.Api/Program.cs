using AutoMapper;
using LRtest.Domain;

var builder = WebApplication.CreateBuilder(args);


// 获取配置
var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.Dev.json")
    .Build();


// 注册服务
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.DocInclusionPredicate((docName, apiDesc) =>
    {
        return true; // 包含所有控制器和操作方法，根据需要修改左面的逻辑来包含或排除特定的控制器和操作方法
    });
    options.DocumentFilter<LRtest.Api.EnumDocumentFilter>(); // 显示枚举值;枚举属性;枚举描述
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "LRtest.Enums.xml"));
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "LRtest.DTO.xml"));
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "LRtest.Api.xml")); // 启用 XML 注释
});

builder.Services.AddSingleton(r =>
{
    IFreeSql fsql = new FreeSql.FreeSqlBuilder()
        .UseConnectionString(FreeSql.DataType.PostgreSQL, @config.GetSection("DBConnectionStrings")["DefaultConnection"])
        .UseMonitorCommand(cmd => Console.WriteLine($"Sql：{cmd.CommandText}")) // 监听SQL语句
        .UseAutoSyncStructure(true) // 自动同步实体结构到数据库，FreeSql不会扫描程序集，只有CRUD时才会生成表
        .Build();
    return fsql;
});

builder.Services.AddSingleton(provider =>
{
    var config = new MapperConfiguration(cfg =>
    {
        cfg.CreateMap<UserRequest, User>(); // 映射规则
        cfg.CreateMap<User, UserResponse>();
    });

    return config.CreateMapper();
});

builder.Services.AddSingleton<IUserRepository, UserRepository>();


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
