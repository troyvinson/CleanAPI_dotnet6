namespace Domain.DataTransferObjects;

public record TenantDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsEnabled { get; set; }
}


