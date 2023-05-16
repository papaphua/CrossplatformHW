using System.ComponentModel.DataAnnotations;

namespace CrossplatformHW.Server.Data.Entities.Joints;

public sealed class RolePermission
{
    [Required] public int RoleId { get; set; }

    [Required] public int PermissionId { get; set; }
}