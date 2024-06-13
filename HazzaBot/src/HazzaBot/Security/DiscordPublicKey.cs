namespace HazzaBot.Security;

public class DiscordPublicKey
{
    internal Lazy<DiscordPublicKey> Singleton { get; } = new(() => new DiscordPublicKey());

    internal byte[] PublicKey { get; }

    private DiscordPublicKey()
    {
        // Attempt to get public key from environment variable
        var publicKey = Environment.GetEnvironmentVariable("DISCORD_PUBLIC_KEY");
        
        if (string.IsNullOrEmpty(publicKey))
        {
            throw new InvalidOperationException("DISCORD_PUBLIC_KEY environment variable is not set.");
        }
        else
        {
            PublicKey = Convert.FromBase64String(publicKey);
        }
    }
}