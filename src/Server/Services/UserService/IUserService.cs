using CrossplatformHW.Server.Data.Entities;
using CrossplatformHW.Shared.Pagination.Parameters;

namespace CrossplatformHW.Server.Services.UserService;

public interface IUserService
{
    Task<List<User>> GetUsersByParametersAsync(BaseParameters parameters);
    Task<User?> GetUserByIdAsync(Guid id);
    Task<User?> GetUserByUsernameAsync(string username);
    Task<User?> GetUserByEmailAsync(string email);
    Task CreateUserAsync(User user);
    Task DeleteUserAsync(Guid id);
    Task UpdateUserAsync(User user);
}