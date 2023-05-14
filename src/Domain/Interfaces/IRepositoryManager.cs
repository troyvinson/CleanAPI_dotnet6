namespace Domain.Interfaces;

public interface IRepositoryManager
{
    IUserRepository User { get; }
    IRoleRepository Role { get; }
    IRoleTypeRepository RoleType { get; }
    ITenantRepository Tenant { get; }
    IMemberRepository Member { get; }
    IMemberRoleRepository MemberRole { get; }
    IUserRoleRepository UserRole { get; }

    Task SaveAsync();
}
