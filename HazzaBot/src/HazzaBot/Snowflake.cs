using System.Text.Json.Serialization;
using HazzaBot.CustomSerializers;

namespace HazzaBot;

[JsonConverter(typeof(SnowflakeSerializer))]
public struct Snowflake : IEquatable<Snowflake>, IEquatable<long>, IEquatable<string>
{
    public static Snowflake ParseOrDefault(string? potentialSnowflake)
        => long.TryParse(potentialSnowflake, out var value) ? new Snowflake(value) : new Snowflake();
    
    public long Value { get; private set; }

    public Snowflake()
    {
        Value = -1L;
    }
    
    public Snowflake(long value)
    {
        Value = value;
    }

    public bool IsDefaultValue()
    {
        return Value == -1L;
    }

    public override string ToString() => Value.ToString();
    
    public bool Equals(Snowflake other) => Value == other.Value;
    
    public bool Equals(long other) => Value == other;
    
    public bool Equals(string? other)
    {
        // We must attempt to parse (as someone could pass null or a non-numeric string)
        if (long.TryParse(other, out var result))
        {
            return Value == result;
        }

        return false;
    }

    public static bool operator ==(Snowflake left, Snowflake right) => left.Value == right.Value;
    public static bool operator !=(Snowflake left, Snowflake right) => left.Value != right.Value;
}