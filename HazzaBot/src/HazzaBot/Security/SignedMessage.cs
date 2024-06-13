using Org.BouncyCastle.Crypto;

namespace HazzaBot.Security;

// Represents a potentially signed message
public class SignedMessage
{
    private byte[] _signature;
    private byte[] _message;

    public SignedMessage(string message, string signature)
    {
        _message = Convert.FromBase64String(message);
        _signature = Convert.FromBase64String(signature);
    }

    public void PopulateMessage(ISigner signer)
    {
        signer.BlockUpdate(_message, 0, _message.Length);
    }

    public bool VerifyMessage(ISigner signer)
    {
        return signer.VerifySignature(_signature);
    }
    
    public bool PopulateAndVerifyMessage(ISigner signer)
    {
        PopulateMessage(signer);
        return VerifyMessage(signer);
    }
}