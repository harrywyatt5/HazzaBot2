using System.Reflection;
using HazzaBot.Interfaces;

namespace HazzaBot.CustomSerializers;

[AttributeUsage(AttributeTargets.Interface, AllowMultiple = true)]
public class CommandHandlerAttribute : Attribute
{
    public static Type GetHandlerTypeByCommandName(string commandName)
    {
        // TODO: Insert 'default' handler for unrecognised commands
        return typeof(ICommandHandler).GetCustomAttributes()
            .Where(x => x is CommandHandlerAttribute)
            .Cast<CommandHandlerAttribute>()
            .Where(y => y.CommandName == commandName)
            .Select(z => z.Type)
            .FirstOrDefault(typeof(ICommandHandler));
    }

    public string CommandName { get; private set;  }
    public Type Type { get; private set; }
    
    public CommandHandlerAttribute(string commandName, Type type)
    {
        CommandName = commandName;
        Type = type; 
    }
}