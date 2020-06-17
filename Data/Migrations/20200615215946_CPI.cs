using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace covid19.Data.Migrations
{
    public partial class CPI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Provinces");

            migrationBuilder.CreateTable(
                name: "Geography",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    Infected = table.Column<int>(nullable: false),
                    Dead = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Geography", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "CPI",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reference_date = table.Column<DateTime>(nullable: false),
                    Vector_Id = table.Column<string>(nullable: true),
                    Ppdg = table.Column<string>(nullable: true),
                    Coordinate = table.Column<decimal>(type: "decimal(7,4)", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(7,4)", nullable: false),
                    GeographyName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CPI", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CPI_Geography_GeographyName",
                        column: x => x.GeographyName,
                        principalTable: "Geography",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CPI_GeographyName",
                table: "CPI",
                column: "GeographyName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CPI");

            migrationBuilder.DropTable(
                name: "Geography");

            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dead = table.Column<int>(type: "int", nullable: false),
                    Infected = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.Id);
                });
        }
    }
}
