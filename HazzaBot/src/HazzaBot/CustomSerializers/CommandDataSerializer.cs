using System.Text.Json;
using System.Text.Json.Serialization;
using HazzaBot.IncomingInteraction;

namespace HazzaBot.CustomSerializers;

public class CommandDataSerializer : JsonConverter<ApplicationCommandData>
{
    public override ApplicationCommandData? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, ApplicationCommandData value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}