using System.ComponentModel.DataAnnotations;

namespace CrossplatformHW.Shared.Dtos;

public sealed class ExceptionDto
{
    [Required] public string Message { get; set; } = null!;
}