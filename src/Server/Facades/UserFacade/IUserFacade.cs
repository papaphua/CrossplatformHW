using CrossplatformHW.Server.Primitives;
using CrossplatformHW.Shared.Dtos;
using CrossplatformHW.Shared.Pagination.Parameters;

namespace CrossplatformHW.Server.Facades.UserFacade;

public interface IUserFacade
{
    Task<PagedList<UserDto>> GetUsersByParametersAsync(BaseParameters parameters);
    Task<UserDto?> GetUserByIdAsync(Guid id);
    Task<UserDto?> GetUserByUsernameAsync(string username);
}