using Domain.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Member : BaseEntity, ISoftDeletable
{
    public string? Position { get; set; }
    public DateTimeOffset DateJoined { get; set; } = DateTimeOffset.UtcNow;

    [ForeignKey(nameof(Tenant))]
    public Guid TenantId { get; set; }
    public Tenant? Tenant { get; set; }

    [ForeignKey(nameof(User))]
    public string? UserId { get; set; }
    public User? User { get; set; }

    public bool IsDeleted { get; set; }

}
