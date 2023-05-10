using Application.Queries.Tenants;
using AutoMapper;
using Domain.Exceptions;
using MediatR;

namespace Application.Handlers.Tenants;

internal sealed class GetTenantForPatchHandler : IRequestHandler<GetTenantForPatchQuery, (TenantForUpdateDto tenantToPatch, Tenant tenantEntity)>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetTenantForPatchHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<(TenantForUpdateDto tenantToPatch, Tenant tenantEntity)> Handle(GetTenantForPatchQuery request, CancellationToken cancellationToken)
    {
        var tenant = await _repository.Tenant.GetTenantByIdAsync(request.TenantId, request.TrackChanges)
            ?? throw new NotFoundException($"Tenant ID: {request.TenantId} was not found.");

        var tenantToPatch = _mapper.Map<TenantForUpdateDto>(tenant);

        return (tenantToPatch, tenant);
    }

}
