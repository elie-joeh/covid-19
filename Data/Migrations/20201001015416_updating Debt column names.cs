using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace covid19.Data.Migrations
{
    public partial class updatingDebtcolumnnames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*
            migrationBuilder.CreateTable(
                name: "Canada_Debt",
                columns: table => new
                {
                    Vector_id = table.Column<long>(nullable: false),
                    Reference_date = table.Column<DateTime>(nullable: false),
                    Value = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Decimals = table.Column<int>(nullable: false),
                    ScalarFactorCode = table.Column<int>(nullable: false),
                    ReleaseTime = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Canada_Debt", x => new { x.Vector_id, x.Reference_date });
                });

            migrationBuilder.CreateTable(
                name: "Debt",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reference_date = table.Column<DateTime>(nullable: false),
                    DGUID = table.Column<string>(nullable: true),
                    Vector_id = table.Column<string>(nullable: true),
                    Geography_name = table.Column<string>(nullable: true),
                    Central_gov_debt = table.Column<string>(nullable: true),
                    Value = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Debt", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "GDP",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    reference_date = table.Column<DateTime>(nullable: false),
                    geography_name = table.Column<string>(nullable: true),
                    seasonal_adj = table.Column<string>(nullable: true),
                    prices = table.Column<string>(nullable: true),
                    industry_classification = table.Column<string>(nullable: true),
                    vector_id = table.Column<string>(nullable: true),
                    value = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GDP", x => x.id);
                });

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
                name: "Manufacturing",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reference_date = table.Column<DateTime>(nullable: false),
                    Geography_name = table.Column<string>(nullable: true),
                    Vector_id = table.Column<string>(nullable: true),
                    Principal_statistics = table.Column<int>(nullable: false),
                    Industry_classification = table.Column<string>(nullable: true),
                    Value = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturing", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Retail",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    reference_date = table.Column<DateTime>(nullable: false),
                    geography_name = table.Column<string>(nullable: true),
                    industry_class = table.Column<string>(nullable: true),
                    adjustments = table.Column<int>(nullable: false),
                    value = table.Column<long>(nullable: false),
                    vector_id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Retail", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CPI",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reference_date = table.Column<DateTime>(nullable: false),
                    DGUID = table.Column<string>(nullable: true),
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
        */
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            /*
            migrationBuilder.DropTable(
                name: "Canada_Debt");

            migrationBuilder.DropTable(
                name: "CPI");

            migrationBuilder.DropTable(
                name: "Debt");

            migrationBuilder.DropTable(
                name: "Employment");

            migrationBuilder.DropTable(
                name: "GDP");

            migrationBuilder.DropTable(
                name: "Manufacturing");

            migrationBuilder.DropTable(
                name: "Retail");

            migrationBuilder.DropTable(
                name: "Geography");
                */
        }
    }
}
