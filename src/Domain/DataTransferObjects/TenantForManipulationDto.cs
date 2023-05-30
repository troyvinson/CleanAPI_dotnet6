namespace Domain.DataTransferObjects;

public abstract record TenantForManipulationDto
{
    public string Name { get; set; } = string.Empty;
    public bool IsEnabled { get; set; } = true;
}
