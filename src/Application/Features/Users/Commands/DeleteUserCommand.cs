using MediatR;

namespace Application.Features.Users.Commands;

public record DeleteUserCommand(Guid UserId, bool TrackChanges) : IRequest;
