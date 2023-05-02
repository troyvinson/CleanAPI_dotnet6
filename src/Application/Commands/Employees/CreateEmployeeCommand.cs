using MediatR;

namespace Application.Commands.EmployeeCommands;

public sealed record CreateEmployeeCommand(int companyId, EmployeeForCreationDto Employee) : IRequest<EmployeeDto>;
