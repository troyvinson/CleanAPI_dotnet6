using MediatR;

namespace Application.Features.Tenants.Queries;

public sealed record GetTenantQuery(Guid TenantId, bool TrackChanges) : IRequest<TenantDto>;
