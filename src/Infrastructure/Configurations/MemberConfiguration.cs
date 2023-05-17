using Infrastructure.Configurations.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class MemberConfiguration : IEntityTypeConfiguration<Member>
{
    public void Configure(EntityTypeBuilder<Member> builder)
    {
        builder.HasQueryFilter(SoftDeleteExpression.CreateFilterExpression(typeof(Member)));
        //builder.HasQueryFilter(m => m.IsEnabled);

        builder.HasData
        (
            new Member { Id = Guid.Parse("{E180D192-27D6-4007-87AB-9782E45EBB62}"), TenantId = Guid.Parse("{D46EAE42-FE4B-4706-BE3D-965B10E3861A}"), UserId = "BCB1F1CF-3072-49D4-BC96-72859E6F0F08", Position = "Manager", IsEnabled = true },
            new Member { Id = Guid.Parse("{7E2D12E1-74F6-49F9-B28F-070D048E1E14}"), TenantId = Guid.Parse("{D46EAE42-FE4B-4706-BE3D-965B10E3861A}"), UserId = "33BCFBF7-EDFC-4F7A-8224-9802519D299D", Position = "Assistant Manager", IsEnabled = true },
            new Member { Id = Guid.Parse("{82F7A407-1C94-406A-B60E-F172C3D1B743}"), TenantId = Guid.Parse("{D46EAE42-FE4B-4706-BE3D-965B10E3861A}"), UserId = "A1A68798-B47F-4653-B37D-D2C4FF37FE9D", Position = "Supervisor", IsEnabled = true },
            new Member { Id = Guid.Parse("{7A1A1100-C588-47D8-807F-2D242B2DEA72}"), TenantId = Guid.Parse("{D46EAE42-FE4B-4706-BE3D-965B10E3861A}"), UserId = "FF971359-568F-4CCF-8F62-194AAE51C745", Position = "Associate", IsEnabled = true },
            new Member { Id = Guid.Parse("{07C752A9-2EEF-4F09-A248-78AA1E90307C}"), TenantId = Guid.Parse("{D46EAE42-FE4B-4706-BE3D-965B10E3861A}"), UserId = "87C317FA-EED0-4E6F-A49F-29D73539D9DE", Position = "Team Lead", IsEnabled = true },
            new Member { Id = Guid.Parse("{C3C65B72-6FBA-4A99-928C-BA3347EFBD9A}"), TenantId = Guid.Parse("{D46EAE42-FE4B-4706-BE3D-965B10E3861A}"), UserId = "A54FF230-6063-42BD-A37B-457D579B2544", Position = "Senior Associate", IsEnabled = true },
            new Member { Id = Guid.Parse("{0D471414-D1B6-4415-8FBF-DBEC7C61DE8E}"), TenantId = Guid.Parse("{D46EAE42-FE4B-4706-BE3D-965B10E3861A}"), UserId = "A62A61E1-419D-4C80-BA81-E6DDCCC50B1C", Position = "Trainer", IsEnabled = true },

            new Member { Id = Guid.Parse("{739EB8CB-EC9F-44FB-9329-B913859E10B0}"), TenantId = Guid.Parse("{D55A75A9-2F99-48EA-B256-E1A44B134D4E}"), UserId = "BCB1F1CF-3072-49D4-BC96-72859E6F0F08", Position = "Quality Assurance", IsEnabled = true },
            new Member { Id = Guid.Parse("{C118CF09-5FEC-4ADC-A915-52ED765F1FF3}"), TenantId = Guid.Parse("{D55A75A9-2F99-48EA-B256-E1A44B134D4E}"), UserId = "6F110D05-8EED-483B-B2FB-0D5FF1601809", Position = "Consultant", IsEnabled = true },
            new Member { Id = Guid.Parse("{0724349D-D0B5-4606-BCC7-991B06605BED}"), TenantId = Guid.Parse("{D55A75A9-2F99-48EA-B256-E1A44B134D4E}"), UserId = "B3B8EFA5-632C-4027-9D16-9703EE09BC92", Position = "Project Manager", IsEnabled = true }
        );
    }
}
