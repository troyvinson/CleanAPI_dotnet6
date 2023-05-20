namespace Domain.DataTransferObjects;

public record MemberDto
{
    public Guid Id { get; set; }
    public string? Position { get; set; }
    public DateTimeOffset DateJoined { get; set; } = DateTimeOffset.Now;
    public Guid TenantId { get; set; }
    public MemberTenantDto? Tenant { get; set; }
    public string UserId { get; set; }
    public MemberUserDto? User { get; set; }
    public bool IsEnabled { get; set; } = true;

}
