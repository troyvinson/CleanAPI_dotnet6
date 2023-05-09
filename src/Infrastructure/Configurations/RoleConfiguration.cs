using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        //builder.HasData(
        //    new Role { Id = -99, Name = "SuperAdmin" },
        //    new Role { Id = 1, Name = "Admin" },
        //    new Role { Id = 2, Name = "Manager" },
        //    new Role { Id = 3, Name = "Member" }
        //);
    }
}
