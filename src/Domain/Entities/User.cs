using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;

public class User : IdentityUser, ISoftDeletable
{
    public string GivenName { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string NormalizedName { get; set; } = string.Empty;

    public bool IsDeleted { get; set; }

    public ICollection<Member>? Memberships { get; set; }
}

