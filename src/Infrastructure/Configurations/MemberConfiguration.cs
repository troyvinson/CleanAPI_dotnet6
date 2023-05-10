using Domain.Entities;
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

        builder.HasData
        (
            new Member { Id = 1, Position = "Manager", TenantId = 1, UserId = 1, IsEnabled = true },
            new Member { Id = 2, Position = "Assistant Manager", TenantId = 1, UserId = 2, IsEnabled = true },
            new Member { Id = 3, Position = "Supervisor", TenantId = 2, UserId = 3, IsEnabled = true },
            new Member { Id = 4, Position = "Associate", TenantId = 2, UserId = 4, IsEnabled = true },
            new Member { Id = 5, Position = "Team Lead", TenantId = 3, UserId = 5, IsEnabled = true },
            new Member { Id = 6, Position = "Senior Associate", TenantId = 3, UserId = 6, IsEnabled = true },
            new Member { Id = 7, Position = "Trainer", TenantId = 4, UserId = 7, IsEnabled = true },
            new Member { Id = 8, Position = "Quality Assurance", TenantId = 4, UserId = 8, IsEnabled = true },
            new Member { Id = 9, Position = "Consultant", TenantId = 5, UserId = 9, IsEnabled = true },
            new Member { Id = 10, Position = "Project Manager", TenantId = 5, UserId = 10, IsEnabled = true },
            new Member { Id = 11, Position = "Technical Lead", TenantId = 6, UserId = 11, IsEnabled = true },
            new Member { Id = 12, Position = "Software Engineer", TenantId = 6, UserId = 12, IsEnabled = true },
            new Member { Id = 13, Position = "Sales Representative", TenantId = 7, UserId = 13, IsEnabled = true },
            new Member { Id = 14, Position = "Account Manager", TenantId = 7, UserId = 14, IsEnabled = true },
            new Member { Id = 15, Position = "HR Manager", TenantId = 8, UserId = 15, IsEnabled = true },
            new Member { Id = 16, Position = "Recruiter", TenantId = 8, UserId = 16, IsEnabled = true },
            new Member { Id = 17, Position = "Financial Analyst", TenantId = 9, UserId = 17, IsEnabled = true },
            new Member { Id = 18, Position = "Controller", TenantId = 9, UserId = 18, IsEnabled = true },
            new Member { Id = 19, Position = "Marketing Manager", TenantId = 10, UserId = 19, IsEnabled = true },
            new Member { Id = 20, Position = "Social Media Specialist", TenantId = 10, UserId = 20, IsEnabled = true }

        );
    }
}
