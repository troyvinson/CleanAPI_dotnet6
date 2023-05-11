using MediatR;

namespace Application.Queries.Members;

public sealed record GetMembersByIdsQuery(int TenantId, string MemberIds, bool TrackChanges) : IRequest<IEnumerable<MemberDto>>;
