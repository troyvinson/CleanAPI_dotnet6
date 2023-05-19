using Infrastructure.Configurations.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class TenantConfiguration : IEntityTypeConfiguration<Tenant>
{
    public void Configure(EntityTypeBuilder<Tenant> builder)
    {
        builder.HasQueryFilter(SoftDeleteExpression.CreateFilterExpression(typeof(Tenant)));
        //builder.HasQueryFilter(t => !t.IsEnabled);

        builder.HasData
        (
            new Tenant { Id = Guid.Parse("{0AAA2440-01FE-451C-BCD9-CA6CBC876A3A}"), Name = "NovellaTech", IsEnabled = true },
            new Tenant { Id = Guid.Parse("{5217A17E-FFFF-4FBC-AA1B-29175AB98F69}"), Name = "VeloVentures", IsEnabled = true }
        );
    }
}
