using Infrastructure.Configurations.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasQueryFilter(SoftDeleteExpression.CreateFilterExpression(typeof(User)));

        builder.HasData
        (
            new User { Id = Guid.Parse("{0B151F5A-8029-4BED-B0C3-EE389BE7F820}"), GivenName = "John", Surname = "Doe", Username = "johndoe", Email = "johndoe@example.com", PhoneNumber = "555-111-1111" },
            new User { Id = Guid.Parse("{B2B0AFA2-9253-44D6-B678-A2E554ADB696}"), GivenName = "Jane", Surname = "Smith", Username = "janesmith", Email = "janesmith@example.com", PhoneNumber = "555-222-2222" },
            new User { Id = Guid.Parse("{E8C4BADB-3D2A-44BE-9479-254CC62660C9}"), GivenName = "Michael", Surname = "Johnson", Username = "michaelj", Email = "michaelj@example.com", PhoneNumber = "555-333-3333" },
            new User { Id = Guid.Parse("{7DE9AD64-486E-41C2-8FA2-EB3248CCF28F}"), GivenName = "Emily", Surname = "Williams", Username = "emilyw", Email = "emilyw@example.com", PhoneNumber = "555-444-4444" },
            new User { Id = Guid.Parse("{ECDD09D1-298B-456F-BADF-B4358AF3A08E}"), GivenName = "Daniel", Surname = "Brown", Username = "danielb", Email = "danielb@example.com", PhoneNumber = "555-555-5555" },
            new User { Id = Guid.Parse("{B5E64E97-7D3B-4338-ADD0-EAD00E4959C2}"), GivenName = "Olivia", Surname = "Jones", Username = "oliviaj", Email = "oliviaj@example.com", PhoneNumber = "555-666-6666" },
            new User { Id = Guid.Parse("{27074358-129C-40AA-9F02-7E1646F1D9AF}"), GivenName = "David", Surname = "Miller", Username = "davidm", Email = "davidm@example.com", PhoneNumber = "555-777-7777" },
            new User { Id = Guid.Parse("{4D2FA6AA-4921-43BF-8578-A355B14BBD63}"), GivenName = "Sophia", Surname = "Davis", Username = "sophiad", Email = "sophiad@example.com", PhoneNumber = "555-888-8888" }
        );
    }
}
