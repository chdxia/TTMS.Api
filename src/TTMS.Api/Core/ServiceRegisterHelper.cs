namespace TTMS.Api.Core
{
    /// <summary>
    /// 提供service注册
    /// </summary>
    public static class ServiceRegisterHelper
    {
        /// <summary>
        /// 批量注册service
        /// </summary>
        /// <param name="services"></param>
        public static void RegisterServices(IServiceCollection services)
        {
            // 获取TTMS.Service命名空间中所有以"Service"结尾的接口类型
            var interfaceTypes = typeof(IUserService).Assembly.GetTypes()
                .Where(t => t.IsInterface && t.Namespace == "TTMS.Service" && t.Name.EndsWith("Service"));

            // 获取TTMS.Service命名空间中所有以"Service"结尾的非接口类型
            var serviceTypes = typeof(UserService).Assembly.GetTypes()
                .Where(t => t.Namespace == "TTMS.Service" && t.Name.EndsWith("Service"))
                .Except(interfaceTypes);

            // 批量注册接口和实现类
            foreach (var interfaceType in interfaceTypes)
            {
                var serviceType = serviceTypes.FirstOrDefault(t => t.Name == $"{interfaceType.Name.Substring(1)}");
                if (serviceType != null)
                {
                    services.AddScoped(interfaceType, serviceType);
                }
            }
        }
    }
}
