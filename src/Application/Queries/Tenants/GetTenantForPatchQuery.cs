using MediatR;

namespace Application.Queries.Tenants;

public sealed record GetTenantForPatchQuery(Guid TenantId, bool TrackChanges) : IRequest<(TenantForUpdateDto tenantToPatch, Tenant tenantEntity)>;
