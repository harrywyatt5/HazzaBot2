using System.Text.Json;
using System.Text.Json.Serialization;
using HazzaBot.DiscordShared;
using HazzaBot.IncomingInteraction;
using HazzaBot.Interfaces;

namespace HazzaBot.CustomSerializers;

public class CommandDataSerializer : JsonConverter<ApplicationCommandData>
{
    private void _populateFields(
        ref Utf8JsonReader reader,
        Type handlerType,
        ICommandHandler handler
    )
    {
        var options = new List<OptionPopulator>();
        OptionPopulator.Builder builder;
        var readingOption = false;
        
        // Read the whole document and try and populate the fields
        while (reader.Read())
        {
            // If we are currently not reading an option/handler property
            if (!readingOption)
            {
                // If we've reached the end of the array of options or the end of the object
                // (without being in the context of reading an option)
                if (reader.TokenType == JsonTokenType.EndArray
                    || reader.TokenType == JsonTokenType.EndObject)
                {
                    break;
                }
                
                // If we are at the start of an object, enable flag and init builder
                if (reader.TokenType == JsonTokenType.StartObject)
                {
                    builder = new OptionPopulator.Builder();
                    readingOption = true;
                }
            }
            // If we are reading an option
            else
            {
                
            }
        }
    }

    private ICommandHandler _createHandler(string commandName)
    {
        // Get the handler type or default and create an instance via reflection
        var hType = CommandHandlerAttribute.GetHandlerTypeByCommandName(commandName.ToLower());
        var handler = Activator.CreateInstance(hType);
        
        // Ensure is not null (to shut up compiler)
        if (handler is null) throw new ArgumentException(commandName);
        
        return (ICommandHandler)handler;
    }

    public override ApplicationCommandData? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        // Determine and build the ApplicationCommandData object
        var builder = new ApplicationCommandData.Builder();
        ReadOnlySpan<byte> optionsData; 
        
        // Read the top level of the object
        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.EndObject)
            {
                break;
            }

            if (reader.TokenType != JsonTokenType.PropertyName)
            {
                continue;
            }

            var propertyName = reader.GetString();
            reader.Read();

            switch (propertyName)
            {
                case "id":
                    builder.WithId(Snowflake.ParseOrDefault(reader.GetString()));
                    break;
                case "name":
                    builder.WithCommandName(reader.GetString());
                    break;
                case "resolved":
                    builder.WithResolved(JsonSerializer.Deserialize<ResolvedData>(ref reader, options));
                    break;
                case "guild_id":
                    builder.WithGuildId(Snowflake.ParseOrDefault(reader.GetString()));
                    break;
                case "target_id":
                    builder.WithTargetId(Snowflake.ParseOrDefault(reader.GetString()));
                    break;
                case "options":
                    // Save into a Span of bytes for processing later
                    optionsData = reader.ValueSpan;
                    break;
            }
        
        }
    }

    public override void Write(Utf8JsonWriter writer, ApplicationCommandData value, JsonSerializerOptions options)
    {
        throw new NotImplementedException("ApplicationCommandData cannot be serialized.");
    }
}