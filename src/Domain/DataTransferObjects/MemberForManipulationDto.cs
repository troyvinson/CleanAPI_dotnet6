namespace Domain.DataTransferObjects;

public abstract record MemberForManipulationDto
{
    public string? Position { get; set; }
    public DateTimeOffset DateJoined { get; set; }

}
