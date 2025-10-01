namespace TaxdoAssignment.Domain;

public sealed class EmailFormatShouldBeValidRule(string email) : IBusinessRule
{
    public bool IsBroken() => !RegexHelper.EmailRegex.IsMatch(email);
    
    public string ErrorMessage => UserErrors.EmailFormatIsInvalid(email);
}
