using MediatR;

namespace Application.Queries.CompanyQueries;

public sealed record GetCompanyQuery(int Id, bool TrackChanges) : IRequest<CompanyDto>;
