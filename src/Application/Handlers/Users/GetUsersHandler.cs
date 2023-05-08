using Application.Queries.Users;
using AutoMapper;
using MediatR;

namespace Application.Handlers.Users;

internal sealed class GetUsersHandler : IRequestHandler<GetUsersQuery, IEnumerable<UserDto>>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetUsersHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserDto>> Handle(GetUsersQuery request,
        CancellationToken cancellationToken)
    {
        var users = await _repository.User.GetAllUsersAsync(request.TrackChanges);

        var usersDto = _mapper.Map<IEnumerable<UserDto>>(users);

        return usersDto;
    }
}
