using System.Text.Json.Serialization;
using HazzaBot.CustomSerializers;

namespace HazzaBot;

[JsonConverter(typeof(SnowflakeSerializer))]
public struct Snowflake
{
    public long Value { get; private set; }

    public Snowflake()
    {
        Value = -1L;
    }
    
    public Snowflake(long value)
    {
        Value = value;
    }

    public override string ToString() => Value.ToString();

    public override bool Equals(object? obj)
    {
        // We can compare Snowflakes, strings and longs
        if (obj is null) return false;

        if (obj is Snowflake)
        {
            return Value == ((Snowflake)obj).Value;
        }

        if (obj is long)
        {
            return Value == (long)obj;
        }

        if (obj is string)
        {
            return ToString() == (string)obj;
        }

        // Otherwise, we cannot compare these two types
        return false;
    }

    public static bool operator ==(Snowflake left, Snowflake right) => left.Value == right.Value;
    public static bool operator !=(Snowflake left, Snowflake right) => left.Value != right.Value;
}