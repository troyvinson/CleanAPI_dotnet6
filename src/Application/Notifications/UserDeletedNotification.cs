using MediatR;

namespace Application.Notifications;

public sealed record UserDeletedNotification(int UserId, bool TrackChanges) : INotification;
