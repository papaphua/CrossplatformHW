namespace CrossplatformHW.Server.Services.PermissionService;

public interface IPermissionService
{
    Task<HashSet<string>> GetUserPermissionsAsync(Guid userId);
}