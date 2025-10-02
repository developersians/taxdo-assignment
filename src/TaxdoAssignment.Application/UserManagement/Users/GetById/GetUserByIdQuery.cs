using MediatR;
using TaxdoAssignment.UserApi;

namespace TaxdoAssignment.Application;

public sealed record GetUserByIdQuery(Guid id) : IRequest<UserResponse?>;