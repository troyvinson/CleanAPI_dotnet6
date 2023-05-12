using Domain.RequestFeatures;
using MediatR;

namespace Application.Queries.Members;

public sealed record GetMembersForTenantPagedQuery(int TenantId,
    MemberAndPagingParameters MemberParameters, bool TrackChanges)
    : IRequest<(IEnumerable<MemberDto> members, PagingMetaData metaData)>;
