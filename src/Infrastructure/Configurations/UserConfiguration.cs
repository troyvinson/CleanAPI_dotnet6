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
            new User { Id = 1, GivenName = "John", Surname = "Doe", Username = "johndoe", Email = "johndoe@example.com", PhoneNumber = "555-111-1111" },
            new User { Id = 2, GivenName = "Jane", Surname = "Smith", Username = "janesmith", Email = "janesmith@example.com", PhoneNumber = "555-222-2222" },
            new User { Id = 3, GivenName = "Michael", Surname = "Johnson", Username = "michaelj", Email = "michaelj@example.com", PhoneNumber = "555-333-3333" },
            new User { Id = 4, GivenName = "Emily", Surname = "Williams", Username = "emilyw", Email = "emilyw@example.com", PhoneNumber = "555-444-4444" },
            new User { Id = 5, GivenName = "Daniel", Surname = "Brown", Username = "danielb", Email = "danielb@example.com", PhoneNumber = "555-555-5555" },
            new User { Id = 6, GivenName = "Olivia", Surname = "Jones", Username = "oliviaj", Email = "oliviaj@example.com", PhoneNumber = "555-666-6666" },
            new User { Id = 7, GivenName = "David", Surname = "Miller", Username = "davidm", Email = "davidm@example.com", PhoneNumber = "555-777-7777" },
            new User { Id = 8, GivenName = "Sophia", Surname = "Davis", Username = "sophiad", Email = "sophiad@example.com", PhoneNumber = "555-888-8888" },
            new User { Id = 9, GivenName = "James", Surname = "Wilson", Username = "jamesw", Email = "jamesw@example.com", PhoneNumber = "555-999-9999" },
            new User { Id = 10, GivenName = "Emma", Surname = "Taylor", Username = "emmat", Email = "emmat@example.com", PhoneNumber = "555-000-0000" },
            new User { Id = 11, GivenName = "Benjamin", Surname = "Anderson", Username = "benjamina", Email = "benjamina@example.com", PhoneNumber = "555-111-1111" },
            new User { Id = 12, GivenName = "Ava", Surname = "Martinez", Username = "avam", Email = "avam@example.com", PhoneNumber = "555-222-2222" },
            new User { Id = 13, GivenName = "William", Surname = "Thomas", Username = "williamt", Email = "williamt@example.com", PhoneNumber = "555-333-3333" },
            new User { Id = 14, GivenName = "Mia", Surname = "White", Username = "miaw", Email = "miaw@example.com", PhoneNumber = "555-444-4444" },
            new User { Id = 15, GivenName = "Alexander", Surname = "Lee", Username = "alexanderl", Email = "alexanderl@example.com", PhoneNumber = "555-555-5555" },
            new User { Id = 17, GivenName = "Ethan", Surname = "Clark", Username = "ethanc", Email = "ethanc@example.com", PhoneNumber = "555-777-7777" },
            new User { Id = 18, GivenName = "Charlotte", Surname = "Lewis", Username = "charlottel", Email = "charlottel@example.com", PhoneNumber = "555-888-8888" },
            new User { Id = 19, GivenName = "Daniel", Surname = "Young", Username = "daniely", Email = "daniely@example.com", PhoneNumber = "555-999-9999" },
            new User { Id = 20, GivenName = "Madison", Surname = "Walker", Username = "madisonw", Email = "madisonw@example.com", PhoneNumber = "555-000-0000" },
            new User { Id = 21, GivenName = "Logan", Surname = "Green", Username = "logang", Email = "logang@example.com", PhoneNumber = "555-111-1111" },
            new User { Id = 22, GivenName = "Grace", Surname = "Allen", Username = "gracea", Email = "gracea@example.com", PhoneNumber = "555-222-2222" },
            new User { Id = 23, GivenName = "Samuel", Surname = "Carter", Username = "samuelc", Email = "samuelc@example.com", PhoneNumber = "555-333-3333" },
            new User { Id = 24, GivenName = "Lily", Surname = "Adams", Username = "lilya", Email = "lilya@example.com", PhoneNumber = "555-444-4444" },
            new User { Id = 25, GivenName = "Ryan", Surname = "Hall", Username = "ryanh", Email = "ryanh@example.com", PhoneNumber = "555-555-5555" },
            new User { Id = 26, GivenName = "Chloe", Surname = "Baker", Username = "chloeb", Email = "chloeb@example.com", PhoneNumber = "555-666-6666" },
            new User { Id = 27, GivenName = "Isaac", Surname = "Rivera", Username = "isaacr", Email = "isaacr@example.com", PhoneNumber = "555-777-7777" },
            new User { Id = 28, GivenName = "Zoe", Surname = "Mitchell", Username = "zoem", Email = "zoem@example.com", PhoneNumber = "555-888-8888" },
            new User { Id = 29, GivenName = "Jackson", Surname = "Turner", Username = "jacksont", Email = "jacksont@example.com", PhoneNumber = "555-999-9999" },
            new User { Id = 30, GivenName = "Penelope", Surname = "Lopez", Username = "penelopel", Email = "penelopel@example.com", PhoneNumber = "555-000-0000" },
            new User { Id = 31, GivenName = "Gabriel", Surname = "Wright", Username = "gabrielw", Email = "gabrielw@example.com", PhoneNumber = "555-111-1111" },
            new User { Id = 33, GivenName = "Carter", Surname = "Harris", Username = "carterh", Email = "carterh@example.com", PhoneNumber = "555-222-2222" },
            new User { Id = 34, GivenName = "Henry", Surname = "King", Username = "henryk", Email = "henryk@example.com", PhoneNumber = "555-333-3333" },
            new User { Id = 35, GivenName = "Ella", Surname = "Ward", Username = "ellaw", Email = "ellaw@example.com", PhoneNumber = "555-444-4444" },
            new User { Id = 36, GivenName = "Sebastian", Surname = "Parker", Username = "sebastianp", Email = "sebastianp@example.com", PhoneNumber = "555-555-5555" },
            new User { Id = 37, GivenName = "Avery", Surname = "Bell", Username = "averyb", Email = "averyb@example.com", PhoneNumber = "555-666-6666" },
            new User { Id = 38, GivenName = "Mason", Surname = "Cook", Username = "masonc", Email = "masonc@example.com", PhoneNumber = "555-777-7777" },
            new User { Id = 39, GivenName = "Scarlett", Surname = "Price", Username = "scarlettp", Email = "scarlettp@example.com", PhoneNumber = "555-888-8888" },
            new User { Id = 40, GivenName = "Liam", Surname = "Bennett", Username = "liamb", Email = "liamb@example.com", PhoneNumber = "555-999-9999" },
            new User { Id = 41, GivenName = "Aria", Surname = "Wood", Username = "ariaw", Email = "ariaw@example.com", PhoneNumber = "555-000-0000" },
            new User { Id = 42, GivenName = "Grayson", Surname = "Phillips", Username = "graysonp", Email = "graysonp@example.com", PhoneNumber = "555-111-1111" },
            new User { Id = 43, GivenName = "Luna", Surname = "Evans", Username = "lunae", Email = "lunae@example.com", PhoneNumber = "555-222-2222" },
            new User { Id = 44, GivenName = "Luke", Surname = "Russell", Username = "luker", Email = "luker@example.com", PhoneNumber = "555-333-3333" },
            new User { Id = 45, GivenName = "Aiden", Surname = "Barnes", Username = "aidenb", Email = "aidenb@example.com", PhoneNumber = "555-444-4444" },
            new User { Id = 46, GivenName = "Layla", Surname = "Long", Username = "laylal", Email = "laylal@example.com", PhoneNumber = "555-555-5555" },
            new User { Id = 47, GivenName = "Oliver", Surname = "Flores", Username = "oliverf", Email = "oliverf@example.com", PhoneNumber = "555-666-6666" },
            new User { Id = 49, GivenName = "Wyatt", Surname = "Morris", Username = "wyattm", Email = "wyattm@example.com", PhoneNumber = "555-777-7777" },
            new User { Id = 50, GivenName = "Nora", Surname = "Simmons", Username = "noras", Email = "noras@example.com", PhoneNumber = "555-888-8888" },
            new User { Id = 51, GivenName = "Caleb", Surname = "Foster", Username = "calebf", Email = "calebf@example.com", PhoneNumber = "555-999-9999" },
            new User { Id = 52, GivenName = "Violet", Surname = "Gonzalez", Username = "violetg", Email = "violetg@example.com", PhoneNumber = "555-000-0000" },
            new User { Id = 53, GivenName = "Gabriel", Surname = "Butler", Username = "gabrielb", Email = "gabrielb@example.com", PhoneNumber = "555-111-1111" },
            new User { Id = 54, GivenName = "Stella", Surname = "Hill", Username = "stellah", Email = "stellah@example.com", PhoneNumber = "555-222-2222" },
            new User { Id = 55, GivenName = "Adrian", Surname = "Bryant", Username = "adrianb", Email = "adrianb@example.com", PhoneNumber = "555-333-3333" },
            new User { Id = 56, GivenName = "Genesis", Surname = "Hayes", Username = "genesish", Email = "genesish@example.com", PhoneNumber = "555-444-4444" },
            new User { Id = 57, GivenName = "Leo", Surname = "Coleman", Username = "leoc", Email = "leoc@example.com", PhoneNumber = "555-555-5555" },
            new User { Id = 58, GivenName = "Zara", Surname = "Wells", Username = "zaraw", Email = "zaraw@example.com", PhoneNumber = "555-666-6666" },
            new User { Id = 59, GivenName = "Easton", Surname = "Price", Username = "eastonp", Email = "eastonp@example.com", PhoneNumber = "555-777-7777" },
            new User { Id = 60, GivenName = "Bella", Surname = "Fisher", Username = "bellaf", Email = "bellaf@example.com", PhoneNumber = "555-888-8888" },
            new User { Id = 61, GivenName = "Nathan", Surname = "Bishop", Username = "nathanb", Email = "nathanb@example.com", PhoneNumber = "555-999-9999" },
            new User { Id = 62, GivenName = "Aaliyah", Surname = "Montgomery", Username = "aaliyahm", Email = "aaliyahm@example.com", PhoneNumber = "555-000-0000" },
            new User { Id = 63, GivenName = "Josiah", Surname = "Rose", Username = "josiahr", Email = "josiahr@example.com", PhoneNumber = "555-111-1111" },
            new User { Id = 65, GivenName = "Ian", Surname = "Hudson", Username = "ianh", Email = "ianh@example.com", PhoneNumber = "555-222-2222" },
            new User { Id = 66, GivenName = "Delilah", Surname = "Wagner", Username = "delilahw", Email = "delilahw@example.com", PhoneNumber = "555-333-3333" },
            new User { Id = 67, GivenName = "Jaxon", Surname = "Carroll", Username = "jaxonc", Email = "jaxonc@example.com", PhoneNumber = "555-444-4444" },
            new User { Id = 68, GivenName = "Emilia", Surname = "Cole", Username = "emiliac", Email = "emiliac@example.com", PhoneNumber = "555-555-5555" },
            new User { Id = 69, GivenName = "Brody", Surname = "Howell", Username = "brodyh", Email = "brodyh@example.com", PhoneNumber = "555-666-6666" },
            new User { Id = 70, GivenName = "Athena", Surname = "Johnston", Username = "athenaj", Email = "athenaj@example.com", PhoneNumber = "555-777-7777" },
            new User { Id = 71, GivenName = "Ryder", Surname = "Ray", Username = "ryderr", Email = "ryderr@example.com", PhoneNumber = "555-888-8888" },
            new User { Id = 72, GivenName = "Clara", Surname = "Sullivan", Username = "claras", Email = "claras@example.com", PhoneNumber = "555-999-9999" },
            new User { Id = 73, GivenName = "Asher", Surname = "Porter", Username = "asherp", Email = "asherp@example.com", PhoneNumber = "555-000-0000" },
            new User { Id = 74, GivenName = "Lillian", Surname = "Cruz", Username = "lillianc", Email = "lillianc@example.com", PhoneNumber = "555-111-1111" },
            new User { Id = 75, GivenName = "Hudson", Surname = "Griffin", Username = "hudsong", Email = "hudsong@example.com", PhoneNumber = "555-222-2222" },
            new User { Id = 76, GivenName = "Eleanor", Surname = "Harris", Username = "eleanorh", Email = "eleanorh@example.com", PhoneNumber = "555-333-3333" },
            new User { Id = 77, GivenName = "Christopher", Surname = "Ross", Username = "christopherr", Email = "christopherr@example.com", PhoneNumber = "555-444-4444" },
            new User { Id = 78, GivenName = "Maya", Surname = "Peterson", Username = "mayap", Email = "mayap@example.com", PhoneNumber = "555-555-5555" },
            new User { Id = 79, GivenName = "Muhammad", Surname = "Graham", Username = "muhammadg", Email = "muhammadg@example.com", PhoneNumber = "555-666-6666" }
        );
    }
}
