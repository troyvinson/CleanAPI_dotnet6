using MediatR;

namespace Application.Commands.Members;

public sealed record UpdateMemberCommand
    (Guid TenantId, Guid MemberId, MemberForUpdateDto Member, bool TenantTrackChanges, bool MemberTrackChanges) : IRequest<Unit>;
