using CrossplatformHW.Server.Common;
using Microsoft.AspNetCore.Authorization;

namespace CrossplatformHW.Server.Auth.PermissionHandler;

public sealed class HasPermissionAttribute : AuthorizeAttribute
{
    public HasPermissionAttribute(Permissions permission) :
        base(permission.ToString())
    {
    }
}