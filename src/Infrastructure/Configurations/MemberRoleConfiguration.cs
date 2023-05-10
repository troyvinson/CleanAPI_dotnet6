using Infrastructure.Configurations.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class MemberRoleConfiguration : IEntityTypeConfiguration<MemberRole>
{
    public void Configure(EntityTypeBuilder<MemberRole> builder)
    {
        builder.HasKey(mr => new { mr.MemberId, mr.RoleId });

        builder.HasQueryFilter(SoftDeleteExpression.CreateFilterExpression(typeof(MemberRole)));
        //builder.HasQueryFilter(mr => !mr.Member.IsDeleted);
        //builder.HasQueryFilter(mr => mr.Member.IsEnabled);

        builder.HasData
        (
            new MemberRole { MemberId = 1, RoleId = 1, IsEnabled = true, IsDeleted = false },
            new MemberRole { MemberId = 2, RoleId = 2, IsEnabled = true, IsDeleted = false },
            new MemberRole { MemberId = 3, RoleId = 3, IsEnabled = true, IsDeleted = false },
            new MemberRole { MemberId = 4, RoleId = 1, IsEnabled = true, IsDeleted = false },
            new MemberRole { MemberId = 5, RoleId = 2, IsEnabled = true, IsDeleted = false },
            new MemberRole { MemberId = 6, RoleId = 3, IsEnabled = true, IsDeleted = false },
            new MemberRole { MemberId = 7, RoleId = 1, IsEnabled = true, IsDeleted = false },
            new MemberRole { MemberId = 8, RoleId = 2, IsEnabled = true, IsDeleted = false },
            new MemberRole { MemberId = 9, RoleId = 3, IsEnabled = true, IsDeleted = false },
            new MemberRole { MemberId = 11, RoleId = 1, IsEnabled = true, IsDeleted = false },
            new MemberRole { MemberId = 12, RoleId = 2, IsEnabled = true, IsDeleted = false },
            new MemberRole { MemberId = 13, RoleId = 3, IsEnabled = true, IsDeleted = false },
            new MemberRole { MemberId = 14, RoleId = 1, IsEnabled = true, IsDeleted = false },
            new MemberRole { MemberId = 15, RoleId = 2, IsEnabled = true, IsDeleted = false },
            new MemberRole { MemberId = 16, RoleId = 3, IsEnabled = true, IsDeleted = false },
            new MemberRole { MemberId = 17, RoleId = 1, IsEnabled = true, IsDeleted = false },
            new MemberRole { MemberId = 18, RoleId = 2, IsEnabled = true, IsDeleted = false },
            new MemberRole { MemberId = 19, RoleId = 3, IsEnabled = true, IsDeleted = false },
            new MemberRole { MemberId = 20, RoleId = 1, IsEnabled = true, IsDeleted = false }
        );
    }

}
