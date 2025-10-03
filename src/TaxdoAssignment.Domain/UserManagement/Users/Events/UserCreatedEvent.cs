using TaxdoAssignment.Domain.Shared;

namespace TaxdoAssignment.Domain;

public sealed record UserCreatedEvent(
    Guid Id,
    string Name,
    string Email) : IDomainEvent
{
    public DateTime OccurredOn => DateTime.UtcNow;
}
