using MediatR;

namespace TaxdoAssignment.Application;

public sealed record CreateUserCommand(
    string Name,
    string Email,
    string Password
) : IRequest<Guid>;
