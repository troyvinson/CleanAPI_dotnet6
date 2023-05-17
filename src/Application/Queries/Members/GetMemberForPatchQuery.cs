using Domain.DataTransferObjects;
using MediatR;

namespace Application.Queries.Members;

public sealed record GetMemberForPatchQuery(Guid TenantId,
    Guid MemberId, bool TenantTrackChanges, bool MemberTrackChanges)
    : IRequest<(MemberForUpdateDto memberToPatch, Member memberEntity)>;
