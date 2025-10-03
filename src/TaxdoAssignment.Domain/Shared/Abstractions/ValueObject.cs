namespace TaxdoAssignment.Domain.Shared;

public abstract class ValueObject
{
    protected static void CheckRule(IBusinessRule rule)
    {
        if (rule.IsBroken())
            throw new BusinessRuleValidationException(rule.ErrorMessage);
    }
}
