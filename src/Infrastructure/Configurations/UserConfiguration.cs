using Infrastructure.Configurations.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasQueryFilter(SoftDeleteExpression.CreateFilterExpression(typeof(User)));
        //builder.HasQueryFilter(u => !u.IsEnabled);

        builder.HasData
        (
            new User { Id =  1, GivenName = "John", Surname = "Doe", Username = "jdoe", Email = "jdoe@example.com", PhoneNumber = "555-555-5555" },
            new User { Id =  2, GivenName = "Jane", Surname = "Doe", Username = "jane_doe", Email = "jane_doe@example.com", PhoneNumber = "555-555-1234" },
            new User { Id =  3, GivenName = "Bob", Surname = "Smith", Username = "bob_smith", Email = "bob_smith@example.com", PhoneNumber = "555-555-6789" },
            new User { Id =  4, GivenName = "Samantha", Surname = "Lee", Username = "slee", Email = "slee@example.com", PhoneNumber = "555-555-9876" },
            new User { Id =  5, GivenName = "Tom", Surname = "Jones", Username = "tjones", Email = "tjones@example.com", PhoneNumber = "555-555-1111" },
            new User { Id =  6, GivenName = "Emily", Surname = "Wang", Username = "ewang", Email = "ewang@example.com", PhoneNumber = "555-555-2222" },
            new User { Id =  7, GivenName = "David", Surname = "Nguyen", Username = "dnguyen", Email = "dnguyen@example.com", PhoneNumber = "555-555-3333" },
            new User { Id =  8, GivenName = "Rachel", Surname = "Kim", Username = "rkim", Email = "rkim@example.com", PhoneNumber = "555-555-4444" },
            new User { Id =  9, GivenName = "Kevin", Surname = "Chen", Username = "kchen", Email = "kchen@example.com", PhoneNumber = "555-555-5555" },
            new User { Id = 10, GivenName = "Maria", Surname = "Garcia", Username = "mgarcia", Email = "mgarcia@example.com", PhoneNumber = "555-555-6666" },
            new User { Id = 11, GivenName = "Michael", Surname = "Brown", Username = "mbrown", Email = "mbrown@example.com", PhoneNumber = "555-555-7777" },
            new User { Id = 12, GivenName = "Alex", Surname = "Wilson", Username = "awilson", Email = "awilson@example.com", PhoneNumber = "555-555-8888" },
            new User { Id = 13, GivenName = "Olivia", Surname = "Smith", Username = "osmith", Email = "osmith@example.com", PhoneNumber = "555-555-9999" },
            new User { Id = 14, GivenName = "Noah", Surname = "Johnson", Username = "njohnson", Email = "njohnson@example.com", PhoneNumber = "555-555-0000" },
            new User { Id = 15, GivenName = "Isabella", Surname = "Davis", Username = "idavis", Email = "idavis@example.com", PhoneNumber = "555-555-1111" },
            new User { Id = 16, GivenName = "Ethan", Surname = "Martinez", Username = "emartinez", Email = "emartinez@example.com", PhoneNumber = "555-555-2222" },
            new User { Id = 17, GivenName = "Sophia", Surname = "Jones", Username = "sjones", Email = "sjones@example.com", PhoneNumber = "555-555-3333" },
            new User { Id = 18, GivenName = "Daniel", Surname = "Jackson", Username = "djackson", Email = "djackson@example.com", PhoneNumber = "555-555-4444" },
            new User { Id = 19, GivenName = "Ava", Surname = "Miller", Username = "amiller", Email = "amiller@example.com", PhoneNumber = "555-555-5555" },
            new User { Id = 20, GivenName = "Mason", Surname = "Garcia", Username = "mgarcia", Email = "mgarcia@example.com", PhoneNumber = "555-555-6666" },
            new User { Id = 21, GivenName = "Charlotte", Surname = "Brown", Username = "cbrown", Email = "cbrown@example.com", PhoneNumber = "555-555-7777" },
            new User { Id = 22, GivenName = "William", Surname = "Wilson", Username = "wwilson", Email = "wwilson@example.com", PhoneNumber = "555-555-8888" },
            new User { Id = 23, GivenName = "Amelia", Surname = "Smith", Username = "asmith", Email = "asmith@example.com", PhoneNumber = "555-555-9999" },
            new User { Id = 24, GivenName = "James", Surname = "Johnson", Username = "jjohnson", Email = "jjohnson@example.com", PhoneNumber = "555-555-0000" },
            new User { Id = 25, GivenName = "Evelyn", Surname = "Davis", Username = "edavis", Email = "edavis@example.com", PhoneNumber = "555-555-1111" },
            new User { Id = 26, GivenName = "Benjamin", Surname = "Martinez", Username = "bmartinez", Email = "bmartinez@example.com", PhoneNumber = "555-555-2222" },
            new User { Id = 27, GivenName = "Abigail", Surname = "Jones", Username = "ajones", Email = "ajones@example.com", PhoneNumber = "555-555-3333" },
            new User { Id = 28, GivenName = "Lucas", Surname = "Jackson", Username = "ljackson", Email = "ljackson@example.com", PhoneNumber = "555-555-4444" },
            new User { Id = 29, GivenName = "Chloe", Surname = "Miller", Username = "cmiller", Email = "cmiller@example.com", PhoneNumber = "555-555-5555" },
            new User { Id = 30, GivenName = "Alexander", Surname = "Garcia", Username = "agarcia", Email = "agarcia@example.com", PhoneNumber = "555-555-6666" }
        );
    }
}
