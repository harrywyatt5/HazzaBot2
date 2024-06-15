using System.Text.Json.Serialization;
using HazzaBot.DiscordShared;
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
    
    [JsonPropertyName("channel_id")]
    public Snowflake ChannelId { get; private set; }
    
    [JsonPropertyName("member")]
    public Member Member { get; private set; }
    
    [JsonPropertyName("user")]
    public User User { get; private set; }
    
    [JsonPropertyName("locale")]
    public string Locale { get; private set; }
    
    [JsonPropertyName("guild_locale")]
    public string GuildLocale { get; private set; }
    
    [JsonPropertyName("context")]
    public InteractionTriggerContext Context { get; private set; }
    
    public abstract override IResponse HandleInteraction();
}