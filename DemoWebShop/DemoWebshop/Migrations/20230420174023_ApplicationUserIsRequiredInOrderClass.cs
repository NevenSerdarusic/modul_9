using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoWebshop.Migrations
{
    public partial class ApplicationUserIsRequiredInOrderClass : Migration
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                value: "6632d6b7-4895-447c-b7a9-3c0e33450c03");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8aaecd59-3fc7-40db-a1e6-8ea379a9d34c",
                column: "ConcurrencyStamp",
                value: "8a814023-a2bd-44b2-bbe2-f96bf38452d5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e02324b1-18a5-4ca9-b562-b7b85eadb1aa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "64941a2d-11f9-4280-9e3c-63f6666b00be", "AQAAAAEAACcQAAAAEH+HrnVSAOIIAImEpmdglCbjzDkPolobBwJmf7cWxCbKxiqghLzcymbga5CZzg4Okw==", "13f43b93-de34-4b89-bb11-a1be02f7c4e7" });

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
