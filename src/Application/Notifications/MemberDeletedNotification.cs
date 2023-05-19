using MediatR;

namespace Application.Notifications;

public sealed record MemberDeletedNotification(Guid MemberId, bool TrackChanges) : INotification;
