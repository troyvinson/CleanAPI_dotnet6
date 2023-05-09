using Domain.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class User : ISoftDeletable
{
    [Column("UserId")]
    public int Id { get; set; }
    public string? IdentityProviderId { get; set; }
    public string? IdentityProviderName { get; set; }
    public string? FullName { get; set; }
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? DateOfBirth { get; set; }

    public bool IsEnabled { get; set; }
    public bool IsDeleted { get; set; }

    public ICollection<Member>? Memberships { get; set; }
}

