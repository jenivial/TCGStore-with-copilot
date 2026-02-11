namespace TCGStore.Api.Features.Users;

public record RegisterUserRequest(
    string Email,
    string Username,
    string Password,
    string? FirstName,
    string? LastName
);

public record LoginRequest(
    string Email,
    string Password
);

public record LoginResponse(
    string Token,
    User User
);
