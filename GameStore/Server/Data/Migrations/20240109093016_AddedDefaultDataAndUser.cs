using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameStore.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedDefaultDataAndUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReviewId",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ad2bcf0c-20db-474f-8407-5a6b159518ba", null, "Administrator", "ADMINISTRATOR" },
                    { "bd2bcf0c-20db-474f-8407-5a6b159518bb", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3781efa7-66dc-47f0-860f-e506d04102e4", 0, "b8370d77-7d4d-4898-b4e5-d5a86ed662be", "admin@localhost.com", false, "Admin", "User", false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAENLD5YXuL7duwP63AYLz9fgWDrBII478ZXRO94Iz67kChR20Af+DXfEat5mg9D0rzw==", null, false, "34d9032e-9fbc-4c15-89c9-d0eb55a0924b", false, "admin@localhost.com" },
                    { "a50453d1-eb03-4e96-a671-82488a8747bd", 0, "5f764b6a-d157-4363-a324-f23f50da8e62", "user@localhost.com", false, "User", "UserLN", false, null, "USER@LOCALHOST.COM", "USER@LOCALHOST.COM", "AQAAAAIAAYagAAAAEEs/Y1nlgCkDc696wLB/Ci+Zb+qGvxsYCOKze/MJ5w0kscCpq5msRuM3aoPvOyc/sQ==", null, false, "ee46e526-9cbf-4e6e-83b2-980743498f9f", false, "user@localhost.com" }
                });

            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2024, 1, 9, 17, 30, 16, 314, DateTimeKind.Local).AddTicks(3249), new DateTime(2024, 1, 9, 17, 30, 16, 314, DateTimeKind.Local).AddTicks(3249), "Obsidian", "System" },
                    { 2, "System", new DateTime(2024, 1, 9, 17, 30, 16, 314, DateTimeKind.Local).AddTicks(3251), new DateTime(2024, 1, 9, 17, 30, 16, 314, DateTimeKind.Local).AddTicks(3251), "Arkane", "System" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2024, 1, 9, 17, 30, 16, 314, DateTimeKind.Local).AddTicks(2625), new DateTime(2024, 1, 9, 17, 30, 16, 314, DateTimeKind.Local).AddTicks(2637), "FPS", "System" },
                    { 2, "System", new DateTime(2024, 1, 9, 17, 30, 16, 314, DateTimeKind.Local).AddTicks(2640), new DateTime(2024, 1, 9, 17, 30, 16, 314, DateTimeKind.Local).AddTicks(2640), "Horror", "System" }
                });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2024, 1, 9, 17, 30, 16, 314, DateTimeKind.Local).AddTicks(3476), new DateTime(2024, 1, 9, 17, 30, 16, 314, DateTimeKind.Local).AddTicks(3476), "PC", "System" },
                    { 2, "System", new DateTime(2024, 1, 9, 17, 30, 16, 314, DateTimeKind.Local).AddTicks(3478), new DateTime(2024, 1, 9, 17, 30, 16, 314, DateTimeKind.Local).AddTicks(3478), "Switch", "System" }
                });

            migrationBuilder.InsertData(
                table: "Titles",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2024, 1, 9, 17, 30, 16, 314, DateTimeKind.Local).AddTicks(3033), new DateTime(2024, 1, 9, 17, 30, 16, 314, DateTimeKind.Local).AddTicks(3034), "Outer Worlds", "System" },
                    { 2, "System", new DateTime(2024, 1, 9, 17, 30, 16, 314, DateTimeKind.Local).AddTicks(3036), new DateTime(2024, 1, 9, 17, 30, 16, 314, DateTimeKind.Local).AddTicks(3037), "Prey", "System" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "ad2bcf0c-20db-474f-8407-5a6b159518ba", "3781efa7-66dc-47f0-860f-e506d04102e4" },
                    { "bd2bcf0c-20db-474f-8407-5a6b159518bb", "a50453d1-eb03-4e96-a671-82488a8747bd" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_ReviewId",
                table: "Games",
                column: "ReviewId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Reviews_ReviewId",
                table: "Games",
                column: "ReviewId",
                principalTable: "Reviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Reviews_ReviewId",
                table: "Games");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Games_ReviewId",
                table: "Games");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ad2bcf0c-20db-474f-8407-5a6b159518ba", "3781efa7-66dc-47f0-860f-e506d04102e4" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bd2bcf0c-20db-474f-8407-5a6b159518bb", "a50453d1-eb03-4e96-a671-82488a8747bd" });

            migrationBuilder.DeleteData(
                table: "Developers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Developers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad2bcf0c-20db-474f-8407-5a6b159518ba");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd2bcf0c-20db-474f-8407-5a6b159518bb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a50453d1-eb03-4e96-a671-82488a8747bd");

            migrationBuilder.DropColumn(
                name: "ReviewId",
                table: "Games");
        }
    }
}
