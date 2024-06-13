using System.Text.Json.Serialization;
using HazzaBot.Interfaces;

namespace HazzaBot.IncomingInteraction;

public abstract class BaseInteraction : PingInteraction
{
    [JsonPropertyName("id")]
    public Snowflake Id { get; private set; }

    [JsonPropertyName("application_id")]
    public string ApplicationId { get; private set; }

    [JsonPropertyName("guild_id")] 
    public Snowflake GuildId { get; private set; }
    
    public abstract override IResponse HandleInteraction();
}