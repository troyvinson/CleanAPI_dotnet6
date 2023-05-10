using Domain.Entities;
using Infrastructure.Configurations.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Infrastructure.Configurations;

public class TenantConfiguration : IEntityTypeConfiguration<Tenant>
{
    public void Configure(EntityTypeBuilder<Tenant> builder)
    {
        builder.HasQueryFilter(t => !t.IsDeleted);
        //builder.HasQueryFilter(SoftDeleteExpression.CreateFilterExpression(typeof(Tenant)));

        //builder.HasData
        //(
        //    new Company
        //    {
        //        Id = 1,
        //        Name = "IT_Solutions Ltd",
        //        Address = "583 Wall Dr. Gwynn Oak, MD 21207",
        //        Country = "USA"
        //    },
        //    new Company
        //    {
        //        Id = 2,
        //        Name = "Admin_Solutions Ltd",
        //        Address = "312 Forest Avenue, BF 923",
        //        Country = "USA"
        //    }
        //);
    }
}
