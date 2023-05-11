using Domain.RequestFeatures;
using MediatR;

namespace Application.Queries.Members;

public sealed record GetMembersForTenantPagedQuery(int TenantId,
    MemberParameters MemberParameters, bool TrackChanges)
    : IRequest<(IEnumerable<MemberDto> members, MetaData metaData)>;
