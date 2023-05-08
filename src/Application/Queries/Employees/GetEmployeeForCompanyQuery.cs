using MediatR;

namespace Application.Queries.Employees;

public sealed record GetEmployeeForCompanyQuery(int CompanyId, int EmployeeId, bool TrackChanges) : IRequest<EmployeeDto>;
