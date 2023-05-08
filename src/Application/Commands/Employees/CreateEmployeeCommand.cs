using MediatR;

namespace Application.Commands.Employees;

public sealed record CreateEmployeeCommand(int companyId, EmployeeForCreationDto Employee) : IRequest<EmployeeDto>;
