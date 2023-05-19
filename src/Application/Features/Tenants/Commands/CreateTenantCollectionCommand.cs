using MediatR;

namespace Application.Features.Tenants.Commands;

public sealed record CreateTenantCollectionCommand(IEnumerable<TenantForCreationDto> TenantCollection) : IRequest<(IEnumerable<TenantDto> tenants, string ids)>;
