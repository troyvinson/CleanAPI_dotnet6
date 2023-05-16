using MediatR;

namespace Application.Commands.Tenants;

public sealed record UpdateTenantCommand
    (Guid TenantId, TenantForUpdateDto Tenant, bool TrackChanges) : IRequest<Unit>;
