using MediatR;

namespace Application.Features.Members.Commands;

public sealed record CreateMemberCommand(Guid TenantId, MemberForCreationDto Member) : IRequest<MemberDto>;
