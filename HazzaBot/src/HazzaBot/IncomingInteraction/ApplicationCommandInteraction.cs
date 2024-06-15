using HazzaBot.Interfaces;

namespace HazzaBot.IncomingInteraction;

public class ApplicationCommandInteraction : BaseInteraction
{
    public ApplicationCommandData Data { get; private set; }

    public override IResponse HandleInteraction()
    {
        throw new System.NotImplementedException();
    }
}