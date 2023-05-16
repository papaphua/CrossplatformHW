using System.Security.Claims;
using CrossplatformHW.Server.Data.Entities;

namespace CrossplatformHW.Server.Common.Providers.TokenProvider;

public interface ITokenProvider
{
    Task<string> GenerateAccessTokenAsync(User user);
    string GenerateRefreshToken(User user);
    string GenerateConfirmationToken(User user);
    ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    Guid GetUserIdFromContext(HttpContext context);
}