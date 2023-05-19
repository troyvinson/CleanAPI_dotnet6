using MediatR;

namespace Application.Features.Members.Commands;

public record DeleteMemberCommand(Guid TenantId, Guid MemberId, bool TrackChanges) : IRequest;
