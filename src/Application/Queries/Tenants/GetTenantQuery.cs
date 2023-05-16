using MediatR;

namespace Application.Queries.Tenants;

public sealed record GetTenantQuery(Guid TenantId, bool TrackChanges) : IRequest<TenantDto>;
