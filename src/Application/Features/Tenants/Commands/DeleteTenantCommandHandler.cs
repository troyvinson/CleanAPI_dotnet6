using Application.Notifications;
using Domain.Exceptions;
using MediatR;

namespace Application.Features.Tenants.Commands;

internal sealed class DeleteTenantCommandHandler : INotificationHandler<TenantDeletedNotification>
{
    private readonly IRepositoryManager _repository;

    public DeleteTenantCommandHandler(IRepositoryManager repository) => _repository = repository;

    public async Task Handle(TenantDeletedNotification notification, CancellationToken cancellationToken)
    {
        var tenant = await _repository.Tenant.GetTenantByIdAsync(notification.TenantId, notification.TrackChanges)
            ?? throw new NotFoundException($"Tenant ID: {notification.TenantId} was not found.");

        _repository.Tenant.DeleteTenant(tenant);
        await _repository.SaveAsync();
    }
}
