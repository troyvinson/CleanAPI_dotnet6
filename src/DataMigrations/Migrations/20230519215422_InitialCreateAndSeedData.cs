using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataMigrations.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateAndSeedData : Migration
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
                    DateJoined = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    { "2afaa526-aa02-4d75-a7a5-ac8a3ca202f8", "31303d69-b870-431d-b493-0e4f2bf02b68", "Manager", "MANAGER" },
                    { "2e5af43a-153f-40a6-b9b2-eb8a1af70e7d", "5dbf20e7-35c5-4e35-af7e-82d0c9c0141b", "Contributor", "CONTRIBUTOR" },
                    { "4105493a-e164-472e-b7a0-ce290eb4b884", "5b2543de-6419-4f60-8d53-b99b7cb4aee2", "Editor", "EDITOR" },
                    { "6b180793-144d-4847-923a-f115818919c4", "be9ead5d-ce6d-40a7-98d5-40f21335abb3", "Administrator", "ADMINISTRATOR" },
                    { "bba9817f-760d-4885-8acf-793cb289bd60", "d9bb31d3-2e27-4528-a9fd-328676efee37", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "GivenName", "IsDeleted", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedName", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0B151F5A-8029-4BED-B0C3-EE389BE7F820", 0, "1a3529b9-3f1e-4166-af2b-b6b1a28ce3b4", "johndoe@example.com", false, "John", false, false, null, "johndoe@example.com", "JOHN DOE", "johndoe", "AQAAAAEAACcQAAAAEBsC4mgGJ93B3Fik2Qt545zriUh5MjzIHMCWiM+P++YVLbkeF8ngQqfquoxr7LwQ+g==", "555-111-1111", false, "48d058c4-434a-4cf9-a77a-7df9a43cec6e", "Doe", false, "johndoe" },
                    { "27074358-129C-40AA-9F02-7E1646F1D9AF", 0, "e727a91c-0fc9-421b-bde1-a29b3292a77a", "davidm@example.com", false, "David", false, false, null, "davidm@example.com", "DAVID MILLER", "davidm", "AQAAAAEAACcQAAAAEBS1miyXcttDBY0rQdiKXzMwUi/NKvqXy5BXmZbjEzCFAjaOGxSgRzAZTClhsRtVzQ==", "555-777-7777", false, "c2833df6-0da0-4563-b600-1e345276722a", "Miller", false, "davidm" },
                    { "4D2FA6AA-4921-43BF-8578-A355B14BBD63", 0, "25ee6d5d-46cf-4412-b739-8b7fa58be039", "sophiad@example.com", false, "Sophia", false, false, null, "sophiad@example.com", "SOPHIA DAVIS", "sophiad", "AQAAAAEAACcQAAAAEMaTTpP42plf8InQE7KyFkFFIC2zEIZ9vMARcZ5UhNzhKYUm1phNKxgzHeRakjKzOA==", "555-888-8888", false, "d9156960-3b6d-4ab4-b79f-c105975531d5", "Davis", false, "sophiad" },
                    { "7DE9AD64-486E-41C2-8FA2-EB3248CCF28F", 0, "a3e2a7e5-f8c5-4f12-8074-776900a95e81", "emilyw@example.com", false, "Emily", false, false, null, "emilyw@example.com", "EMILY WILLIAMS", "emilyw", "AQAAAAEAACcQAAAAEPV/K9MDLGNfhCioH8SrUgGWtcTGchLMQchiOU8HguvWGYvfGtwcENpWVD82eV+HcA==", "555-444-4444", false, "eebc99a6-f25c-4450-ac18-faab29ecdd77", "Williams", false, "emilyw" },
                    { "B2B0AFA2-9253-44D6-B678-A2E554ADB696", 0, "24afe154-3274-4779-8d00-7a3fbcce069f", "janesmith@example.com", false, "Jane", false, false, null, "janesmith@example.com", "JANE SMITH", "janesmith", "AQAAAAEAACcQAAAAEMxHjasFkA/yyxDilELGpIogjEiIFg5Ah76HPs750TMzsWmCPVjCSARoVvj/Zez9GQ==", "555-222-2222", false, "1eb2d0bb-8556-4c7c-bb3c-0040b75264fc", "Smith", false, "janesmith" },
                    { "B5E64E97-7D3B-4338-ADD0-EAD00E4959C2", 0, "22d610f2-1350-4523-86cf-7e4ee683fd75", "oliviaj@example.com", false, "Olivia", false, false, null, "oliviaj@example.com", "OLIVIA JONES", "oliviaj", "AQAAAAEAACcQAAAAED3SMOE6lsIP/V4YamnZ0SRYjPPsYAB0OLn5MTx3oid9ChPqWtmeS7btv5a2focsAg==", "555-666-6666", false, "83f873ad-4fc7-41c2-9d7d-f7d8fb95601b", "Jones", false, "oliviaj" },
                    { "E8C4BADB-3D2A-44BE-9479-254CC62660C9", 0, "1e74399d-12a7-423c-953d-4fc094fe30ad", "michaelj@example.com", false, "Michael", false, false, null, "michaelj@example.com", "MICHAEL JOHNSON", "michaelj", "AQAAAAEAACcQAAAAEM8CPWw3QhYH/2QKkPVXJIqoX9pZ1GkEX8k4Nj5ACkd104K6M1QnpW/sPEvwWGdqtA==", "555-333-3333", false, "cc9a31ff-57d0-4adc-a1f3-b7fc12b4d01b", "Johnson", false, "michaelj" },
                    { "ECDD09D1-298B-456F-BADF-B4358AF3A08E", 0, "eeb38202-c0c0-4b03-a2d9-4f5dd7878928", "danielb@example.com", false, "Daniel", false, false, null, "danielb@example.com", "DANIEL BROWN", "danielb", "AQAAAAEAACcQAAAAEOr1bxou/A9PGvANrfgnOjjBckIHQ3Z7nVGomC4yiLhEiWyeiRsdVi9GPZ3ohsYZUg==", "555-555-5555", false, "6910256b-3e89-4294-b9a7-a1f17996f6a8", "Brown", false, "danielb" }
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
                    { new Guid("1510ed1d-317c-4e81-900b-869ff32795b3"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(2023, 5, 19, 21, 54, 22, 408, DateTimeKind.Utc).AddTicks(8834), false, true, "Manager", new Guid("0aaa2440-01fe-451c-bcd9-ca6cbc876a3a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "0B151F5A-8029-4BED-B0C3-EE389BE7F820" },
                    { new Guid("53398a73-8b13-4ca6-803d-3c74b0dad959"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(2023, 5, 19, 21, 54, 22, 408, DateTimeKind.Utc).AddTicks(8858), false, true, "Consultant", new Guid("5217a17e-ffff-4fbc-aa1b-29175ab98f69"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "27074358-129C-40AA-9F02-7E1646F1D9AF" },
                    { new Guid("54cb4c6a-017a-4fb5-9a16-6770bbdb6ce1"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(2023, 5, 19, 21, 54, 22, 408, DateTimeKind.Utc).AddTicks(8856), false, true, "Quality Assurance", new Guid("5217a17e-ffff-4fbc-aa1b-29175ab98f69"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "4D2FA6AA-4921-43BF-8578-A355B14BBD63" },
                    { new Guid("678f7712-4d04-4cc0-bbcc-8d67767b165e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(2023, 5, 19, 21, 54, 22, 408, DateTimeKind.Utc).AddTicks(8850), false, true, "Team Lead", new Guid("0aaa2440-01fe-451c-bcd9-ca6cbc876a3a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "ECDD09D1-298B-456F-BADF-B4358AF3A08E" },
                    { new Guid("7f96c51d-2a89-42bd-8c67-86399c12c672"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(2023, 5, 19, 21, 54, 22, 408, DateTimeKind.Utc).AddTicks(8844), false, true, "Supervisor", new Guid("0aaa2440-01fe-451c-bcd9-ca6cbc876a3a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "E8C4BADB-3D2A-44BE-9479-254CC62660C9" },
                    { new Guid("81a07a01-90d3-4100-b952-20ac0a6428a7"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(2023, 5, 19, 21, 54, 22, 408, DateTimeKind.Utc).AddTicks(8842), false, true, "Assistant Manager", new Guid("0aaa2440-01fe-451c-bcd9-ca6cbc876a3a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "B2B0AFA2-9253-44D6-B678-A2E554ADB696" },
                    { new Guid("c2fba861-cf6a-49e0-b393-4eb01fa08fe7"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(2023, 5, 19, 21, 54, 22, 408, DateTimeKind.Utc).AddTicks(8847), false, true, "Associate", new Guid("0aaa2440-01fe-451c-bcd9-ca6cbc876a3a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "7DE9AD64-486E-41C2-8FA2-EB3248CCF28F" },
                    { new Guid("d88a4de2-fe96-4825-8da4-d9eebd9eceb3"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(2023, 5, 19, 21, 54, 22, 408, DateTimeKind.Utc).AddTicks(8854), false, true, "Trainer", new Guid("0aaa2440-01fe-451c-bcd9-ca6cbc876a3a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "27074358-129C-40AA-9F02-7E1646F1D9AF" },
                    { new Guid("e8d32f9e-bb43-4551-9c11-e481b98eb00f"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(2023, 5, 19, 21, 54, 22, 408, DateTimeKind.Utc).AddTicks(8860), false, true, "Project Manager", new Guid("5217a17e-ffff-4fbc-aa1b-29175ab98f69"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "4D2FA6AA-4921-43BF-8578-A355B14BBD63" },
                    { new Guid("fc115211-a273-49a8-a955-bc9900d41acc"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(2023, 5, 19, 21, 54, 22, 408, DateTimeKind.Utc).AddTicks(8852), false, true, "Senior Associate", new Guid("0aaa2440-01fe-451c-bcd9-ca6cbc876a3a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "B5E64E97-7D3B-4338-ADD0-EAD00E4959C2" }
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
