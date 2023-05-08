using Application.Commands.Users;
using AutoMapper;
using Domain.Exceptions;
using MediatR;

namespace Application.Handlers.Users;

internal sealed class UpdateUserHandler : IRequestHandler<UpdateUserCommand, Unit>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public UpdateUserHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var userEntity = await _repository.User.GetUserByIdAsync(request.UserId, request.TrackChanges);
        if (userEntity is null)
            throw new UserNotFoundException(request.UserId);

        _mapper.Map(request.User, userEntity);
        await _repository.SaveAsync();

        return Unit.Value;
    }

}
