using Domain.RequestFeatures;
using MediatR;

namespace Application.Queries.Members;

public sealed record GetMembersForTenantQuery(Guid TenantId,
    MemberParameters MemberParameters, bool TrackChanges) 
    : IRequest<IEnumerable<MemberDto>>;
