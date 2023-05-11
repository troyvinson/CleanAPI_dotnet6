namespace Domain.Exceptions;

public sealed class CollectionByIdsBadRequestException : BadRequestException
{
    public CollectionByIdsBadRequestException()
        : base("Collection count mismatch comparing requested and result ids.")
    {
    }
}
