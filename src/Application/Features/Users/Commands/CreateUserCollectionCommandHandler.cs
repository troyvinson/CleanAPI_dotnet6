using AutoMapper;
using Domain.Exceptions;
using MediatR;

namespace Application.Features.Users.Commands;

internal sealed class CreateUserCollectionCommandHandler : IRequestHandler<CreateUserCollectionCommand, (IEnumerable<UserDto> users, string ids)>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public CreateUserCollectionCommandHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<(IEnumerable<UserDto> users, string ids)> Handle(CreateUserCollectionCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new BadRequestException("User collection sent from client is null.");

        var userEntities = _mapper.Map<IEnumerable<User>>(request.UserCollection);
        foreach (var user in userEntities)
        {
            _repository.User.CreateUser(user);
        }

        await _repository.SaveAsync();

        var userCollectionToReturn = _mapper.Map<IEnumerable<UserDto>>(userEntities);
        var ids = string.Join(",", userCollectionToReturn.Select(c => c.Id));

        return (users: userCollectionToReturn, ids);

    }
}
