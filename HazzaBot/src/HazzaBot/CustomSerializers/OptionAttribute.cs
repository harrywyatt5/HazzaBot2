namespace HazzaBot.CustomSerializers;

[AttributeUsage(AttributeTargets.Field)]
public class OptionAttribute : Attribute
{
    public string FieldName { get; private set; }
    public bool IsRegularExpression { get; private set; }

    public OptionAttribute(string fieldName)
    {
        FieldName = fieldName;
        IsRegularExpression = false;
    }
    
    public OptionAttribute(string fieldName, bool isRegularExpression)
    {
        FieldName = fieldName;
        IsRegularExpression = isRegularExpression;
    }
}