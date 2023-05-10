namespace Domain.DataTransferObjects;

public record CompanyDto
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string? FullAddress { get; init; }
}
