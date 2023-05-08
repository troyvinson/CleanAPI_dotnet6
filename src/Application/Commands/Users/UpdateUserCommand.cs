using MediatR;

namespace Application.Commands.Users;

public sealed record UpdateUserCommand
    (int UserId, UserForUpdateDto User, bool TrackChanges) : IRequest<Unit>;
