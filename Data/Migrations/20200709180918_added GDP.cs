using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace covid19.Data.Migrations
{
    public partial class addedGDP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GDP");
        }
    }
}
