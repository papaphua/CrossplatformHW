using Blazorise;
using CrossplatformHW.Client.Auth.PermissionHandler;
using CrossplatformHW.Client.Services.AuthService;
using CrossplatformHW.Client.Services.HttpInterceptorService;
using CrossplatformHW.Shared.Dtos;
using Microsoft.AspNetCore.Components;

namespace CrossplatformHW.Client.Pages.Profile;

[HasPermission(Permissions.CustomerPermission)]
public sealed partial class EmailChange : IDisposable
{
    private const string ConfirmationUrl = "/profile/email/change/confirmation";
    private Validations _validations = new();
    [Inject] private HttpInterceptorService HttpInterceptorService { get; set; } = null!;
    [Inject] private NavigationManager NavigationManager { get; set; } = null!;
    [Inject] private IAuthService AuthService { get; set; } = null!;

    private EmailDto EmailDto { get; } = new();

    public void Dispose()
    {
        HttpInterceptorService.DisposeEvent();
    }

    protected override void OnInitialized()
    {
        HttpInterceptorService.RegisterEvent();
    }

    private async Task SendCodesAction()
    {
        if (await _validations.ValidateAll())
        {
            await AuthService.GetConfirmationCode();
            await AuthService.GetNewEmailConfirmationCode(EmailDto);

            var url = ConfirmationUrl + $"?email={EmailDto.Email}";
            NavigationManager.NavigateTo(url);
        }
    }
}