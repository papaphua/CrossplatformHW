using CrossplatformHW.Client.Auth.PermissionHandler;
using CrossplatformHW.Client.Services.HttpInterceptorService;
using CrossplatformHW.Client.Services.UserService;
using CrossplatformHW.Shared.Dtos;
using Microsoft.AspNetCore.Components;

namespace CrossplatformHW.Client.Pages.Profile;

[HasPermission(Permissions.CustomerPermission)]
public sealed partial class View : IDisposable
{
    [Inject] private IUserService UserService { get; set; } = null!;
    [Inject] private HttpInterceptorService HttpInterceptorService { get; set; } = null!;

    [Parameter] public string Username { get; set; }

    private UserDto User { get; set; } = new();

    public void Dispose()
    {
        HttpInterceptorService.DisposeEvent();
    }

    protected override async Task OnInitializedAsync()
    {
        HttpInterceptorService.RegisterEvent();
        User = await UserService.GetUserByUsername(Username);
    }
}