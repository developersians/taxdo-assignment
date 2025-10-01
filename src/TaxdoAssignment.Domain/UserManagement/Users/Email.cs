namespace TaxdoAssignment.Domain;

public sealed class Email : ValueObject
{
    public string Value { get; }

    public Email(string email, bool isEmailUnique)
    {
        CheckRule(new EmailFormatShouldBeValidRule(email));
        CheckRule(new EmailShouldBeUniqueRule(email, isEmailUnique));

        Value = email;
    }
}
