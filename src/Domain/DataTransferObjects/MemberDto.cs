namespace Domain.DataTransferObjects;

public record MemberDto
{
    public int Id { get; set; }
    public string Position { get; set; }
    public DateTime DateJoined { get; set; }
    public int TenantId { get; set; }
    public int UserId { get; set; }

}
