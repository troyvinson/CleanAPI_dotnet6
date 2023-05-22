using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Users.Commands;

public sealed record AuthenticateUserCommand(UserForAuthenticationDto User) : IRequest<TokenDto>;
