using MediatR;

namespace Application.Queries.Tenants;

public sealed record GetTenantQuery(int TenantId, bool TrackChanges) : IRequest<TenantDto>;
