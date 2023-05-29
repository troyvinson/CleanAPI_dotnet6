using Domain.RequestFeatures;
using MediatR;

namespace Application.Features.Tenants.Queries;

public sealed record GetTenantsByIdsQuery(string TenantIds, TenantParameters tenantParameters, bool TrackChanges) : IRequest<IEnumerable<TenantDto>>;
