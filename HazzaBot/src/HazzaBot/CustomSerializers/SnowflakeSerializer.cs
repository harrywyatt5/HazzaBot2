using System.Text.Json;
using System.Text.Json.Serialization;

namespace HazzaBot.CustomSerializers;

public class SnowflakeSerializer : JsonConverter<Snowflake>
{
    public override Snowflake Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        long numValue;

        if (value != null && long.TryParse(value, out numValue))
        {
            return new Snowflake(numValue);
        }
        else
        {
            return new Snowflake();
        }
    }

    public override void Write(Utf8JsonWriter writer, Snowflake value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}