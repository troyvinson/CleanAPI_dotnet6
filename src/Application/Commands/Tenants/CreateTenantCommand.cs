using Domain.DataTransferObjects;
using MediatR;

namespace Application.Commands.Tenants;

public sealed record CreateTenantCommand(TenantForCreationDto Tenant) : IRequest<TenantDto>;
