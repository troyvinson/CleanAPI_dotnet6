namespace Domain.Interfaces;

public interface IRepositoryManager
{
    ICompanyRepository Company { get; }
    IEmployeeRepository Employee { get; }
    IUserRepository User { get; }
    IRoleRepository Role { get; }
    ITenantRepository Tenant { get; }

    Task SaveAsync();
}
