using System.ComponentModel.DataAnnotations;

namespace Domain.DataTransferObjects;

public record UserForAuthenticationDto
{
    public string? UserName { get; init; }
    public string? Password { get; init; }
}
