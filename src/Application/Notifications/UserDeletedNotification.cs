using MediatR;

namespace Application.Notifications;

public sealed record UserDeletedNotification(Guid UserId, bool TrackChanges) : INotification;
