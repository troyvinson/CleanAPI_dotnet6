namespace Domain.DataTransferObjects;

public record MemberForUpdateDto : MemberForManipulationDto
{
    public Guid TenantId { get; set; }

}