using Blazorise;
using CrossplatformHW.Client.Services.AuthService;
using CrossplatformHW.Client.Services.HttpInterceptorService;
using CrossplatformHW.Shared.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;

namespace CrossplatformHW.Client.Pages.Accounts;

[AllowAnonymous]
public sealed partial class FindLogin : IDisposable
{
    private Validations _validations = new();
    [Inject] private IAuthService AuthService { get; set; } = null!;
    [Inject] private HttpInterceptorService HttpInterceptorService { get; set; } = null!;

    private LoginDto LoginDto { get; } = new();

    public void Dispose()
    {
        HttpInterceptorService.DisposeEvent();
    }

    protected override void OnInitialized()
    {
        HttpInterceptorService.RegisterEvent();
    }

    private async Task ContinueAction()
    {
        if (await _validations.ValidateAll()) await AuthService.FindLoginInfo(LoginDto);
    }
}