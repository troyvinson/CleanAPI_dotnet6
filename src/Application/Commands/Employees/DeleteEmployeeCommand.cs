using MediatR;

namespace Application.Commands.EmployeeCommands;

public record DeleteEmployeeCommand(int companyId, int employeeId, bool TrackChanges) : IRequest;
