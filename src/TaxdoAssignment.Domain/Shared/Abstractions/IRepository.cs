using System.Linq.Expressions;

namespace TaxdoAssignment.Domain;

public interface IRepository<TAggregateRoot> : IAggregateRoot
{
    Task<bool> ExistsAsync(Expression<Func<TAggregateRoot, bool>> predicate, CancellationToken cancellationToken = default);
    Task<TAggregateRoot?> GetAsync(Guid id, CancellationToken cancellation = default);
    Task<TAggregateRoot?> GetAsync(Expression<Func<TAggregateRoot, bool>> predicate, CancellationToken cancellationToken = default);
    Task<IEnumerable<TAggregateRoot>> GetListAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<TAggregateRoot>> GetListAsync(Expression<Func<TAggregateRoot, bool>> predicate, CancellationToken cancellationToken = default);
    Task AddAsync(TAggregateRoot aggregate, CancellationToken cancellationToken = default);

    // We can define other generic methods like update, delete, and so on
}
