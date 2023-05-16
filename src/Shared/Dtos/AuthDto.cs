using System.ComponentModel.DataAnnotations;

namespace CrossplatformHW.Shared.Dtos;

public sealed class AuthDto
{
    [Required] public bool IsSucceeded { get; set; }

    public string? Url { get; set; }

    public TokenDto? Tokens { get; set; }
}