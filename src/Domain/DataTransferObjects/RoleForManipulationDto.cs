namespace Domain.DataTransferObjects;

public abstract record RoleForManipulationDto
{
    public string Name { get; set; }
    public int TypeId { get; set; }
}
