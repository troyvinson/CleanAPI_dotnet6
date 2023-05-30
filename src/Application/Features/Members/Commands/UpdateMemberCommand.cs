using MediatR;

namespace Application.Features.Members.Commands;

public sealed record UpdateMemberCommand
    (Guid TenantId, Guid MemberId, MemberForUpdateDto Member, bool TenantTrackChanges, bool MemberTrackChanges) : IRequest<Unit>;
