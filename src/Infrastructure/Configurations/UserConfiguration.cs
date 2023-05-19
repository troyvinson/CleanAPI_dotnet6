using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasQueryFilter(u => !u.IsDeleted);

        var hasher = new PasswordHasher<User>();

        builder.HasData(
            new User
            {
                Id = "0B151F5A-8029-4BED-B0C3-EE389BE7F820",
                PasswordHash = hasher.HashPassword(null!, "Pa$$w0rd"),
                GivenName = "John",
                Surname = "Doe",
                NormalizedName = "JOHN DOE".Normalize(),
                UserName = "johndoe",
                NormalizedUserName = "johndoe".Normalize(),
                Email = "johndoe@example.com",
                NormalizedEmail = "johndoe@example.com".Normalize(),
                PhoneNumber = "555-111-1111"
            },
            new User
            {
                Id = "B2B0AFA2-9253-44D6-B678-A2E554ADB696",
                PasswordHash = hasher.HashPassword(null!, "Pa$$w0rd"),
                GivenName = "Jane",
                Surname = "Smith",
                NormalizedName = "JANE SMITH".Normalize(),
                UserName = "janesmith",
                NormalizedUserName = "janesmith".Normalize(),
                Email = "janesmith@example.com",
                NormalizedEmail = "janesmith@example.com",
                PhoneNumber = "555-222-2222"
            },
            new User
            {
                Id = "E8C4BADB-3D2A-44BE-9479-254CC62660C9",
                PasswordHash = hasher.HashPassword(null!, "Pa$$w0rd"),
                GivenName = "Michael",
                Surname = "Johnson",
                NormalizedName = "MICHAEL JOHNSON".Normalize(),
                UserName = "michaelj",
                NormalizedUserName = "michaelj".Normalize(),
                Email = "michaelj@example.com",
                NormalizedEmail = "michaelj@example.com".Normalize(),
                PhoneNumber = "555-333-3333"
            },
            new User
            {
                Id = "7DE9AD64-486E-41C2-8FA2-EB3248CCF28F",
                PasswordHash = hasher.HashPassword(null!, "Pa$$w0rd"),
                GivenName = "Emily",
                Surname = "Williams",
                NormalizedName = "EMILY WILLIAMS".Normalize(),
                UserName = "emilyw",
                NormalizedUserName = "emilyw".Normalize(),
                Email = "emilyw@example.com",
                NormalizedEmail = "emilyw@example.com",
                PhoneNumber = "555-444-4444"
            },
            new User
            {
                Id = "ECDD09D1-298B-456F-BADF-B4358AF3A08E",
                PasswordHash = hasher.HashPassword(null!, "Pa$$w0rd"),
                GivenName = "Daniel",
                Surname = "Brown",
                NormalizedName = "DANIEL BROWN".Normalize(),
                UserName = "danielb",
                NormalizedUserName = "danielb".Normalize(),
                Email = "danielb@example.com",
                NormalizedEmail = "danielb@example.com".Normalize(),
                PhoneNumber = "555-555-5555"
            },
            new User
            {
                Id = "B5E64E97-7D3B-4338-ADD0-EAD00E4959C2",
                PasswordHash = hasher.HashPassword(null!, "Pa$$w0rd"),
                GivenName = "Olivia",
                Surname = "Jones",
                NormalizedName = "OLIVIA JONES".Normalize(),
                UserName = "oliviaj",
                NormalizedUserName = "oliviaj".Normalize(),
                Email = "oliviaj@example.com",
                NormalizedEmail = "oliviaj@example.com".Normalize(),
                PhoneNumber = "555-666-6666"
            },
            new User
            {
                Id = "27074358-129C-40AA-9F02-7E1646F1D9AF",
                PasswordHash = hasher.HashPassword(null!, "Pa$$w0rd"),
                GivenName = "David",
                Surname = "Miller",
                NormalizedName = "DAVID MILLER".Normalize(),
                UserName = "davidm",
                NormalizedUserName = "davidm".Normalize(),
                Email = "davidm@example.com",
                NormalizedEmail = "davidm@example.com".Normalize(),
                PhoneNumber = "555-777-7777"
            },
            new User
            {
                Id = "4D2FA6AA-4921-43BF-8578-A355B14BBD63",
                PasswordHash = hasher.HashPassword(null!, "Pa$$w0rd"),
                GivenName = "Sophia",
                Surname = "Davis",
                NormalizedName = "SOPHIA DAVIS".Normalize(),
                UserName = "sophiad",
                NormalizedUserName = "sophiad".Normalize(),
                Email = "sophiad@example.com",
                NormalizedEmail = "sophiad@example.com".Normalize(),
                PhoneNumber = "555-888-8888"
            }
        );
    }
}
