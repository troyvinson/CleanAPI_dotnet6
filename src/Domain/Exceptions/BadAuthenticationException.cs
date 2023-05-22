namespace Domain.Exceptions;

public class BadAuthenticationException : Exception
{
    public BadAuthenticationException(string message)
        : base(message)
    {
    }
}
