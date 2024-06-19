using System.Text.Json.Serialization;
using HazzaBot.DiscordShared;
using HazzaBot.Interfaces;

namespace HazzaBot.IncomingInteraction;

public class UserMessageApplicationCommandData : ApplicationCommandData
{
    [JsonPropertyName("target_id")]
    public Snowflake TargetId { get; private set; }
    
    public UserMessageApplicationCommandData(
        Snowflake id,
        string commandName,
        ResolvedData resolved,
        ICommandHandler handler,
        Snowflake guildId,
        Snowflake targetId
    ) : base(id, commandName, resolved, handler, guildId)
    {
        TargetId = targetId;
    }
}