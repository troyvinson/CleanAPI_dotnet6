﻿using Domain.Interfaces;
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
    public Tenant? Tenant { get; set; }

    [ForeignKey(nameof(User))]
    public int UserId { get; set; }
    public User? User { get; set; }

    public bool IsEnabled { get; set; } = true;
    public bool IsDeleted { get; set; }

    public virtual ICollection<MemberRole>? MemberRoles { get; set; }
}
