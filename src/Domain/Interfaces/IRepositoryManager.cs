namespace Domain.Interfaces;

internal interface IRepositoryManager
{
    ICompanyRepository Company { get; }
    IEmployeeRepository Employee { get; }
    IUserRoleRepository ApplicationUserRole { get; }

    Task SaveAsync();
}
