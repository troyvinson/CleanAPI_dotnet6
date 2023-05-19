﻿using AutoMapper;
using Domain.Exceptions;
using MediatR;

namespace Application.Features.Users.Queries;

internal sealed class GetUsersByIdsQueryHandler : IRequestHandler<GetUsersByIdsQuery, IEnumerable<UserDto>>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetUsersByIdsQueryHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserDto>> Handle(GetUsersByIdsQuery request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new IdParametersBadRequestException();

        var ids = request.UserIds.Split(',').Select(id => Guid.Parse(id)).ToList();

        var userEntities = await _repository.User.GetUsersByIdsAsync(ids, request.TrackChanges);
        if (ids.Count != userEntities.Count())
            throw new CollectionByIdsBadRequestException();

        var usersToReturn = _mapper.Map<IEnumerable<UserDto>>(userEntities);

        return usersToReturn;
    }
}
