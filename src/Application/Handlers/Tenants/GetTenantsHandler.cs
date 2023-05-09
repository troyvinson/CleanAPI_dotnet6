using Application.Queries.Tenants;
using AutoMapper;
using MediatR;

namespace Application.Handlers.Tenants;

internal sealed class GetTenantsHandler : IRequestHandler<GetTenantsQuery, IEnumerable<TenantDto>>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetTenantsHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TenantDto>> Handle(GetTenantsQuery request,
        CancellationToken cancellationToken)
    {
        var tenants = await _repository.Tenant.GetTenantsAsync(request.TrackChanges);

        var tenantsDto = _mapper.Map<IEnumerable<TenantDto>>(tenants);

        return tenantsDto;
    }
}
