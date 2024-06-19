using HazzaBot.CustomSerializers;
using HazzaBot.DiscordShared;
using HazzaBot.Interfaces;

namespace HazzaBot.IncomingInteraction.CommandHandler;

public class CreateGroupHandler : ICommandHandler
{
    [ParentData]
    private ApplicationCommandData _parentData;

    // Fields
    [Option("groupname")]
    [RequiredOption]
    private string _commandName;
    
    [Option("member", isRegularExpression: true)]
    [RequiredOption]
    private IList<Member> _members;

    public void HandleCommand()
    {
        throw new NotImplementedException();
    }
}