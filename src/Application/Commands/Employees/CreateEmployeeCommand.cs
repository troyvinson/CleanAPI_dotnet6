using MediatR;

namespace Application.Commands.Employees;

public sealed record CreateEmployeeCommand(int CompanyId, EmployeeForCreationDto Employee) : IRequest<EmployeeDto>;
