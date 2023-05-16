using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;

public class User : IdentityUser, ISoftDeletable
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }

    public DateTimeOffset CreatedDate { get; set; }
    public string CreatedBy { get; set; } = string.Empty;
    public DateTimeOffset UpdatedDate { get; set; }
    public string UpdatedBy { get; set; } = string.Empty;

    public bool IsEnabled { get; set; }
    public bool IsDeleted { get; set; }
}
