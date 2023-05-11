using Domain.RequestFeatures;
using MediatR;

namespace Application.Queries.Members;

public sealed record GetMembersForTenantQuery(int TenantId,
    MemberSearchParameters MemberSearchParameters, bool TrackChanges)
    : IRequest<(IEnumerable<MemberDto> members, MetaData metaData)>;
