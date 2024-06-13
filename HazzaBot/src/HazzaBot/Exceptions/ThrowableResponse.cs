using HazzaBot.Interfaces;
using HazzaBot.Util;

namespace HazzaBot.Exceptions;

public abstract class ThrowableResponse : Exception
{
    // ThrowableResponse must have a message
    public ThrowableResponse(string message) : base(message)
    { }
    
    public abstract IResponse CreateResponseFromThrowable();

    public static IResponse CreateGenericExceptionResponse(string errorMessage)
    {
        return new DiscordErrorResponse(
            HttpCode.InternalServerError, 
            $"An internal server error occurred: {errorMessage}"
        );
    }
}