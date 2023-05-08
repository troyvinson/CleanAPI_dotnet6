using MediatR;

namespace Application.Queries.Companies;

public sealed record GetCompaniesByIdsQuery(string Ids, bool TrackChanges) : IRequest<IEnumerable<CompanyDto>>;
