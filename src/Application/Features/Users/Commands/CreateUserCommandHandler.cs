using AutoMapper;
using MediatR;

namespace Application.Features.Users.Commands;

internal sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public CreateUserCommandHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var userEntity = _mapper.Map<User>(request.User);

        _repository.User.CreateUser(userEntity);
        await _repository.SaveAsync();

        var userToReturn = _mapper.Map<UserDto>(userEntity);

        return userToReturn;
    }
}
