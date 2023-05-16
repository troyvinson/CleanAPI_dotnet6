﻿// <auto-generated />
using System;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataMigrations.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    partial class RepositoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Member", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTime>("DateJoined")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("UpdatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("TenantId");

                    b.HasIndex("UserId");

                    b.ToTable("Member");
                });

            modelBuilder.Entity("Domain.Entities.Tenant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("UpdatedDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.ToTable("Tenant");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset>("UpdatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "BCB1F1CF-3072-49D4-BC96-72859E6F0F08",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "b7a96d37-c454-4194-9909-8f087882c16a",
                            CreatedDate = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Email = "johndoe@example.com",
                            EmailConfirmed = false,
                            FirstName = "John",
                            IsDeleted = false,
                            LastName = "Doe",
                            LockoutEnabled = false,
                            PhoneNumber = "555-111-1111",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "3b98bf5e-614f-4715-99eb-29b85a8fd8cd",
                            TwoFactorEnabled = false,
                            UpdatedDate = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            UserName = "johndoe"
                        },
                        new
                        {
                            Id = "33BCFBF7-EDFC-4F7A-8224-9802519D299D",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "236876a4-f8d6-4b1c-ba54-efe146c8eeea",
                            CreatedDate = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Email = "janesmith@example.com",
                            EmailConfirmed = false,
                            FirstName = "Jane",
                            IsDeleted = false,
                            LastName = "Smith",
                            LockoutEnabled = false,
                            PhoneNumber = "555-222-2222",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "d5167ec8-dcf7-4fab-812b-ac47e7a311c4",
                            TwoFactorEnabled = false,
                            UpdatedDate = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            UserName = "janesmith"
                        },
                        new
                        {
                            Id = "A1A68798-B47F-4653-B37D-D2C4FF37FE9D",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "008026c8-e078-481d-bea9-a1aec7455009",
                            CreatedDate = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Email = "michaelj@example.com",
                            EmailConfirmed = false,
                            FirstName = "Michael",
                            IsDeleted = false,
                            LastName = "Johnson",
                            LockoutEnabled = false,
                            PhoneNumber = "555-333-3333",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "031617df-3062-49e3-bea6-37f5b153f002",
                            TwoFactorEnabled = false,
                            UpdatedDate = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            UserName = "michaelj"
                        },
                        new
                        {
                            Id = "FF971359-568F-4CCF-8F62-194AAE51C745",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "de847a46-23ed-43da-8579-c16b5daf63cf",
                            CreatedDate = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Email = "emilyw@example.com",
                            EmailConfirmed = false,
                            FirstName = "Emily",
                            IsDeleted = false,
                            LastName = "Williams",
                            LockoutEnabled = false,
                            PhoneNumber = "555-444-4444",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "53c6ef13-00bd-405d-a796-0b0eba013d7e",
                            TwoFactorEnabled = false,
                            UpdatedDate = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            UserName = "emilyw"
                        },
                        new
                        {
                            Id = "87C317FA-EED0-4E6F-A49F-29D73539D9DE",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "8cf38674-aa80-481f-ab58-41fc43682818",
                            CreatedDate = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Email = "danielb@example.com",
                            EmailConfirmed = false,
                            FirstName = "Daniel",
                            IsDeleted = false,
                            LastName = "Brown",
                            LockoutEnabled = false,
                            PhoneNumber = "555-555-5555",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "edb6e487-79cc-49b1-8334-523c477572fe",
                            TwoFactorEnabled = false,
                            UpdatedDate = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            UserName = "danielb"
                        },
                        new
                        {
                            Id = "A54FF230-6063-42BD-A37B-457D579B2544",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "1c29a9b5-659c-4b8b-a676-0bb879898181",
                            CreatedDate = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Email = "oliviaj@example.com",
                            EmailConfirmed = false,
                            FirstName = "Olivia",
                            IsDeleted = false,
                            LastName = "Jones",
                            LockoutEnabled = false,
                            PhoneNumber = "555-666-6666",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "86bda8f2-2b29-409e-a6b5-b30d561404ed",
                            TwoFactorEnabled = false,
                            UpdatedDate = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            UserName = "oliviaj"
                        },
                        new
                        {
                            Id = "A62A61E1-419D-4C80-BA81-E6DDCCC50B1C",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "441b9232-9ea2-4b90-aabe-2fae6cf043db",
                            CreatedDate = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Email = "davidm@example.com",
                            EmailConfirmed = false,
                            FirstName = "David",
                            IsDeleted = false,
                            LastName = "Miller",
                            LockoutEnabled = false,
                            PhoneNumber = "555-777-7777",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "2cb44711-f0aa-4179-946b-7e7f50ada789",
                            TwoFactorEnabled = false,
                            UpdatedDate = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            UserName = "davidm"
                        },
                        new
                        {
                            Id = "6F110D05-8EED-483B-B2FB-0D5FF1601809",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "78481d54-4e5e-43ec-b673-028151f544e7",
                            CreatedDate = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Email = "sophiad@example.com",
                            EmailConfirmed = false,
                            FirstName = "Sophia",
                            IsDeleted = false,
                            LastName = "Davis",
                            LockoutEnabled = false,
                            PhoneNumber = "555-888-8888",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "1fb24743-b36a-4533-b347-a38903aa1060",
                            TwoFactorEnabled = false,
                            UpdatedDate = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            UserName = "sophiad"
                        },
                        new
                        {
                            Id = "B3B8EFA5-632C-4027-9D16-9703EE09BC92",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "b2ccf4a5-0509-4842-acec-e7a6159f0ed3",
                            CreatedDate = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Email = "jamesw@example.com",
                            EmailConfirmed = false,
                            FirstName = "James",
                            IsDeleted = false,
                            LastName = "Wilson",
                            LockoutEnabled = false,
                            PhoneNumber = "555-999-9999",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "fbe4a1f4-4347-48fb-a087-a70a65333e3d",
                            TwoFactorEnabled = false,
                            UpdatedDate = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            UserName = "jamesw"
                        },
                        new
                        {
                            Id = "28279BE8-C3F4-451A-82FE-C11828C6AA1D",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "9835e4a1-d875-4654-ab13-7813cf0a3eec",
                            CreatedDate = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Email = "emmat@example.com",
                            EmailConfirmed = false,
                            FirstName = "Emma",
                            IsDeleted = false,
                            LastName = "Taylor",
                            LockoutEnabled = false,
                            PhoneNumber = "555-000-0000",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "13def0a3-b7bc-4841-a286-f221eb562073",
                            TwoFactorEnabled = false,
                            UpdatedDate = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            UserName = "emmat"
                        },
                        new
                        {
                            Id = "557D1752-0B6A-4FFA-B939-29A57EAA0E91",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "0dff70a6-76e1-43d1-a178-4fc66145e22c",
                            CreatedDate = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Email = "benjamina@example.com",
                            EmailConfirmed = false,
                            FirstName = "Benjamin",
                            IsDeleted = false,
                            LastName = "Anderson",
                            LockoutEnabled = false,
                            PhoneNumber = "555-111-1111",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "94fb5d81-f22f-449a-b662-f03832463a0f",
                            TwoFactorEnabled = false,
                            UpdatedDate = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            UserName = "benjamina"
                        },
                        new
                        {
                            Id = "BDDFCAEC-E23E-4D61-8A02-0A1F75D40240",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "e0d96f2d-a814-4205-a2ef-333372085c13",
                            CreatedDate = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Email = "avam@example.com",
                            EmailConfirmed = false,
                            FirstName = "Ava",
                            IsDeleted = false,
                            LastName = "Martinez",
                            LockoutEnabled = false,
                            PhoneNumber = "555-222-2222",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "794e5e3f-c71e-4c9b-be1f-5a0df09c1a1d",
                            TwoFactorEnabled = false,
                            UpdatedDate = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            UserName = "avam"
                        },
                        new
                        {
                            Id = "8D5F0776-AC3C-4C33-9EF1-FA9DC2933972",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "f5400431-22cd-4546-87ce-cc69af25e5e3",
                            CreatedDate = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Email = "williamt@example.com",
                            EmailConfirmed = false,
                            FirstName = "William",
                            IsDeleted = false,
                            LastName = "Thomas",
                            LockoutEnabled = false,
                            PhoneNumber = "555-333-3333",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "bca8ebda-736b-4e50-9438-6416771446b1",
                            TwoFactorEnabled = false,
                            UpdatedDate = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            UserName = "williamt"
                        },
                        new
                        {
                            Id = "F476A298-9040-4F68-86A2-FB6F94258190",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "1e38178e-6f30-4954-8702-0de3f86ba9be",
                            CreatedDate = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Email = "miaw@example.com",
                            EmailConfirmed = false,
                            FirstName = "Mia",
                            IsDeleted = false,
                            LastName = "White",
                            LockoutEnabled = false,
                            PhoneNumber = "555-444-4444",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "efab69fe-5299-4f71-ae1a-b6a45596002e",
                            TwoFactorEnabled = false,
                            UpdatedDate = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            UserName = "miaw"
                        },
                        new
                        {
                            Id = "3DFA5AEA-7D68-4BB2-B221-DA563E0ED646",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "07ff02e7-9814-46ca-9405-14b50fd5aee2",
                            CreatedDate = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Email = "alexanderl@example.com",
                            EmailConfirmed = false,
                            FirstName = "Alexander",
                            IsDeleted = false,
                            LastName = "Lee",
                            LockoutEnabled = false,
                            PhoneNumber = "555-555-5555",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "bc701c58-9dc0-435a-a0a9-01be2178a790",
                            TwoFactorEnabled = false,
                            UpdatedDate = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            UserName = "alexanderl"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "0355f514-67e7-42b2-96f3-196b9f9a6f67",
                            ConcurrencyStamp = "88b5412d-27cf-4c19-af94-817c9b575980",
                            Name = "User",
                            NormalizedName = "USER"
                        },
                        new
                        {
                            Id = "7e7d5a1d-89e3-4f85-9327-78b156822ffc",
                            ConcurrencyStamp = "34eae145-54b5-4f69-a42d-67cb6e060c4b",
                            Name = "Contributor",
                            NormalizedName = "CONTRIBUTOR"
                        },
                        new
                        {
                            Id = "f244e5da-e181-4781-9ec8-7a1e3e23b962",
                            ConcurrencyStamp = "65ec33b5-94aa-4c32-97d9-f28c925de7fd",
                            Name = "Editor",
                            NormalizedName = "EDITOR"
                        },
                        new
                        {
                            Id = "ed41285c-79ec-4db1-ab29-ab11758ea54a",
                            ConcurrencyStamp = "2e20d4ee-2c0d-481c-96de-653edd9f1625",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = "7d8153a4-96c2-40bc-b973-10818c3262a1",
                            ConcurrencyStamp = "11a527fa-431d-4ddf-90bc-f2487e5e7781",
                            Name = "SuperAdmin",
                            NormalizedName = "SUPERADMIN"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Member", b =>
                {
                    b.HasOne("Domain.Entities.Tenant", "Tenant")
                        .WithMany("Members")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("Memberships")
                        .HasForeignKey("UserId");

                    b.Navigation("Tenant");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Tenant", b =>
                {
                    b.Navigation("Members");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Navigation("Memberships");
                });
#pragma warning restore 612, 618
        }
    }
}
