using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoWebshop.Migrations
{
    public partial class SeedAspNetRolesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "209cf38b-e7a3-48b2-a5ca-6744d6eb464a", "fdbedd24-eee4-4b3e-bccb-8c390c60d1d3", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8aaecd59-3fc7-40db-a1e6-8ea379a9d34c", "7c82f2f1-4928-4f16-ae49-ac05d6a4533a", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "209cf38b-e7a3-48b2-a5ca-6744d6eb464a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8aaecd59-3fc7-40db-a1e6-8ea379a9d34c");
        }
    }
}
