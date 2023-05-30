using MediatR;

namespace Application.Features.Tenants.Queries;

public sealed record GetTenantForPatchQuery(Guid TenantId, bool TrackChanges) : IRequest<(TenantForUpdateDto tenantToPatch, Tenant tenantEntity)>;
