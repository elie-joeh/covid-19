using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace covid19.Data.Migrations
{
    public partial class Addmanufacturingtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Manufacturing");
        }
    }
}
