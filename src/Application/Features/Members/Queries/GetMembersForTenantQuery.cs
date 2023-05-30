using Domain.RequestFeatures;
using MediatR;

namespace Application.Features.Members.Queries;

public sealed record GetMembersForTenantQuery(Guid TenantId,
    MemberParameters MemberParameters, bool TrackChanges)
    : IRequest<IEnumerable<MemberDto>>;
