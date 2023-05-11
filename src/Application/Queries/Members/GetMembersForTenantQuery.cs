using Domain.RequestFeatures;
using MediatR;

namespace Application.Queries.Members;

public sealed record GetMembersForTenantQuery(int TenantId, bool TrackChanges) : IRequest<IEnumerable<MemberDto>>;
