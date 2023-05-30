namespace Domain.Exceptions;

public sealed class UserCollectionBadRequest : BadRequestException
{
    public UserCollectionBadRequest()
        : base("User collection sent from client is null.")
    {
    }
}
