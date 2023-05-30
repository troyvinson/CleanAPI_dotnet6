namespace Domain.Exceptions;

public class RefreshTokenRequestException : Exception
{
    public RefreshTokenRequestException(string message)
        : base(message)
    {
    }
}
