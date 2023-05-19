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
                name: "Tenants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GivenName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateJoined = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Members_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Members_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Email", "GivenName", "IsDeleted", "PhoneNumber", "Surname", "UpdatedDate", "Username" },
                values: new object[,]
                {
                    { new Guid("0b151f5a-8029-4bed-b0c3-ee389be7f820"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "johndoe@example.com", "John", false, "555-111-1111", "Doe", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "johndoe" },
                    { new Guid("27074358-129c-40aa-9f02-7e1646f1d9af"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "davidm@example.com", "David", false, "555-777-7777", "Miller", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "davidm" },
                    { new Guid("4d2fa6aa-4921-43bf-8578-a355b14bbd63"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "sophiad@example.com", "Sophia", false, "555-888-8888", "Davis", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "sophiad" },
                    { new Guid("7de9ad64-486e-41c2-8fa2-eb3248ccf28f"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "emilyw@example.com", "Emily", false, "555-444-4444", "Williams", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "emilyw" },
                    { new Guid("b2b0afa2-9253-44d6-b678-a2e554adb696"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "janesmith@example.com", "Jane", false, "555-222-2222", "Smith", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "janesmith" },
                    { new Guid("b5e64e97-7d3b-4338-add0-ead00e4959c2"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "oliviaj@example.com", "Olivia", false, "555-666-6666", "Jones", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "oliviaj" },
                    { new Guid("e8c4badb-3d2a-44be-9479-254cc62660c9"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "michaelj@example.com", "Michael", false, "555-333-3333", "Johnson", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "michaelj" },
                    { new Guid("ecdd09d1-298b-456f-badf-b4358af3a08e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "danielb@example.com", "Daniel", false, "555-555-5555", "Brown", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "danielb" }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "CreatedDate", "DateJoined", "IsDeleted", "IsEnabled", "Position", "TenantId", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("1510ed1d-317c-4e81-900b-869ff32795b3"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(2023, 5, 19, 17, 4, 7, 5, DateTimeKind.Utc).AddTicks(9988), false, true, "Manager", new Guid("0aaa2440-01fe-451c-bcd9-ca6cbc876a3a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("0b151f5a-8029-4bed-b0c3-ee389be7f820") },
                    { new Guid("53398a73-8b13-4ca6-803d-3c74b0dad959"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(2023, 5, 19, 17, 4, 7, 6, DateTimeKind.Utc).AddTicks(14), false, true, "Consultant", new Guid("5217a17e-ffff-4fbc-aa1b-29175ab98f69"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("27074358-129c-40aa-9f02-7e1646f1d9af") },
                    { new Guid("54cb4c6a-017a-4fb5-9a16-6770bbdb6ce1"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(2023, 5, 19, 17, 4, 7, 6, DateTimeKind.Utc).AddTicks(11), false, true, "Quality Assurance", new Guid("5217a17e-ffff-4fbc-aa1b-29175ab98f69"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("4d2fa6aa-4921-43bf-8578-a355b14bbd63") },
                    { new Guid("678f7712-4d04-4cc0-bbcc-8d67767b165e"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(2023, 5, 19, 17, 4, 7, 6, DateTimeKind.Utc).AddTicks(3), false, true, "Team Lead", new Guid("0aaa2440-01fe-451c-bcd9-ca6cbc876a3a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("ecdd09d1-298b-456f-badf-b4358af3a08e") },
                    { new Guid("7f96c51d-2a89-42bd-8c67-86399c12c672"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(2023, 5, 19, 17, 4, 7, 5, DateTimeKind.Utc).AddTicks(9998), false, true, "Supervisor", new Guid("0aaa2440-01fe-451c-bcd9-ca6cbc876a3a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("e8c4badb-3d2a-44be-9479-254cc62660c9") },
                    { new Guid("81a07a01-90d3-4100-b952-20ac0a6428a7"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(2023, 5, 19, 17, 4, 7, 5, DateTimeKind.Utc).AddTicks(9995), false, true, "Assistant Manager", new Guid("0aaa2440-01fe-451c-bcd9-ca6cbc876a3a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b2b0afa2-9253-44d6-b678-a2e554adb696") },
                    { new Guid("c2fba861-cf6a-49e0-b393-4eb01fa08fe7"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(2023, 5, 19, 17, 4, 7, 6, DateTimeKind.Utc), false, true, "Associate", new Guid("0aaa2440-01fe-451c-bcd9-ca6cbc876a3a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("7de9ad64-486e-41c2-8fa2-eb3248ccf28f") },
                    { new Guid("d88a4de2-fe96-4825-8da4-d9eebd9eceb3"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(2023, 5, 19, 17, 4, 7, 6, DateTimeKind.Utc).AddTicks(8), false, true, "Trainer", new Guid("0aaa2440-01fe-451c-bcd9-ca6cbc876a3a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("27074358-129c-40aa-9f02-7e1646f1d9af") },
                    { new Guid("e8d32f9e-bb43-4551-9c11-e481b98eb00f"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(2023, 5, 19, 17, 4, 7, 6, DateTimeKind.Utc).AddTicks(16), false, true, "Project Manager", new Guid("5217a17e-ffff-4fbc-aa1b-29175ab98f69"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("4d2fa6aa-4921-43bf-8578-a355b14bbd63") },
                    { new Guid("fc115211-a273-49a8-a955-bc9900d41acc"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTime(2023, 5, 19, 17, 4, 7, 6, DateTimeKind.Utc).AddTicks(6), false, true, "Senior Associate", new Guid("0aaa2440-01fe-451c-bcd9-ca6cbc876a3a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b5e64e97-7d3b-4338-add0-ead00e4959c2") }
                });

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
                name: "Members");

            migrationBuilder.DropTable(
                name: "Tenants");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
