using Domain.Interfaces;

namespace Domain.Entities;

public class UserTenant : ISoftDeletable
{
    public int UserId { get; set; }
    public User? User { get; set; }

    public int TenantId { get; set; }
    public Tenant? Tenant { get; set; }

    public int RoleId { get; set; }
    public Role? Role { get; set; }

    public bool IsDeleted { get; set; }

}
