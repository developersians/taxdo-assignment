namespace TaxdoAssignment.Domain;

public interface IBusinessRule
{
    bool IsBroken();

    string ErrorMessage { get; }
}
