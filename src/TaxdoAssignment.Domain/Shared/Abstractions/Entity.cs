namespace TaxdoAssignment.Domain.Shared;

public abstract class Entity
{
    private readonly ICollection<IDomainEvent> _domainEvents = [];

    public Guid Id { get; init; }

    public void AddDomainEvent(IDomainEvent @event)
        => _domainEvents.Add(@event);

    public void ClearDomainEvents()
        => _domainEvents.Clear();

    //protected static void CheckRule(IBusinessRule rule)
    //{
    //    if (rule.IsBroken())
    //        throw new BusinessRuleValidationException(rule.ErrorMessage);
    //}
}
