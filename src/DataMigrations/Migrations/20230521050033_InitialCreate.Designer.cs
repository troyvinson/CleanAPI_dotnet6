﻿// <auto-generated />
using System;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataMigrations.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20230521050033_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("DateJoined")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("UpdatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("TenantId");

                    b.HasIndex("UserId");

                    b.ToTable("Members");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1510ed1d-317c-4e81-900b-869ff32795b3"),
                            CreatedDate = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            DateJoined = new DateTimeOffset(new DateTime(2023, 5, 21, 5, 0, 32, 966, DateTimeKind.Unspecified).AddTicks(5090), new TimeSpan(0, 0, 0, 0, 0)),
                            IsDeleted = false,
                            IsEnabled = true,
                            Position = "Manager",
                            TenantId = new Guid("0aaa2440-01fe-451c-bcd9-ca6cbc876a3a"),
                            UpdatedDate = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            UserId = "0B151F5A-8029-4BED-B0C3-EE389BE7F820"
                        },
                        new
                        {
                            Id = new Guid("81a07a01-90d3-4100-b952-20ac0a6428a7"),
                            CreatedDate = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            DateJoined = new DateTimeOffset(new DateTime(2023, 5, 21, 5, 0, 32, 966, DateTimeKind.Unspecified).AddTicks(5096), new TimeSpan(0, 0, 0, 0, 0)),
                            IsDeleted = false,
                            IsEnabled = true,
                            Position = "Assistant Manager",
                            TenantId = new Guid("0aaa2440-01fe-451c-bcd9-ca6cbc876a3a"),
                            UpdatedDate = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            UserId = "B2B0AFA2-9253-44D6-B678-A2E554ADB696"
                        },
                        new
                        {
                            Id = new Guid("7f96c51d-2a89-42bd-8c67-86399c12c672"),
                            CreatedDate = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            DateJoined = new DateTimeOffset(new DateTime(2023, 5, 21, 5, 0, 32, 966, DateTimeKind.Unspecified).AddTicks(5139), new TimeSpan(0, 0, 0, 0, 0)),
                            IsDeleted = false,
                            IsEnabled = true,
                            Position = "Supervisor",
                            TenantId = new Guid("0aaa2440-01fe-451c-bcd9-ca6cbc876a3a"),
                            UpdatedDate = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            UserId = "E8C4BADB-3D2A-44BE-9479-254CC62660C9"
                        },
                        new
                        {
                            Id = new Guid("c2fba861-cf6a-49e0-b393-4eb01fa08fe7"),
                            CreatedDate = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            DateJoined = new DateTimeOffset(new DateTime(2023, 5, 21, 5, 0, 32, 966, DateTimeKind.Unspecified).AddTicks(5142), new TimeSpan(0, 0, 0, 0, 0)),
                            IsDeleted = false,
                            IsEnabled = true,
                            Position = "Associate",
                            TenantId = new Guid("0aaa2440-01fe-451c-bcd9-ca6cbc876a3a"),
                            UpdatedDate = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            UserId = "7DE9AD64-486E-41C2-8FA2-EB3248CCF28F"
                        },
                        new
                        {
                            Id = new Guid("678f7712-4d04-4cc0-bbcc-8d67767b165e"),
                            CreatedDate = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            DateJoined = new DateTimeOffset(new DateTime(2023, 5, 21, 5, 0, 32, 966, DateTimeKind.Unspecified).AddTicks(5144), new TimeSpan(0, 0, 0, 0, 0)),
                            IsDeleted = false,
                            IsEnabled = true,
                            Position = "Team Lead",
                            TenantId = new Guid("0aaa2440-01fe-451c-bcd9-ca6cbc876a3a"),
                            UpdatedDate = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            UserId = "ECDD09D1-298B-456F-BADF-B4358AF3A08E"
                        },
                        new
                        {
                            Id = new Guid("fc115211-a273-49a8-a955-bc9900d41acc"),
                            CreatedDate = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            DateJoined = new DateTimeOffset(new DateTime(2023, 5, 21, 5, 0, 32, 966, DateTimeKind.Unspecified).AddTicks(5146), new TimeSpan(0, 0, 0, 0, 0)),
                            IsDeleted = false,
                            IsEnabled = true,
                            Position = "Senior Associate",
                            TenantId = new Guid("0aaa2440-01fe-451c-bcd9-ca6cbc876a3a"),
                            UpdatedDate = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            UserId = "B5E64E97-7D3B-4338-ADD0-EAD00E4959C2"
                        },
                        new
                        {
                            Id = new Guid("d88a4de2-fe96-4825-8da4-d9eebd9eceb3"),
                            CreatedDate = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            DateJoined = new DateTimeOffset(new DateTime(2023, 5, 21, 5, 0, 32, 966, DateTimeKind.Unspecified).AddTicks(5148), new TimeSpan(0, 0, 0, 0, 0)),
                            IsDeleted = false,
                            IsEnabled = true,
                            Position = "Trainer",
                            TenantId = new Guid("0aaa2440-01fe-451c-bcd9-ca6cbc876a3a"),
                            UpdatedDate = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            UserId = "27074358-129C-40AA-9F02-7E1646F1D9AF"
                        },
                        new
                        {
                            Id = new Guid("54cb4c6a-017a-4fb5-9a16-6770bbdb6ce1"),
                            CreatedDate = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            DateJoined = new DateTimeOffset(new DateTime(2023, 5, 21, 5, 0, 32, 966, DateTimeKind.Unspecified).AddTicks(5150), new TimeSpan(0, 0, 0, 0, 0)),
                            IsDeleted = false,
                            IsEnabled = true,
                            Position = "Quality Assurance",
                            TenantId = new Guid("5217a17e-ffff-4fbc-aa1b-29175ab98f69"),
                            UpdatedDate = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            UserId = "4D2FA6AA-4921-43BF-8578-A355B14BBD63"
                        },
                        new
                        {
                            Id = new Guid("53398a73-8b13-4ca6-803d-3c74b0dad959"),
                            CreatedDate = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            DateJoined = new DateTimeOffset(new DateTime(2023, 5, 21, 5, 0, 32, 966, DateTimeKind.Unspecified).AddTicks(5153), new TimeSpan(0, 0, 0, 0, 0)),
                            IsDeleted = false,
                            IsEnabled = true,
                            Position = "Consultant",
                            TenantId = new Guid("5217a17e-ffff-4fbc-aa1b-29175ab98f69"),
                            UpdatedDate = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            UserId = "27074358-129C-40AA-9F02-7E1646F1D9AF"
                        },
                        new
                        {
                            Id = new Guid("e8d32f9e-bb43-4551-9c11-e481b98eb00f"),
                            CreatedDate = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            DateJoined = new DateTimeOffset(new DateTime(2023, 5, 21, 5, 0, 32, 966, DateTimeKind.Unspecified).AddTicks(5155), new TimeSpan(0, 0, 0, 0, 0)),
                            IsDeleted = false,
                            IsEnabled = true,
                            Position = "Project Manager",
                            TenantId = new Guid("5217a17e-ffff-4fbc-aa1b-29175ab98f69"),
                            UpdatedDate = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            UserId = "4D2FA6AA-4921-43BF-8578-A355B14BBD63"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Tenant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("UpdatedDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.ToTable("Tenants");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0aaa2440-01fe-451c-bcd9-ca6cbc876a3a"),
                            CreatedDate = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            IsDeleted = false,
                            IsEnabled = true,
                            Name = "NovellaTech",
                            UpdatedDate = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = new Guid("5217a17e-ffff-4fbc-aa1b-29175ab98f69"),
                            CreatedDate = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            IsDeleted = false,
                            IsEnabled = true,
                            Name = "VeloVentures",
                            UpdatedDate = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0))
                        });
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

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("GivenName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

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
                            Id = "0B151F5A-8029-4BED-B0C3-EE389BE7F820",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "2745527c-6fe0-4901-8194-9cac44484228",
                            Email = "johndoe@example.com",
                            EmailConfirmed = false,
                            GivenName = "John",
                            IsDeleted = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "johndoe@example.com",
                            NormalizedName = "JOHN DOE",
                            NormalizedUserName = "johndoe",
                            PasswordHash = "AQAAAAEAACcQAAAAEJuUM1V2lqAZsRX7SllfNEVtARVTrG1DGgvViVEQ+p8OJbpyW08P60ZFrZG4DwdJUQ==",
                            PhoneNumber = "555-111-1111",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "f8de8b4a-5e30-4175-8f92-4696ceee1635",
                            Surname = "Doe",
                            TwoFactorEnabled = false,
                            UserName = "johndoe"
                        },
                        new
                        {
                            Id = "B2B0AFA2-9253-44D6-B678-A2E554ADB696",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "5ff65696-5d8d-4d36-aefe-e428a756fc39",
                            Email = "janesmith@example.com",
                            EmailConfirmed = false,
                            GivenName = "Jane",
                            IsDeleted = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "janesmith@example.com",
                            NormalizedName = "JANE SMITH",
                            NormalizedUserName = "janesmith",
                            PasswordHash = "AQAAAAEAACcQAAAAELfJ/0l9zEYBzu91dUCHA6ooQLRDSjgWHnzn/ZdjGHO28B/reeZ1KfBiozmT6Ytuow==",
                            PhoneNumber = "555-222-2222",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "fb28a86f-e9e8-43e2-ab32-d5688a70461e",
                            Surname = "Smith",
                            TwoFactorEnabled = false,
                            UserName = "janesmith"
                        },
                        new
                        {
                            Id = "E8C4BADB-3D2A-44BE-9479-254CC62660C9",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "c7b8e41f-83bb-425c-bad1-ac88bf7368ca",
                            Email = "michaelj@example.com",
                            EmailConfirmed = false,
                            GivenName = "Michael",
                            IsDeleted = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "michaelj@example.com",
                            NormalizedName = "MICHAEL JOHNSON",
                            NormalizedUserName = "michaelj",
                            PasswordHash = "AQAAAAEAACcQAAAAEMe6C5YDwa6Pnf18zBtXOb1ARmgqdO5O9Zi2RzhJ9mcttaiN21GeUQpglMLUg+0YXw==",
                            PhoneNumber = "555-333-3333",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "e857cbd8-881f-416d-a8ce-42e2481f3899",
                            Surname = "Johnson",
                            TwoFactorEnabled = false,
                            UserName = "michaelj"
                        },
                        new
                        {
                            Id = "7DE9AD64-486E-41C2-8FA2-EB3248CCF28F",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "bccd97c9-2493-4555-b154-541c0ffbf779",
                            Email = "emilyw@example.com",
                            EmailConfirmed = false,
                            GivenName = "Emily",
                            IsDeleted = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "emilyw@example.com",
                            NormalizedName = "EMILY WILLIAMS",
                            NormalizedUserName = "emilyw",
                            PasswordHash = "AQAAAAEAACcQAAAAENIPpNdNqvloCbo2ee9Nuu+JaciypvrPk4Mh8TTOjqP1ipKdc8ylzNNIJ7tGDD5Yfg==",
                            PhoneNumber = "555-444-4444",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "07699a46-5641-4835-8303-cbd44d129246",
                            Surname = "Williams",
                            TwoFactorEnabled = false,
                            UserName = "emilyw"
                        },
                        new
                        {
                            Id = "ECDD09D1-298B-456F-BADF-B4358AF3A08E",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "72244d86-8468-4073-9d30-bd9b8ac48d03",
                            Email = "danielb@example.com",
                            EmailConfirmed = false,
                            GivenName = "Daniel",
                            IsDeleted = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "danielb@example.com",
                            NormalizedName = "DANIEL BROWN",
                            NormalizedUserName = "danielb",
                            PasswordHash = "AQAAAAEAACcQAAAAEIHkpk0uzpoK3TVkw+VCtcsQb23Zmr2HyIuwHujM8aYDMUDE7AEfutviJxQvC26PVg==",
                            PhoneNumber = "555-555-5555",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "7f092cb0-4f92-4653-920e-7fe4da54637b",
                            Surname = "Brown",
                            TwoFactorEnabled = false,
                            UserName = "danielb"
                        },
                        new
                        {
                            Id = "B5E64E97-7D3B-4338-ADD0-EAD00E4959C2",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "301508dc-70d5-4eeb-908a-8fad8d8ed8bc",
                            Email = "oliviaj@example.com",
                            EmailConfirmed = false,
                            GivenName = "Olivia",
                            IsDeleted = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "oliviaj@example.com",
                            NormalizedName = "OLIVIA JONES",
                            NormalizedUserName = "oliviaj",
                            PasswordHash = "AQAAAAEAACcQAAAAEDcLG//zXM3sw7tsczAvLntXtIYOHejymTZw1EytXyHVwl+ByMgHHBipoa+bC6McCA==",
                            PhoneNumber = "555-666-6666",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "da9a54d7-7771-400d-bf3c-942aa69d4ddc",
                            Surname = "Jones",
                            TwoFactorEnabled = false,
                            UserName = "oliviaj"
                        },
                        new
                        {
                            Id = "27074358-129C-40AA-9F02-7E1646F1D9AF",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "893f1d2d-da5d-4083-9ddf-eda15e042443",
                            Email = "davidm@example.com",
                            EmailConfirmed = false,
                            GivenName = "David",
                            IsDeleted = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "davidm@example.com",
                            NormalizedName = "DAVID MILLER",
                            NormalizedUserName = "davidm",
                            PasswordHash = "AQAAAAEAACcQAAAAEOHucH4Qn5W9j7g23YecH1gzj62GOwwkjxSsREWSr6ODK2CD5iWaBlag9r4Tnv4AhA==",
                            PhoneNumber = "555-777-7777",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "ac25f654-13c7-4e87-a0b2-e847e50edd77",
                            Surname = "Miller",
                            TwoFactorEnabled = false,
                            UserName = "davidm"
                        },
                        new
                        {
                            Id = "4D2FA6AA-4921-43BF-8578-A355B14BBD63",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "47592915-1d6b-4c29-a71d-fa2979dcc9b1",
                            Email = "sophiad@example.com",
                            EmailConfirmed = false,
                            GivenName = "Sophia",
                            IsDeleted = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "sophiad@example.com",
                            NormalizedName = "SOPHIA DAVIS",
                            NormalizedUserName = "sophiad",
                            PasswordHash = "AQAAAAEAACcQAAAAEKX0sgxjbtp/rCA2Ic0Tmw7jY6WhQa+PLsBI0GGjHebSsIGgUdhNqLuh7ylfi+wBaQ==",
                            PhoneNumber = "555-888-8888",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "6a2c3ca1-0f25-4ea7-93ea-b9261f43c212",
                            Surname = "Davis",
                            TwoFactorEnabled = false,
                            UserName = "sophiad"
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
                            Id = "9585f639-7b9c-4580-a912-59ec5fceecbc",
                            ConcurrencyStamp = "da93675e-dca3-452e-ad99-e4a603ebb7f6",
                            Name = "User",
                            NormalizedName = "USER"
                        },
                        new
                        {
                            Id = "6890cab0-88ee-4a9b-b49b-569a8c24380d",
                            ConcurrencyStamp = "3b5d5bf0-f1b8-4bc2-b707-e5689ea1ea28",
                            Name = "Contributor",
                            NormalizedName = "CONTRIBUTOR"
                        },
                        new
                        {
                            Id = "59c21f05-ac5a-4a98-af9c-155725398422",
                            ConcurrencyStamp = "2169773b-cfb1-41b8-a9ed-059a27423b4c",
                            Name = "Editor",
                            NormalizedName = "EDITOR"
                        },
                        new
                        {
                            Id = "184542af-0bb4-4a8e-9ddb-9baa0838196d",
                            ConcurrencyStamp = "3176acc9-c2bd-4cf1-a356-8e9d7791e420",
                            Name = "Manager",
                            NormalizedName = "MANAGER"
                        },
                        new
                        {
                            Id = "9b39668e-6b02-4395-92de-2bae25595425",
                            ConcurrencyStamp = "4baa41ae-5ee4-45fc-ac19-beed1134d286",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
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
