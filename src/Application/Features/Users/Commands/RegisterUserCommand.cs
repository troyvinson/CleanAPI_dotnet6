using MediatR;

namespace Application.Features.Users.Commands;

public sealed record RegisterUserCommand(UserForRegistrationDto User) : IRequest<UserDto>;
