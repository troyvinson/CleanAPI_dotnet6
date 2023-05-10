namespace Domain.DataTransferObjects;

public abstract record RoleForManipulationDto
{
    public string Name { get; set; } = string.Empty;
    public int TypeId { get; set; }
}
