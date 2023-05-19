using Domain.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Member : BaseEntity, ISoftDeletable
{
    public string? Position { get; set; }
    public DateTime DateJoined { get; set; } = DateTime.UtcNow;

    [ForeignKey(nameof(Tenant))]
    public Guid TenantId { get; set; }
    public Tenant? Tenant { get; set; }

    [ForeignKey(nameof(User))]
    public Guid UserId { get; set; }
    public User? User { get; set; }

    public bool IsEnabled { get; set; } = true;
    public bool IsDeleted { get; set; }

}
