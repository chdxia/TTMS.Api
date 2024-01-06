namespace TTMS.Api.Core
{
    /// <summary>
    /// 提供FreeSql实例的创建和配置
    /// </summary>
    public class FreeSqlProvider
    {
        /// <summary>
        /// 创建FreeSql实例
        /// </summary>
        /// <returns></returns>
        public static IFreeSql CreateFreeSqlInstance(IConfiguration Configuration)
        {
            IFreeSql fsql = new FreeSql.FreeSqlBuilder()
                .UseConnectionString(FreeSql.DataType.PostgreSQL, Configuration.GetConnectionString("DefaultDBConnection"))
                .UseMonitorCommand(cmd => Console.WriteLine($"Sql：{cmd.CommandText}")) // 监听SQL语句
                .UseAutoSyncStructure(true) // 自动同步实体结构到数据库，FreeSql不会扫描程序集，只有CRUD时才会生成表
                .Build();

            return fsql;
        }
    }
}
