using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace TTMS.Api.Core
{
    /// <summary>
    /// 提供身份验证注册
    /// </summary>
    public static class AuthenticationRegisterHelper
    {
        /// <summary>
        /// JWT Bearer 身份验证
        /// </summary>
        /// <param name="services"></param>
        /// <param name="Configuration"></param>
        public static void AddCustomAuthentication(this IServiceCollection services, IConfiguration Configuration)
        {
            var issuer = Configuration.GetSection("JwtConfig:Issuer").Value;
            var audience = Configuration.GetSection("JwtConfig:Audience").Value;
            var secretKey = Configuration.GetSection("JwtConfig:Key").Value;
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = issuer, // 发行者
                    ValidAudience = audience, // 受众
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)) // 令牌的签名密钥
                };
            });
        }
    }
}
