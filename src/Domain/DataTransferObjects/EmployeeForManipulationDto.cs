namespace Domain.DataTransferObjects;

public abstract record EmployeeForManipulationDto
{
    public string Name { get; init; } = string.Empty;

    public int Age { get; init; }

    public string? Position { get; init; }
}
