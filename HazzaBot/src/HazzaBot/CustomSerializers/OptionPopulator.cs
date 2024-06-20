namespace HazzaBot.CustomSerializers;

public class OptionPopulator
{
    public class Builder
    {
        private string? _name;
        private OptionType _type;
        private byte[]? _value;

        public Builder()
        {
            _name = null;
            _type = OptionType.Invalid;
            _value = null;
        }

        public Builder WithName(string name)
        {
            _name = name;
            return this;
        }

        public Builder WithType(OptionType type)
        {
            _type = type;
            return this;
        }

        public Builder WithValue(byte[] value)
        {
            _value = value;
            return this;
        }

        public OptionPopulator Build()
        {
            // Check no values are null
            if (_name is null || _type == OptionType.Invalid || _value is null)
            {
                throw new InvalidOperationException("Cannot build OptionPopulator with null values");
            }
            
            return new OptionPopulator(_name, _type, _value);
        }
    }

    private string _name;
    private OptionType _type;
    private byte[] _value;
    
    private OptionPopulator(string name, OptionType type, byte[] value)
    {
        _name = name;
        _type = type;
        _value = value;
    }
}