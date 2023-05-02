using MediatR;

namespace Application.Queries.CompanyQueries;

public sealed record GetCompaniesQuery(bool TrackChanges) : IRequest<IEnumerable<CompanyDto>>;
