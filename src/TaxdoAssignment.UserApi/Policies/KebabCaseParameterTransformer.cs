using System.Text.RegularExpressions;

namespace TaxdoAssignment.UserApi;

public class KebabCaseParameterTransformer : IOutboundParameterTransformer
{
    /// <summary>
    /// Converts routes to kebab-case routes
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public string? TransformOutbound(object? value)
    {
        if (value == null) return null;

        return Regex
            .Replace(value.ToString()!, "([a-z])([A-Z])", "$1-$2")
            .ToLowerInvariant();
    }
}
