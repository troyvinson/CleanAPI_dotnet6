﻿using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Users.Commands;

public sealed record RegisterUserCommand(UserForRegistrationDto User) : IRequest<IdentityResult>;
