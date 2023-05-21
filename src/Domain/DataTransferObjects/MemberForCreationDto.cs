namespace Domain.DataTransferObjects;

public record MemberForCreationDto : MemberForManipulationDto
{
    public Guid TenantId { get; set; }
    public string? UserId { get; set; }
}