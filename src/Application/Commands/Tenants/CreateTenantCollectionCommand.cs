using Domain.DataTransferObjects;
using MediatR;

namespace Application.Commands.Tenants;

public sealed record CreateTenantCollectionCommand(IEnumerable<TenantForCreationDto> TenantCollection) : IRequest<(IEnumerable<TenantDto> tenants, string ids)>;
