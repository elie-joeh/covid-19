using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace covid19.Data.Migrations
{
    public partial class CorrectEmploymenttabledata1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VectorId = table.Column<string>(nullable: true),
                    ReferenceDate = table.Column<DateTime>(nullable: false),
                    GeoName = table.Column<string>(nullable: true),
                    Lfc = table.Column<int>(nullable: false),
                    Sex = table.Column<int>(nullable: false),
                    AgeGroup = table.Column<int>(nullable: false),
                    UOM = table.Column<string>(nullable: true),
                    ScalarFactor = table.Column<string>(nullable: true),
                    Value = table.Column<decimal>(type: "decimal(7,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employment", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employment");
        }
    }
}
