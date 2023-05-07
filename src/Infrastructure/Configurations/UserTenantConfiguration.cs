using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Infrastructure.Configurations;

public class UserTenantConfiguration : IEntityTypeConfiguration<UserTenant>
{
    public void Configure(EntityTypeBuilder<UserTenant> modelBuilder)
    {
        modelBuilder.HasKey(ut => new { ut.UserId, ut.TenantId });

        modelBuilder.HasOne(ut => ut.User)
            .WithMany(u => u.UserTenants)
            .HasForeignKey(ut => ut.UserId);

        modelBuilder.HasOne(ut => ut.Tenant)
            .WithMany(t => t.UserTenants)
            .HasForeignKey(ut => ut.TenantId);

        modelBuilder.HasOne(ut => ut.Role)
            .WithMany()
            .HasForeignKey(ut => ut.RoleId);
    }
}
