using MediatR;

namespace Application.Features.Tenants.Commands;

public sealed record UpdateTenantCommand
    (Guid TenantId, TenantForUpdateDto Tenant, bool TrackChanges) : IRequest<Unit>;
