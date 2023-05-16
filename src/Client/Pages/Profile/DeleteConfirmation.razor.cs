using System.Net.Http.Headers;
using CrossplatformHW.Client.Auth;
using CrossplatformHW.Client.Services.ProfileService;
using CrossplatformHW.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;

namespace CrossplatformHW.Client.Pages.Profile;

[AllowAnonymous]
public sealed partial class DeleteConfirmation
{
    [Inject] private IProfileService ProfileService { get; set; } = null!;
    [Inject] private HttpClient HttpClient { get; set; } = null!;
    [Inject] private NavigationManager NavigationManager { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        var query = NavigationManager.ToAbsoluteUri(NavigationManager.Uri).Query;

        StringValues token;
        StringValues email;

        QueryHelpers.ParseQuery(query).TryGetValue(nameof(token), out token);
        QueryHelpers.ParseQuery(query).TryGetValue(nameof(email), out email);

        HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(AuthNamings.Bearer, token);

        await ProfileService.DeleteProfile(new ConfirmationParameters(token!, email!));
    }
}