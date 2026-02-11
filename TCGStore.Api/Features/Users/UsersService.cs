namespace TCGStore.Api.Features.Users;

public class UsersService : IUsersService
{
    private readonly ILogger<UsersService> _logger;

    public UsersService(ILogger<UsersService> logger)
    {
        _logger = logger;
    }

    public async Task<User?> GetUserByIdAsync(int id)
    {
        // TODO: Implement database query
        await Task.CompletedTask;
        return null;
    }

    public async Task<User> RegisterUserAsync(RegisterUserRequest request)
    {
        // TODO: Implement password hashing and database insert
        await Task.CompletedTask;
        return new User
        {
            Email = request.Email,
            Username = request.Username,
            PasswordHash = "hashed_password", // TODO: Hash password
            FirstName = request.FirstName,
            LastName = request.LastName,
            Role = UserRole.Customer,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
    }

    public async Task<LoginResponse?> LoginAsync(LoginRequest request)
    {
        // TODO: Implement authentication and JWT generation
        await Task.CompletedTask;
        return null;
    }
}
