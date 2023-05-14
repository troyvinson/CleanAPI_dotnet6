using Application.Notifications;
using MediatR;

namespace Application.Handlers;

internal sealed class EmailHandler : INotificationHandler<UserDeletedNotification>
{
    private readonly ILoggerManager _logger;

    public EmailHandler(ILoggerManager logger) => _logger = logger;

    public async Task Handle(UserDeletedNotification notification, CancellationToken cancellationToken)
    {
        // Email configureation here
        _logger.LogWarn($"Delete action for the user with id: {notification.UserId} has occurred.");

        await Task.CompletedTask;
    }
}
