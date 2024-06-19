using HazzaBot.CustomSerializers;
using HazzaBot.IncomingInteraction;
using HazzaBot.IncomingInteraction.CommandHandler;

namespace HazzaBot.Interfaces;

[CommandHandler("groupcreate", typeof(CreateGroupHandler))]
public interface ICommandHandler
{
    public void HandleCommand();
}