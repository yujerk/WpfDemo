using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WpfDemo.Models
{
    public class DateTimeConverter : JsonConverter<DateTime?>
    {
        public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                string dateString = reader.GetString();
                if (string.IsNullOrEmpty(dateString))
                    return null;

                // 尝试解析不同的日期格式
                if (DateTime.TryParseExact(dateString, "yyyy-MM-dd HH:mm:ss",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
                {
                    return result;
                }

                // 如果上面的格式不匹配，尝试使用默认解析
                if (DateTime.TryParse(dateString, out result))
                {
                    return result;
                }
            }
            else if (reader.TokenType == JsonTokenType.Null)
            {
                return null;
            }

            return null;
        }

        public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
        {
            if (value.HasValue)
            {
                writer.WriteStringValue(value.Value.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            else
            {
                writer.WriteNullValue();
            }
        }
    }
}
