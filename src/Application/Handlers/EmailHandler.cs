using Application.Notifications;
using MediatR;

namespace Application.Handlers;

internal sealed class EmailHandler : INotificationHandler<CompanyDeletedNotification>
{
    private readonly ILoggerManager _logger;

    public EmailHandler(ILoggerManager logger) => _logger = logger;

    public async Task Handle(CompanyDeletedNotification notification, CancellationToken cancellationToken)
    {
        // Email configureation here
        _logger.LogWarn($"Delete action for the company with id: {notification.CompanyId} has occurred.");

        await Task.CompletedTask;
    }
}
