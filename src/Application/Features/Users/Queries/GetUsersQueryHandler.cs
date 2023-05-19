using AutoMapper;
using MediatR;

namespace Application.Features.Users.Queries;

internal sealed class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IEnumerable<UserDto>>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetUsersQueryHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserDto>> Handle(GetUsersQuery request,
        CancellationToken cancellationToken)
    {
        var users = await _repository.User.GetUsersAsync(request.TrackChanges);

        var usersDto = _mapper.Map<IEnumerable<UserDto>>(users);

        return usersDto;
    }
}
