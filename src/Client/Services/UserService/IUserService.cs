using CrossplatformHW.Client.Models.Pagination;
using CrossplatformHW.Shared.Dtos;
using CrossplatformHW.Shared.Pagination.Parameters;

namespace CrossplatformHW.Client.Services.UserService;

public interface IUserService
{
    Task<PagingResponse<UserDto>> GetUsers(BaseParameters parameters);
    Task<UserDto> GetUserById(Guid userId);
    Task<UserDto> GetUserByUsername(string username);
    Task DeleteUser(Guid userId);
}