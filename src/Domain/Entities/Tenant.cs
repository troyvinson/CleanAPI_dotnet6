using Domain.Interfaces;

namespace Domain.Entities;

public class Tenant : ISoftDeletable
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsDeleted { get; set; }


    public ICollection<UserTenant> UserTenants { get; set; } = new List<UserTenant>();
}
