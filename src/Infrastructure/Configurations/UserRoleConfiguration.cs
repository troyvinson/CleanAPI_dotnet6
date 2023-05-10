using Infrastructure.Configurations.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.HasKey(mr => new { mr.UserId, mr.RoleId });

        builder.HasQueryFilter(SoftDeleteExpression.CreateFilterExpression(typeof(UserRole)));
        //builder.HasQueryFilter(ur => !ur.User.IsDeleted);

        builder.HasData
        (
            new UserRole { UserId = 28, RoleId = 4, IsEnabled = true, IsDeleted = false },
            new UserRole { UserId = 29, RoleId = 4, IsEnabled = true, IsDeleted = false },
            new UserRole { UserId = 30, RoleId = 4, IsEnabled = true, IsDeleted = false }
        );
    }

}
