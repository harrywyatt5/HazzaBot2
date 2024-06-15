using System.Text.Json.Serialization;
using HazzaBot.DiscordShared;

namespace HazzaBot.IncomingInteraction;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(UserMessageApplicationCommandData), (int)ApplicationCommandType.Message)]
[JsonDerivedType(typeof(UserMessageApplicationCommandData), (int)ApplicationCommandType.User)]
public class ApplicationCommandData
{
    public Snowflake Id { get; private set; }
    public string CommandName { get; private set; }
    public ApplicationCommandType Type { get; private set; }
    public ResolvedData Resolved { get; private set; }
    public string[] Options { get; private set; }
    public Snowflake GuildId { get; private set; }
}