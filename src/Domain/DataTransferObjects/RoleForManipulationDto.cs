namespace Domain.DataTransferObjects;

public abstract record RoleForManipulationDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int TypeId { get; set; }
}
