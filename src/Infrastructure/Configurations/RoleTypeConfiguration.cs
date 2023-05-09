using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class RoleTypeConfiguration : IEntityTypeConfiguration<RoleType>
{
    public void Configure(EntityTypeBuilder<RoleType> modelBuilder)
    {
        modelBuilder.HasData(
            new Role { Id = 1, Name = "Application" },
            new Role { Id = 2, Name = "Tenant" }
        );
    }
}
