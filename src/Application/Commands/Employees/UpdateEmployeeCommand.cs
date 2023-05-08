using MediatR;

namespace Application.Commands.Employees;

public sealed record UpdateEmployeeCommand
    (int companyId, int employeeyId, EmployeeForUpdateDto Employee, bool companyTrackChanges, bool employeeTrackChanges) : IRequest<Unit>;
