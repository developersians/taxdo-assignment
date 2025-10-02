using MediatR;
using TaxdoAssignment.Domain;
using TaxdoAssignment.UserApi;

namespace TaxdoAssignment.Application;

public class GetUserByIdQueryHandler(IUserRepository userRepository)
    : IRequestHandler<GetUserByIdQuery, UserResponse?>
{
    public async Task<UserResponse?> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
    {
        UserEntity? user = await userRepository.GetAsync(query.id, cancellationToken);

        if (user is null)
            return null;

        return new UserResponse(
            Id: user.Id,
            Name: user.Name.Value,
            Email: user.Email.Value,
            PasswordHash: user.PasswordHash,
            CreatedAt: user.CreatedAt,
            LastUpdatedAt: user.LastUpdatedAt
        );
    }
}
