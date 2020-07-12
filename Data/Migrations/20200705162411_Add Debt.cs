using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace covid19.Data.Migrations
{
    public partial class AddDebt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Debt");
        }
    }
}
