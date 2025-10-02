namespace TaxdoAssignment.UserApi;

public sealed record UserResponse(
    Guid Id,
    string Name,
    string Email,
    string PasswordHash,
    DateTime CreatedAt,
    DateTime LastUpdatedAt
);
