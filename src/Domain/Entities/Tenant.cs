using Domain.Interfaces;

namespace Domain.Entities;

public class Tenant : BaseEntity
{
    public string? Name { get; set; } = string.Empty;

    public ICollection<Member>? Members { get; set; }

}
