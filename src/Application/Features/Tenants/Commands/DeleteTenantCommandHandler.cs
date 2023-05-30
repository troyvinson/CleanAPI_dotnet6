using Application.Notifications;
using Domain.Exceptions;
using MediatR;

namespace Application.Features.Tenants.Commands;

internal sealed class DeleteTenantCommandHandler : IRequestHandler<DeleteTenantCommand>
{
    private readonly IRepositoryManager _repository;

    public DeleteTenantCommandHandler(IRepositoryManager repository) => _repository = repository;

    public async Task Handle(DeleteTenantCommand request, CancellationToken cancellationToken)
    {
        var tenant = await _repository.Tenant.GetTenantByIdAsync(request.TenantId, request.TrackChanges)
            ?? throw new NotFoundException($"Tenant ID: {request.TenantId} was not found.");
        
        _repository.Tenant.DeleteTenant(tenant);
        await _repository.SaveAsync();
    }

}
