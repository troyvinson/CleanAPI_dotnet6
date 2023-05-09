using MediatR;

namespace Application.Notifications;

public sealed record MemberDeletedNotification(int MemberId, bool TrackChanges) : INotification;
