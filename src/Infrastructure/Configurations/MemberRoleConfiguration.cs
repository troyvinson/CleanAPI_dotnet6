using Infrastructure.Configurations.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class MemberRoleConfiguration : IEntityTypeConfiguration<MemberRole>
{
    public void Configure(EntityTypeBuilder<MemberRole> builder)
    {
        builder.HasKey(mr => new { mr.Id, mr.RoleId });

        builder.HasQueryFilter(SoftDeleteExpression.CreateFilterExpression(typeof(MemberRole)));
        //builder.HasQueryFilter(mr => !mr.Member.IsDeleted);
        builder.HasQueryFilter(mr => mr.Member.IsEnabled);

        builder.HasData
        (
            new MemberRole { Id = 1, RoleId = 1, IsEnabled = true, IsDeleted = false },
            new MemberRole { Id = 2, RoleId = 2, IsEnabled = true, IsDeleted = false },
            new MemberRole { Id = 3, RoleId = 3, IsEnabled = true, IsDeleted = false },
            new MemberRole { Id = 4, RoleId = 1, IsEnabled = true, IsDeleted = false },
            new MemberRole { Id = 5, RoleId = 2, IsEnabled = true, IsDeleted = false },
            new MemberRole { Id = 6, RoleId = 3, IsEnabled = true, IsDeleted = false },
            new MemberRole { Id = 7, RoleId = 1, IsEnabled = true, IsDeleted = false },
            new MemberRole { Id = 8, RoleId = 2, IsEnabled = true, IsDeleted = false },
            new MemberRole { Id = 9, RoleId = 3, IsEnabled = true, IsDeleted = false },
            new MemberRole { Id = 11, RoleId = 1, IsEnabled = true, IsDeleted = false },
            new MemberRole { Id = 12, RoleId = 2, IsEnabled = true, IsDeleted = false },
            new MemberRole { Id = 13, RoleId = 3, IsEnabled = true, IsDeleted = false },
            new MemberRole { Id = 14, RoleId = 1, IsEnabled = true, IsDeleted = false },
            new MemberRole { Id = 15, RoleId = 2, IsEnabled = true, IsDeleted = false },
            new MemberRole { Id = 16, RoleId = 3, IsEnabled = true, IsDeleted = false },
            new MemberRole { Id = 17, RoleId = 1, IsEnabled = true, IsDeleted = false },
            new MemberRole { Id = 18, RoleId = 2, IsEnabled = true, IsDeleted = false },
            new MemberRole { Id = 19, RoleId = 3, IsEnabled = true, IsDeleted = false },
            new MemberRole { Id = 20, RoleId = 1, IsEnabled = true, IsDeleted = false }
        );
    }

}
