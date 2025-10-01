using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxdoAssignment.Domain;

public static class UserErrors
{
    public static string EmailIsNotUnique(string email)
        => $"Email {email} is already registered.";

    public static string EmailFormatIsInvalid(string email)
        => $"Email format: {email} is invalid.";

    internal static string NameIsTooLong(string name)
        => $"The name {name} is too long. It should not have more than 100 characters.";
}
