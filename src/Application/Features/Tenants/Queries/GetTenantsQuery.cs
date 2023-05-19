using MediatR;

namespace Application.Features.Tenants.Queries;

public sealed record GetTenantsQuery(bool TrackChanges) : IRequest<IEnumerable<TenantDto>>;
