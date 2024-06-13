using Org.BouncyCastle.Crypto.Parameters;

namespace HazzaBot.Security;

public class DiscordPublicKey
{
    internal static Lazy<DiscordPublicKey> Singleton { get; } = new(() => new DiscordPublicKey());

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
    
    internal Ed25519PublicKeyParameters ToEd25519PublicKeyParameters()
    {
        return new Ed25519PublicKeyParameters(PublicKey, 0);
    }
}