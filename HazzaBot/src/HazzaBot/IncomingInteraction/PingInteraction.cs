using System.Text.Json.Serialization;
using HazzaBot.Interfaces;

namespace HazzaBot.IncomingInteraction;


[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(PingInteraction), (int)InteractionType.Ping)]
public class PingInteraction : IHandleInteraction
{
    public virtual IResponse HandleInteraction()
    {
        throw new NotImplementedException();
    }
}