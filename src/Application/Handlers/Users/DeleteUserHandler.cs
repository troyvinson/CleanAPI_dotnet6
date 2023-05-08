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
        var user = await _repository.User.GetUserByIdAsync(notification.UserId, notification.TrackChanges);
        if (user is null)
            throw new UserNotFoundException(notification.UserId);

        _repository.User.DeleteUser(user);
        await _repository.SaveAsync();
    }
}
