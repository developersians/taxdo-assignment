using MediatR;
using TaxdoAssignment.Domain;
using TaxdoAssignment.UserApi;

namespace TaxdoAssignment.Application;

public sealed class GetUserListQueryHandler(IUserRepository userRepository)
    : IRequestHandler<GetUserListQuery, IEnumerable<UserResponse>>
{
    public async Task<IEnumerable<UserResponse>> Handle(GetUserListQuery query, CancellationToken cancellationToken)
    {
        var list = await userRepository.GetListAsync(cancellationToken);

        if (list.Count() == 0)
            return [];

        return [.. list.Select(x =>
            new UserResponse(
                Id: x.Id,
                Name: x.Name.Value,
                Email: x.Email.Value,
                PasswordHash: x.PasswordHash,
                CreatedAt: x.CreatedAt,
                LastUpdatedAt: x.LastUpdatedAt)
            )];
    }
}
