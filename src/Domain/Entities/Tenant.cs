using Domain.Interfaces;

namespace Domain.Entities;

public class Tenant : BaseEntity, ISoftDeletable
{
    public string? Name { get; set; } = string.Empty;

    public bool IsDeleted { get; set; }

    public ICollection<Member>? Members { get; set; }
}
