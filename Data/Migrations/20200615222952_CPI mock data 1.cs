using Microsoft.EntityFrameworkCore.Migrations;

namespace covid19.Data.Migrations
{
    public partial class CPImockdata1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Geography",
                keyColumn: "Name",
                keyValue: "Alberta");

            migrationBuilder.DeleteData(
                table: "Geography",
                keyColumn: "Name",
                keyValue: "Canada");

            migrationBuilder.DeleteData(
                table: "Geography",
                keyColumn: "Name",
                keyValue: "Ontario");

            migrationBuilder.DeleteData(
                table: "Geography",
                keyColumn: "Name",
                keyValue: "Quebec");

            migrationBuilder.InsertData(
                table: "Geography",
                columns: new[] { "Name", "Dead", "Infected" },
                values: new object[,]
                {
                    { "CA", 3999, 50000 },
                    { "QC", 500, 10000 },
                    { "ON", 399, 7000 },
                    { "AB", 200, 5000 },
                    { "BC", 150, 6000 },
                    { "YT", 2, 50 },
                    { "PE", 30, 300 },
                    { "MB", 40, 500 },
                    { "NS", 100, 2000 },
                    { "NB", 95, 1500 },
                    { "NL", 100, 1200 },
                    { "SK", 5, 50 },
                    { "NU", 20, 100 },
                    { "NT", 1, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Geography",
                keyColumn: "Name",
                keyValue: "AB");

            migrationBuilder.DeleteData(
                table: "Geography",
                keyColumn: "Name",
                keyValue: "BC");

            migrationBuilder.DeleteData(
                table: "Geography",
                keyColumn: "Name",
                keyValue: "CA");

            migrationBuilder.DeleteData(
                table: "Geography",
                keyColumn: "Name",
                keyValue: "MB");

            migrationBuilder.DeleteData(
                table: "Geography",
                keyColumn: "Name",
                keyValue: "NB");

            migrationBuilder.DeleteData(
                table: "Geography",
                keyColumn: "Name",
                keyValue: "NL");

            migrationBuilder.DeleteData(
                table: "Geography",
                keyColumn: "Name",
                keyValue: "NS");

            migrationBuilder.DeleteData(
                table: "Geography",
                keyColumn: "Name",
                keyValue: "NT");

            migrationBuilder.DeleteData(
                table: "Geography",
                keyColumn: "Name",
                keyValue: "NU");

            migrationBuilder.DeleteData(
                table: "Geography",
                keyColumn: "Name",
                keyValue: "ON");

            migrationBuilder.DeleteData(
                table: "Geography",
                keyColumn: "Name",
                keyValue: "PE");

            migrationBuilder.DeleteData(
                table: "Geography",
                keyColumn: "Name",
                keyValue: "QC");

            migrationBuilder.DeleteData(
                table: "Geography",
                keyColumn: "Name",
                keyValue: "SK");

            migrationBuilder.DeleteData(
                table: "Geography",
                keyColumn: "Name",
                keyValue: "YT");

            migrationBuilder.InsertData(
                table: "Geography",
                columns: new[] { "Name", "Dead", "Infected" },
                values: new object[,]
                {
                    { "Canada", 3999, 50000 },
                    { "Quebec", 500, 10000 },
                    { "Ontario", 399, 7000 },
                    { "Alberta", 200, 5000 }
                });
        }
    }
}
