namespace TaxdoAssignment.Domain.Shared;

public interface IBusinessRule
{
    bool IsBroken();

    string ErrorMessage { get; }
}
