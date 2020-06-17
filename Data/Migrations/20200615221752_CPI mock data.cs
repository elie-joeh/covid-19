using Microsoft.EntityFrameworkCore.Migrations;

namespace covid19.Data.Migrations
{
    public partial class CPImockdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
