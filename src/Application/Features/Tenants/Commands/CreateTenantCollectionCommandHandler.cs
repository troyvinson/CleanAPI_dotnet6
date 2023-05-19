using AutoMapper;
using Domain.Exceptions;
using MediatR;

namespace Application.Features.Tenants.Commands;

internal sealed class CreateTenantCollectionCommandHandler : IRequestHandler<CreateTenantCollectionCommand, (IEnumerable<TenantDto> tenants, string ids)>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public CreateTenantCollectionCommandHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<(IEnumerable<TenantDto> tenants, string ids)> Handle(CreateTenantCollectionCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new BadRequestException("Tenant collection sent from the client is null.");

        var tenantEntities = _mapper.Map<IEnumerable<Tenant>>(request.TenantCollection);
        foreach (var tenant in tenantEntities)
        {
            _repository.Tenant.CreateTenant(tenant);
        }

        await _repository.SaveAsync();

        var tenantCollectionToReturn = _mapper.Map<IEnumerable<TenantDto>>(tenantEntities);
        var ids = string.Join(",", tenantCollectionToReturn.Select(c => c.Id));

        return (tenants: tenantCollectionToReturn, ids);

    }
}
