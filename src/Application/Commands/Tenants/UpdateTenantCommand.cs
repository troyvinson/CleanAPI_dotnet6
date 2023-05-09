using MediatR;

namespace Application.Commands.Tenants;

public sealed record UpdateTenantCommand
    (int TenantId, TenantForUpdateDto Tenant, bool TrackChanges) : IRequest<Unit>;
