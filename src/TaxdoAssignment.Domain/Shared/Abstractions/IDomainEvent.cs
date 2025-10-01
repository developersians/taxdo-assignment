namespace TaxdoAssignment.Domain;

public interface IDomainEvent
{
    DateTime OccurredOn { get; }
}
