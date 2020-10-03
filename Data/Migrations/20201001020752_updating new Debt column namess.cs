using Microsoft.EntityFrameworkCore.Migrations;

namespace covid19.Data.Migrations
{
    public partial class updatingnewDebtcolumnnamess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Canada_Debt",
                newName: "Reference_date");

            migrationBuilder.RenameColumn(
                name: "vectorId",
                table: "Canada_Debt",
                newName: "Vector_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Reference_date",
                table: "Canada_Debt",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "Vector_id",
                table: "Canada_Debt",
                newName: "vectorId");
        }
    }
}
