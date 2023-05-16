using Application.Commands.Users;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Handlers.Users;

internal sealed class RegisterUserHandler : IRequestHandler<RegisterUserCommand, IdentityResult>
{
    private readonly IRepositoryManager _repository;
    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;

    public RegisterUserHandler(IRepositoryManager repository, IMapper mapper, UserManager<User> userManager)
    {
        _repository = repository;
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task<IdentityResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<User>(request.User); 

        var result = await _userManager.CreateAsync(user, request.User.Password); 

        if (result.Succeeded) 
            await _userManager.AddToRolesAsync(user, request.User.Roles); 

        return result;
    }
}
