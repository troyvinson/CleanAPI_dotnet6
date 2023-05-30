using Domain.RequestFeatures;
using MediatR;

namespace Application.Features.Members.Queries;

public sealed record GetMembersByIdsQuery(Guid TenantId, string MemberIds,
    MemberParameters MemberParameters, bool TrackChanges)
    : IRequest<IEnumerable<MemberDto>>;
