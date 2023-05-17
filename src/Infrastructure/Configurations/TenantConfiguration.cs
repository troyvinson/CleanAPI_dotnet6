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
            new Tenant { Id = Guid.Parse("{D55A75A9-2F99-48EA-B256-E1A44B134D4E}"), Name = "VeloVentures", IsEnabled = true }
        );
    }
}
