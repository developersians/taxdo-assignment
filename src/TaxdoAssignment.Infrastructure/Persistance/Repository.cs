using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TaxdoAssignment.Domain.Shared;

namespace TaxdoAssignment.Infrastructure;

public class Repository<TAggregateRoot>(AppDbContext context)
    : IRepository<TAggregateRoot>
    where TAggregateRoot : Entity, IAggregateRoot
{
    public async Task<bool> ExistsAsync(Expression<Func<TAggregateRoot, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await context
            .Set<TAggregateRoot>()
            .Where(predicate)
            .AnyAsync(cancellationToken);
    }

    public async Task<TAggregateRoot?> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await context
            .Set<TAggregateRoot>()
            .Where(p => p.Id == id)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<TAggregateRoot?> GetAsync(Expression<Func<TAggregateRoot, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await context
            .Set<TAggregateRoot>()
            .Where(predicate)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<IEnumerable<TAggregateRoot>> GetListAsync(CancellationToken cancellationToken = default)
    {
        return await context
            .Set<TAggregateRoot>()
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<TAggregateRoot>> GetListAsync(Expression<Func<TAggregateRoot, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await context
            .Set<TAggregateRoot>()
            .Where(predicate)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(TAggregateRoot aggregate, CancellationToken cancellationToken = default)
    {
        await context
            .Set<TAggregateRoot>()
            .AddAsync(aggregate);
    }
}
