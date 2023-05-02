using MediatR;

namespace Application.Queries.CompanyQueries;

public sealed record GetCompaniesByIdsQuery(string ids, bool TrackChanges) : IRequest<IEnumerable<CompanyDto>>;
