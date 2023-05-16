using MediatR;

namespace Application.Notifications;

public sealed record UserDeletedNotification(string UserId, bool TrackChanges) : INotification;
