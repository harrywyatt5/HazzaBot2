using System.Text.Json;
using System.Text.Json.Serialization;
using HazzaBot.CustomSerializers;

namespace HazzaBot;

public class JsonSerializationSingleton
{
    public static readonly Lazy<JsonSerializationSingleton> Singleton =
        new Lazy<JsonSerializationSingleton>(() => new JsonSerializationSingleton());
    
    public JsonSerializerOptions JsonOptions { get; private set; }

    private JsonSerializationSingleton()
    {
        JsonOptions = new JsonSerializerOptions()
        {
            Converters =
            {
                new SnowflakeSerializer()
            },
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
            UnmappedMemberHandling = JsonUnmappedMemberHandling.Skip,
            ReadCommentHandling = JsonCommentHandling.Skip
        };
        
        JsonOptions.MakeReadOnly();
    }
}