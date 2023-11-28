namespace TTMS.Api.Core
{
    /// <summary>
    /// 提供repository注册
    /// </summary>
    public static class RepositoryRegisterHelper
    {
        /// <summary>
        /// 批量注册repository
        /// </summary>
        /// <param name="services"></param>
        public static void RegisterRepositories(IServiceCollection services)
        {
            // 获取TTMS.Repository命名空间中所有以"Repository"结尾的接口类型
            var interfaceTypes = typeof(IUserRepository).Assembly.GetTypes()
                .Where(t => t.IsInterface && t.Namespace == "TTMS.Repository" && t.Name.EndsWith("Repository"));

            // 获取TTMS.Repository命名空间中所有以"Repository"结尾的非接口类型
            var repositoryTypes = typeof(UserRepository).Assembly.GetTypes()
                .Where(t => t.Namespace == "TTMS.Repository" && t.Name.EndsWith("Repository"))
                .Except(interfaceTypes);

            // 批量注册接口和实现类
            foreach (var interfaceType in interfaceTypes)
            {
                var repositoryType = repositoryTypes.FirstOrDefault(t => t.Name == $"{interfaceType.Name.Substring(1)}");
                if (repositoryType != null)
                {
                    services.AddScoped(interfaceType, repositoryType);
                }
            }
        }
    }
}
