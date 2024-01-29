using System.Text.Json;
using System.Text.Json.Serialization;

namespace TTMS.Api.Core
{
    /// <summary>
    /// 自定义时间转换器;用于JSON序列化和反序列化
    /// </summary>
    public class DateTimeConverter : JsonConverter<DateTime>
    {
        private const string DateFormat = "yyyy-MM-dd";
        private const string TimeFormat = "HH:mm:ss";

        /// <summary>
        /// 从JSON字符串中反序列化为DateTime对象
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="typeToConvert"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String && reader.TryGetDateTime(out var dateTime))
            {
                return dateTime;
            }

            return DateTime.MinValue;
        }

        /// <summary>
        /// 将DateTime对象序列化为JSON字符串
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="options"></param>
        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(DateFormat + " " + TimeFormat));
        }
    }
}
