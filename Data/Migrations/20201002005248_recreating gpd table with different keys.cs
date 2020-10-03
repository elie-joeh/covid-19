using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace covid19.Data.Migrations
{
    public partial class recreatinggpdtablewithdifferentkeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GDP",
                columns: table => new
                {
                    Vector_id = table.Column<string>(nullable: false),
                    Reference_date = table.Column<DateTime>(nullable: false),
                    Value = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Decimals = table.Column<int>(nullable: false),
                    ScalarFactorCode = table.Column<int>(nullable: false),
                    ReleaseTime = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GDP", x => new { x.Vector_id, x.Reference_date });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GDP");
        }
    }
}
