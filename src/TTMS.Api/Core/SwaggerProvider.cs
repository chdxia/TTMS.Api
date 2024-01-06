using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace TTMS.Api.Core
{
    /// <summary>
    /// 提供Swagger生成器的配置
    /// </summary>
    public static class SwaggerProvider
    {
        /// <summary>
        /// 配置Swagger生成器
        /// </summary>
        /// <param name="options"></param>
        public static void ConfigureSwaggerGen(SwaggerGenOptions options)
        {
            options.DocInclusionPredicate((docName, apiDesc) =>
            {
                return true; // 包含所有控制器和操作方法，根据需要修改左面的逻辑来包含或排除特定的控制器和操作方法
            });

            options.DocumentFilter<EnumDocumentFilter>(); // 显示枚举值;枚举属性;枚举描述

            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "TTMS.Api.xml")); // 启用 XML 注释
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "TTMS.DTO.xml"));
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "TTMS.Enums.xml"));

            // 添加 JWT 认证支持
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer"
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Id = "Bearer",
                            Type = ReferenceType.SecurityScheme
                        }
                    },
                    new List<string>()
                }
            });
        }
    }
}
