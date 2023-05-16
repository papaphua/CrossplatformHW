﻿using System.ComponentModel.DataAnnotations;

namespace CrossplatformHW.Shared.Dtos;

public sealed class NewCommentDto
{
    [Required] public Guid ProductId { get; set; }

    [Required] public string Text { get; set; } = null!;
}