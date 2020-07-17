using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace covid19.Data.Migrations
{
    public partial class Addretail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Retail");
        }
    }
}
