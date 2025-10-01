namespace TaxdoAssignment.Domain;

public sealed class EmailShouldBeUniqueRule(string email, bool isEmailUnique) : IBusinessRule
{
    public string ErrorMessage => UserErrors.EmailIsNotUnique(email);

    public bool IsBroken() => !isEmailUnique;
}
