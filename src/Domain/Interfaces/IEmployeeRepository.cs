using Domain.Entities;
using Domain.RequestFeatures;

namespace Domain.Interfaces;

public interface IEmployeeRepository
{
    Task<PagedList<Employee>> GetEmployeesForCompanyAsync(int companyId, EmployeeParameters employeeParameters, bool trackChanges);
    Task<Employee> GetEmployeeForCompanyAsync(int companyId, int employeeId, bool trackChanges);
    void CreateEmployeeForCompany(int companyId, Employee employee);
    void DeleteEmployee(Employee employee);
}
