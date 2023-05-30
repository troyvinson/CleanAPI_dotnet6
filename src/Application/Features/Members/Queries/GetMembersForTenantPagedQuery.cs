using Domain.RequestFeatures;
using MediatR;

namespace Application.Features.Members.Queries;

public sealed record GetMembersForTenantPagedQuery(Guid TenantId,
    MemberAndPagingParameters MemberParameters, bool TrackChanges)
    : IRequest<(IEnumerable<MemberDto> members, PagingMetaData metaData)>;
