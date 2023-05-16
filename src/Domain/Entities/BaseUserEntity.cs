using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;

public class BaseUserEntity : IdentityUser, ISoftDeletable
{
    public DateTimeOffset CreatedDate { get; set; }
    public DateTimeOffset UpdatedDate { get; set; }
    public bool IsDeleted { get; set; }


}
