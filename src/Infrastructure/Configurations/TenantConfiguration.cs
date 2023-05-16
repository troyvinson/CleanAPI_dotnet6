using Infrastructure.Configurations.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class TenantConfiguration : IEntityTypeConfiguration<Tenant>
{
    public void Configure(EntityTypeBuilder<Tenant> builder)
    {
        builder.HasQueryFilter(SoftDeleteExpression.CreateFilterExpression(typeof(Tenant)));
        //builder.HasQueryFilter(t => t.IsEnabled);

        builder.HasData
        (
            new Tenant { Id = Guid.Parse("{D46EAE42-FE4B-4706-BE3D-965B10E3861A}"), Name = "NovellaTech", IsEnabled = true },
            new Tenant { Id = Guid.Parse("{D55A75A9-2F99-48EA-B256-E1A44B134D4E}"), Name = "VeloVentures", IsEnabled = true },
            new Tenant { Id = Guid.Parse("{1BAFE33A-24B2-489E-BC1B-7F7E2FD00640}"), Name = "StellarWorks", IsEnabled = true },
            new Tenant { Id = Guid.Parse("{27B0F8E4-72DC-4618-B0F4-12A33E2600DE}"), Name = "Nexus Solutions", IsEnabled = true },
            new Tenant { Id = Guid.Parse("{BCB1F1CF-3072-49D4-BC96-72859E6F0F08}"), Name = "Zenith Dynamics", IsEnabled = true }
        );
    }
}
