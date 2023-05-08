using MediatR;

namespace Application.Commands.Users;

public sealed record CreateUserCommand(UserForCreationDto User) : IRequest<UserDto>;
