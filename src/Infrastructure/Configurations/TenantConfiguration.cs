using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class TenantConfiguration : IEntityTypeConfiguration<Tenant>
{
    public void Configure(EntityTypeBuilder<Tenant> builder)
    {
        builder.HasQueryFilter(t => t.IsEnabled);
        builder.HasQueryFilter(t => !t.IsDeleted);

        builder.HasData
        (
            new Tenant { Id = Guid.Parse("{0aaa2440-01fe-451c-bcd9-ca6cbc876a3a}"), Name = "NovellaTech", IsEnabled = true },
            new Tenant { Id = Guid.Parse("{5217a17e-ffff-4fbc-aa1b-29175ab98f69}"), Name = "VeloVentures", IsEnabled = true }
        );
    }
}
