using Domain.Interfaces;

namespace Domain.Entities;

public abstract class BaseEntity : ISoftDeletable
{
    public Guid Id { get; set; }

    public DateTimeOffset CreatedDate { get; set; }
    public string CreatedBy { get; set; } = string.Empty;
    public DateTimeOffset UpdatedDate { get; set; }
    public string UpdatedBy { get; set; } = string.Empty;

    public bool IsEnabled { get; set; }
    public bool IsDeleted { get; set; }


}
