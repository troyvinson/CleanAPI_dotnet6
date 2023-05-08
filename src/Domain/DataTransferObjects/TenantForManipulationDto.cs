namespace Domain.DataTransferObjects;

public abstract record TenantForManipulationDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
}
