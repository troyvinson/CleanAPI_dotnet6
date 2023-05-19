using Domain.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class User : BaseEntity, ISoftDeletable
{
    public string GivenName { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? PhoneNumber { get; set; }


    public bool IsDeleted { get; set; }

    public ICollection<Member>? Memberships { get; set; }
}

