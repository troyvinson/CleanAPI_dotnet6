using Application.Queries.Tenants;
using AutoMapper;
using Domain.Exceptions;
using MediatR;

namespace Application.Handlers.Tenants;

internal sealed class GetTenantHandler : IRequestHandler<GetTenantQuery, TenantDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetTenantHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<TenantDto> Handle(GetTenantQuery request, CancellationToken cancellationToken)
    {
        var tenant = await _repository.Tenant.GetTenantByIdAsync(request.TenantId, request.TrackChanges)
            ?? throw new NotFoundException($"Tenant ID: {request.TenantId} was not found.");

        var tenantDto = _mapper.Map<TenantDto>(tenant);

        return tenantDto;
    }
}
