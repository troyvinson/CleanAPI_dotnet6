using AutoMapper;
using MediatR;

namespace Application.Features.Tenants.Queries;

internal sealed class GetTenantsQueryHandler : IRequestHandler<GetTenantsQuery, IEnumerable<TenantDto>>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetTenantsQueryHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TenantDto>> Handle(GetTenantsQuery request,
        CancellationToken cancellationToken)
    {
        var tenants = await _repository.Tenant.GetTenantsAsync(request.tenantParameters, request.TrackChanges);

        var tenantsDto = _mapper.Map<IEnumerable<TenantDto>>(tenants);

        return tenantsDto;
    }
}
