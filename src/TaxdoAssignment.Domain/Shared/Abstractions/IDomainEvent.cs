namespace TaxdoAssignment.Domain.Shared;

public interface IDomainEvent
{
    DateTime OccurredOn { get; }
}
