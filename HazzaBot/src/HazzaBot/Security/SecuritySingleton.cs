using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Signers;

namespace HazzaBot.Security;

public class SecuritySingleton
{
    public static Lazy<SecuritySingleton> Singleton { get; } = new(() => new SecuritySingleton());

    private Ed25519PublicKeyParameters _publicKey;
    
    private SecuritySingleton()
    {
        _publicKey = DiscordPublicKey.Singleton.Value.ToEd25519PublicKeyParameters();
    }
    
    public bool VerifyMessage(SignedMessage signedMessage)
    {
        var signer = new Ed25519Signer();
        signer.Init(false, _publicKey);
        
        return signedMessage.PopulateAndVerifyMessage(signer);
    }
}