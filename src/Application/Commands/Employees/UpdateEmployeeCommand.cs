using MediatR;

namespace Application.Commands.Employees;

public sealed record UpdateEmployeeCommand
    (int CompanyId, int EmployeeyId, EmployeeForUpdateDto Employee, bool CompanyTrackChanges, bool EmployeeTrackChanges) : IRequest<Unit>;
