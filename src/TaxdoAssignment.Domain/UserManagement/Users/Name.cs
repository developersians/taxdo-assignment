using TaxdoAssignment.Domain.Shared;

namespace TaxdoAssignment.Domain;

public sealed class Name : ValueObject
{
    private Name() { }

    public string Value { get; }

    public Name(string name)
    {
        CheckRule(new NameLengthShouldBeAcceptableRule(name));

        Value = name;
    }
}
