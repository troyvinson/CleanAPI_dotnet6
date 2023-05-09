using MediatR;

namespace Application.Commands.Members;

public sealed record CreateMemberCommand(int TenantId, MemberForCreationDto Member) : IRequest<MemberDto>;
