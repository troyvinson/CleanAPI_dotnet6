using MediatR;

namespace Application.Commands.Members;

public record DeleteMemberCommand(int TenantId, int MemberId, bool TrackChanges) : IRequest;
