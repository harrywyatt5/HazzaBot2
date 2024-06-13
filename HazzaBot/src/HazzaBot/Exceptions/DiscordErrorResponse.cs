using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Amazon.Lambda.APIGatewayEvents;
using HazzaBot.Interfaces;
using HazzaBot.Util;

namespace HazzaBot.Exceptions;

public class DiscordErrorResponse : IResponse
{
    [JsonIgnore]
    public HttpCode HttpCode { get; private set; }
    
    [JsonPropertyName("error")]
    public string ErrorMessage { get; private set; }
    
    public DiscordErrorResponse(HttpCode httpCode, string errorMessage)
    {
        HttpCode = httpCode;
        ErrorMessage = errorMessage;
    }

    public async Task<APIGatewayProxyResponse> CreateResponse()
    {
        // Create MemoryStream for putting serialized JSON
        var memoryStream = new MemoryStream();
        
        // Serialize JSON to MemoryStream
        await JsonSerializer.SerializeAsync(memoryStream, this, JsonSerializationSingleton.Singleton.Value.JsonOptions);
        
        return new APIGatewayProxyResponse()
        {
            StatusCode = (int)HttpCode,
            Body = Encoding.UTF8.GetString(memoryStream.ToArray())
        };
    }
}