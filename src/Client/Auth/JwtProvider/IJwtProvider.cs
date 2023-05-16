using System.Security.Claims;

namespace CrossplatformHW.Client.Auth.JwtProvider;

public interface IJwtProvider
{
    IEnumerable<Claim> Parse(string jwt);
}