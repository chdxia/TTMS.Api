var builder = WebApplication.CreateBuilder(args);

// 获取配置
var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.Dev.json")
    .Build();

Func<IServiceProvider, IFreeSql> fsqlFactory = r =>
{
    IFreeSql fsql = new FreeSql.FreeSqlBuilder()
        .UseConnectionString(FreeSql.DataType.PostgreSQL, @config.GetSection("DBConnectionStrings")["DefaultConnection"])
        .UseMonitorCommand(cmd => Console.WriteLine($"Sql：{cmd.CommandText}")) // 监听SQL语句
        .UseAutoSyncStructure(true) // 自动同步实体结构到数据库，FreeSql不会扫描程序集，只有CRUD时才会生成表
        .Build();
    return fsql;
};

// 注册服务
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.DocInclusionPredicate((docName, apiDesc) =>
    {
        return true; // 包含所有控制器和操作方法，根据需要修改左面的逻辑来包含或排除特定的控制器和操作方法
    });
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "LRtest.Api.xml")); // 启用 XML 注释
});
builder.Services.AddSingleton(fsqlFactory);
builder.Services.AddSingleton<IUserRepository, UserRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
