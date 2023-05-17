using Domain.DataTransferObjects;
using Domain.RequestFeatures;
using MediatR;

namespace Application.Queries.Members;

public sealed record GetMembersForTenantPagedQuery(Guid TenantId,
    MemberAndPagingParameters MemberParameters, bool TrackChanges)
    : IRequest<(IEnumerable<MemberDto> members, PagingMetaData metaData)>;
