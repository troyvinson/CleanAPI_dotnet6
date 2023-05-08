using MediatR;

namespace Application.Notifications;

public sealed record CompanyDeletedNotification(int CompanyId, bool TrackChanges) : INotification;
