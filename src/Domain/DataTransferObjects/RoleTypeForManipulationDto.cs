namespace Domain.DataTransferObjects;

public abstract record RoleTypeForManipulationDto
{
    public string Name { get; set; }
    public string Description { get; set; }
}
