using MediatR;

namespace Application.Queries.Tenants;

public sealed record GetTenantsByIdsQuery(string TenantIds, bool TrackChanges) : IRequest<IEnumerable<TenantDto>>;
