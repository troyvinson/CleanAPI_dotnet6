using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class MemberConfiguration : IEntityTypeConfiguration<Member>
{
    public void Configure(EntityTypeBuilder<Member> builder)
    {
        builder.HasQueryFilter(m => m.IsEnabled);
        builder.HasQueryFilter(m => !m.IsDeleted);
        builder.HasQueryFilter(u => !u.User!.IsDeleted);

        builder.HasData
        (
            new Member { Id = Guid.Parse("{1510ED1D-317C-4E81-900B-869FF32795B3}"), TenantId = Guid.Parse("{0AAA2440-01FE-451C-BCD9-CA6CBC876A3A}"), UserId = "0B151F5A-8029-4BED-B0C3-EE389BE7F820", Position = "Manager" },
            new Member { Id = Guid.Parse("{81A07A01-90D3-4100-B952-20AC0A6428A7}"), TenantId = Guid.Parse("{0AAA2440-01FE-451C-BCD9-CA6CBC876A3A}"), UserId = "B2B0AFA2-9253-44D6-B678-A2E554ADB696", Position = "Assistant Manager" },
            new Member { Id = Guid.Parse("{7F96C51D-2A89-42BD-8C67-86399C12C672}"), TenantId = Guid.Parse("{0AAA2440-01FE-451C-BCD9-CA6CBC876A3A}"), UserId = "E8C4BADB-3D2A-44BE-9479-254CC62660C9", Position = "Supervisor" },
            new Member { Id = Guid.Parse("{C2FBA861-CF6A-49E0-B393-4EB01FA08FE7}"), TenantId = Guid.Parse("{0AAA2440-01FE-451C-BCD9-CA6CBC876A3A}"), UserId = "7DE9AD64-486E-41C2-8FA2-EB3248CCF28F", Position = "Associate" },
            new Member { Id = Guid.Parse("{678F7712-4D04-4CC0-BBCC-8D67767B165E}"), TenantId = Guid.Parse("{0AAA2440-01FE-451C-BCD9-CA6CBC876A3A}"), UserId = "ECDD09D1-298B-456F-BADF-B4358AF3A08E", Position = "Team Lead" },
            new Member { Id = Guid.Parse("{FC115211-A273-49A8-A955-BC9900D41ACC}"), TenantId = Guid.Parse("{0AAA2440-01FE-451C-BCD9-CA6CBC876A3A}"), UserId = "B5E64E97-7D3B-4338-ADD0-EAD00E4959C2", Position = "Senior Associate" },
            new Member { Id = Guid.Parse("{D88A4DE2-FE96-4825-8DA4-D9EEBD9ECEB3}"), TenantId = Guid.Parse("{0AAA2440-01FE-451C-BCD9-CA6CBC876A3A}"), UserId = "27074358-129C-40AA-9F02-7E1646F1D9AF", Position = "Trainer" },
            new Member { Id = Guid.Parse("{54CB4C6A-017A-4FB5-9A16-6770BBDB6CE1}"), TenantId = Guid.Parse("{5217A17E-FFFF-4FBC-AA1B-29175AB98F69}"), UserId = "4D2FA6AA-4921-43BF-8578-A355B14BBD63", Position = "Quality Assurance" },
            new Member { Id = Guid.Parse("{53398A73-8B13-4CA6-803D-3C74B0DAD959}"), TenantId = Guid.Parse("{5217A17E-FFFF-4FBC-AA1B-29175AB98F69}"), UserId = "27074358-129C-40AA-9F02-7E1646F1D9AF", Position = "Consultant" },
            new Member { Id = Guid.Parse("{E8D32F9E-BB43-4551-9C11-E481B98EB00F}"), TenantId = Guid.Parse("{5217A17E-FFFF-4FBC-AA1B-29175AB98F69}"), UserId = "4D2FA6AA-4921-43BF-8578-A355B14BBD63", Position = "Project Manager" }

        );
    }
}
