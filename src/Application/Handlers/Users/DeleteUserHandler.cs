using Application.Notifications;
using Domain.Exceptions;
using MediatR;

namespace Application.Handlers.Users;

internal sealed class DeleteUserHandler : INotificationHandler<UserDeletedNotification>
{
    private readonly IRepositoryManager _repository;

    public DeleteUserHandler(IRepositoryManager repository) => _repository = repository;

    public async Task Handle(UserDeletedNotification notification, CancellationToken cancellationToken)
    {
        var user = await _repository.User.GetUserByIdAsync(notification.UserId, notification.TrackChanges)
            ?? throw new NotFoundException($"User identified by '{notification.UserId}' was not found in the database.");

        _repository.User.DeleteUser(user);
        await _repository.SaveAsync();
    }
}
