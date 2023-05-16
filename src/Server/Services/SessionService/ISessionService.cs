using CrossplatformHW.Server.Data.Entities;

namespace CrossplatformHW.Server.Services.SessionService;

public interface ISessionService
{
    Task<Session?> GetUserSessionAsync(Guid userId);
    Task CreateSessionAsync(Guid userId, string accessToken, string refreshToken);
    Task UpdateSessionAsync(Guid userId, string accessToken, string refreshToken);
}