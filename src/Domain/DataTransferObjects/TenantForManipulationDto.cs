namespace Domain.DataTransferObjects;

public abstract record TenantForManipulationDto
{
    public string Name { get; set; }
    public bool IsEnabled { get; set; }
}
