using Domain.Interfaces;

namespace Domain.Entities;

public class Role : ISoftDeletable
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsDeleted { get; set; }
}

