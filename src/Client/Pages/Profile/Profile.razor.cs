using Blazorise;
using CrossplatformHW.Client.Auth.PermissionHandler;
using CrossplatformHW.Client.Services.HttpInterceptorService;
using CrossplatformHW.Client.Services.ProfileService;
using CrossplatformHW.Shared.Dtos;
using Microsoft.AspNetCore.Components;

namespace CrossplatformHW.Client.Pages.Profile;

[HasPermission(Permissions.CustomerPermission)]
public sealed partial class Profile : IDisposable
{
    private Validations _validations = new();
    [Inject] private IProfileService ProfileService { get; set; } = null!;
    [Inject] private HttpInterceptorService HttpInterceptorService { get; set; } = null!;

    private ProfileDto UserProfile { get; set; } = new();

    public void Dispose()
    {
        HttpInterceptorService.RegisterEvent();
    }

    protected override async Task OnInitializedAsync()
    {
        HttpInterceptorService.RegisterEvent();
        UserProfile = await ProfileService.GetUserProfile();
    }

    private async Task SaveAction()
    {
        if (await _validations.ValidateAll()) await ProfileService.UpdateUserProfile(UserProfile);
    }
}