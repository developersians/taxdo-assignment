using TaxdoAssignment.Domain.Shared;

namespace TaxdoAssignment.Domain;

public sealed class NameLengthShouldBeAcceptableRule(string name) : IBusinessRule
{
    public bool IsBroken() => name.Length >= 100;

    public string ErrorMessage => UserErrors.NameIsTooLong(name);
}