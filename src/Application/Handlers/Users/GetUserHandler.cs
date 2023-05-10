using Application.Queries.Users;
using AutoMapper;
using Domain.Exceptions;
using MediatR;

namespace Application.Handlers.Users;

internal sealed class GetUserHandler : IRequestHandler<GetUserQuery, UserDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetUserHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _repository.User.GetUserByIdAsync(request.UserId, request.TrackChanges)
            ?? throw new NotFoundException($"User identified by '{request.UserId}' was not found in the database.");

        var userDto = _mapper.Map<UserDto>(user);

        return userDto;
    }
}
