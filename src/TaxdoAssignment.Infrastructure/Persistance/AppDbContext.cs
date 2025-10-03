using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TaxdoAssignment.Domain;
using TaxdoAssignment.Domain.Shared;

namespace TaxdoAssignment.Infrastructure;

public class AppDbContext(
    DbContextOptions<AppDbContext> options, 
    ILogger<AppDbContext> logger) : DbContext(options), IUnitOfWork
{
    public DbSet<UserEntity> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var result = await base.SaveChangesAsync(cancellationToken);


        return result;
    }
}
