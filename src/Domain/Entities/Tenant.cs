using Domain.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Tenant : BaseEntity, ISoftDeletable
{
    public string? Name { get; set; } = string.Empty;

    public bool IsEnabled { get; set; }
    public bool IsDeleted { get; set; }

    public ICollection<Member>? Members { get; set; }
}
