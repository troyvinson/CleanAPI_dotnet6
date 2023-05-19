using AutoMapper;
using Domain.Exceptions;
using MediatR;

namespace Application.Features.Users.Queries;

internal sealed class GetUserForPatchQueryHandler : IRequestHandler<GetUserForPatchQuery, (UserForUpdateDto userToPatch, User userEntity)>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetUserForPatchQueryHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<(UserForUpdateDto userToPatch, User userEntity)> Handle(GetUserForPatchQuery request, CancellationToken cancellationToken)
    {
        var user = await _repository.User.GetUserByIdAsync(request.UserId, request.TrackChanges)
            ?? throw new NotFoundException($"User identified by '{request.UserId}' was not found in the database.");

        var userToPatch = _mapper.Map<UserForUpdateDto>(user);

        return (userToPatch, user);
    }

}
