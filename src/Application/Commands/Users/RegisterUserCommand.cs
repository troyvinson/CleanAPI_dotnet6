using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Commands.Users;

public sealed record RegisterUserCommand(UserForRegistrationDto User) : IRequest<IdentityResult>;
