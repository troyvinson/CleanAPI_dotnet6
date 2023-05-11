namespace Domain.DataTransferObjects;

public record MemberDto
{
    public int Id { get; set; }
    public string? Position { get; set; }
    public DateTime DateJoined { get; set; } = DateTime.Now;
    public int TenantId { get; set; }
    public string? TenantName { get; set; }
    public int UserId { get; set; }
    public string? Username { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
}
