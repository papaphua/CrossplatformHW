using CrossplatformHW.Client.Services.AuthService;
using Microsoft.AspNetCore.Components;

namespace CrossplatformHW.Client.Shared;

public partial class TopMenu
{
    [Inject] private IAuthService AuthService { get; set; } = null!;
}