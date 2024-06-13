using System.Text.Json.Serialization;

namespace HazzaBot.IncomingInteraction;

public class ApplicationCommand
{
    [JsonPropertyName("id")]
    public Snowflake Id { get; private set; }
    
    [JsonPropertyName("name")]
    public string Name { get; private set; }
    
    [JsonPropertyName("type")]
    public ApplicationCommandType Type { get; private set; }
    
    // TODO: Implement resolved type
    [JsonPropertyName("resolved")]
    public string Resolved { get; private set; }
}