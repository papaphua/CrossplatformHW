﻿using System.ComponentModel.DataAnnotations;

namespace CrossplatformHW.Shared.Dtos;

public sealed class LoginDto
{
    [Required(ErrorMessage = "Username or email is required.")]
    public string Login { get; set; } = null!;
}