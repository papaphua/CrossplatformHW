using Blazorise;
using CrossplatformHW.Client.Services.AuthService;
using CrossplatformHW.Client.Services.HttpInterceptorService;
using CrossplatformHW.Shared.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;

namespace CrossplatformHW.Client.Pages.Accounts;

[AllowAnonymous]
public partial class DefaultLogin : IDisposable
{
    private Validations _validations = new();
    [Inject] private IAuthService AuthService { get; set; } = null!;
    [Inject] private HttpInterceptorService HttpInterceptorService { get; set; } = null!;
    [Inject] private NavigationManager NavigationManager { get; set; } = null!;

    private DefaultLoginDto DefaultLoginDto { get; } = new();

    public void Dispose()
    {
        HttpInterceptorService.DisposeEvent();
    }

    protected override void OnInitialized()
    {
        HttpInterceptorService.RegisterEvent();

        var query = NavigationManager.ToAbsoluteUri(NavigationManager.Uri).Query;

        QueryHelpers.ParseQuery(query).TryGetValue("login", out var login);

        DefaultLoginDto.Login = login;
    }

    private async Task LoginAction()
    {
        if (await _validations.ValidateAll()) await AuthService.DefaultLogin(DefaultLoginDto);
    }
}