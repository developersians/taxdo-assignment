using MediatR;
using TaxdoAssignment.UserApi;

namespace TaxdoAssignment.Application;

public sealed record GetUserListQuery() : IRequest<IEnumerable<UserResponse>>;

