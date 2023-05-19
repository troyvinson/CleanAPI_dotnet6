﻿using AutoMapper;
using Domain.Exceptions;
using MediatR;

namespace Application.Features.Users.Commands;

internal sealed class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public UpdateUserCommandHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var userEntity = await _repository.User.GetUserByIdAsync(request.UserId, request.TrackChanges)
            ?? throw new NotFoundException($"User identified by '{request.UserId}' was not found in the database.");

        _mapper.Map(request.User, userEntity);
        await _repository.SaveAsync();

        return Unit.Value;
    }

}