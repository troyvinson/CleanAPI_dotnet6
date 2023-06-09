﻿using AutoMapper;
using Domain.Exceptions;
using MediatR;

namespace Application.Features.Tenants.Queries;

internal sealed class GetTenantsByIdsQueryHandler : IRequestHandler<GetTenantsByIdsQuery, IEnumerable<TenantDto>>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetTenantsByIdsQueryHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TenantDto>> Handle(GetTenantsByIdsQuery request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new IdParametersBadRequestException();

        var ids = request.TenantIds.Split(',').Select(id => Guid.Parse(id)).ToList();

        var companyEntities = await _repository.Tenant.GetTenantsByIdsAsync(ids, request.tenantParameters, request.TrackChanges);
        if (ids.Count != companyEntities.Count())
            throw new CollectionByIdsBadRequestException();

        var companiesToReturn = _mapper.Map<IEnumerable<TenantDto>>(companyEntities);

        return companiesToReturn;
    }
}
