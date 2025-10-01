namespace TaxdoAssignment.Domain;

public sealed class Name : ValueObject
{
    public string Value { get; }

    public Name(string name)
    {
        CheckRule(new NameLengthShouldBeAcceptableRule(name));

        Value = name;
    }
}
