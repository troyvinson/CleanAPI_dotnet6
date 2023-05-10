namespace Domain.Interfaces;

public interface IRepositoryManager
{
    ICompanyRepository Company { get; }
    IEmployeeRepository Employee { get; }
    IUserRepository User { get; }
    IRoleRepository Role { get; }
    IRoleTypeRepository RoleType { get; }
    ITenantRepository Tenant { get; }
    IMemberRepository Member { get; }
    IMemberRoleRepository MemberRole { get; }
    IUserRoleRepository UserRole { get; }

    Task SaveAsync();
}
