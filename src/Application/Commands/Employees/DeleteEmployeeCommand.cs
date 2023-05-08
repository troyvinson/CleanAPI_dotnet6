using MediatR;

namespace Application.Commands.Employees;

public record DeleteEmployeeCommand(int companyId, int employeeId, bool TrackChanges) : IRequest;
