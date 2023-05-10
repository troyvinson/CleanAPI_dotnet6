namespace Domain.DataTransferObjects;

public record RoleTypeDto
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
}

