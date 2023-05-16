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
            new User { Id = "BCB1F1CF-3072-49D4-BC96-72859E6F0F08", FirstName = "John", LastName = "Doe", UserName = "johndoe", Email = "johndoe@example.com", PhoneNumber = "555-111-1111" },
            new User { Id = "33BCFBF7-EDFC-4F7A-8224-9802519D299D", FirstName = "Jane", LastName = "Smith", UserName = "janesmith", Email = "janesmith@example.com", PhoneNumber = "555-222-2222" },
            new User { Id = "A1A68798-B47F-4653-B37D-D2C4FF37FE9D", FirstName = "Michael", LastName = "Johnson", UserName = "michaelj", Email = "michaelj@example.com", PhoneNumber = "555-333-3333" },
            new User { Id = "FF971359-568F-4CCF-8F62-194AAE51C745", FirstName = "Emily", LastName = "Williams", UserName = "emilyw", Email = "emilyw@example.com", PhoneNumber = "555-444-4444" },
            new User { Id = "87C317FA-EED0-4E6F-A49F-29D73539D9DE", FirstName = "Daniel", LastName = "Brown", UserName = "danielb", Email = "danielb@example.com", PhoneNumber = "555-555-5555" },
            new User { Id = "A54FF230-6063-42BD-A37B-457D579B2544", FirstName = "Olivia", LastName = "Jones", UserName = "oliviaj", Email = "oliviaj@example.com", PhoneNumber = "555-666-6666" },
            new User { Id = "A62A61E1-419D-4C80-BA81-E6DDCCC50B1C", FirstName = "David", LastName = "Miller", UserName = "davidm", Email = "davidm@example.com", PhoneNumber = "555-777-7777" },
            new User { Id = "6F110D05-8EED-483B-B2FB-0D5FF1601809", FirstName = "Sophia", LastName = "Davis", UserName = "sophiad", Email = "sophiad@example.com", PhoneNumber = "555-888-8888" },
            new User { Id = "B3B8EFA5-632C-4027-9D16-9703EE09BC92", FirstName = "James", LastName = "Wilson", UserName = "jamesw", Email = "jamesw@example.com", PhoneNumber = "555-999-9999" },
            new User { Id = "28279BE8-C3F4-451A-82FE-C11828C6AA1D", FirstName = "Emma", LastName = "Taylor", UserName = "emmat", Email = "emmat@example.com", PhoneNumber = "555-000-0000" },
            new User { Id = "557D1752-0B6A-4FFA-B939-29A57EAA0E91", FirstName = "Benjamin", LastName = "Anderson", UserName = "benjamina", Email = "benjamina@example.com", PhoneNumber = "555-111-1111" },
            new User { Id = "BDDFCAEC-E23E-4D61-8A02-0A1F75D40240", FirstName = "Ava", LastName = "Martinez", UserName = "avam", Email = "avam@example.com", PhoneNumber = "555-222-2222" },
            new User { Id = "8D5F0776-AC3C-4C33-9EF1-FA9DC2933972", FirstName = "William", LastName = "Thomas", UserName = "williamt", Email = "williamt@example.com", PhoneNumber = "555-333-3333" },
            new User { Id = "F476A298-9040-4F68-86A2-FB6F94258190", FirstName = "Mia", LastName = "White", UserName = "miaw", Email = "miaw@example.com", PhoneNumber = "555-444-4444" },
            new User { Id = "3DFA5AEA-7D68-4BB2-B221-DA563E0ED646", FirstName = "Alexander", LastName = "Lee", UserName = "alexanderl", Email = "alexanderl@example.com", PhoneNumber = "555-555-5555" }
        );
    }
}
