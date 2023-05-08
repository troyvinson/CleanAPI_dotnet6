using MediatR;

namespace Application.Commands.Employees;

public record DeleteEmployeeCommand(int CompanyId, int EmployeeId, bool TrackChanges) : IRequest;
