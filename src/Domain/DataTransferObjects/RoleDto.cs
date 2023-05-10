namespace Domain.DataTransferObjects;

public record RoleDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int TypeId { get; set; }
    public string TypeName { get; set; } = string.Empty;

}
