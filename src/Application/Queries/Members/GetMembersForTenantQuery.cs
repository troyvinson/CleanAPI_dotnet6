using Domain.RequestFeatures;
using MediatR;

namespace Application.Queries.Members;

public sealed record GetMembersForTenantQuery(int TenantId,
    MemberParameters MemberParameters, bool TrackChanges) 
    : IRequest<IEnumerable<MemberDto>>;
