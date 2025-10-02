using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using TaxdoAssignment.Application;

namespace TaxdoAssignment.UserApi;

[Route("api/[controller]")]
[ApiController]
public class UsersController(ISender sender) : ControllerBase
{
    /// <summary>
    /// Retrieves a user by its Id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<UserResponse>> GetById([FromRoute] Guid id, CancellationToken cancellationToken = default)
    {
        var query = new GetUserByIdQuery(id);
        UserResponse? result = await sender.Send(query, cancellationToken);

        return result is null
            ? new NotFoundObjectResult(null)
            : new OkObjectResult(result);
    }

    /// <summary>
    /// Retrieves the list of current users
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserResponse>>> GetList(CancellationToken cancellationToken = default)
    {
        var query = new GetUserListQuery();
        IEnumerable<UserResponse> result = await sender.Send(query, cancellationToken);

        return Ok(result);
    }

    /// <summary>
    /// Creates a new user
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserRequest request, CancellationToken cancellationToken = default)
    {
        var command = new CreateUserCommand(
            Name: request.Name,
            Email: request.Email,
            Password: request.Password
        );

        Guid result = await sender.Send(command, cancellationToken);

        return CreatedAtAction(nameof(GetById), result);
    }
}
