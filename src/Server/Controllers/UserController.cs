using CrossplatformHW.Server.Auth.PermissionHandler;
using CrossplatformHW.Server.Common;
using CrossplatformHW.Server.Facades.UserFacade;
using CrossplatformHW.Server.Services.UserService;
using CrossplatformHW.Shared.Dtos;
using CrossplatformHW.Shared.Pagination.Parameters;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CrossplatformHW.Server.Controllers;

[Route("api/users")]
[ApiController]
public sealed class UserController : ControllerBase
{
    private readonly IUserFacade _userFacade;
    private readonly IUserService _userService;

    public UserController(IUserFacade userFacade, IUserService userService)
    {
        _userFacade = userFacade;
        _userService = userService;
    }

    [HasPermission(Permissions.AdminPermission)]
    [HttpGet]
    public async Task<List<UserDto>> GetUsersByParameters([FromQuery] BaseParameters parameters)
    {
        var pagedList = await _userFacade.GetUsersByParametersAsync(parameters);

        Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(pagedList.MetaData));

        return pagedList;
    }

    [HasPermission(Permissions.AdminPermission)]
    [HttpGet("id/{id:guid}")]
    public async Task<UserDto?> GetUserById(Guid id)
    {
        return await _userFacade.GetUserByIdAsync(id);
    }

    [HasPermission(Permissions.AdminPermission)]
    [HttpGet("username/{username}")]
    public async Task<UserDto?> GetUserByUsername(string username)
    {
        return await _userFacade.GetUserByUsernameAsync(username);
    }

    [HasPermission(Permissions.AdminPermission)]
    [HttpDelete("{id:guid}")]
    public async Task DeleteUser(Guid id)
    {
        await _userService.DeleteUserAsync(id);
    }
}