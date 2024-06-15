using HazzaBot.CustomSerializers;
using HazzaBot.DiscordShared;
using HazzaBot.Interfaces;

namespace HazzaBot.IncomingInteraction.CommandHandler;

[CommandHandler("groupcreate")]
public class CreateGroupHandler : ICommandHandler
{
    private ApplicationCommandData _parentData;

    // Fields
    [Option("groupname")]
    [RequiredOption]
    private string _commandName;
    
    [Option("member1")]
    [RequiredOption]
    private Member _member1;

    public void HandleCommand()
    {
        throw new NotImplementedException();
    }

    // Constructor - all command handlers should have a constructor that takes in the parent 'data'
    public CreateGroupHandler(ApplicationCommandData parentData)
    {
        _parentData = parentData;
    }
}