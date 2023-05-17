using Domain.DataTransferObjects;
using MediatR;

namespace Application.Queries.Members;

public sealed record GetMemberForTenantQuery(Guid TenantId,
    Guid MemberId, bool TrackChanges) : IRequest<MemberDto>;
