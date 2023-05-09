using Domain.Entities;
using MediatR;

namespace Application.Queries.Tenants;

public sealed record GetTenantForPatchQuery(int TenantId, bool TrackChanges) : IRequest<(TenantForUpdateDto tenantToPatch, Tenant tenantEntity)>;
