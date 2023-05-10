namespace Domain.DataTransferObjects;

public abstract record CompanyForManipulationDto
{
    public string Name { get; init; } = string.Empty;

    public string? Address { get; init; }

    public string? Country { get; init; }
}
