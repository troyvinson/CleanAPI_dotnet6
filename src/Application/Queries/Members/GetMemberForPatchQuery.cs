using MediatR;

namespace Application.Queries.Members;

public sealed record GetMemberForPatchQuery(int TenantId,
    int MemberId, bool TenantTrackChanges, bool MemberTrackChanges)
    : IRequest<(MemberForUpdateDto memberToPatch, Member memberEntity)>;
