using Domain.RequestFeatures;
using Infrastructure.Repositories.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public sealed class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
{
    public EmployeeRepository(RepositoryContext repositoryContext)
        : base(repositoryContext) { }

    public async Task<PagedList<Employee>> GetEmployeesForCompanyAsync(int companyId, EmployeeParameters employeeParameters, bool trackChanges)
    {
        employeeParameters.SearchTerm ??= string.Empty;

        var employees = await FindByCondition(e => e.CompanyId.Equals(companyId), trackChanges)
            .FilterEmployees(employeeParameters.MinAge, employeeParameters.MaxAge)
            .Search(employeeParameters.SearchTerm)
            .OrderBy(e => e.Name)
            .ToListAsync();

        return PagedList<Employee>
            .ToPagedList(employees, employeeParameters.PageNumber, employeeParameters.PageSize);
    }

    public async Task<Employee?> GetEmployeeForCompanyAsync(int companyId, int employeeId, bool trackChanges) =>
        await FindByCondition(e => e.CompanyId.Equals(companyId) && e.Id.Equals(employeeId), trackChanges)
        .SingleOrDefaultAsync();

    public void CreateEmployeeForCompany(int companyId, Employee employee)
    {
        employee.CompanyId = companyId;
        Create(employee);
    }

    public void DeleteEmployee(Employee employee) => Delete(employee);

}
