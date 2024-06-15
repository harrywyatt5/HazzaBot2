namespace HazzaBot.CustomSerializers;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class CommandHandlerAttribute : Attribute
{
    public string CommandName { get; private set;  }
    
    public CommandHandlerAttribute(string commandName)
    {
        CommandName = commandName;
    }
}