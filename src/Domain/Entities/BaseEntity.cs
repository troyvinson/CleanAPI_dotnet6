namespace Domain.Entities;

public class BaseEntity
{
    public Guid Id { get; set; }

    public DateTimeOffset CreatedDate { get; set; }
    public DateTimeOffset UpdatedDate { get; set; }
}
