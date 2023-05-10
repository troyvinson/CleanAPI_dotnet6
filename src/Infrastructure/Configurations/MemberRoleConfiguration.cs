using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class MemberRoleConfiguration : IEntityTypeConfiguration<MemberRole>
{
    public void Configure(EntityTypeBuilder<MemberRole> builder)
    {
        builder.HasKey(mr => new { mr.MemberId, mr.RoleId });

        builder.HasQueryFilter(mr => !mr.Member.IsDeleted);

    }

}
