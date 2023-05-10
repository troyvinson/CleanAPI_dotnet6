using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class RoleTypeConfiguration : IEntityTypeConfiguration<RoleType>
{
    public void Configure(EntityTypeBuilder<RoleType> builder)
    {
        builder.HasData(
            new RoleType 
            { 
                Id = 1, 
                Name = "UserRole", 
                Description = string.Empty,
                CreatedDate = DateTimeOffset.Now,
                UpdatedDate = DateTimeOffset.Now,
            },
            new RoleType 
            { 
                Id = 2, 
                Name = "MemberRole", 
                Description = string.Empty,
                CreatedDate = DateTimeOffset.Now,
                UpdatedDate = DateTimeOffset.Now,
            }
        );
    }
}
