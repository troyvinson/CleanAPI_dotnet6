using MediatR;

namespace Application.Queries.EmployeeQueries;

public sealed record GetEmployeeForCompanyQuery(int CompanyId, int EmployeeId, bool TrackChanges) : IRequest<EmployeeDto>;
