using Domain.RequestFeatures;
using MediatR;

namespace Application.Features.Tenants.Queries;

public sealed record GetTenantsQuery(TenantParameters tenantParameters, bool TrackChanges) : IRequest<IEnumerable<TenantDto>>;
