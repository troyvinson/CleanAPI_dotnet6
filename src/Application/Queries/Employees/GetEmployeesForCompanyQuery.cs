using Domain.RequestFeatures;
using MediatR;

namespace Application.Queries.EmployeeQueries;

public sealed record GetEmployeesForCompanyQuery(int CompanyId, 
    EmployeeParameters EmployeeParameters, bool TrackChanges) 
    : IRequest<(IEnumerable<EmployeeDto> employees, MetaData metaData)>;
