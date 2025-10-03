using MediatR;

namespace TaxdoAssignment.Domain.Shared;

public interface IDomainEvent : INotification
{
    DateTime OccurredOn { get; }
}
