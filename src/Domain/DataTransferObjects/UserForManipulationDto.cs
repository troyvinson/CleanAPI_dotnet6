namespace Domain.DataTransferObjects;

public abstract record UserForManipulationDto
{
    public int Id { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }
}
