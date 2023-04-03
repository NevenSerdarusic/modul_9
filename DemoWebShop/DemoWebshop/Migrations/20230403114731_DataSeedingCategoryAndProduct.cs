using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoWebshop.Migrations
{
    public partial class DataSeedingCategoryAndProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Image", "Title" },
                values: new object[,]
                {
                    { 1, "Voće i proizvodi od voća", "voce.png", "Voće" },
                    { 10, "Mlijeko i mliječni proizvodi", "mlijecniproizvodi.png", "Mliječni proizvodi" },
                    { 20, "Proizvodi od brašna", "pekarskiproizvodi.png", "Pekarski proizvodi" },
                    { 50, "Pića i napitci", "pica.png", "Pića" },
                    { 70, "Meso i proizvodi od mesa", "meso.png", "Meso" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Image", "InStock", "Price", "Sku", "Title" },
                values: new object[,]
                {
                    { 1, "Crvena jabuka", "crvenajabuka.png", 1023.13m, 0.77m, "j01-voće", "Jabuka crvena" },
                    { 2, "Zelena jabuka", "zelenajabuka.png", 957.15m, 0.73m, "j02-voće", "Jabuka zelena" },
                    { 17, "Jogurt sa 2,8% mm", "jogurt2,8%.png", 500m, 1.22m, "j03-jog", "Jogurt 0,5L" },
                    { 22, "Kruh sa sjemenkama", "kruhsjemnkeKlara.png", 150m, 1.27m, "p09-peka", "Kruh Klara" },
                    { 54, "Bavaria", "bavaria.png", 257m, 2.14m, "p17-pića", "Pivo 0,33L" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 54);
        }
    }
}
