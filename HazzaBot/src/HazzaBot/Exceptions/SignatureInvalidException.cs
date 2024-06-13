using HazzaBot.Interfaces;
using HazzaBot.Util;

namespace HazzaBot.Exceptions;

public class SignatureInvalidException : ThrowableResponse
{
    public SignatureInvalidException() : base("Bad signature: request signature is invalid")
    { }
    
    public override IResponse CreateResponseFromThrowable()
    {
        return new DiscordErrorResponse(HttpCode.Unauthorised, Message);
    }
}