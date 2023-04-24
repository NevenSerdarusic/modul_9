using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoWebshop.Migrations
{
    public partial class ApplicatiionUserIsRequiredAgainInOrderClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "209cf38b-e7a3-48b2-a5ca-6744d6eb464a",
                column: "ConcurrencyStamp",
                value: "918b1315-a916-41e8-965b-1c330e56232b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8aaecd59-3fc7-40db-a1e6-8ea379a9d34c",
                column: "ConcurrencyStamp",
                value: "13214f3c-5f38-4f68-ac13-12e32f05bb13");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e02324b1-18a5-4ca9-b562-b7b85eadb1aa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f289c4a2-de6b-4fc0-abfd-bd7acdbc1261", "AQAAAAEAACcQAAAAEJSvlfkJ/CQHO8cEXgtXPlrZgb9AuqSwCuEljuIFP0RLsbQY315rDDvbQ1qvxLXSKQ==", "a8cf807b-5723-49e8-8928-b0c232939ba7" });

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "209cf38b-e7a3-48b2-a5ca-6744d6eb464a",
                column: "ConcurrencyStamp",
                value: "cda6cdf8-8787-456a-97cd-bd8a2d1c5fed");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8aaecd59-3fc7-40db-a1e6-8ea379a9d34c",
                column: "ConcurrencyStamp",
                value: "c4dee2fb-2ec6-4ff9-a009-30bb8b27fc96");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e02324b1-18a5-4ca9-b562-b7b85eadb1aa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ccca26a5-75fd-4000-b5c3-7943d4e8106f", "AQAAAAEAACcQAAAAEPIXUkND0SZat3hb5NnnQ8plYFGc+lP54Ll1I6fBH3fAFriY6ldmwJpB2n9MJVX5OQ==", "fa377679-bfb4-42f2-aafe-2b8913b28a7d" });

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
