using MediatR;

namespace Application.Notifications;

public sealed record TenantDeletedNotification(int TenantId, bool TrackChanges) : INotification;
