using System.ComponentModel.DataAnnotations;

namespace CrossplatformHW.Shared.Dtos;

public sealed class CategoryDto
{
    [Required] public Guid Id { get; set; }

    [Required] public string Name { get; set; } = null!;

    [Required] public string Slug { get; set; } = null!;
}