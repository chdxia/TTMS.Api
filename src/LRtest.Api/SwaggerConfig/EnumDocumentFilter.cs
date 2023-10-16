using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.ComponentModel;
using System.Reflection;

namespace LRtest.Api.SwaggerConfig
{
    /// <summary>
    /// Swagger文档显示枚举值、枚举属性、枚举描述
    /// </summary>
    public class EnumDocumentFilter : IDocumentFilter
    {
        /// <summary>
        /// 实现接口
        /// </summary>
        /// <param name="swaggerDoc"></param>
        /// <param name="context"></param>
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            Dictionary<string, Type> dict = GetAllEnum();
            foreach (var item in swaggerDoc.Components.Schemas)
            {
                var property = item.Value;
                var typeName = item.Key;
                Type itemType = null;
                if (property.Enum != null && property.Enum.Count > 0)
                {
                    if (dict.ContainsKey(typeName))
                    {
                        itemType = dict[typeName];
                    }
                    else
                    {
                        itemType = null;
                    }
                    List<OpenApiInteger> list = new List<OpenApiInteger>();
                    foreach (var val in property.Enum)
                    {
                        list.Add((OpenApiInteger)val);
                    }
                    property.Description += DescribeEnum(itemType, list);
                }
            }
        }

        private static Dictionary<string, Type> GetAllEnum()
        {
            Assembly ass = Assembly.Load("LRtest.Enums");
            Type[] types = ass.GetTypes();
            Dictionary<string, Type> dict = new Dictionary<string, Type>();
            foreach (Type item in types)
            {
                if (item.IsEnum)
                {
                    dict.Add(item.Name, item);
                }
            }
            return dict;
        }

        private static string DescribeEnum(Type type, List<OpenApiInteger> enums)
        {
            var enumDescriptions = new List<string>();
            foreach (var item in enums)
            {
                if (type == null) continue;
                var value = Enum.Parse(type, item.Value.ToString());
                var desc = GetDescription(type, value);
                if (string.IsNullOrEmpty(desc)) enumDescriptions.Add($"{item.Value.ToString()}:{Enum.GetName(type, value)};");
                else enumDescriptions.Add($"{item.Value.ToString()}:{Enum.GetName(type, value)}, {desc};");
            }
            return $"<br><div>{Environment.NewLine}{string.Join("<br/>" + Environment.NewLine, enumDescriptions)}</div>";
        }

        private static string GetDescription(Type t, object value)
        {
            foreach (MemberInfo mInfo in t.GetMembers())
            {
                if (mInfo.Name == t.GetEnumName(value))
                {
                    foreach (Attribute attr in Attribute.GetCustomAttributes(mInfo))
                    {
                        if (attr.GetType() == typeof(DescriptionAttribute))
                        {
                            return ((DescriptionAttribute)attr).Description;
                        }
                    }
                }
            }
            return string.Empty;
        }
    }
}
