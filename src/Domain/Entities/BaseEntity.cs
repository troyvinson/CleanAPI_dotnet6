namespace Domain.Entities;

public class BaseEntity
{
    public Guid Id { get; set; }

    public DateTimeOffset CreatedDate { get; set; }
    public string CreatedBy { get; set; } = string.Empty;
    public DateTimeOffset UpdatedDate { get; set; }
    public string UpdatedBy { get; set; } = string.Empty;
}
