using Domain.RequestFeatures;
using MediatR;

namespace Application.Queries.Employees;

public sealed record GetEmployeesForCompanyQuery(int CompanyId,
    EmployeeParameters EmployeeParameters, bool TrackChanges)
    : IRequest<(IEnumerable<EmployeeDto> employees, PagingMetaData metaData)>;
