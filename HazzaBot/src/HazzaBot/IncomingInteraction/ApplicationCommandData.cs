using System.Text.Json.Serialization;
using HazzaBot.DiscordShared;
using HazzaBot.Interfaces;

namespace HazzaBot.IncomingInteraction;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(UserMessageApplicationCommandData), (int)ApplicationCommandType.Message)]
[JsonDerivedType(typeof(UserMessageApplicationCommandData), (int)ApplicationCommandType.User)]
public class ApplicationCommandData
{
    public class Builder
    {
        private Snowflake _id;
        private string? _commandName;
        private ResolvedData? _resolved;
        private ICommandHandler? _handler;
        private Snowflake _guildId;
        private Snowflake _targetId;
        
        public Builder()
        {
            _id = new Snowflake();
            _commandName = null;
            _resolved = null;
            _handler = null;
            _guildId = new Snowflake();
            _targetId = new Snowflake();
        }
        
        public Builder WithId(Snowflake id)
        {
            _id = id;
            return this;
        }
        
        public Builder WithCommandName(string? commandName)
        {
            _commandName = commandName;
            return this;
        }
        
        public Builder WithResolved(ResolvedData? resolved)
        {
            _resolved = resolved;
            return this;
        }
        
        public Builder WithHandler(ICommandHandler? handler)
        {
            _handler = handler;
            return this;
        }
        
        public Builder WithGuildId(Snowflake guildId)
        {
            _guildId = guildId;
            return this;
        }
        
        public Builder WithTargetId(Snowflake targetId)
        {
            _targetId = targetId;
            return this;
        }

        private void _validateFields()
        {
            if (
                _id.IsDefaultValue() 
                || _commandName == null 
                || _resolved == null 
                || _handler == null 
                || _guildId.IsDefaultValue() 
            )
            {
                throw new ArgumentException("Field was missing from ApplicationCommandData builder");
            }
        }

        public ApplicationCommandData Build()
        {
            // Validate fields
            _validateFields();
            
            // Create a ApplicationCommandData object if we don't have target id
            // (!s are to silence warnings about null references - this is checked in _validateFields())
            if (_targetId.IsDefaultValue())
            {
                return new ApplicationCommandData(
                    _id,
                    _commandName!,
                    _resolved!, 
                    _handler!, 
                    _guildId
                );
            }
            
            // Create a UserMessageApplicationCommandData object if we have a target id
            return new UserMessageApplicationCommandData(
                _id,
                _commandName!,
                _resolved!, 
                _handler!, 
                _guildId,
                _targetId
            );
        }
    }

    public Snowflake Id { get; private set; }
    public string CommandName { get; private set; }
    public ResolvedData Resolved { get; private set; }
    public ICommandHandler Handler { get; private set; }
    public Snowflake GuildId { get; private set; }
    
    public ApplicationCommandData(
        Snowflake id,
        string commandName,
        ResolvedData resolved,
        ICommandHandler handler,
        Snowflake guildId
    )
    {
        Id = id;
        CommandName = commandName;
        Resolved = resolved;
        Handler = handler;
        GuildId = guildId;
    }
}