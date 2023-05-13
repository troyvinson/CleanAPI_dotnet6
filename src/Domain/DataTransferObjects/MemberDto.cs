using System.ComponentModel.DataAnnotations;

namespace Domain.DataTransferObjects;

public record MemberDto
{
    public int Id { get; set; }
    public string? Position { get; set; }
    public DateTime DateJoined { get; set; } = DateTime.Now;
    public int TenantId { get; set; }
    public MemberTenantDto? Tenant { get; set; }
    public int UserId { get; set; }
    public MemberUserDto? User { get; set; }
    public bool IsEnabled { get; set; } = true;
}
