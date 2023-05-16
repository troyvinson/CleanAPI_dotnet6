using Infrastructure.Configurations.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class MemberConfiguration : IEntityTypeConfiguration<Member>
{
    public void Configure(EntityTypeBuilder<Member> builder)
    {
        builder.HasQueryFilter(SoftDeleteExpression.CreateFilterExpression(typeof(Member)));
        //builder.HasQueryFilter(m => !m.IsEnabled);

        //builder.HasData
        //(
        //    new Member { Position = "Manager", TenantId = 1, IsEnabled = true },
        //    new Member { Position = "Assistant Manager", TenantId = 1, IsEnabled = true },
        //    new Member { Position = "Supervisor", TenantId = 2, IsEnabled = true },
        //    new Member { Position = "Associate", TenantId = 2, IsEnabled = true },
        //    new Member { Position = "Team Lead", TenantId = 3, IsEnabled = true },
        //    new Member { Position = "Senior Associate", TenantId = 3, IsEnabled = true },
        //    new Member { Position = "Trainer", TenantId = 4, IsEnabled = true },
        //    new Member { Position = "Quality Assurance", TenantId = 4, IsEnabled = true },
        //    new Member { Position = "Consultant", TenantId = 5, IsEnabled = true },
        //    new Member { Position = "Project Manager", TenantId = 5, IsEnabled = true }
        //);
    }
}
