using MediatR;

namespace Application.Queries.Companies;

public sealed record GetCompanyQuery(int Id, bool TrackChanges) : IRequest<CompanyDto>;
