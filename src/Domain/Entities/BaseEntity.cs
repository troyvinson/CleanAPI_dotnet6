namespace Domain.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; set; }

    public bool IsEnabled { get; set; } = true;
    public DateTimeOffset CreatedDate { get; set; }
    public DateTimeOffset UpdatedDate { get; set; }

}
