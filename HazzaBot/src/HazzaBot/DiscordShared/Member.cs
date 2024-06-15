using System.Text.Json.Serialization;

namespace HazzaBot.DiscordShared;

public class Member
{
    public User User { get; private set; }
    
    [JsonPropertyName("nick")]
    public string Nickname { get; private set; }
    
    public Snowflake[] Roles { get; private set; }
    
    public DateTimeOffset JoinedAt { get; private set; }
    
    [JsonPropertyName("deaf")]
    public bool IsDeafened { get; private set; }
    
    [JsonPropertyName("mute")]
    public bool IsMuted { get; private set; }
}