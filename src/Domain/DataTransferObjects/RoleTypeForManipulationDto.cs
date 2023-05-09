namespace Domain.DataTransferObjects;

public abstract record RoleTypeForManipulationDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
}
