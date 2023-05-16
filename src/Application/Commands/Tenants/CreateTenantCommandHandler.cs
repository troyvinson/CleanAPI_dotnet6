using AutoMapper;
using MediatR;

namespace Application.Commands.Tenants;

internal sealed class CreateTenantCommandHandler : IRequestHandler<CreateTenantCommand, TenantDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public CreateTenantCommandHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<TenantDto> Handle(CreateTenantCommand request, CancellationToken cancellationToken)
    {
        var tenantEntity = _mapper.Map<Tenant>(request.Tenant);

        _repository.Tenant.CreateTenant(tenantEntity);
        await _repository.SaveAsync();

        var tenantToReturn = _mapper.Map<TenantDto>(tenantEntity);

        return tenantToReturn;
    }
}
