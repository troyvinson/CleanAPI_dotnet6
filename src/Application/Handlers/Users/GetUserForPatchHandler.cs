using Application.Queries.Companies;
using Application.Queries.Users;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;

namespace Application.Handlers.Users;

internal sealed class GetUserForPatchHandler : IRequestHandler<GetUserForPatchQuery, (UserForUpdateDto userToPatch, User userEntity)>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetUserForPatchHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<(UserForUpdateDto userToPatch, User userEntity)> Handle(GetUserForPatchQuery request, CancellationToken cancellationToken)
    {
        var user = await _repository.User.GetUserByIdAsync(request.UserId, request.TrackChanges);
        if (user is null)
            throw new UserNotFoundException(request.UserId);

        var userToPatch = _mapper.Map<UserForUpdateDto>(user);

        return (userToPatch, user);
    }

}
