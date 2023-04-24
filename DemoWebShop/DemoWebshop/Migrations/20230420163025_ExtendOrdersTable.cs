using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoWebshop.Migrations
{
    public partial class ExtendOrdersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Orders",
                type: "nvarchar(150)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Orders",
                type: "nvarchar(150)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Orders",
                type: "nvarchar(150)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "Orders",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Orders",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Orders",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "Orders",
                type: "nvarchar(3000)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Orders",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "Orders",
                type: "nvarchar(10)",
                nullable: false,
                defaultValue: "");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Message",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Orders");

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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e02324b1-18a5-4ca9-b562-b7b85eadb1aa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e14704f7-0210-4892-bd56-9007b8f11086", "AQAAAAEAACcQAAAAEPxuIZvejNtRz/wwLVZ6uwXkF8GEdh5afARDagxw+cZIHqwAueAb1WHrSTi+SeKEoA==", "b188481a-5026-4bab-8ed4-c131b3e10322" });
        }
    }
}
