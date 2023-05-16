namespace Domain.DataTransferObjects;

public record TenantDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsEnabled { get; set; } = true;
}


