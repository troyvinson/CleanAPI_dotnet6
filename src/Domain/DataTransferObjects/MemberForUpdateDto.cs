namespace Domain.DataTransferObjects;

public record MemberForUpdateDto : MemberForManipulationDto
{
    public int TenantId { get; set; }

}