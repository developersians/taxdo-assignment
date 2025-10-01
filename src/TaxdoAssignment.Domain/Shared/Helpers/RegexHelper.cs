using System.Text.RegularExpressions;

namespace TaxdoAssignment.Domain;

public static class RegexHelper
{
    private const string EmailRegexPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

    public static readonly Regex EmailRegex = new(EmailRegexPattern, RegexOptions.Compiled);
}
