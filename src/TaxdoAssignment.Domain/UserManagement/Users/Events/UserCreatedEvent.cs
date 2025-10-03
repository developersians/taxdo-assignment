using TaxdoAssignment.Domain.Shared;

namespace TaxdoAssignment.Domain;

public sealed record UserCreatedEvent(string Name, Email Email) : IDomainEvent
{
    public DateTime OccurredOn => DateTime.UtcNow;
}
