using MediatR;

namespace Application.Features.Members.Queries;

public sealed record GetMemberForTenantQuery(Guid TenantId,
    Guid MemberId, bool TrackChanges) : IRequest<MemberDto>;
