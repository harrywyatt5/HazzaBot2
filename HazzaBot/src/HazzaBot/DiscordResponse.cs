using System.Text;
using System.Text.Json;
using Amazon.Lambda.APIGatewayEvents;
using HazzaBot.Interfaces;
using HazzaBot.Util;

namespace HazzaBot;

public class DiscordResponse : IResponse
{
    public HttpCode HttpCode { get; private set; }
    public InteractionCallback<object> Callback { get; private set; }

    public DiscordResponse(HttpCode code, InteractionCallback<object> callback)
    {
        HttpCode = code;
        Callback = callback;
    }
    
    public DiscordResponse(InteractionCallback<object> callback)
    {
        HttpCode = HttpCode.Ok;
        Callback = callback;
    }
    
    public async Task<APIGatewayProxyResponse> CreateResponse()
    {
        // Create MemoryStream for putting serialized JSON
        var memoryStream = new MemoryStream();
        
        // Serialize JSON to MemoryStream
        await JsonSerializer.SerializeAsync(memoryStream, Callback, JsonSerializationSingleton.Singleton.Value.JsonOptions);
        
        return new APIGatewayProxyResponse()
        {
            StatusCode = (int) HttpCode,
            Body = Encoding.UTF8.GetString(memoryStream.ToArray())
        };
    }
}