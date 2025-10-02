using System.Linq.Expressions;

namespace TaxdoAssignment.Domain;

public interface IRepository<TAggregateRoot> : IAggregateRoot
{
    Task<TAggregateRoot> GetAsync(Guid id, CancellationToken cancellation = default);
    Task<TAggregateRoot> GetAsync(Expression<Func<TAggregateRoot, bool>> predicate, CancellationToken cancellation = default);
    Task<IEnumerable<TAggregateRoot>> GetListAsync(CancellationToken cancellation = default);
    Task<IEnumerable<TAggregateRoot>> GetListAsync(Expression<Func<TAggregateRoot, bool>> predicate, CancellationToken cancellation = default);

    // We can define other generic methods like update, delete, isExists, and so on
}
