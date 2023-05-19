using MediatR;

namespace Application.Features.Users.Commands;

public sealed record UpdateUserCommand
    (Guid UserId, UserForUpdateDto User, bool TrackChanges) : IRequest<Unit>;
