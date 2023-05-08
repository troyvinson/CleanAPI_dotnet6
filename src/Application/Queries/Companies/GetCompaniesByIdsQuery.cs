using MediatR;

namespace Application.Queries.Companies;

public sealed record GetCompaniesByIdsQuery(string CompanyIds, bool TrackChanges) : IRequest<IEnumerable<CompanyDto>>;
