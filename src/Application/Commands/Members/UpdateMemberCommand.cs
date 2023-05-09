using MediatR;

namespace Application.Commands.Members;

public sealed record UpdateMemberCommand
    (int TenantId, int MemberId, MemberForUpdateDto Member, bool TenantTrackChanges, bool MemberTrackChanges) : IRequest<Unit>;
