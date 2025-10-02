using System.Linq.Expressions;
using TaxdoAssignment.Domain;

namespace TaxdoAssignment.Infrastructure;

public class Repository<TAggregateRoot>(AppDbContext context)
    : IRepository<TAggregateRoot>
    where TAggregateRoot : Entity, IAggregateRoot
{
    public Task<TAggregateRoot> GetAsync(Guid id, CancellationToken cancellation = default)
    {
        throw new NotImplementedException();
    }

    public Task<TAggregateRoot> GetAsync(Expression<Func<TAggregateRoot, bool>> predicate, CancellationToken cancellation = default)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TAggregateRoot>> GetListAsync(CancellationToken cancellation = default)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TAggregateRoot>> GetListAsync(Expression<Func<TAggregateRoot, bool>> predicate, CancellationToken cancellation = default)
    {
        throw new NotImplementedException();
    }
}
