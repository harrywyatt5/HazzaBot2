using System.Text.Json.Serialization;

namespace HazzaBot.DiscordShared;

public class User
{
    public Snowflake Id { get; private set; }
    public string Username { get; private set; }
    public string Discriminator { get; private set; }
    
    [JsonPropertyName("global_name")]
    public string GlobalName { get; private set; }
    
    // Not for use externally - use User.AvatarAsset instead
    [JsonPropertyName("avatar")]
    private string _avatarHash;
        
    [JsonIgnore]
    public AvatarAsset? AvatarAsset { get; private set; }
    
    public void OnDeserialized()
    {
        AvatarAsset = !string.IsNullOrEmpty(_avatarHash) ? new AvatarAsset(_avatarHash, this) : null;
    }
}