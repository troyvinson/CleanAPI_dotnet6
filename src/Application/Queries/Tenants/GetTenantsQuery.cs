using MediatR;

namespace Application.Queries.Tenants;

public sealed record GetTenantsQuery(bool TrackChanges) : IRequest<IEnumerable<TenantDto>>;
