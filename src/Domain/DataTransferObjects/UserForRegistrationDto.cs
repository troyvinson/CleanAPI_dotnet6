using System.ComponentModel.DataAnnotations;

namespace Domain.DataTransferObjects;

public record UserForRegistrationDto
{
    public string GivenName { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    [Required(ErrorMessage = "Username is required")]
    public string UserName { get; set; } = string.Empty;
    [Required(ErrorMessage = "Password is required")] 
    public string? Password { get; init; }
    public string Email { get; set; } = string.Empty;
    public string? PhoneNumber { get; set; }

    public ICollection<string>? Roles { get; init; }

}
