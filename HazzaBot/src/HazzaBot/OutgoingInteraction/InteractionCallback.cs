using System.Text.Json.Serialization;
using HazzaBot.OutgoingInteraction;

namespace HazzaBot;

[JsonUnmappedMemberHandling(JsonUnmappedMemberHandling.Skip)]
public class InteractionCallback<T>
{
    public OutgoingInteractionType Type { get; private set; }
    
    public T? Data { get; private set; }
    
    public InteractionCallback(OutgoingInteractionType type, T data)
    {
        Type = type;
        Data = data;
    }
    
    public InteractionCallback(OutgoingInteractionType type)
    {
        Type = type;
        Data = default;
    }
}