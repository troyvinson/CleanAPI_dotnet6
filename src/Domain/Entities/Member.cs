using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Member : BaseEntity
{
    public string? Position { get; set; }
    public DateTime DateJoined { get; set; } = DateTime.UtcNow;

    [ForeignKey(nameof(Tenant))]
    public Guid TenantId { get; set; }
    public Tenant? Tenant { get; set; }

    [ForeignKey(nameof(User))]
    public string? UserId { get; set; }
    public User? User { get; set; }

}
