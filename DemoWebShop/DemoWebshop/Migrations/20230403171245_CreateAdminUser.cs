using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoWebshop.Migrations
{
    public partial class CreateAdminUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "209cf38b-e7a3-48b2-a5ca-6744d6eb464a",
                column: "ConcurrencyStamp",
                value: "8906f809-dfaa-42e7-8daa-614999bf1ca9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8aaecd59-3fc7-40db-a1e6-8ea379a9d34c",
                column: "ConcurrencyStamp",
                value: "6e9b5e4a-4383-44b0-b2fd-353cb9fad32b");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Adress", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e02324b1-18a5-4ca9-b562-b7b85eadb1aa", 0, "Stara cesta bb", "e14704f7-0210-4892-bd56-9007b8f11086", "mico@admin.com", false, "Mićo", "Programerić", false, null, "MICO@ADMIN.COM", "MICO@ADMIN.COM", "AQAAAAEAACcQAAAAEPxuIZvejNtRz/wwLVZ6uwXkF8GEdh5afARDagxw+cZIHqwAueAb1WHrSTi+SeKEoA==", null, false, "b188481a-5026-4bab-8ed4-c131b3e10322", false, "mico@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "209cf38b-e7a3-48b2-a5ca-6744d6eb464a", "e02324b1-18a5-4ca9-b562-b7b85eadb1aa" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "209cf38b-e7a3-48b2-a5ca-6744d6eb464a", "e02324b1-18a5-4ca9-b562-b7b85eadb1aa" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e02324b1-18a5-4ca9-b562-b7b85eadb1aa");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "209cf38b-e7a3-48b2-a5ca-6744d6eb464a",
                column: "ConcurrencyStamp",
                value: "fdbedd24-eee4-4b3e-bccb-8c390c60d1d3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8aaecd59-3fc7-40db-a1e6-8ea379a9d34c",
                column: "ConcurrencyStamp",
                value: "7c82f2f1-4928-4f16-ae49-ac05d6a4533a");
        }
    }
}
