using MediatR;

namespace Application.Features.Tenants.Commands;

public sealed record CreateTenantCommand(TenantForCreationDto Tenant) : IRequest<TenantDto>;
