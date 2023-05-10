using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class MemberConfiguration : IEntityTypeConfiguration<Member>
{
    public void Configure(EntityTypeBuilder<Member> builder)
    {
        builder.HasQueryFilter(m => !m.IsDeleted);
        //builder.HasQueryFilter(SoftDeleteExpression.CreateFilterExpression(typeof(Member)));

        //builder.HasData
        //(
        //    new Member
        //    {
        //        Id = 1,
        //        Name = "Sam Raiden",
        //        Age = 26,
        //        Position = "Software developer",
        //        TenantId = 1
        //    },
        //    new Member
        //    {
        //        Id = 2,
        //        Name = "Jana McLeaf",
        //        Age = 30,
        //        Position = "Software developer",
        //        TenantId = 2
        //    },
        //     new Member
        //     {
        //         Id = 3,
        //         Name = "Kane Miller",
        //         Age = 35,
        //         Position = "Administrator",
        //         TenantId = 2
        //     }
        //);
    }
}
