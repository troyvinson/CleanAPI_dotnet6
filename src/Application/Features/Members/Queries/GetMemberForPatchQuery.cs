using MediatR;

namespace Application.Features.Members.Queries;

public sealed record GetMemberForPatchQuery(Guid TenantId,
    Guid MemberId, bool TenantTrackChanges, bool MemberTrackChanges)
    : IRequest<(MemberForUpdateDto memberToPatch, Member memberEntity)>;
