namespace HazzaBot.CustomSerializers;

[AttributeUsage(AttributeTargets.Field)]
public class OptionAttribute : Attribute
{
    public string FieldName { get; private set; }

    public OptionAttribute(string fieldName)
    {
        FieldName = fieldName;
    }
}