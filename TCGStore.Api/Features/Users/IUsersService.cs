namespace TCGStore.Api.Features.Users;

public interface IUsersService
{
    Task<User?> GetUserByIdAsync(int id);
    Task<User> RegisterUserAsync(RegisterUserRequest request);
    Task<LoginResponse?> LoginAsync(LoginRequest request);
}
