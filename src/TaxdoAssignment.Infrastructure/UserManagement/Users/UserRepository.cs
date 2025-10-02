using TaxdoAssignment.Domain;
using TaxdoAssignment.Infrastructure;

namespace TaxdoAssignment.Infrastructur;

public class UserRepository(AppDbContext context) 
    : Repository<UserEntity>(context), IUserRepository
{
}
