using MediatR;

namespace Application.Commands.Members;

public sealed record CreateMemberCommand(Guid TenantId, MemberForCreationDto Member) : IRequest<MemberDto>;
