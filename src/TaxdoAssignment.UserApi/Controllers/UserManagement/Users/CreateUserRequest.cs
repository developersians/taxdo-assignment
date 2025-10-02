using MediatR;

namespace TaxdoAssignment.UserApi;

public sealed record CreateUserRequest(
    string Name,
    string Email,
    string Password
) : IRequest<Guid>;
