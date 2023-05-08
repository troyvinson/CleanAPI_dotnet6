using MediatR;

namespace Application.Commands.Users;

public record DeleteUserCommand(int UserId, bool TrackChanges) : IRequest;
