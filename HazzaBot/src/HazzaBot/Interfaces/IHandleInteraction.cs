using System.Text.Json.Serialization;
using HazzaBot.IncomingInteraction;

namespace HazzaBot.Interfaces;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(PingInteraction), (int)InteractionType.Ping)]
[JsonDerivedType(typeof(ApplicationCommandInteraction), (int)InteractionType.ApplicationCommand)]
public interface IHandleInteraction
{
    public IResponse HandleInteraction();
}