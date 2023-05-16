using MediatR;

namespace Application.Notifications;

public sealed record TenantDeletedNotification(Guid TenantId, bool TrackChanges) : INotification;
