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

        //builder.HasData
        //(
        //    new Tenant { Id = 1, Name = "NovellaTech", IsEnabled = true },
        //    new Tenant { Id = 2, Name = "VeloVentures", IsEnabled = true },
        //    new Tenant { Id = 3, Name = "StellarWorks", IsEnabled = true },
        //    new Tenant { Id = 4, Name = "Nexus Solutions", IsEnabled = true },
        //    new Tenant { Id = 5, Name = "Zenith Dynamics", IsEnabled = true },
        //    new Tenant { Id = 6, Name = "Horizon Innovations", IsEnabled = true },
        //    new Tenant { Id = 7, Name = "QuantumCorp", IsEnabled = true },
        //    new Tenant { Id = 8, Name = "FusionX Technologies", IsEnabled = true },
        //    new Tenant { Id = 9, Name = "Apex Analytics", IsEnabled = true },
        //    new Tenant { Id = 10, Name = "Luminary Labs", IsEnabled = true }
        //);
    }
}
