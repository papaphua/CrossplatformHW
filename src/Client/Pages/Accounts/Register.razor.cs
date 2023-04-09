﻿using Blazorise;
using BlazorShop.Client.Services.AuthService;
using BlazorShop.Client.Services.HttpInterceptorService;
using BlazorShop.Shared.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;

namespace BlazorShop.Client.Pages.Accounts;

[AllowAnonymous]
public sealed partial class Register : IDisposable
{
    private Validations _validations = new();
    [Inject] private IAuthService AuthService { get; set; } = null!;
    [Inject] private HttpInterceptorService HttpInterceptorService { get; set; } = null!;

    private RegisterDto RegisterDto { get; } = new();

    public void Dispose()
    {
        HttpInterceptorService.DisposeEvent();
    }

    protected override void OnInitialized()
    {
        HttpInterceptorService.RegisterEvent();
    }

    private async Task RegisterAction()
    {
        if (await _validations.ValidateAll()) await AuthService.Register(RegisterDto);
    }
}