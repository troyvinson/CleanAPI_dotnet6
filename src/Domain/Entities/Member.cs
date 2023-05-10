using Domain.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Member : BaseEntity, ISoftDeletable
{
    [Column("MemberId")]
    public int Id { get; set; }
    public string? Position { get; set; }
    public DateTime DateJoined { get; set; } = DateTime.UtcNow;

    [ForeignKey(nameof(Tenant))]
    public int TenantId { get; set; }
    public Tenant Tenant { get; set; } = null!;

    [ForeignKey(nameof(User))]
    public int UserId { get; set; }
    public User User { get; set; } = null!;

    public bool IsEnabled { get; set; }
    public bool IsDeleted { get; set; }


}
