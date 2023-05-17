using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataMigrations.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
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
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
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
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
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
                    DateJoined = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
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
                    { "20e1ece5-ead7-420d-bd95-872af0392da8", "85107b35-a485-4d58-8288-ca95fcdcab3e", "Administrator", "ADMINISTRATOR" },
                    { "75642c64-c595-4c4c-b739-28580eeb7c4c", "6db67556-b1b6-4fac-881c-89601717541a", "Contributor", "CONTRIBUTOR" },
                    { "83aab88e-b3e1-4476-9fe8-457f9f4c277d", "1ed325c4-f9ec-4270-a865-79191a05f16c", "SuperAdmin", "SUPERADMIN" },
                    { "cd58fc44-ed64-46bd-a976-3147347f165e", "9ece3eb9-e492-4b67-8493-ee2be8290851", "Editor", "EDITOR" },
                    { "e866125e-6ca1-4c8b-8eec-1e2bdcc468e7", "2564baa9-48d2-4413-9ae2-d05084b2d0fa", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedBy", "CreatedDate", "Email", "EmailConfirmed", "FirstName", "IsDeleted", "IsEnabled", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedBy", "UpdatedDate", "UserName" },
                values: new object[,]
                {
                    { "28279BE8-C3F4-451A-82FE-C11828C6AA1D", 0, "9727d859-3546-4379-a9bc-96257f34c985", "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "emmat@example.com", false, "Emma", false, false, "Taylor", false, null, null, null, null, "555-000-0000", false, "5d955ca8-e156-43ad-a774-218823f1ae8a", false, "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "emmat" },
                    { "33BCFBF7-EDFC-4F7A-8224-9802519D299D", 0, "d86f600c-ac2a-4829-8ec6-2c8dcd09ebcd", "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "janesmith@example.com", false, "Jane", false, false, "Smith", false, null, null, null, null, "555-222-2222", false, "a8bcb5c5-4e7b-409a-8cec-3486ed1e2cc5", false, "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "janesmith" },
                    { "3DFA5AEA-7D68-4BB2-B221-DA563E0ED646", 0, "5bfa62d5-485f-4ed5-88cd-ef24d86022e7", "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "alexanderl@example.com", false, "Alexander", false, false, "Lee", false, null, null, null, null, "555-555-5555", false, "56ed4ae5-c541-4148-879c-0a8937d9ec22", false, "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "alexanderl" },
                    { "557D1752-0B6A-4FFA-B939-29A57EAA0E91", 0, "ca980d56-8ac8-4e84-8202-20d952d861e3", "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "benjamina@example.com", false, "Benjamin", false, false, "Anderson", false, null, null, null, null, "555-111-1111", false, "3a184c27-371d-4423-b019-ef5a4e2a76f9", false, "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "benjamina" },
                    { "6F110D05-8EED-483B-B2FB-0D5FF1601809", 0, "75a70ec5-8773-4bcc-a41f-88fe99be630b", "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "sophiad@example.com", false, "Sophia", false, false, "Davis", false, null, null, null, null, "555-888-8888", false, "3793d778-76c2-4f16-9a3f-d29183a54e23", false, "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "sophiad" },
                    { "87C317FA-EED0-4E6F-A49F-29D73539D9DE", 0, "4fdea714-38a4-4e5a-86eb-0f15f7d2f3f2", "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "danielb@example.com", false, "Daniel", false, false, "Brown", false, null, null, null, null, "555-555-5555", false, "a36252e3-7367-43cf-9fc5-80cac446d8f9", false, "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "danielb" },
                    { "8D5F0776-AC3C-4C33-9EF1-FA9DC2933972", 0, "80587072-ed57-4918-ac9d-bcf7e0eaf670", "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "williamt@example.com", false, "William", false, false, "Thomas", false, null, null, null, null, "555-333-3333", false, "3a922db9-1a29-4ee2-a555-23f472690df0", false, "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "williamt" },
                    { "A1A68798-B47F-4653-B37D-D2C4FF37FE9D", 0, "6f21bcac-2c94-4750-b89a-64a1c683f107", "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "michaelj@example.com", false, "Michael", false, false, "Johnson", false, null, null, null, null, "555-333-3333", false, "d1eff772-063a-4906-a23f-7879a450babb", false, "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "michaelj" },
                    { "A54FF230-6063-42BD-A37B-457D579B2544", 0, "797cb012-e3d4-42a4-b37e-00a98e810ecc", "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "oliviaj@example.com", false, "Olivia", false, false, "Jones", false, null, null, null, null, "555-666-6666", false, "e74ae829-e00d-45cd-b3e2-936ef2a5051e", false, "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "oliviaj" },
                    { "A62A61E1-419D-4C80-BA81-E6DDCCC50B1C", 0, "cd43d016-e7d1-4d33-a000-0f96abe2d2e8", "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "davidm@example.com", false, "David", false, false, "Miller", false, null, null, null, null, "555-777-7777", false, "0935cfbe-72f4-4672-b273-dbc6dc498328", false, "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "davidm" },
                    { "B3B8EFA5-632C-4027-9D16-9703EE09BC92", 0, "13db3705-121a-47a2-96ba-57b8dcea9b91", "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "jamesw@example.com", false, "James", false, false, "Wilson", false, null, null, null, null, "555-999-9999", false, "00d3eede-2ef8-4b03-bd42-02fef45446e4", false, "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "jamesw" },
                    { "BCB1F1CF-3072-49D4-BC96-72859E6F0F08", 0, "bea0e015-c78a-42d2-8054-58683b59e3e1", "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "johndoe@example.com", false, "John", false, false, "Doe", false, null, null, null, null, "555-111-1111", false, "a312e53f-1a7e-4b9f-824e-2a8dba673fae", false, "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "johndoe" },
                    { "BDDFCAEC-E23E-4D61-8A02-0A1F75D40240", 0, "e7520eed-b308-429d-b794-d54fc07f1c8c", "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "avam@example.com", false, "Ava", false, false, "Martinez", false, null, null, null, null, "555-222-2222", false, "97c80158-3a6a-4c33-96d9-281944a0f738", false, "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "avam" },
                    { "F476A298-9040-4F68-86A2-FB6F94258190", 0, "c2d82b41-0040-4b5a-8bee-dcb0b7894c57", "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "miaw@example.com", false, "Mia", false, false, "White", false, null, null, null, null, "555-444-4444", false, "c3954e5e-c1e3-4dae-9375-6d1ad56a46ce", false, "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "miaw" },
                    { "FF971359-568F-4CCF-8F62-194AAE51C745", 0, "360d51b2-abec-4dd6-8ae6-9ce829e1af45", "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "emilyw@example.com", false, "Emily", false, false, "Williams", false, null, null, null, null, "555-444-4444", false, "98251192-7661-42e6-bdc4-41acaa8f31d6", false, "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "emilyw" }
                });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsDeleted", "IsEnabled", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("d46eae42-fe4b-4706-be3d-965b10e3861a"), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, true, "NovellaTech", "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("d55a75a9-2f99-48ea-b256-e1a44b134d4e"), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, true, "VeloVentures", "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DateJoined", "IsDeleted", "IsEnabled", "Position", "TenantId", "UpdatedBy", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("0724349d-d0b5-4606-bcc7-991b06605bed"), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(2023, 5, 17, 16, 12, 35, 715, DateTimeKind.Utc).AddTicks(201), false, true, "Project Manager", new Guid("d55a75a9-2f99-48ea-b256-e1a44b134d4e"), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "B3B8EFA5-632C-4027-9D16-9703EE09BC92" },
                    { new Guid("07c752a9-2eef-4f09-a248-78aa1e90307c"), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(2023, 5, 17, 16, 12, 35, 715, DateTimeKind.Utc).AddTicks(190), false, true, "Team Lead", new Guid("d46eae42-fe4b-4706-be3d-965b10e3861a"), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "87C317FA-EED0-4E6F-A49F-29D73539D9DE" },
                    { new Guid("0d471414-d1b6-4415-8fbf-dbec7c61de8e"), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(2023, 5, 17, 16, 12, 35, 715, DateTimeKind.Utc).AddTicks(195), false, true, "Trainer", new Guid("d46eae42-fe4b-4706-be3d-965b10e3861a"), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "A62A61E1-419D-4C80-BA81-E6DDCCC50B1C" },
                    { new Guid("739eb8cb-ec9f-44fb-9329-b913859e10b0"), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(2023, 5, 17, 16, 12, 35, 715, DateTimeKind.Utc).AddTicks(197), false, true, "Quality Assurance", new Guid("d55a75a9-2f99-48ea-b256-e1a44b134d4e"), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "BCB1F1CF-3072-49D4-BC96-72859E6F0F08" },
                    { new Guid("7a1a1100-c588-47d8-807f-2d242b2dea72"), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(2023, 5, 17, 16, 12, 35, 715, DateTimeKind.Utc).AddTicks(188), false, true, "Associate", new Guid("d46eae42-fe4b-4706-be3d-965b10e3861a"), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "FF971359-568F-4CCF-8F62-194AAE51C745" },
                    { new Guid("7e2d12e1-74f6-49f9-b28f-070d048e1e14"), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(2023, 5, 17, 16, 12, 35, 715, DateTimeKind.Utc).AddTicks(184), false, true, "Assistant Manager", new Guid("d46eae42-fe4b-4706-be3d-965b10e3861a"), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "33BCFBF7-EDFC-4F7A-8224-9802519D299D" },
                    { new Guid("82f7a407-1c94-406a-b60e-f172c3d1b743"), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(2023, 5, 17, 16, 12, 35, 715, DateTimeKind.Utc).AddTicks(186), false, true, "Supervisor", new Guid("d46eae42-fe4b-4706-be3d-965b10e3861a"), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "A1A68798-B47F-4653-B37D-D2C4FF37FE9D" },
                    { new Guid("c118cf09-5fec-4adc-a915-52ed765f1ff3"), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(2023, 5, 17, 16, 12, 35, 715, DateTimeKind.Utc).AddTicks(199), false, true, "Consultant", new Guid("d55a75a9-2f99-48ea-b256-e1a44b134d4e"), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "6F110D05-8EED-483B-B2FB-0D5FF1601809" },
                    { new Guid("c3c65b72-6fba-4a99-928c-ba3347efbd9a"), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(2023, 5, 17, 16, 12, 35, 715, DateTimeKind.Utc).AddTicks(193), false, true, "Senior Associate", new Guid("d46eae42-fe4b-4706-be3d-965b10e3861a"), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "A54FF230-6063-42BD-A37B-457D579B2544" },
                    { new Guid("e180d192-27d6-4007-87ab-9782e45ebb62"), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(2023, 5, 17, 16, 12, 35, 715, DateTimeKind.Utc).AddTicks(179), false, true, "Manager", new Guid("d46eae42-fe4b-4706-be3d-965b10e3861a"), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "BCB1F1CF-3072-49D4-BC96-72859E6F0F08" }
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
