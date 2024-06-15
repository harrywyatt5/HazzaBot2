using System.Text.Json.Serialization;

namespace HazzaBot.IncomingInteraction;

public class UserMessageApplicationCommandData : ApplicationCommandData
{
    [JsonPropertyName("target_id")]
    public Snowflake TargetId { get; private set; }
}