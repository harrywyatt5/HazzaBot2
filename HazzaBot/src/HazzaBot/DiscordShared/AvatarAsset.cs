namespace HazzaBot.DiscordShared;

public class AvatarAsset
{
    private const string BaseUrl = "https://cdn.discordapp.com/avatar/";

    private static bool _determineIfAnimated(string hash)
    {
        return hash.StartsWith("a_");
    }

    private string _hash;
    private User _user;
    public bool IsAnimated { get; private set; }

    public AvatarAsset(string avatarHash, User user)
    {
        _hash = avatarHash;
        _user = user;
        
        // Determine if the avatar is animated
        IsAnimated = _determineIfAnimated(avatarHash);
    }

    public string GetUrl(bool animated)
    {
        if (animated && IsAnimated)
        {
            return $"{BaseUrl}{_user.Id}/{_hash}.gif";
        }
        else
        {
            return $"{BaseUrl}{_user.Id}/{_hash}.png";
        }
    }

    public string GetUrl() => GetUrl(true);
}