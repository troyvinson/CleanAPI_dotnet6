using MediatR;

namespace Application.Features.Tenants.Queries;

public sealed record GetTenantsByIdsQuery(string TenantIds, bool TrackChanges) : IRequest<IEnumerable<TenantDto>>;
