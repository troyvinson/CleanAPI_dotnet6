using MediatR;

namespace Application.Commands.Members;

public record DeleteMemberCommand(Guid TenantId, Guid MemberId, bool TrackChanges) : IRequest;
