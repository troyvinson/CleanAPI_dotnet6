using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Users.Commands;

internal sealed class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, UserDto>
{
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;

    public RegisterUserCommandHandler(IMapper mapper, UserManager<User> userManager)
    {
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task<UserDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<User>(request.User);
        var result = await _userManager.CreateAsync(user, request.User.Password);

        if (result.Succeeded && request.User.Roles!.Count() > 0)
            await _userManager.AddToRolesAsync(user, request.User.Roles);

        var userDto = _mapper.Map<UserDto>(user);

        return userDto;

    }
}
