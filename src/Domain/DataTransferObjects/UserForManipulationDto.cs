﻿using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Domain.DataTransferObjects;

public record UserForManipulationDto
{
    public string? GivenName { get; set; } = string.Empty;
    public string? Surname { get; set; } = string.Empty;
    public string? NormalizedName { get; set; }
    public string? UserName { get; set; } = string.Empty;
    public string? NormalizedUserName { get; set; }
    public string? Email { get; set; } = string.Empty;
    public string? NormalizedEmail { get; set; }
    public string? PhoneNumber { get; set; }
}
