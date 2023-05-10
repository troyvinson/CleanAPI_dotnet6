using Application.Commands.Tenants;
using AutoMapper;
using Domain.Exceptions;
using MediatR;

namespace Application.Handlers.Tenants;

internal sealed class UpdateTenantHandler : IRequestHandler<UpdateTenantCommand, Unit>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public UpdateTenantHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateTenantCommand request, CancellationToken cancellationToken)
    {
        var tenantEntity = await _repository.Tenant.GetTenantByIdAsync(request.TenantId, request.TrackChanges)
            ?? throw new NotFoundException($"Tenant ID: {request.TenantId} was not found.");

        _mapper.Map(request.Tenant, tenantEntity);
        await _repository.SaveAsync();

        return Unit.Value;
    }

}
