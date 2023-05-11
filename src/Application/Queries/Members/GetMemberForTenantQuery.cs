using MediatR;

namespace Application.Queries.Members;

public sealed record GetMemberForTenantQuery(int TenantId,
    int MemberId, bool TrackChanges) : IRequest<MemberDto>;
