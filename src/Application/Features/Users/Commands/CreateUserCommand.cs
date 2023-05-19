using MediatR;

namespace Application.Features.Users.Commands;

public sealed record CreateUserCommand(UserForCreationDto User) : IRequest<UserDto>;
