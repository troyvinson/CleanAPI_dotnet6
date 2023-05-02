namespace Domain.Exceptions;

public class EmployeeNotFoundException : NotFoundException
{
    public EmployeeNotFoundException(int employeeId, int companyId)
        : base($"Employee with id {employeeId} for CompanyId {companyId} doesn't exist in the database.")
    {
    }
}
