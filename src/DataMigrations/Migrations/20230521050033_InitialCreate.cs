using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataMigrations.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GivenName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tenants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateJoined = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Members_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Members_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "184542af-0bb4-4a8e-9ddb-9baa0838196d", "3176acc9-c2bd-4cf1-a356-8e9d7791e420", "Manager", "MANAGER" },
                    { "59c21f05-ac5a-4a98-af9c-155725398422", "2169773b-cfb1-41b8-a9ed-059a27423b4c", "Editor", "EDITOR" },
                    { "6890cab0-88ee-4a9b-b49b-569a8c24380d", "3b5d5bf0-f1b8-4bc2-b707-e5689ea1ea28", "Contributor", "CONTRIBUTOR" },
                    { "9585f639-7b9c-4580-a912-59ec5fceecbc", "da93675e-dca3-452e-ad99-e4a603ebb7f6", "User", "USER" },
                    { "9b39668e-6b02-4395-92de-2bae25595425", "4baa41ae-5ee4-45fc-ac19-beed1134d286", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "GivenName", "IsDeleted", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedName", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0B151F5A-8029-4BED-B0C3-EE389BE7F820", 0, "2745527c-6fe0-4901-8194-9cac44484228", "johndoe@example.com", false, "John", false, false, null, "johndoe@example.com", "JOHN DOE", "johndoe", "AQAAAAEAACcQAAAAEJuUM1V2lqAZsRX7SllfNEVtARVTrG1DGgvViVEQ+p8OJbpyW08P60ZFrZG4DwdJUQ==", "555-111-1111", false, "f8de8b4a-5e30-4175-8f92-4696ceee1635", "Doe", false, "johndoe" },
                    { "27074358-129C-40AA-9F02-7E1646F1D9AF", 0, "893f1d2d-da5d-4083-9ddf-eda15e042443", "davidm@example.com", false, "David", false, false, null, "davidm@example.com", "DAVID MILLER", "davidm", "AQAAAAEAACcQAAAAEOHucH4Qn5W9j7g23YecH1gzj62GOwwkjxSsREWSr6ODK2CD5iWaBlag9r4Tnv4AhA==", "555-777-7777", false, "ac25f654-13c7-4e87-a0b2-e847e50edd77", "Miller", false, "davidm" },
                    { "4D2FA6AA-4921-43BF-8578-A355B14BBD63", 0, "47592915-1d6b-4c29-a71d-fa2979dcc9b1", "sophiad@example.com", false, "Sophia", false, false, null, "sophiad@example.com", "SOPHIA DAVIS", "sophiad", "AQAAAAEAACcQAAAAEKX0sgxjbtp/rCA2Ic0Tmw7jY6WhQa+PLsBI0GGjHebSsIGgUdhNqLuh7ylfi+wBaQ==", "555-888-8888", false, "6a2c3ca1-0f25-4ea7-93ea-b9261f43c212", "Davis", false, "sophiad" },
                    { "7DE9AD64-486E-41C2-8FA2-EB3248CCF28F", 0, "bccd97c9-2493-4555-b154-541c0ffbf779", "emilyw@example.com", false, "Emily", false, false, null, "emilyw@example.com", "EMILY WILLIAMS", "emilyw", "AQAAAAEAACcQAAAAENIPpNdNqvloCbo2ee9Nuu+JaciypvrPk4Mh8TTOjqP1ipKdc8ylzNNIJ7tGDD5Yfg==", "555-444-4444", false, "07699a46-5641-4835-8303-cbd44d129246", "Williams", false, "emilyw" },
                    { "B2B0AFA2-9253-44D6-B678-A2E554ADB696", 0, "5ff65696-5d8d-4d36-aefe-e428a756fc39", "janesmith@example.com", false, "Jane", false, false, null, "janesmith@example.com", "JANE SMITH", "janesmith", "AQAAAAEAACcQAAAAELfJ/0l9zEYBzu91dUCHA6ooQLRDSjgWHnzn/ZdjGHO28B/reeZ1KfBiozmT6Ytuow==", "555-222-2222", false, "fb28a86f-e9e8-43e2-ab32-d5688a70461e", "Smith", false, "janesmith" },
                    { "B5E64E97-7D3B-4338-ADD0-EAD00E4959C2", 0, "301508dc-70d5-4eeb-908a-8fad8d8ed8bc", "oliviaj@example.com", false, "Olivia", false, false, null, "oliviaj@example.com", "OLIVIA JONES", "oliviaj", "AQAAAAEAACcQAAAAEDcLG//zXM3sw7tsczAvLntXtIYOHejymTZw1EytXyHVwl+ByMgHHBipoa+bC6McCA==", "555-666-6666", false, "da9a54d7-7771-400d-bf3c-942aa69d4ddc", "Jones", false, "oliviaj" },
                    { "E8C4BADB-3D2A-44BE-9479-254CC62660C9", 0, "c7b8e41f-83bb-425c-bad1-ac88bf7368ca", "michaelj@example.com", false, "Michael", false, false, null, "michaelj@example.com", "MICHAEL JOHNSON", "michaelj", "AQAAAAEAACcQAAAAEMe6C5YDwa6Pnf18zBtXOb1ARmgqdO5O9Zi2RzhJ9mcttaiN21GeUQpglMLUg+0YXw==", "555-333-3333", false, "e857cbd8-881f-416d-a8ce-42e2481f3899", "Johnson", false, "michaelj" },
                    { "ECDD09D1-298B-456F-BADF-B4358AF3A08E", 0, "72244d86-8468-4073-9d30-bd9b8ac48d03", "danielb@example.com", false, "Daniel", false, false, null, "danielb@example.com", "DANIEL BROWN", "danielb", "AQAAAAEAACcQAAAAEIHkpk0uzpoK3TVkw+VCtcsQb23Zmr2HyIuwHujM8aYDMUDE7AEfutviJxQvC26PVg==", "555-555-5555", false, "7f092cb0-4f92-4653-920e-7fe4da54637b", "Brown", false, "danielb" }
                });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "IsEnabled", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("0aaa2440-01fe-451c-bcd9-ca6cbc876a3a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, true, "NovellaTech", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("5217a17e-ffff-4fbc-aa1b-29175ab98f69"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, true, "VeloVentures", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "CreatedDate", "DateJoined", "IsDeleted", "IsEnabled", "Position", "TenantId", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("1510ed1d-317c-4e81-900b-869ff32795b3"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 5, 21, 5, 0, 32, 966, DateTimeKind.Unspecified).AddTicks(5090), new TimeSpan(0, 0, 0, 0, 0)), false, true, "Manager", new Guid("0aaa2440-01fe-451c-bcd9-ca6cbc876a3a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "0B151F5A-8029-4BED-B0C3-EE389BE7F820" },
                    { new Guid("53398a73-8b13-4ca6-803d-3c74b0dad959"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 5, 21, 5, 0, 32, 966, DateTimeKind.Unspecified).AddTicks(5153), new TimeSpan(0, 0, 0, 0, 0)), false, true, "Consultant", new Guid("5217a17e-ffff-4fbc-aa1b-29175ab98f69"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "27074358-129C-40AA-9F02-7E1646F1D9AF" },
                    { new Guid("54cb4c6a-017a-4fb5-9a16-6770bbdb6ce1"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 5, 21, 5, 0, 32, 966, DateTimeKind.Unspecified).AddTicks(5150), new TimeSpan(0, 0, 0, 0, 0)), false, true, "Quality Assurance", new Guid("5217a17e-ffff-4fbc-aa1b-29175ab98f69"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "4D2FA6AA-4921-43BF-8578-A355B14BBD63" },
                    { new Guid("678f7712-4d04-4cc0-bbcc-8d67767b165e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 5, 21, 5, 0, 32, 966, DateTimeKind.Unspecified).AddTicks(5144), new TimeSpan(0, 0, 0, 0, 0)), false, true, "Team Lead", new Guid("0aaa2440-01fe-451c-bcd9-ca6cbc876a3a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "ECDD09D1-298B-456F-BADF-B4358AF3A08E" },
                    { new Guid("7f96c51d-2a89-42bd-8c67-86399c12c672"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 5, 21, 5, 0, 32, 966, DateTimeKind.Unspecified).AddTicks(5139), new TimeSpan(0, 0, 0, 0, 0)), false, true, "Supervisor", new Guid("0aaa2440-01fe-451c-bcd9-ca6cbc876a3a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "E8C4BADB-3D2A-44BE-9479-254CC62660C9" },
                    { new Guid("81a07a01-90d3-4100-b952-20ac0a6428a7"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 5, 21, 5, 0, 32, 966, DateTimeKind.Unspecified).AddTicks(5096), new TimeSpan(0, 0, 0, 0, 0)), false, true, "Assistant Manager", new Guid("0aaa2440-01fe-451c-bcd9-ca6cbc876a3a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "B2B0AFA2-9253-44D6-B678-A2E554ADB696" },
                    { new Guid("c2fba861-cf6a-49e0-b393-4eb01fa08fe7"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 5, 21, 5, 0, 32, 966, DateTimeKind.Unspecified).AddTicks(5142), new TimeSpan(0, 0, 0, 0, 0)), false, true, "Associate", new Guid("0aaa2440-01fe-451c-bcd9-ca6cbc876a3a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "7DE9AD64-486E-41C2-8FA2-EB3248CCF28F" },
                    { new Guid("d88a4de2-fe96-4825-8da4-d9eebd9eceb3"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 5, 21, 5, 0, 32, 966, DateTimeKind.Unspecified).AddTicks(5148), new TimeSpan(0, 0, 0, 0, 0)), false, true, "Trainer", new Guid("0aaa2440-01fe-451c-bcd9-ca6cbc876a3a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "27074358-129C-40AA-9F02-7E1646F1D9AF" },
                    { new Guid("e8d32f9e-bb43-4551-9c11-e481b98eb00f"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 5, 21, 5, 0, 32, 966, DateTimeKind.Unspecified).AddTicks(5155), new TimeSpan(0, 0, 0, 0, 0)), false, true, "Project Manager", new Guid("5217a17e-ffff-4fbc-aa1b-29175ab98f69"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "4D2FA6AA-4921-43BF-8578-A355B14BBD63" },
                    { new Guid("fc115211-a273-49a8-a955-bc9900d41acc"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 5, 21, 5, 0, 32, 966, DateTimeKind.Unspecified).AddTicks(5146), new TimeSpan(0, 0, 0, 0, 0)), false, true, "Senior Associate", new Guid("0aaa2440-01fe-451c-bcd9-ca6cbc876a3a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "B5E64E97-7D3B-4338-ADD0-EAD00E4959C2" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Members_TenantId",
                table: "Members",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_UserId",
                table: "Members",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Tenants");
        }
    }
}
