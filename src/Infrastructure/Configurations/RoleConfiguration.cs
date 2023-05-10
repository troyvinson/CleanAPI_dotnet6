using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasData(
            new Role { Id = 1, Name = "TenantMember", RoleTypeId = 2 },
            new Role { Id = 2, Name = "TenantManager", RoleTypeId = 2 },
            new Role { Id = 3, Name = "TenantAdmin", RoleTypeId = 2 },
            new Role { Id = 4, Name = "Manager", RoleTypeId = 1 },
            new Role { Id = 5, Name = "Admin", RoleTypeId = 1 },
            new Role { Id = 6, Name = "SuperAdmin", RoleTypeId = 1 }
        );
    }
}
