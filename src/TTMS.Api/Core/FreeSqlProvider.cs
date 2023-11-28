namespace TTMS.Api.Core
{
    /// <summary>
    /// 提供FreeSql实例的创建和配置
    /// </summary>
    public class FreeSqlProvider
    {
        private readonly IConfiguration _config;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="config"></param>
        public FreeSqlProvider(IConfiguration config)
        {
            _config = config;
        }

        /// <summary>
        /// 创建FreeSql实例
        /// </summary>
        /// <returns></returns>
        public static IFreeSql CreateFreeSqlInstance(IConfiguration config)
        {
            IFreeSql fsql = new FreeSql.FreeSqlBuilder()
                .UseConnectionString(FreeSql.DataType.PostgreSQL, config.GetConnectionString("DefaultDBConnection"))
                .UseMonitorCommand(cmd => Console.WriteLine($"Sql：{cmd.CommandText}")) // 监听SQL语句
                .UseAutoSyncStructure(true) // 自动同步实体结构到数据库，FreeSql不会扫描程序集，只有CRUD时才会生成表
                .Build();

            return fsql;
        }
    }
}
